using Core;
using Core.Entities;
using Core.Interface;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class LeaveRequestRepository: RepositoryBase<LeaveRequest>, ILeaveRequestRepository
    {
        public LeaveRequestRepository(EisContext context): base(context)
        {
            
        }

        public async Task<IReadOnlyList<LeaveRequest>> GetLeaveRequests(Pagination pagination = null)
        {
            return await base.ListAll(pagination)
                .Include(m => m.Employee)
            //    .Include(m => m.EmployeeAddress)
                .ToListAsync();
        }

        public async Task<LeaveRequest> GetLeaveRequestById(int id)
        {
            return await base.ListAll()
                .Include(m => m.Employee)
                //.Include(m => m.EmployeeAddress)
                .FirstOrDefaultAsync(m => m.Id == id);
        }
    }
}