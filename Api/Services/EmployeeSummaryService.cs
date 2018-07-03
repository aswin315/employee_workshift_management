using System.Collections.Generic;
using System.Linq;
using Api.Models;

namespace Api.Services
{
    public class EmployeeSummaryService : IEmployeeSummaryService
    {
        private IEmployeeService _employeeService;

        public EmployeeSummaryService(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public IList<EmployeeSummary> GetEmployeesSummary()
        {
            var employees = _employeeService.GetEmployees();

            var employeesSummary = from employee in employees
                                      select
                                          new EmployeeSummary
                                          {
                                              ID = employee.EmployeeID,
                                              EmployeeName = employee.EmployeeName,
                                              TotalWorkingHours = TotalWorkingHours(employee.EmployeeWorksShifts)
                                          };
            return employeesSummary.ToList();
        }

        private Dictionary<string, int> TotalWorkingHours(IList<EmployeeWorksShift> workShifts)
        {
            var totalWorkingHours = new Dictionary<string, int>();
                  
            foreach (var workShift in workShifts)
            {
                var shift = workShift.Shift;
                var month = shift.Month;

                if (totalWorkingHours.ContainsKey(month))
                {
                    totalWorkingHours[month] += shift.Hours;
                }
                else
                {
                    totalWorkingHours.Add(month, shift.Hours);
                }
            }
            return totalWorkingHours;
        }
    }
}
