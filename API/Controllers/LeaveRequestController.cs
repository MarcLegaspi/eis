using API.Dtos;
using AutoMapper;
using Core;
using Core.Entities;
using Core.Enums;
using Core.Interface;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class LeaveRequestsController: BaseController
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public LeaveRequestsController(
            ILeaveRequestRepository leaveRequestRepository, 
            IMapper mapper, 
            IUserRepository userRepository): base(userRepository)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _leaveRequestRepository = leaveRequestRepository;
            
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<LeaveRequestDto>>> GetLeaveRequests([FromQuery] Pagination pagination) 
        {
            var leaveRequests = await _leaveRequestRepository.GetLeaveRequests(pagination);

            var leaveRequestsMap = _mapper.Map<IReadOnlyList<LeaveRequestDto>>(leaveRequests);

            return Ok(leaveRequestsMap);
        }     

        [HttpGet("{id}")]
        public async Task<ActionResult<LeaveRequestDto>> GetById(int id)
        {
            var leaveRequest = await _leaveRequestRepository.GetLeaveRequestById(id);

            if(leaveRequest == null) {
                return NotFound("LeaveRequest not found!");
            }

            leaveRequest.LeaveRequestStatus = LeaveRequestStatusEnum.New;
            var leaveRequestMap = _mapper.Map<LeaveRequestDto>(leaveRequest);
            return Ok(leaveRequestMap);
        } 

        [HttpPost]
        public async Task<ActionResult<LeaveRequestDto>> Post(LeaveRequestSaveDto model)
        {
            var leaveRequest = _mapper.Map<LeaveRequest>(model);

            leaveRequest.CreatedByUserId = CurrentUser().Id;
            leaveRequest.LeaveRequestStatus = LeaveRequestStatusEnum.New;
            
            var leaveRequestDb = await _leaveRequestRepository.CreateAsync(leaveRequest);
            var leaveRequestMap = _mapper.Map<LeaveRequestDto>(leaveRequestDb);
            return Ok(leaveRequestMap);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<LeaveRequestDto>> Post(LeaveRequestSaveDto model, int id)
        {
            var leaveRequest = await _leaveRequestRepository.GetLeaveRequestById(id);

            _mapper.Map(model, leaveRequest);

            leaveRequest.LeaveRequestStatus = LeaveRequestStatusEnum.Updated;
            leaveRequest.UpdatedByUserId = 1;
            leaveRequest.UpdatedDate = DateTime.Now;

            var leaveRequestDb = await _leaveRequestRepository.UpdateAsync(leaveRequest);
            var leaveRequestMap = _mapper.Map<LeaveRequestDto>(leaveRequestDb);
            return Ok(leaveRequestMap);
        }

        [HttpPost("{id}/approve")]
        public async Task<ActionResult<LeaveRequestDto>> Approve(int id) 
        {            
            return await UpdateStatus(id, LeaveRequestStatusEnum.Approved);
        }

        [HttpPost("{id}/reject")]
        public async Task<ActionResult<LeaveRequestDto>> Reject(int id) 
        {
            return await UpdateStatus(id, LeaveRequestStatusEnum.Rejected);
        }

        private async Task<ActionResult<LeaveRequestDto>> UpdateStatus(int id, LeaveRequestStatusEnum status) 
        {
            var leaveRequest = await _leaveRequestRepository.GetLeaveRequestById(id);

            if(leaveRequest == null) {
                return NotFound("LeaveRequest not found!");
            }

            leaveRequest.LeaveRequestStatus = status;
            leaveRequest.UpdatedByUserId = 1;
            leaveRequest.UpdatedDate = DateTime.Now;

            var leaveRequestDb = await _leaveRequestRepository.UpdateAsync(leaveRequest);
            var leaveRequestMap = _mapper.Map<LeaveRequestDto>(leaveRequestDb);

            return Ok(leaveRequestMap);
        }
    }
}