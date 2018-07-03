using Api.Models;
using System.Collections.Generic;

namespace Api.Services
{
    public interface IEmployeeSummaryService
    {
        IList<EmployeeSummary> GetEmployeesSummary();
    }
}
