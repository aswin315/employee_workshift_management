using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Api.Data;
using Api.Models;
using Api.Presenters;
using Api.ViewModels;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeesDataPresenter _dataPresenter;

        public EmployeesController(IEmployeesDataPresenter dataPresenter)
        {
            _dataPresenter = dataPresenter;
        }

        // GET: api/Employees
        [HttpGet]
        public IEnumerable<EmployeeViewModel> GetEmployees()
        {
            return _dataPresenter.GetEmployeesData();
        }
    }
}