using System;
using System.ComponentModel.DataAnnotations;

namespace manage.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeID { get; set; }

        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public Nullable<System.DateTime> DateOfBirth { get; set; }

        public string JobRole { get; set; }
        public Nullable<decimal> Phone { get; set; }
        public string Email { get; set; }
    }
}