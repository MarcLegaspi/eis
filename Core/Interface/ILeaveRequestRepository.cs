using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interface
{
    public interface ILeaveRequestRepository: IRepository<LeaveRequest>
    {
        Task<IReadOnlyList<LeaveRequest>> GetLeaveRequests(Pagination pagination = null);
        Task<LeaveRequest> GetLeaveRequestById(int id);
    }
}