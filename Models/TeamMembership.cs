using NordicDoorApplication.Areas.Identity.Data;

namespace NordicDoorApplication.Models
{
    public class TeamMembership
    {
        public int Id { get; set; }

        //[StringLength(50, MinimumLength = 0)]
        public int TeamID { get; set; }

        //[StringLength(50, MinimumLength = 0)]
        public int EmployeeNumber { get; set; }


        //Foreign keys under her, som forbinder seg med feltene TeamID og EmployeeID
        //[ForeignKey("TeamID")]
        public virtual Team? Team { get; set; } //er bare en connetion til Team

        //[ForeignKey("EmployeeID")]
        //public virtual ApplicationUser? Employee { get; set; } //er en connection til Emplyee
    }
}
