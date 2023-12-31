﻿using AutoMapper;
using LibaryManagement.Application.Contract;
using LibaryManagement.Common.Constants;
using LibaryManagement.Common.Models;
using LibaryManagementWeb.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LibaryManagementWeb.Controllers
{
    [Authorize]
    public class EmployeeController : Controller
    {
        // GET: EmployeeController
        private readonly UserManager<Employee> _userManager;
        private readonly IMapper _mapper;
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        private readonly ILogger<EmployeeController> _logger;

        public EmployeeController(
            UserManager<Employee> userManager,
            IMapper mapper,
            ILeaveAllocationRepository leaveAllocationRepository,
            ILogger<EmployeeController> logger
            )
        {
            this._userManager = userManager;
            this._mapper = mapper;
            this._leaveAllocationRepository = leaveAllocationRepository;
            _logger = logger;
        }
        // GET: EmployeeController
        public async Task<IActionResult> Index()
        {
            var employee = await _userManager.GetUsersInRoleAsync(Roles.User);
            var model = _mapper.Map<List<EmployeeListVM>>(employee);
            return View(model);

        }
        // GET: EmployeeController/Details/5
        public async Task<IActionResult> ViewAllocations(string id)
        {
            var model = await _leaveAllocationRepository.GetEmployeeAllocation(id);
            return View(model);
        }

        //GET: EmployeeController/Edit/5
        public async Task<ActionResult> EditAllocation(int id)
        {

            var model = await _leaveAllocationRepository.GetEmployeeAllocation(id);
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }

        // POST: EmployeeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditAllocation(int id, LeaveAllocationEditVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (await _leaveAllocationRepository.UpdateEmployeeAllocation(model))
                    {
                        return RedirectToAction(nameof(ViewAllocations), new { id = model.EmployeeId });
                    }
                }
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, "Error EditAllocation Employee");
            }
            model.Employee = _mapper.Map<EmployeeListVM>(_userManager.FindByIdAsync(model.EmployeeId));
            model.LeaveType = _mapper.Map<LeaveTypeVM>(await _leaveAllocationRepository.GetAsync(model.LeaveTypeId));
            return View(model);
        }




    }
}
