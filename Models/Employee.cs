using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NordicDoors.Models
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string EmployeeId { get; set; } = null!;

        [Required]
        [Display(Name = "Ansatt Navn")]
        [StringLength(150, MinimumLength = 3)]
        public string EmpName { get; set; } = null!;

        [Display(Name = "Telefon nummer")]
        [StringLength(20, MinimumLength = 3)]
        public string? PhoneNr { get; set; }

        [StringLength(320, MinimumLength = 0)]
        public string? Email { get; set; }

        [Display(Name = "Admin?")]
        public bool IsAdmin { get; set; } = false;

    }
}

