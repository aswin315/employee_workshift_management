using Api.Models;
using System;
using System.Linq;
using Xunit;

namespace Api.Tests.Models
{
    public class EmployeeTests
    {
        [Fact]
        public void FullName_ReturnsFullName()
        {
            // Arrange
            var employee = new Employee
            {
                FirstName = "First",
                Surname = "Employee"
            };

            // Act
            var result = employee.EmployeeName;

            /// Assert
            Assert.Equal("First Employee", employee.EmployeeName);
        }
    }
}
