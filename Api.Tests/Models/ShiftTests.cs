using Api.Models;
using System;
using System.Linq;
using Xunit;

namespace Api.Tests.Models
{
    public class ShiftTests
    {
        [Fact]
        public void Month_ReturnsMonth()
        {
            //Arrange
            var shift = new Shift
            {
                ShiftStart = new DateTime(2018, 1, 1, 1, 1, 1)
            };

            //Act
            //Assert
            Assert.Equal("January", shift.Month);
        }

        [Fact]
        public void TotalHours_ReturnsTotalShiftTimeInHours()
        {
            //Arrange
            var shift = new Shift
            {
                ShiftStart = new DateTime(2018, 1, 1, 8, 0, 0),
                ShiftEnd = new DateTime(2018, 1, 1, 16, 0, 0)
            };

            //Act
            //Assert
            Assert.Equal(8, shift.Hours);
        }
    }
}
