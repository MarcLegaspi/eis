using Core.Entities;
using System.Collections.Generic;

namespace Core.Interface
{
    public interface IAttendanceRepository: IRepository<Attendance>
    {        
        Task<IReadOnlyList<Attendance>> GetTimeLogsByEmployeeId(int employeeId);
    }
}