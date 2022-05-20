using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Core.Entities;

namespace Infrastructure.Data.Config
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.Property(m => m.Id).IsRequired();
            builder.Property(m => m.EmployeeNumber).IsRequired().HasMaxLength(10);
            builder.Property(m => m.FirstName).IsRequired().HasMaxLength(50);
            builder.Property(m => m.LastName).IsRequired().HasMaxLength(30);
            builder.Property(m => m.MiddleName).HasMaxLength(30);

            builder.HasOne(m => m.Position).WithMany()
                .HasForeignKey(m => m.PositionId);
        }
    }

    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.Property(m => m.Id).IsRequired();
            builder.Property(m => m.Code).IsRequired().HasMaxLength(10);
            builder.Property(m => m.Name).IsRequired().HasMaxLength(50);
        }
    }

    public class PositionConfiguration : IEntityTypeConfiguration<Position>
    {
        public void Configure(EntityTypeBuilder<Position> builder)
        {
            builder.Property(m => m.Id).IsRequired();
            builder.Property(m => m.Code).IsRequired().HasMaxLength(10);
            builder.Property(m => m.Name).IsRequired().HasMaxLength(50);
            
            builder.HasOne(m => m.Department).WithMany()
                .HasForeignKey(m => m.DepartmentId);
        }
    }

    public class LeaveRequestTypesConfiguration : IEntityTypeConfiguration<LeaveRequestType>
    {
        public void Configure(EntityTypeBuilder<LeaveRequestType> builder)
        {
            builder.Property(m => m.Id).IsRequired();
            builder.Property(m => m.Name).IsRequired().HasMaxLength(50);
        }
    }
}