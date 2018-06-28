using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Models
{
    public class Shift
    {
        [Column("Shift_ID")]
        public int ShiftID { get; set; }

        [Column("Shift_Start")]
        public DateTime ShiftStart { get; set; }

        [Column("Shift_End")]
        public DateTime ShiftEnd { get; set; }

        [Column("Shift_Name")]
        [StringLength(50)]
        public string ShiftName { get; set; }

        public ICollection<EmployeeWorksShift> EmployeeWorksShifts { get; set; }

        public string Month => ShiftStart.ToString("MMMM");

        public int Hours => ShiftEnd.Subtract(ShiftStart).Hours;
    }
}
