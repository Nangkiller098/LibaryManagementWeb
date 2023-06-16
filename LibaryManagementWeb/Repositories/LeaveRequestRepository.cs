using LibaryManagementWeb.Contract;
using LibaryManagementWeb.Data;

namespace LibaryManagementWeb.Repositories
{

    public class LeaveRequestRepository : GenericRepository<LeaveRequest>, ILeaveRequestRepository
    {
        public LeaveRequestRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
