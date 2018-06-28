using Api.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Presenters
{
    public interface IEmployeesDataPresenter
    {
        IList<EmployeeViewModel> GetEmployeesData();
    }
}
