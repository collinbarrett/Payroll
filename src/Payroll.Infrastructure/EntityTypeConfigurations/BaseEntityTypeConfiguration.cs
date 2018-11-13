using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Payroll.Core.Entities;

namespace Payroll.Infrastructure.EntityTypeConfigurations
{
    public class BaseEntityTypeConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : BaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> entityTypeBuilder)
        {
            entityTypeBuilder.Property(x => x.Id)
                .ValueGeneratedOnAdd();
            entityTypeBuilder.Property(x => x.DateCreatedUtc)
                .ValueGeneratedOnAdd();
            entityTypeBuilder.Property(x => x.DateModifiedUtc)
                .ValueGeneratedOnAddOrUpdate();
        }
    }
}