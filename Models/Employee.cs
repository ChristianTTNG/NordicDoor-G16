using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NordicDoorTestingrep.Models
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        //[Display(Name = "Ansatt Nummer")]
        public int EmployeeId { get; set; }

        //[Display(Name = "Ansatt Navn")]
        //[StringLength(150, MinimumLength = 3)]
        public string EmpName { get; set; } = null!;

        //[Display(Name = "Er ansatt admin?")]
        public bool IsAdmin { get; set; }

        //public bool IsActive { get; set; } = true;
        
        public virtual ICollection<TeamMembership>? Teams { get; set; }

        public ICollection<Comment>? Comments { get; set; }
        public virtual ICollection<Suggestion>? SugCreatorCon { get; set; }
        public virtual ICollection<Suggestion>? ResponsibleEmpCon { get; set; }
    }
}
