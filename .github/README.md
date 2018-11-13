# Payroll

A demo application allowing employers to input employees and their dependents and get a preview of the costs of employees’ benefits packages.

## Assumptions

- The cost of benefits is $1000/year for each employee.
- Each dependent (children and possibly spouses) incurs a cost of $500/year.
- Anyone whose name starts with ‘A’ gets a 10% discount, employee or dependent.
- All employees are paid $2000 per paycheck before deductions.
- There are 26 paychecks in a year.

## Getting Started

### Prerequisites

 - Latest version of MySQL flavor (MySQL, *MariaDB, PostgreSQL)
   - *MariaDB used by maintainer
 - Latest version of .NET Core SDK

### Installing

 - `git clone https://github.com/collinbarrett/Payroll.git`
 - use `/scripts/createDb.sql` to create db user and db
 - populate `PayrollConnection` in `/src/Payroll.Web/appsettings.json`
 - `dotnet run --project src/Payroll.Web/Payroll.Web.csproj`
 - navigate to `http://localhost:50635/` in a browser