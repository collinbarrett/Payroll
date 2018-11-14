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
                             .UseMySqlIdentityColumn();
            entityTypeBuilder.Property(x => x.DateCreatedUtc)
                             .HasColumnType("TIMESTAMP")
                             .ValueGeneratedOnAdd()
                             .IsRequired()
                             .HasDefaultValueSql("current_timestamp()");
            entityTypeBuilder.Property(x => x.DateModifiedUtc)
                             .HasColumnType("TIMESTAMP")
                             .ValueGeneratedOnAddOrUpdate()
                             .IsRequired()
                             .HasDefaultValueSql("current_timestamp() ON UPDATE current_timestamp()");
        }
    }
}