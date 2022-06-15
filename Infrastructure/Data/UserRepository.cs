using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interface;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(EisContext context) : base(context)
        {
        }

        public async Task<User> GetUserbyEmployeeEmailAsync(string email)
        {
            return await base.ListAll().Where(u => u.Employee.Email == email)
                        .Include(m => m.Employee)
                        .Include(m => m.UserRoles)
                        .ThenInclude(m => m.Role)
                        .SingleOrDefaultAsync();
        }

        public async Task<User> GetUserByEmployeeIdAsync(int id)
        {
            return await base.ListAll().Where(u => u.EmployeeId == id).SingleOrDefaultAsync();
        }
    }
}