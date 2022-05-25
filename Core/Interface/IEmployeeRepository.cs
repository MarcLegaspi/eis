using Core.Entities;


namespace Core.Interface
{
    public interface IEmployeeRepository: IRepository<Employee>
    {
        Task<IReadOnlyList<Employee>> GetEmployees(Pagination pagination = null);
        Task<Employee> GetEmployeeById(int id);
    }
}