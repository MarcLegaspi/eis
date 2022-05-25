using API.Dtos;
using AutoMapper;
using Core.Entities;

namespace API.Helpers
{
    public class MappingProfiles: Profile
    {
        public MappingProfiles()
        {
            CreateMap<Employee,EmployeeDto>()
                .ForMember(x => x.Position, o=> o.MapFrom(s => s.Position.Name));

            CreateMap<LeaveRequest,LeaveRequestDto>()
                .ForMember(x => x.Employee, o=> o.MapFrom(s => s.Employee));

            CreateMap<LeaveRequestSaveDto,LeaveRequest>();
            CreateMap<LeaveRequest,LeaveRequestSaveDto>();
        }
    }
}