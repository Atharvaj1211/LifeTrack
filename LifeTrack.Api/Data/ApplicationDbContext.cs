using LifeTrack.Api.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LifeTrack.Api.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        // Study Module Tables
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<StudyPlanItem> StudyPlanItems { get; set; }
        public DbSet<StudyLink> StudyLinks { get; set; }
        public DbSet<StudyLog> StudyLogs { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.HasDefaultSchema("public"); 

            // Configure Delete Cascade behavior to prevent orphaned data
            builder.Entity<StudyPlanItem>()
                .HasMany(p => p.Links)
                .WithOne()
                .HasForeignKey(l => l.StudyPlanItemId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}