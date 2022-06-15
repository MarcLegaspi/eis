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
                .ForMember(x => x.Position, o=> o.MapFrom(s => s.Position.Name))
                .ForMember(x => x.Department, o=> o.MapFrom(s => s.Position.Department.Name));

            CreateMap<LeaveRequest,LeaveRequestDto>()
                .ForMember(x => x.Employee, o=> o.MapFrom(s => s.Employee));

            CreateMap<LeaveRequestSaveDto,LeaveRequest>();
            CreateMap<LeaveRequest,LeaveRequestSaveDto>();
            CreateMap<Attendance,TimeLogDto>().ReverseMap();

            CreateMap<EmployeeFormDto, Employee>().ReverseMap();

            CreateMap<EmployeeAddressDto, EmployeeAddress>().ReverseMap();
        
            CreateMap<Position, PositionDto>()
                .ForMember(x => x.DepartmentCode, o => o.MapFrom(s => s.Department.Code))
                .ForMember(x => x.Department, o => o.MapFrom(s => s.Department.Name));
        }
    }
}