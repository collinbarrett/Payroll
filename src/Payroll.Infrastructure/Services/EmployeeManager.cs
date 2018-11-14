using System.Collections.Generic;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Payroll.Core.Entities;

namespace Payroll.Infrastructure.Services
{
    [UsedImplicitly]
    public class EmployeeManager
    {
        private readonly PayrollDbContext _payrollDbContext;

        public EmployeeManager(PayrollDbContext payrollDbContext) =>
            _payrollDbContext = payrollDbContext;

        public async Task<IEnumerable<Employee>> GetAllAsync() =>
            await _payrollDbContext.Employees
                                   .Include(e => e.Person)
                                   .AsNoTracking()
                                   .ToListAsync();

        public async Task AddAsync(Employee employee)
        {
            employee.Person = await GetOrAddPerson(employee.Person);
            _payrollDbContext.Employees.Add(employee);
            await _payrollDbContext.SaveChangesAsync();
        }

        private async Task<Person> GetOrAddPerson(Person person)
        {
            var existingPerson = await _payrollDbContext.Persons.FirstOrDefaultAsync(p =>
                p.LastName == person.LastName &&
                p.FirstName == person.FirstName);
            if (existingPerson != null)
                return existingPerson;
            _payrollDbContext.Persons.Add(person);
            return person;
        }
    }
}