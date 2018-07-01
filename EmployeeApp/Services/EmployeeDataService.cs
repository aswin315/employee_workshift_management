using EmployeeApp.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;
using Flurl.Http;

namespace EmployeeApp.Services
{
    public class EmployeeDataService : IEmployeeDataService
    {
        public async Task<IList<EmployeeViewModel>> GetData()
        {
            var employees = await "https://localhost:5501/api/employees"
                                .GetAsync()
                                .ReceiveJson<List<EmployeeViewModel>>();

            return employees;
        }
    }
}
