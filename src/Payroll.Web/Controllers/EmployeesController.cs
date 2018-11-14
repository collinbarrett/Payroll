using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Payroll.Core.Entities;
using Payroll.Infrastructure.Services;

namespace Payroll.Web.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly EmployeeManager _employeeManager;

        public EmployeesController(EmployeeManager employeeManager) => _employeeManager = employeeManager;

        public async Task<IActionResult> Index() => View(await _employeeManager.GetAllAsync());

        public IActionResult Add() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(Employee employee)
        {
            if (!ModelState.IsValid)
                return View(employee);
            await _employeeManager.AddAsync(employee);
            return RedirectToAction(nameof(Index));
        }
    }
}