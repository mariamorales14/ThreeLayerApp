using BusinessLogicLayer;
using Microsoft.AspNetCore.Mvc;

namespace ThreeLayerDemoApp.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }
        public async Task<IActionResult> Index()
        {
            var employees = await employeeService.GetEmployeesAsync(); //this makes sure the business logic gets processed before returning the view
            return View(employees);
        }

        public async Task<IActionResult> Details(int id)
        {
            var employee = await employeeService.GetEmployeeByIdAsync(id);
            await employeeService.GetDetailsAsync(employee);
            return View(employee);
        }
    }
}
