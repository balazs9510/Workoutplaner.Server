using Microsoft.EntityFrameworkCore;
using Workoutplaner.Server.Models;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Workoutplaner.Server.Context
{
    public class WorkoutContext : DbContext
    {
        public WorkoutContext(DbContextOptions<WorkoutContext> options) : base(options)
        {

        }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<ExerciseItem> ExerciseItems { get; set; }
        public DbSet<DailyWorkout> DailyWorkouts { get; set; }
        public DbSet<WeeklyWorkout> WeeklyWorkouts { get; set; }
        public DbSet<MonthlyWorkout> MonthlyWorkouts { get; set; }
    }
}
