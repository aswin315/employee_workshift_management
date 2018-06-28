using Api.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Data
{
    public class EmployeeShiftContext : DbContext
    {
        public EmployeeShiftContext(DbContextOptions<EmployeeShiftContext> options)
            : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeWorksShift> EmployeeWorksShifts { get; set; }
        public DbSet<Shift> Shifts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .ToTable("Employee");
            modelBuilder.Entity<EmployeeWorksShift>()
                .ToTable("Employee_Works_Shift")
                .HasKey(t => new { t.EmployeeID, t.ShiftID });
            modelBuilder.Entity<Shift>().ToTable("Shifts");
        }
    }
}
