using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Services
{
    public interface ITokenService
    {
        string CreateToken(string email, string role);
    }
}