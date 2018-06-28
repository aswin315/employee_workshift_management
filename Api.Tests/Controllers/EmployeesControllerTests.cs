using Api.Controllers;
using Api.Presenters;
using Api.ViewModels;
using Moq;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Api.Tests.Controllers
{
    public class EmployeesControllerTests
    {
        [Fact]
        public void GetEmployees_ReturnsEmployeesData()
        {
            //Arrange
            var employeeLists = new List<EmployeeViewModel>
            {
                new EmployeeViewModel{ ID = 1, EmployeeName = "First"},
                new EmployeeViewModel{ ID = 2, EmployeeName = "second"}
            };
            var employeeDataPresenter = new Mock<IEmployeesDataPresenter>();
            employeeDataPresenter.Setup(p => p.GetEmployeesData()).Returns(employeeLists);

            var controller = new EmployeesController(employeeDataPresenter.Object);

            //Act
            var employees = controller.GetEmployees();

            //Assert
            Assert.IsAssignableFrom<IEnumerable<EmployeeViewModel>>(employees);

            var employee = employees.First(e => e.ID == 1);
            Assert.Equal("First", employee.EmployeeName);
        }
    }
}
