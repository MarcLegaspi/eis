using Core;
using Core.Entities;
using Core.Interface;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(EisContext context):base(context)
        {
            
        }
        public async Task<IReadOnlyList<Employee>> GetEmployees(Pagination pagination)
        {
            return await base.ListAll(pagination)
                .Include(m => m.Position)
                .Include(m => m.EmployeeAddress)
                .ToListAsync();
        }

        public async Task<Employee> GetEmployeeById(int id)
        {
            return await base.ListAll()
                .Include(m => m.Position)
                .Include(m => m.EmployeeAddress)
                .FirstOrDefaultAsync(m => m.Id == id);
        }
    }
}