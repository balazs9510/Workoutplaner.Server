using Microsoft.EntityFrameworkCore;
using Workoutplaner.Server.Models;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Workoutplaner.Server.Models.Identity;
using System;

namespace Workoutplaner.Server.Context
{
    public class WorkoutContext : IdentityDbContext<ApplicationUser>
    {
        public bool _inMemory;
        public WorkoutContext(DbContextOptions<WorkoutContext> options)
           : base(options)
        {
            _inMemory = false;
        }


        public WorkoutContext(DbContextOptions<WorkoutContext> options
            ,bool InMemory) : base(options)
        {
            _inMemory = InMemory;
        }
       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ApplicationUser>()
                .HasIndex(u => u.UserName)
                .IsUnique();
            //modelBuilder.Entity<BaseWorkout>().ToTable("Workouts");
            modelBuilder.Entity<BaseWorkout>()
            .HasDiscriminator<string>("Workout_Type")
            .HasValue<DailyWorkout>("Daily")
            .HasValue<WeeklyWorkout>("Weekly")
            .HasValue<MonthlyWorkout>("Monthly");

            modelBuilder.Entity<DoneDailyWorkout>()                
                .HasKey(w => new { w.Date , w.UserId   });
            modelBuilder.Entity<ApplicationUser>()
                .HasMany<DoneDailyWorkout>()
                .WithOne();


            //modelBuilder.Entity<Exercise>().HasKey(e=>e.Id);

            //modelBuilder.Entity<Exercise>().Property(e => e.Id).UseSqlServerIdentityColumn();
            //modelBuilder.Entity<DailyWorkout>().HasKey(e => e.Id);
            //modelBuilder.Entity<DailyWorkout>().Property(e => e.Id).HasDefaultValue(1);
            //modelBuilder.Entity<WeeklyWorkout>().HasKey(e => e.Id);
            //modelBuilder.Entity<WeeklyWorkout>().Property(e => e.Id).HasDefaultValue(1);
            //modelBuilder.Entity<MonthlyWorkout>().HasKey(e => e.Id);
            //modelBuilder.Entity<MonthlyWorkout>().Property(e => e.Id).HasDefaultValue(1);

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (_inMemory)
                optionsBuilder.UseInMemoryDatabase();
            else optionsBuilder
                .UseMySql(@"Server=localhost;database=Workout;uid=root;pwd=root;");
        }
      //  public DbSet<BaseWorkout> Workouts { get; set; }
        public DbSet<DailyWorkout> DailyWorkouts { get; set; }
        public DbSet<WeeklyWorkout> WeeklyWorkouts { get; set; }
        public DbSet<MonthlyWorkout> MonthlyWorkouts { get; set; }
        public DbSet<DoneDailyWorkout> DonedDailyWorkouts { get; set; }
    }
}
