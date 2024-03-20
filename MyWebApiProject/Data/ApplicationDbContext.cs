using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyWebApiProject.Models;

namespace MyWebApiProject.Data
{
    public class ApplicationDbContext:IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions dbContextOptions):base(dbContextOptions)
        {
            
        }

        public DbSet<Workouts> workouts{get;set;}
        public DbSet<Exercises> exercises{get;set;}
        public DbSet<Goals> goals{get;set;}
        public DbSet<Progress> progress{get;set;}
       

    //   protected override void OnModelCreating(ModelBuilder modelBuilder)
    //   {
    //      base.OnModelCreating(modelBuilder);
    //      modelBuilder.Entity<Workouts>()
    //     .HasMany(w => w.exercise)
    //     .WithOne(e => e.workout)
    //     .HasForeignKey(e => e.WorkoutID)
    //     .IsRequired(false) // Make the relationship optional
    //     .OnDelete(DeleteBehavior.Restrict); // Set delete behavior to restrict
       
    //    }
        
    protected override void OnModelCreating(ModelBuilder modelBuilder)
   {
       base.OnModelCreating(modelBuilder);


        modelBuilder.Entity<Exercises>()
        .HasOne(e => e.workout)           // Exercise has one workout
        .WithMany(w => w.exercise)        // Workout has many exercises
        .HasForeignKey(e => e.WorkoutID) // Define the foreign key property
        .IsRequired(false) // Make the relationship optional
        .OnDelete(DeleteBehavior.Restrict); // Specify the delete behavior, in this case, cascade delete

        // Additional configurations if needed
        List<IdentityRole> roles = new List<IdentityRole>
        {
           new IdentityRole
           {
             Name = "Admin",
             NormalizedName = "ADMIN"
           },
           new IdentityRole
           {
             Name = "User",
             NormalizedName = "USER"
           },
              
        };
        modelBuilder.Entity<IdentityRole>().HasData(roles);
    }

    }
}
    