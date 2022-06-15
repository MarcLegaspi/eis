using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using Core.Entities;
using Core.Enums;
using Core.Interface;
using Core.Services;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class UserController : BaseController
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;
        public UserController(IUserRepository userRepository, ITokenService tokenService) : base(userRepository)
        {
            _tokenService = tokenService;
            _userRepository = userRepository;
        }

        [HttpPost("register/{employeeId}")]
        public async Task<ActionResult> RegisterUser(int employeeId)
        {
            //check if employee user is already registered
            var user = await _userRepository.GetUserByEmployeeIdAsync(employeeId);
            if (user != null) return BadRequest("error registering user");

            byte[] passwordHash;
            byte[] passwordSalt;
            var tempPassword = "1234";

            Authentication.CreatePasswordHash(tempPassword, out passwordHash, out passwordSalt);

            user = new User();
            user.EmployeeId = employeeId;
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            user.CreatedByUserId = CurrentUser().Id;
            user.UserStatus = UserStatusEnum.ForActivation;

            user.UserRoles = new List<UserRole>();
            user.UserRoles.Add(new UserRole { RoleId = 1 });

            var userDb = await _userRepository.CreateAsync(user);
            return Ok();
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login([FromBody] LoginDto loginDto)
        {
            var user = await _userRepository.GetUserbyEmployeeEmailAsync(loginDto.Email);

            if (user == null) return Unauthorized("Invaluid Credentials");

            var result = Authentication.VerifyPasswordHash(loginDto.Password, user.PasswordHash, user.PasswordSalt);

            if (!result) return Unauthorized("Invaluid Credentials");

            return new UserDto
            {
                Email = user.Employee.Email,
                DisplayName = user.Employee.Email,
                Token = _tokenService.CreateToken(user.Employee.Email, user.UserRoles[0].Role.Name)
            };
        }
    }
}