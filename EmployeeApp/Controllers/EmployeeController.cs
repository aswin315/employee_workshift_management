using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using EmployeeApp.Services;
using EmployeeApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeApp.Controllers
{
    public class EmployeeController : Controller
    {
        private IEmployeeDataService _employeeDataService;

        public EmployeeController(IEmployeeDataService employeeDataService)
        {
            _employeeDataService = employeeDataService;
        }
        public async Task<IActionResult> Index()
        {
            var employeeData = await _employeeDataService.GetData();
            return View(employeeData);
        }
    }
}