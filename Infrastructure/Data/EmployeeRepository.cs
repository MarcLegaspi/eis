using Core;
using Core.Entities;
using Core.Interface;
using Core.Filters;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(EisContext context) : base(context)
        {

        }
        public async Task<IReadOnlyList<Employee>> GetEmployeesAsync(EmployeesFilter employeesFilter,Pagination pagination)
        {
            base.SetFilter(x => (string.IsNullOrEmpty(employeesFilter.Search) 
                || x.FirstName.Contains(employeesFilter.Search)
                || x.LastName.Contains(employeesFilter.Search)
                || x.MiddleName.Contains(employeesFilter.Search)
                || x.EmployeeNumber.Contains(employeesFilter.Search))
                    && (!employeesFilter.DepartmentId.HasValue || x.Position.DepartmentId == employeesFilter.DepartmentId)
                );

            return await base.ListAllIncludingAsync(pagination, r => r.EmployeeAddress, d => d.Position.Department);
        }

        public async Task<int> GetEmployeesCountAsync(EmployeesFilter employeesFilter)
        {
            base.SetFilter(x => (string.IsNullOrEmpty(employeesFilter.Search) 
                || x.FirstName.Contains(employeesFilter.Search)
                || x.LastName.Contains(employeesFilter.Search)
                || x.MiddleName.Contains(employeesFilter.Search)
                || x.EmployeeNumber.Contains(employeesFilter.Search))
                    && (!employeesFilter.DepartmentId.HasValue || x.Position.DepartmentId == employeesFilter.DepartmentId)
                );

            return await base.CountAsync();
        }

        public async Task<Employee> GetEmployeeByIdAsync(int id)
        {
            //return await base.GetByIdIncludingAsync(id, p => p.Position, e => e.EmployeeAddress);
            return await base.ListAll()
                .Include(m => m.Position)
                .Include(m => m.EmployeeAddress)
                .Where(m => m.Id == id)
                .SingleOrDefaultAsync();
        }

        public async Task<Employee> GetEmployeeByEmailAsync(string email)
        {
            return await base.ListAll()
                .Where(m => m.Email == email)
                .SingleOrDefaultAsync();
        }
    }
}