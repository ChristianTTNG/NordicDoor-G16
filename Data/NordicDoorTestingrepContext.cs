using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NordicDoorTestingrep.Models;

namespace NordicDoorTestingrep.Data
{
    public class NordicDoorTestingrepContext : DbContext
    {
        public NordicDoorTestingrepContext (DbContextOptions<NordicDoorTestingrepContext> options)
            : base(options)
        {
        }

        public DbSet<NordicDoorTestingrep.Models.Employee> Employee { get; set; } = default!;

        public DbSet<NordicDoorTestingrep.Models.Team> Team { get; set; }
        public DbSet<NordicDoorTestingrep.Models.TeamMembership> TeamMembership{ get; set; }
        public DbSet<NordicDoorTestingrep.Models.Suggestion> Suggestion { get; set; }
        public DbSet<NordicDoorTestingrep.Models.SugImage> SugImage{ get; set; }
        public DbSet<NordicDoorTestingrep.Models.Comment> Comment { get; set; }

        
    }
}
