using System.Collections.Generic;

namespace EmployeeApp.ViewModels
{
    public class EmployeeViewModel
    {
        public int ID { get; set; }
        public string EmployeeName { get; set; }
        public Dictionary<string, int> TotalWorkingHours { get; set; }
    }
}
