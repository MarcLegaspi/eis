using System.Security.Claims;
using Core.Entities;
using Core.Interface;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BaseController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private User _user = null;

        public BaseController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        public async Task<User> CurrentUser()
        {
            var email = HttpContext.User.FindFirst(ClaimTypes.Email).Value;

            if(_user == null) {
                _user = await _userRepository.GetUserbyEmployeeEmailAsync(email);
            }

            return _user;  
        }
    }
}