using System.Reflection;
using Core.Entities;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure.Data
{
    public class EisContext : DbContext
    {
        public EisContext(DbContextOptions<EisContext> options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<LeaveRequestType> LeaveRequestTypes { get; set; }
        public DbSet<LeaveRequest> LeaveRequests { get; set; }
        public DbSet<Attendance> Attendance { get; set; }
        public DbSet<EmployeeAddress> EmployeeAddress { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}