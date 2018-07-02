using EmployeeApp.Services;
using EmployeeApp.ViewModels;
using Flurl.Http.Testing;
using System.Collections.Generic;
using System.Net.Http;
using Xunit;

namespace EmployeeApp.Tests.Services
{
    public class EmployeeDataServiceTests
    {
        [Fact]
        public void GetData_WhenCalled_GetsDataFromTheAPI()
        {
            using (var httpTest = new HttpTest())
            {
                //Arrange
                var service = new EmployeeDataService();
                var employeesData = new List<EmployeeViewModel>();
                httpTest.RespondWithJson(employeesData, 200);
                
                //Act
                var result = service.GetData().Result;
                
                //Assert
                httpTest.ShouldHaveCalled("https://localhost:5501/api/employees")
                        .WithVerb(HttpMethod.Get);

                Assert.IsAssignableFrom<IList<EmployeeViewModel>>(result);
            }
        }
    }
}
