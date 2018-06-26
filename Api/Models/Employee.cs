using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Models
{
    public class Employee
    {
        [Column("Employee_ID")]
        public int EmployeeID { get; set; }

        [StringLength(50)]
        public string FirstName { get; set; }

        [StringLength(50)]
        public string Surname { get; set; }

        public ICollection<EmployeeWorksShift> EmployeeWorksShifts { get; set; }
    }
}
