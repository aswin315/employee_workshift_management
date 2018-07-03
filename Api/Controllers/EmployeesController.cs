using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Api.Models;
using Api.Services;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeSummaryService _employeeSummaryService;

        public EmployeesController(IEmployeeSummaryService dataPresenter)
        {
            _employeeSummaryService = dataPresenter;
        }

        // GET: api/Employees
        [HttpGet]
        public IEnumerable<EmployeeSummary> GetEmployees()
        {
            return _employeeSummaryService.GetEmployeesSummary();
        }
    }
}