﻿using FarmersDiary.Infrastructure.Data;
using FarmersDiary.Infrastructure.Data.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using System.Reflection.Emit;

namespace FarmersDiary.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Animal>()
                   .HasMany(l => l.Labours)
                   .WithMany(s => s.Offsprings);

            base.OnModelCreating(builder);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Farmer> Farmers { get; set; }
        public DbSet<Farm>? Farms { get; set; }
        public DbSet<Animal> Animals { get; set; }
        public DbSet<Labour> Labours { get; set; }
        public DbSet<Land>? Lands { get; set; }
        public DbSet<Vehicle>? Vehicles { get; set; }
    }
}