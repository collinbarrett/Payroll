using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Payroll.Core.Entities;

namespace Payroll.Infrastructure.EntityTypeConfigurations
{
    public class DependentTypeConfiguration : BaseEntityTypeConfiguration<Dependent>
    {
        public override void Configure(EntityTypeBuilder<Dependent> entityTypeBuilder)
        {
            base.Configure(entityTypeBuilder);
            entityTypeBuilder.Property(x => x.BenefitsDeduction)
                             .HasDefaultValue(500);
        }
    }
}