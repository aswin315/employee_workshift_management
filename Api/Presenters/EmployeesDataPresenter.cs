using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            var employeesInformation = new List<EmployeeViewModel>();

            if (employees.Count == 0)
            {
                return employeesInformation;
            }
            foreach(var employee in employees)
            {
                employeesInformation.Add(new EmployeeViewModel {ID = employee.EmployeeID, EmployeeName = EmployeeName(employee),
                    TotalWorkingHours = WorkingHours(employee.EmployeeWorksShifts.ToList())});
            }

            return employeesInformation;
        }

        private Dictionary<string, int> WorkingHours(List<EmployeeWorksShift> workShifts)
        {
            var workingHours = new Dictionary<string, int>();
            foreach(var workShift in workShifts)
            {
                var shift = workShift.Shift;
                var month = shift.ShiftStart.ToString("MMMM");
                var totalShiftTime = shift.ShiftEnd.Subtract(shift.ShiftStart).Hours;
                if(workingHours.ContainsKey(month))
                {
                    workingHours[month] += totalShiftTime;
                }
                else
                {
                    workingHours.Add(month, totalShiftTime);
                }
            }
            return workingHours;
        }
        private string EmployeeName(Employee employee)
        {
            return $"{employee.FirstName} {employee.Surname}";
        }
    }
}
