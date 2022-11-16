using System;
namespace NordicDoors.Models
{
    public class TeamMembership
    {
        public int TeamMembershipId { get; set; }
        public int TeamId { get; set; }
        public int EmployeeId { get; set; }
    }
}

