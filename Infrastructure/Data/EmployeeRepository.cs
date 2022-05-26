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
            return await base.ListAllIncludingAsync(pagination,  p => p.Position, r => r.EmployeeAddress);
        }

        public async Task<Employee> GetEmployeeById(int id)
        {
            return await base.GetByIdIncludingAsync(id, p=> p.Position, e=> e.EmployeeAddress);
        }
    }
}