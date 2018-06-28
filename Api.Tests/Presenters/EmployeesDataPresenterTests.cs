using Api.Models;
using Api.Presenters;
using Api.Services;
using Api.ViewModels;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Api.Tests.Presenters
{
    public class EmployeesDataPresenterTests
    {
        [Fact]
        public void GetEmployeesData_WhenCalled_CallsEmployeeServiceToGetData()
        {
            // Arrange
            var employees = SetupData();
            var employeeService = new Mock<IEmployeeService>();
            employeeService.Setup(s => s.GetEmployees()).Returns(employees);
            var presenter = new EmployeesDataPresenter(employeeService.Object);

            // Act
            var result = presenter.GetEmployeesData();

            // Assert
            employeeService.Verify(m => m.GetEmployees(), Times.Once);
            Assert.IsAssignableFrom<IList<EmployeeViewModel>>(result);
        }

        [Fact]
        public void GetEmployees_WhenEmployeeServiceReturnEmptyList_ReturnsEmptyEmployeeViewModelList()
        {
            //Arrange
            var employees = SetupData();
            var employeeService = new Mock<IEmployeeService>();
            employeeService.Setup(s => s.GetEmployees()).Returns(new List<Employee>());
            var presenter = new EmployeesDataPresenter(employeeService.Object);
           
            //Act
            var result = presenter.GetEmployeesData();

            //Assert
            Assert.Empty(result);
        }

        [Fact]
        public void GetEmployees_WhenEmployeeServiceReturnEmployees_ReturnsEmployeeViewModelList()
        {
            //Arrange
            var employees = SetupData();
            var employeeService = new Mock<IEmployeeService>();
            employeeService.Setup(s => s.GetEmployees()).Returns(employees);
            var presenter = new EmployeesDataPresenter(employeeService.Object);

            //Act
            var result = presenter.GetEmployeesData();

            //Assert
            var item = result[0];
            Assert.Equal(1, item.ID);
            Assert.Equal("First Employee", item.EmployeeName);
            var totalWorkingHours = item.TotalWorkingHours;
            Assert.Equal(17, totalWorkingHours["January"]);
            Assert.Equal(9, totalWorkingHours["February"]);
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
