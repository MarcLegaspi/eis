using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Core.Entities;

namespace Infrastructure.Data.Config
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("Employees", schema: "employee");
            builder.Property(m => m.Id).IsRequired();
            builder.Property(m => m.EmployeeNumber).IsRequired().HasMaxLength(10);
            builder.Property(m => m.FirstName).IsRequired().HasMaxLength(50);
            builder.Property(m => m.LastName).IsRequired().HasMaxLength(30);
            builder.Property(m => m.MiddleName).HasMaxLength(30);
            builder.Property(m => m.TIN).HasMaxLength(10);
            builder.Property(m => m.Gsis).HasMaxLength(10);
            builder.Property(m => m.PhilhealthNo).HasMaxLength(12);

            builder.HasOne(m => m.Position).WithMany()
                .HasForeignKey(m => m.PositionId);

            builder.HasOne<EmployeeAddress>(m => m.EmployeeAddress)
                .WithOne(m => m.Employee)
                .HasForeignKey<EmployeeAddress>(m => m.EmployeeId);
        }
    }

    public class LeaveRequestConfiguration : IEntityTypeConfiguration<LeaveRequest>
    {
        public void Configure(EntityTypeBuilder<LeaveRequest> builder)
        {
            builder.Property(m => m.Id).IsRequired();
            builder.Property(m => m.EmployeeId).IsRequired();
            builder.Property(m => m.LeaveRequestType).IsRequired();
            builder.Property(m => m.LeaveRequestStatus).IsRequired();
            builder.Property(m => m.From).IsRequired();
            builder.Property(m => m.To).IsRequired();
        }
    }

    public class EmployeeAddressConfiguration : IEntityTypeConfiguration<EmployeeAddress>
    {
        public void Configure(EntityTypeBuilder<EmployeeAddress> builder)
        {
            builder.ToTable("EmployeeAddress", schema: "employee");
            builder.Property(m => m.Id).IsRequired();
            builder.Property(m => m.EmployeeId).IsRequired();
            builder.Property(m => m.Address1).IsRequired().HasMaxLength(100);
            builder.Property(m => m.Barangay).IsRequired().HasMaxLength(50);
            builder.Property(m => m.Municipality).IsRequired().HasMaxLength(50);
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
            builder.ToTable("Positions", schema: "lookup");
            builder.Property(m => m.Id).IsRequired();
            builder.Property(m => m.Code).IsRequired().HasMaxLength(10);
            builder.Property(m => m.Name).IsRequired().HasMaxLength(50);

            builder.HasOne(m => m.Department).WithMany()
                .HasForeignKey(m => m.DepartmentId);
        }
    }

    // public class LeaveRequestTypesConfiguration : IEntityTypeConfiguration<LeaveRequestType>
    // {
    //     public void Configure(EntityTypeBuilder<LeaveRequestType> builder)
    //     {
    //         builder.ToTable("LeaveRequestTypes", schema: "lookup");
    //         builder.Property(m => m.Id).IsRequired();
    //         builder.Property(m => m.Name).IsRequired().HasMaxLength(50);
    //     }
    // }
}