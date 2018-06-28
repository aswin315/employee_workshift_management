using Api.Data;
using Api.Models;
using Api.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Api.Tests
{
    public class EmployeeServiceTests
    {
        [Fact]
        public void GetEmployees_WhenCalledWithoutSettingData_ReturnsEmptyEmployeesList()
        {
            // Arrange
            var options = DbContextOptions("EmptyDatabase");
            var dbcontext = new EmployeeShiftContext(options);

            var service = new EmployeeService(dbcontext);

            // Act
            var result = service.GetEmployees();

            // Assert
            Assert.Empty(result);
            Assert.IsAssignableFrom<IList<Employee>>(result);
        }

        [Fact]
        public void GetEmployess_WhenCalledAfterSettingData_ReturnsEmployees()
        {
            // Arrange
            SetupDb(out DbContextOptions<EmployeeShiftContext>  options);
            var dbcontext = new EmployeeShiftContext(options);

            var service = new EmployeeService(dbcontext);


            // Act
            var result = service.GetEmployees();

            // Assert
            Assert.Equal(2, result.Count);

            var item = result[0];
            Assert.Equal("FirstName", item.FirstName);
            Assert.Equal("Surname", item.Surname);
        }


        [Fact]
        public void GetEmployess_WhenCalledAfterSettingData_ReturnsEmployeesWithWorkShifts()
        {
            // Arrange
            SetupDb(out DbContextOptions<EmployeeShiftContext> options);
            var dbcontext = new EmployeeShiftContext(options);

            var service = new EmployeeService(dbcontext);

            // Act
            var result = service.GetEmployees();

            // Assert
            var employee = result.First(e => e.EmployeeID == 1);

            var items = employee.EmployeeWorksShifts;

            Assert.IsAssignableFrom<IList<EmployeeWorksShift>>(items);
            Assert.Equal(3, items.Count);
        }

        [Fact]
        public void GetEmployess_WhenCalledAfterSettingData_ReturnsEmployeesWithWorkShiftsAndShiftInformation()
        {
            // Arrange
            SetupDb(out DbContextOptions<EmployeeShiftContext> options);
            var dbcontext = new EmployeeShiftContext(options);

            var service = new EmployeeService(dbcontext);

            // Act
            var result = service.GetEmployees();

            // Assert
            var workShift = result
                .First(e => e.EmployeeID == 1)
                .EmployeeWorksShifts.First( x=> x.ShiftID == 1)
                .Shift;
            Assert.Equal("First Shift", workShift.ShiftName);
        }

        private void SetupDb(out DbContextOptions<EmployeeShiftContext> options)
        {
            options = DbContextOptions();

            var shifts = new List<Shift>
            {
                new Shift{ ShiftID = 1, ShiftName = "First Shift", ShiftStart = new DateTime(2018,1,1,8,0,0), ShiftEnd = new DateTime(2018,1,1,16,0,0) },
                new Shift{ ShiftID = 2, ShiftName = "Second Shift", ShiftStart = new DateTime(2018,1,2,8,0,0), ShiftEnd = new DateTime(2018,1,1,16,0,0) },
                new Shift{ ShiftID = 3, ShiftName = "Fourth Shift", ShiftStart = new DateTime(2018,1,1,7,0,0), ShiftEnd = new DateTime(2018,1,1,16,0,0) },
                new Shift{ ShiftID = 4, ShiftName = "Fifth Shift", ShiftStart = new DateTime(2018,2,1,8,0,0), ShiftEnd = new DateTime(2018,1,1,16,0,0) }
            };

            var employees = new List<Employee>
            {
                new Employee{ EmployeeID = 1, FirstName = "FirstName", Surname = "Surname"},
                new Employee{ EmployeeID = 2, FirstName = "First Name", Surname = "Sur Name"}
            };

            var employeeWorkShifts = new List<EmployeeWorksShift>
            {
                new EmployeeWorksShift{ ShiftID = 1, EmployeeID = 1},
                new EmployeeWorksShift{ ShiftID = 2, EmployeeID = 2},
                new EmployeeWorksShift{ ShiftID = 3, EmployeeID = 1},
                new EmployeeWorksShift{ ShiftID = 4, EmployeeID = 1},
            };

            using (var context = new EmployeeShiftContext(options))
            {
                if(context.Employees.Any())
                    return;

                context.AddRange(employees);
                context.AddRange(employeeWorkShifts);
                context.AddRange(shifts);
                context.SaveChanges();
            }
        }

        private DbContextOptions<EmployeeShiftContext> DbContextOptions(string databaseName = "EmployeeWorkShift")
        {
             return new DbContextOptionsBuilder<EmployeeShiftContext>()
                .UseInMemoryDatabase(databaseName).Options;
        }
    }
}
