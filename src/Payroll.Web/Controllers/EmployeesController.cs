using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Payroll.Core.Entities;
using Payroll.Infrastructure;

namespace Payroll.Web.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly PayrollContext _context;

        public EmployeesController(PayrollContext context) => _context = context;

        public async Task<IActionResult> Index()
        {
            var payrollContext = _context.Employees.Include(e => e.Person);
            return View(await payrollContext.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var employee = await _context.Employees
                .Include(e => e.Person)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employee == null) return NotFound();

            return View(employee);
        }

        public IActionResult Create()
        {
            ViewData["PersonId"] = new SelectList(_context.Persons, "Id", "Id");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind("PersonId,Salary,BenefitsDeduction,Id,DateCreatedUtc,DateModifiedUtc")]
            Employee employee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["PersonId"] = new SelectList(_context.Persons, "Id", "Id", employee.PersonId);
            return View(employee);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var employee = await _context.Employees.FindAsync(id);
            if (employee == null) return NotFound();
            ViewData["PersonId"] = new SelectList(_context.Persons, "Id", "Id", employee.PersonId);
            return View(employee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,
            [Bind("PersonId,Salary,BenefitsDeduction,Id,DateCreatedUtc,DateModifiedUtc")]
            Employee employee)
        {
            if (id != employee.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(employee.Id))
                        return NotFound();
                    throw;
                }

                return RedirectToAction(nameof(Index));
            }

            ViewData["PersonId"] = new SelectList(_context.Persons, "Id", "Id", employee.PersonId);
            return View(employee);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var employee = await _context.Employees
                .Include(e => e.Person)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employee == null) return NotFound();

            return View(employee);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employees.Any(e => e.Id == id);
        }
    }
}