// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
using LibaryManagementWeb.Data;
using LibaryManagementWeb.Models;

namespace LibaryManagementWeb.Contract
{
    public interface ILeaveRequestRepository1
    {
        Task CreateLeaveRequest(LeaveRequestCreateVM model);
        Task<List<LeaveRequest>> GetAllAsync(string employeeId);
        Task<EmployeeLeaveRequestVM> GetMyLeaveDetails();
    }
}