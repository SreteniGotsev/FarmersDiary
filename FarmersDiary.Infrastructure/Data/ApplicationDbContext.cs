using FarmersDiary.Infrastructure.Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FarmersDiary.Data
{
    public class ApplicationDbContext : IdentityDbContext<Farmer>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options) { }
        

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public DbSet<Farmer> Farmers { get; set; }
        public DbSet<Farm>? Farms { get; set; }
        public DbSet<Animal> Animals { get; set; }
        public DbSet<Labour> Labours { get; set; }
        public DbSet<Land>? Lands { get; set; }
        public DbSet<Vehicle>? Vehicles { get; set; }
    }
}