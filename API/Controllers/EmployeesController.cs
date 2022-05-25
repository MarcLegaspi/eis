using API.Dtos;
using AutoMapper;
using Core;
using Core.Entities;
using Core.Interface;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class EmployeesController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeesController(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<EmployeeDto>>> Index(int pageIndex = 0, int PageSize = 0)
        {
            var pagination = new Pagination { PageIndex = pageIndex, PageSize = PageSize };
            var employees = await _employeeRepository.GetEmployees(pagination);
            var employeesMap = _mapper.Map<IReadOnlyList<EmployeeDto>>(employees);
            return Ok(employeesMap);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            var employee = await _employeeRepository.GetEmployeeById(id);
            var employeeMap = _mapper.Map<EmployeeDto>(employee);
            return Ok(employeeMap);
        }

        [HttpPost("Created")]
        public async Task<ActionResult<EmployeeDto>> CreateEmployee(Employee employee)
        {
            var employeeDb = await _employeeRepository.CreateAsync(employee);
            var employeeMap = _mapper.Map<EmployeeDto>(employeeDb);
            return Ok(employee);
        }

        [HttpPost("update")]
        public async Task<ActionResult<EmployeeDto>> UpdateEmployee(Employee employee)
        {
            var employeeDb = await _employeeRepository.UpdateAsync(employee);
            var employeeMap = _mapper.Map<EmployeeDto>(employeeDb);
            return Ok(employee);
        }
    }
}