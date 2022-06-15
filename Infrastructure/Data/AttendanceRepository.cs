using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interface;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class AttendanceRepository : RepositoryBase<Attendance>, IAttendanceRepository
    {
        public AttendanceRepository(EisContext context) : base(context)
        {
        }

        public async Task<IReadOnlyList<Attendance>> GetTimeLogsByEmployeeId(int employeeId)
        {
            return await base.ListAll()
                .Where(m => m.EmployeeId == employeeId)
                .OrderBy(m => m.Time)
                .ToListAsync();
        }
    }
}