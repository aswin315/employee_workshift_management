using Api.Models;
using Api.Services;
using Moq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Api.Tests.Services
{
    public class EmployeeSummaryServiceTests
    {
        [Fact]
        public void GetEmployeeSummary_WhenEmployeesIsEmpty_ReturnsEmptySummaryCollection()
        {
            // Arrange
            var employeeService = new Mock<IEmployeeService>();
            employeeService.Setup(s => s.GetEmployees()).Returns(new List<Employee>());

            var service = new EmployeeSummaryService(employeeService.Object);

            //Act
            var result = service.GetEmployeesSummary();
           
            // Assert
            Assert.IsAssignableFrom<IList<EmployeeSummary>>(result);
            Assert.Empty(result);
           
        }

        [Fact]
        public void GetEmployeeSummary_WhenEmployeesDataIsPresent_ReturnsEmployeesSummaryCollection()
        {
            // Arrange
            var employees = SetupData();
            var employeeService = new Mock<IEmployeeService>();
            employeeService.Setup(s => s.GetEmployees()).Returns(employees);

            var service = new EmployeeSummaryService(employeeService.Object);

            //Act
            var result = service.GetEmployeesSummary();
            var item = result.Where(r => r.ID == 1);

            // Assert
            Assert.IsAssignableFrom<IList<EmployeeSummary>>(result);
            Assert.NotEmpty(item);

        }
        private List<Employee> SetupData()
        {
            var shifts = new List<Shift>
            {
                new Shift { ShiftStart = new DateTime(2018, 1, 1, 8, 0, 0), ShiftEnd = new DateTime(2018, 1, 1, 16, 0, 0) },
                new Shift { ShiftStart = new DateTime(2018, 1, 1, 7, 0, 0), ShiftEnd = new DateTime(2018, 1, 1, 16, 0, 0) },
                new Shift { ShiftStart = new DateTime(2018, 1, 1, 7, 0, 0), ShiftEnd = new DateTime(2018, 1, 1, 16, 0, 0) },
                new Shift { ShiftStart = new DateTime(2018, 2, 1, 7, 0, 0), ShiftEnd = new DateTime(2018, 2, 1, 16, 0, 0) }
            };


            var employees = new List<Employee>
            {
                new Employee{
                    EmployeeID = 1,
                    FirstName = "First",
                    Surname = "Employee",
                    EmployeeWorksShifts = new List<EmployeeWorksShift>
                    {
                        new EmployeeWorksShift {Shift = shifts[0] },
                        new EmployeeWorksShift {Shift = shifts[2] },
                        new EmployeeWorksShift {Shift = shifts[3] },

                    }
                },
                 new Employee{
                    EmployeeID = 2,
                    FirstName = "Second",
                    Surname = "Employee",
                    EmployeeWorksShifts = new List<EmployeeWorksShift>
                    {
                        new EmployeeWorksShift {Shift = shifts[0] },
                        new EmployeeWorksShift {Shift = shifts[2] },
                        new EmployeeWorksShift {Shift = shifts[3] },

                    }
                }
            };
            return employees;
        }
    }
}
