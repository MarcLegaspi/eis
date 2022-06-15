using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using API.Dtos;
using AutoMapper;

namespace API.Controllers
{
    public class PositionsController: BaseController
    {
        private readonly IMapper _mapper;
        private readonly IPositionRepository _positionRepository;
        private readonly IUserRepository _userRepository;

        public PositionsController(IPositionRepository positionRepository, IUserRepository userRepository, IMapper mapper):base(userRepository)
        {
            _positionRepository = positionRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<PositionDto>>> GetPositions()
        {
            var positions = await _positionRepository.GetPositions();
            var positionMap = _mapper.Map<IReadOnlyList<PositionDto>>(positions);
            return Ok(positionMap);
        }        
    }
}