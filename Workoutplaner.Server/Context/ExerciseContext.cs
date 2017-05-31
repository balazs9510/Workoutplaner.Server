using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workoutplaner.Server.Models;

namespace Workoutplaner.Server.Context
{
    public class ExerciseContext :DbContext
    {
        public ExerciseContext(DbContextOptions<ExerciseContext> options) : base(options)
        {

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasSequence<int>("HiLoSeq")
                .StartsAt(1000).IncrementsBy(10);
            modelBuilder.Entity<Exercise>()
                .Property(e => e.Id)
                .ForSqlServerUseSequenceHiLo("HiLoSeq");
            modelBuilder.Entity<Exercise>()
                .HasDiscriminator<string>("exercise_type")
                .HasValue<Exercise>("exercise_base")
                .HasValue<ExerciseItem>("exercise_item");
        }

        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<ExerciseItem> ExerciseItems { get; set; }
    }
}
