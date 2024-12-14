using edu.Models;
using edu.Services;
using Microsoft.AspNetCore.Mvc;

namespace edu.Controllers
{
    public class EmployeeController : Controller
    {
        private EmployeeService empService;

        public EmployeeController(EmployeeService service)
        {
            this.empService = service;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var employees = empService.ReadEmployees();
            return View(employees);
        }

        [HttpGet]
        //veiw data
        public IActionResult DisplayEmployees()
        {
            var employees = empService.ReadEmployees(); // Assuming ReadEmployees returns a list of employees
            return View(employees); // Make sure you have a DisplayEmployees.cshtml view
        }

        [HttpGet]
        //search by id
        public IActionResult SearchByID(int employeeId)
        {
            var employee = empService.SearchById(employeeId);

            return View("Index", employee);
        }
        
        [HttpGet]
        //search by language sorted
        public IActionResult SearchByLanguage(Language lan)
        {
            var employees = empService.GetEmployeesByLanguage(lan.LanguageName, lan.ScoreOutof100);

            return View("Index", employees.OrderBy(e => e.FirstName));
        }

        //add
        [HttpPost]
        public IActionResult AddEmployee(Employee employee)
        {
            empService.AddEmployee(employee);
            return RedirectToAction("Index");
        }

        //delete
        [HttpPost]
        public IActionResult DeleteEmployee(int employeeId)
        {
            empService.DeleteEmployee(employeeId);
            return RedirectToAction("Index");
        }

        //update
        [HttpPost]
        public IActionResult EditEmployee(int employeeId, string newDesignation)
        {
            empService.UpdateEmployeeDesignation(employeeId, newDesignation);
            return RedirectToAction("Index");
        }

    }
}
