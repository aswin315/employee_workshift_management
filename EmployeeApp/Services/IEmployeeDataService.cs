using EmployeeApp.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeApp.Services
{
    public interface IEmployeeDataService
    {
         Task<IList<EmployeeViewModel>> GetData();
    }
}
