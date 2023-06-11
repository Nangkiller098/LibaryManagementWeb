using LibaryManagementWeb.Contract;
using LibaryManagementWeb.Data;

namespace LibaryManagementWeb.Repositories
{
    public class LeaveTypeRepository : GenericRepository<LeaveType>, ILeaveTypeRepository
    {
        public LeaveTypeRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
