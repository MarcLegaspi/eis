using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interface
{
    public interface IUserRepository: IRepository<User>
    {
        Task<User> GetUserByEmployeeIdAsync(int id);
        Task<User> GetUserbyEmployeeEmailAsync(string email);

    }
}