using Microsoft.EntityFrameworkCore;
using Workoutplaner.Server.Models;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Workoutplaner.Server.Models.Identity;

namespace Workoutplaner.Server.Context
{
    public class WorkoutContext : IdentityDbContext<ApplicationUser>
    {
        public WorkoutContext(DbContextOptions<WorkoutContext> options) : base(options)
        {

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<Exercise>().HasKey(e=>e.Id);
            modelBuilder.Entity<Exercise>().Property(e => e.Id)
                .ForSqlServerUseSequenceHiLo();
            //modelBuilder.Entity<Exercise>().Property(e => e.Id).UseSqlServerIdentityColumn();
            //modelBuilder.Entity<DailyWorkout>().HasKey(e => e.Id);
            //modelBuilder.Entity<DailyWorkout>().Property(e => e.Id).HasDefaultValue(1);
            //modelBuilder.Entity<WeeklyWorkout>().HasKey(e => e.Id);
            //modelBuilder.Entity<WeeklyWorkout>().Property(e => e.Id).HasDefaultValue(1);
            //modelBuilder.Entity<MonthlyWorkout>().HasKey(e => e.Id);
            //modelBuilder.Entity<MonthlyWorkout>().Property(e => e.Id).HasDefaultValue(1);

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder
                .UseMySql(@"Server=localhost;database=Workout;uid=root;pwd=root;");
        
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<ExerciseItem> ExerciseItems { get; set; }
        public DbSet<DailyWorkout> DailyWorkouts { get; set; }
        public DbSet<WeeklyWorkout> WeeklyWorkouts { get; set; }
        public DbSet<MonthlyWorkout> MonthlyWorkouts { get; set; }
    }
}
