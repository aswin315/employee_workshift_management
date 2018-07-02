using EmployeeApp.Controllers;
using EmployeeApp.Services;
using EmployeeApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace EmployeeApp.Tests.Controllers
{
    public class EmployeeControllerTests
    {
        [Fact]
        public void Index_WhenInvoked_ReturnsData()
        {
            // Arrange
            var employeeDataService = new Mock<IEmployeeDataService>();
            employeeDataService.Setup(s => s.GetData()).ReturnsAsync(new List<EmployeeViewModel>());

            var controller = new EmployeeController(employeeDataService.Object);
           
            // Act
            var result = controller.Index().Result;

            // Assert
            employeeDataService.Verify(service => service.GetData(), Times.Once);

            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.IsAssignableFrom<IList<EmployeeViewModel>>(viewResult.ViewData.Model);
        }
    }
}
