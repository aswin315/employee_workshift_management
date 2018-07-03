using Api.Controllers;
using Api.Models;
using Api.Services;
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
            var employeesSummary = new List<EmployeeSummary>
            {
                new EmployeeSummary{ ID = 1, EmployeeName = "First"},
                new EmployeeSummary{ ID = 2, EmployeeName = "second"}
            };
            var employeeSummaryService = new Mock<IEmployeeSummaryService>();
            employeeSummaryService.Setup(p => p.GetEmployeesSummary()).Returns(employeesSummary);

            var controller = new EmployeesController(employeeSummaryService.Object);

            //Act
            var employees = controller.GetEmployees();

            //Assert
            Assert.IsAssignableFrom<IEnumerable<EmployeeSummary>>(employees);

            var employee = employees.First(e => e.ID == 1);
            Assert.Equal("First", employee.EmployeeName);
        }
    }
}
