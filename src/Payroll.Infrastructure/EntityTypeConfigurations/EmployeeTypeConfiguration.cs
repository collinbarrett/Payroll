using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Payroll.Core.Entities;

namespace Payroll.Infrastructure.EntityTypeConfigurations
{
    public class EmployeeTypeConfiguration : BaseEntityTypeConfiguration<Employee>
    {
        public override void Configure(EntityTypeBuilder<Employee> entityTypeBuilder)
        {
            base.Configure(entityTypeBuilder);
            entityTypeBuilder.Property(x => x.Salary)
                .HasDefaultValue(2000 * 26);
            entityTypeBuilder.Property(x => x.BenefitsDeduction)
                .HasDefaultValue(1000);
        }
    }
}