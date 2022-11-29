namespace NordicDoorApplication.Models
{
    public class Team
    {
        public int TeamId { get; set; }

        //[StringLength(50, MinimumLength = 1)]
        public string TeamName { get; set; } = null!;

        //public ICollection<Suggestion> Suggerstions { get; set; } = null!;

        //public virtual ICollection<TeamMembership>? TeamMembers { get; set; }
    }
}
