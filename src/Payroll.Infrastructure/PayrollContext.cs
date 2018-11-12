using Microsoft.EntityFrameworkCore;
using Payroll.Core.Entities;

namespace Payroll.Infrastructure
{
    public class PayrollContext : DbContext
    {
        public PayrollContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Person> Persons { get; set; }
    }
}