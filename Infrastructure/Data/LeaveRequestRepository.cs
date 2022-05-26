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
            return await base.ListAllIncludingAsync(pagination, e=> e.Employee);
        }

        public async Task<LeaveRequest> GetLeaveRequestById(int id)
        {
            return await base.GetByIdIncludingAsync(id, e => e.Employee);
        }
    }
}