using System.Text.Json;
using Core.Entities;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Data
{
    public class EisContextSeed
    {
        public static async Task SeedAsync(EisContext context, ILoggerFactory loggerFactory)
        {
            try
            {
                if (!context.Departments.Any())
                {
                    var departmentsData = File.ReadAllText("../Infrastructure/Data/SeedData/json/departments.json");
                    var departments = JsonSerializer.Deserialize<List<Department>>(departmentsData);

                    foreach (var item in departments)
                    {
                        context.Departments.Add(item);
                    }
                    await context.SaveChangesAsync();
                }

                if (!context.Positions.Any())
                {
                    var positionsData = File.ReadAllText("../Infrastructure/Data/SeedData/json/positions.json");
                    var positions = JsonSerializer.Deserialize<List<Position>>(positionsData);

                    foreach (var item in positions)
                    {
                        context.Positions.Add(item);
                    }
                    await context.SaveChangesAsync();
                }

                if (!context.Employees.Any())
                {
                    var employeesData = File.ReadAllText("../Infrastructure/Data/SeedData/json/employees.json");
                    var employees = JsonSerializer.Deserialize<List<Employee>>(employeesData);

                    foreach (var item in employees)
                    {
                        context.Employees.Add(item);
                    }
                    await context.SaveChangesAsync();
                }


                // if (!context.LeaveRequestTypes.Any())
                // {
                //     var leaveRequestTypesData = File.ReadAllText("../Infrastructure/Data/SeedData/json/leaveRequestTypes.json");
                //     var leaveRequestTypes = JsonSerializer.Deserialize<List<LeaveRequestType>>(leaveRequestTypesData);

                //     foreach (var item in leaveRequestTypes)
                //     {
                //         context.LeaveRequestTypes.Add(item);
                //     }
                //     await context.SaveChangesAsync();
                // }

                if (!context.EmployeeAddress.Any())
                {
                    var employeeAddressData = File.ReadAllText("../Infrastructure/Data/SeedData/json/employeeAddress.json");
                    var  employeeAddress = JsonSerializer.Deserialize<List<EmployeeAddress>>(employeeAddressData);

                    foreach (var item in employeeAddress)
                    {
                        context.EmployeeAddress.Add(item);
                    }
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<EisContextSeed>();
                logger.LogError(ex, "An error occured during seeding");
            }
        }
    }
}