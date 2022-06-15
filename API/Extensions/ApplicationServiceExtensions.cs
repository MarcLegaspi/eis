using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Interface;
using Core.Services;
using Infrastructure.Data;
using Infrastructure.Services;

namespace API.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IAttendanceRepository, AttendanceRepository>();
            services.AddScoped<IPositionRepository, PositionRepository>();
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<ILeaveRequestRepository, LeaveRequestRepository>();

            return services;
        }
    }
}