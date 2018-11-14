using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Payroll.Core.DTOs;
using Payroll.Infrastructure.Services;

namespace Payroll.Web.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly EmployeeManager _employeeManager;

        public EmployeesController(EmployeeManager employeeManager) => _employeeManager = employeeManager;

        public async Task<IActionResult> Index() => View(await _employeeManager.GetAllAsync());

        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null) return NotFound();

        //    var employee = await _dbContext.Employees
        //        .Include(e => e.Person)
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (employee == null) return NotFound();

        //    return View(employee);
        //}

        public IActionResult Add() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(EmployeeDto employee)
        {
            if (!ModelState.IsValid)
                return View(employee);
            await _employeeManager.AddAsync(employee);
            return RedirectToAction(nameof(Index));
        }

        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null) return NotFound();

        //    var employee = await _dbContext.Employees.FindAsync(id);
        //    if (employee == null) return NotFound();
        //    ViewData["PersonId"] = new SelectList(_dbContext.Persons, "Id", "Id", employee.PersonId);
        //    return View(employee);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id,
        //    [Bind("PersonId,Salary,BenefitsDeduction,Id,DateCreatedUtc,DateModifiedUtc")]
        //    Employee employee)
        //{
        //    if (id != employee.Id) return NotFound();

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _dbContext.Update(employee);
        //            await _dbContext.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!EmployeeExists(employee.Id))
        //                return NotFound();
        //            throw;
        //        }

        //        return RedirectToAction(nameof(Index));
        //    }

        //    ViewData["PersonId"] = new SelectList(_dbContext.Persons, "Id", "Id", employee.PersonId);
        //    return View(employee);
        //}

        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null) return NotFound();

        //    var employee = await _dbContext.Employees
        //        .Include(e => e.Person)
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (employee == null) return NotFound();

        //    return View(employee);
        //}

        //[HttpPost]
        //[ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var employee = await _dbContext.Employees.FindAsync(id);
        //    _dbContext.Employees.Remove(employee);
        //    await _dbContext.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool EmployeeExists(int id)
        //{
        //    return _dbContext.Employees.Any(e => e.Id == id);
        //}
    }
}