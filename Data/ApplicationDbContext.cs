using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NordicDoors.Models;

namespace NordicDoors.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    public DbSet<NordicDoors.Models.Employee>? Employee { get; set; }
    public DbSet<NordicDoors.Models.Comment>? Comment { get; set; }
    public DbSet<NordicDoors.Models.Suggestion>? Suggestion { get; set; }
    public DbSet<NordicDoors.Models.SuggestionImage>? SuggestionImage { get; set; }
    public DbSet<NordicDoors.Models.Team>? Team { get; set; }
    public DbSet<NordicDoors.Models.TeamMembership>? TeamMembership { get; set; }
}

