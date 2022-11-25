using System.ComponentModel.DataAnnotations;

namespace NordicDoorTestingrep.Models
{
    public class Team
    {
        [Key]
        public int TeamID { get; set; }

        //[StringLength(50, MinimumLength = 1)]
        public string TeamName { get; set; } = null!;

        //public ICollection<Suggestion> Suggerstions { get; set; } = null!;
        
        public virtual ICollection<TeamMembership>? TeamMembers { get; set; }
    }
}
