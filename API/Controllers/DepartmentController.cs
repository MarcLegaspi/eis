using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Interface;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class DepartmentsController: BaseController
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IUserRepository _userRepository;

        public DepartmentsController(IDepartmentRepository departmentRepository, IUserRepository userRepository):base(userRepository)
        {
            _departmentRepository = departmentRepository;
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Department>>> GetDepartments()
        {
           return Ok(await _departmentRepository.GetDepartments());
        }
    }
}