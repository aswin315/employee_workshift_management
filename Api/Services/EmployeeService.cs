using Api.Data;
using Api.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Api.Services
{
    public class EmployeeService : IEmployeeService
    {
        private EmployeeShiftContext _employeeShiftContext;

        public EmployeeService(EmployeeShiftContext employeeShiftContext)
        {
            _employeeShiftContext = employeeShiftContext;
        }

        public IList<Employee> GetEmployees()
        {
            return _employeeShiftContext.Employees
                .Include(e => e.EmployeeWorksShifts)
                .ToList();
        }
    }
}
