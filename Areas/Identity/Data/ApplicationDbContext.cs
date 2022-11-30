using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NordicDoorApplication.Areas.Identity.Data;
using NordicDoorApplication.Models;

namespace NordicDoorApplication.Areas.Identity.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
        builder.ApplyConfiguration(new ApplicationUserEntityConfiguration());

    }

    public DbSet<Suggestion> Suggestions { get; set; }
    public DbSet<Team> Teams { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<TeamMembership> TeamsMembership { get; set; }


}
public class ApplicationUserEntityConfiguration : IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        builder.Property(u => u.EmployeeNumber).HasMaxLength(64);
        builder.Property(u => u.EmpName).HasMaxLength(255);
        builder.Property(u => u.PhoneNumber).HasMaxLength(20);
    }
}
