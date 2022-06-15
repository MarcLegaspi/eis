using Core.Entities;
using Core.Interface;
using Core.Filters;

namespace Core.Interface
{
    public interface IEmployeeRepository: IRepository<Employee>
    {
        Task<IReadOnlyList<Employee>> GetEmployeesAsync(EmployeesFilter employeesFilter,Pagination pagination);
        Task<int> GetEmployeesCountAsync(EmployeesFilter employeesFilter);
        Task<Employee> GetEmployeeByIdAsync(int id);
        Task<Employee> GetEmployeeByEmailAsync(string email);
    }
}