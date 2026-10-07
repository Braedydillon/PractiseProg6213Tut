using Microsoft.EntityFrameworkCore;
using PractiseProg6213Tut.Models;

namespace PractiseProg6213Tut.Data
{
    public class SkillForgeDbContext : DbContext
    {
        public SkillForgeDbContext(DbContextOptions<SkillForgeDbContext> options) : base(options) { }

        public DbSet<User> Users => Set<User>();
        public DbSet<Workshop> Workshops => Set<Workshop>();
        public DbSet<Category> Categories => Set<Category>();
        public DbSet<Registration> Registrations => Set<Registration>();
        public DbSet<Certificate> Certificates => Set<Certificate>();
        public DbSet<Feedback> Feedback => Set<Feedback>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Registration>()
                .HasOne<Workshop>()
                .WithMany()
                .HasForeignKey(r => r.WorkshopID)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}