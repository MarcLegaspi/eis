using Core;
using Core.Entities;
using Core.Interface;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class DepartmentRepository: RepositoryBase<Department>, IDepartmentRepository
    {
        public DepartmentRepository(EisContext context): base(context)
        {
            
        }

        public async Task<IReadOnlyList<Department>> GetDepartments() 
        {
            return await base.ListAll()
                .OrderBy(m => m.Name)
                .ToListAsync();
        }
    }
}
