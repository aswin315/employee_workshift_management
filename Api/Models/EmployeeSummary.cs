using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Models
{
    public class EmployeeSummary
    {
        public int ID { get; set; }
        public string EmployeeName { get; set; }
        public Dictionary<string, int> TotalWorkingHours { get; set; }
    }
}
