using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using AutoMapper;
using Core.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace API.Controllers
{
    public class EmployeesController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly EisContext _context;

        public EmployeesController(IMapper mapper, EisContext context)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<EmployeeDto>>> Index()
        {
            var employees = await _context.Employees.Include(o => o.Position).ToListAsync();
            var employeesMap = _mapper.Map<IReadOnlyList<EmployeeDto>>(employees);
             return Ok(employeesMap);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id) 
        {
            var employee = await _context.Employees.Where(m => m.Id == id).Include(o => o.Position).FirstOrDefaultAsync();
            var employeeMap = _mapper.Map<EmployeeDto>(employee);
             return Ok(employeeMap);
        }
    }
}