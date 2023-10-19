using Microsoft.EntityFrameworkCore;
using project_be.Models;

namespace project_be
{
    public class ProjectDbContext: DbContext
    {
        public ProjectDbContext(DbContextOptions<ProjectDbContext> options)
            : base(options)
        {
        }

        public DbSet<AddressModel> Countries { get; set; }
        public DbSet<ProjectModel> Projects { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProjectModel>()
                .HasOne(p => p.Country)
                .WithMany().HasForeignKey(p => p.CountryId);
        }
    }
}
