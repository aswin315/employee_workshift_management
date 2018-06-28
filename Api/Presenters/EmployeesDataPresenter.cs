using System.Collections.Generic;
using System.Linq;
using Api.Models;
using Api.Services;
using Api.ViewModels;

namespace Api.Presenters
{
    public class EmployeesDataPresenter : IEmployeesDataPresenter
    {
        private IEmployeeService _employeeService;

        public EmployeesDataPresenter(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public IList<EmployeeViewModel> GetEmployeesData()
        {
            var employees = _employeeService.GetEmployees();

            var employeeInformation = from employee in employees
                    select
                        new EmployeeViewModel
                        {
                            ID = employee.EmployeeID,
                            EmployeeName = employee.EmployeeName,
                            TotalWorkingHours = WorkingHours(employee.EmployeeWorksShifts)
                        };
            return employeeInformation.ToList();
        }

        private Dictionary<string, int> WorkingHours(IList<EmployeeWorksShift> workShifts)
        {
            var workingHours = new Dictionary<string, int>();
                          
            foreach (var workShift in workShifts)
            {
                var shift = workShift.Shift;
                var month = shift.Month;

                if (workingHours.ContainsKey(month))
                {
                    workingHours[month] +=  shift.Hours;
                }
                else
                {
                    workingHours.Add(month, shift.Hours);
                }
            }
            return workingHours;
        }
    }
}
