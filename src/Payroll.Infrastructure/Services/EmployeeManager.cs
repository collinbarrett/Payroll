using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Payroll.Core.DTOs;
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
            await _payrollDbContext.Employees.AsNoTracking().ToListAsync();

        public async Task AddAsync(EmployeeDto employeeDto)
        {
            var person = await GetOrAddPerson(employeeDto);
            var employee = new Employee
            {
                Person = person
            };
            _payrollDbContext.Employees.Add(employee);
            await _payrollDbContext.SaveChangesAsync();
        }

        private async Task<Person> GetOrAddPerson(EmployeeDto employeeDto)
        {
            var person = await _payrollDbContext.Persons.FirstOrDefaultAsync(p =>
                p.LastName == employeeDto.LastName &&
                p.FirstName == employeeDto.FirstName);
            if (person != null)
                return person;
            person = new Person
            {
                LastName = employeeDto.LastName,
                FirstName = employeeDto.FirstName
            };
            _payrollDbContext.Persons.Add(person);
            return person;
        }
    }
}