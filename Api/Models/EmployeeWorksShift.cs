using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Models
{
    public class EmployeeWorksShift
    {
        [Column("Employee_ID")]
        public int EmployeeID { get; set; }

        [Column("Shift_ID")]
        public int ShiftID { get; set; }

        public Employee Employee { get; set; }
        public Shift Shift { get; set; }
    }
}
