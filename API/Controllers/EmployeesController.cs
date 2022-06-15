using API.Dtos;
using AutoMapper;
using Core;
using Core.Entities;
using Core.Enums;
using Core.Interface;
using Core.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using API.Helpers;

namespace API.Controllers
{
    public class EmployeesController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IUserRepository _userRepository;
        private readonly IAttendanceRepository _attendanceRepository;

        public EmployeesController(
            IEmployeeRepository employeeRepository,
            IUserRepository userRepository,
            IAttendanceRepository attendanceRepository,
            IMapper mapper) : base(userRepository)
        {
            _attendanceRepository = attendanceRepository;
            _userRepository = userRepository;
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<PaginationData<EmployeeDto>>> Index([FromQuery] EmployeesFilter employeesFilter,[FromQuery] Pagination pagination)
        {
            var employees = await _employeeRepository.GetEmployeesAsync(employeesFilter, pagination);
            var employeesMap = _mapper.Map<IReadOnlyList<EmployeeDto>>(employees);

            var count = await _employeeRepository.GetEmployeesCountAsync(employeesFilter);
            return Ok(new PaginationData<EmployeeDto> {
                Count=count,
                Data=employeesMap,
                PageSize = pagination.PageSize,
                PageIndex = pagination.PageIndex
            });
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeFormDto>> GetEmployee(int id)
        {
            var employee = await _employeeRepository.GetEmployeeByIdAsync(id);
            var employeeMap = _mapper.Map<EmployeeFormDto>(employee);
            return Ok(employeeMap);
        }

        [Authorize]
        [HttpPost("Created")]
        public async Task<ActionResult<EmployeeDto>> CreateEmployee(EmployeeFormDto employeeCreateDto)
        {
            var employee = _mapper.Map<Employee>(employeeCreateDto);
           
            employee.CreatedByUserId = (await CurrentUser()).Id;

            var employeeDb = await _employeeRepository.CreateAsync(employee);
            var employeeMap = _mapper.Map<EmployeeDto>(employeeDb);
            return Ok(employee);
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<ActionResult<EmployeeDto>> UpdateEmployee(EmployeeFormDto employeeForm, int id)
        {
            var modifiedDate = DateTime.Now;        
            var employeeDb = await _employeeRepository.GetEmployeeByIdAsync(id);
            _mapper.Map(employeeForm, employeeDb);

            employeeDb.UpdatedDate = modifiedDate;
            employeeDb.UpdatedByUserId = (await CurrentUser()).Id;

            // TODO: Set updated date only if there are changes on the address
            if(employeeDb.EmployeeAddress != null) {
                employeeDb.EmployeeAddress.UpdatedDate = modifiedDate;
                employeeDb.EmployeeAddress.UpdatedByUserId = (await CurrentUser()).Id;
            }

            await _employeeRepository.UpdateAsync(employeeDb);
            var employeeMap = _mapper.Map<EmployeeDto>(employeeDb);
            return Ok(employeeMap);
        }

        [Authorize]
        [HttpPost("timein")]
        public async Task<ActionResult<TimeLogDto>> TimeIn()
        {
            return await TimeLog(TimeLogType.TimeIn);
        }

        [Authorize]
        [HttpPost("timeout")]
        public async Task<ActionResult<TimeLogDto>> TimeOut()
        {
            return await TimeLog(TimeLogType.TimeOut);
        }

        private async Task<ActionResult<TimeLogDto>> TimeLog(TimeLogType timeLogType)
        {
            var user = await CurrentUser();

            if (user == null) return BadRequest("Invalid request");

            var attendance = await _attendanceRepository.CreateAsync(new Attendance
            {
                EmployeeId = user.EmployeeId,
                Time = DateTime.Now,
                TimeLogType = timeLogType
            });

            var timeLogMap = _mapper.Map<TimeLogDto>(attendance);

            return Ok(timeLogMap);
        }

        [Authorize]
        [HttpGet("timelogs")]
        public async Task<ActionResult<IReadOnlyList<TimeLogDto>>> GetTimeLogs()
        {
            var user = await CurrentUser();

            var attendance = await _attendanceRepository.GetTimeLogsByEmployeeId(user.EmployeeId);

            var timeLogMap = _mapper.Map<IReadOnlyList<TimeLogDto>>(attendance);

            return Ok(timeLogMap);
        }
    }
}