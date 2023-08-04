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
        }
    }
}