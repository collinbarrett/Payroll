using Microsoft.EntityFrameworkCore;
using Payroll.Core.Entities;
using Payroll.Infrastructure.EntityTypeConfigurations;

namespace Payroll.Infrastructure
{
    public class PayrollContext : DbContext
    {
        public PayrollContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Dependent> Dependents { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Person> Persons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            ApplyConfigurations(modelBuilder);
        }

        private static void ApplyConfigurations(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new DependentTypeConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeeTypeConfiguration());
            modelBuilder.ApplyConfiguration(new BaseEntityTypeConfiguration<Person>());
        }
    }
}