using Api.Models;
using System.Collections.Generic;

namespace Api.Services
{
    public interface IEmployeeService
    {
        IList<Employee> GetEmployees();
    }
}
