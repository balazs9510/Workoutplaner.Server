using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Workoutplaner.Server.Context;
using Workoutplaner.Server.Models;

namespace Workoutplaner.Server.Migrations
{
    [DbContext(typeof(WorkoutContext))]
    partial class WorkoutContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Workoutplaner.Server.Models.DailyWorkout", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<int>("WorkoutType");

                    b.HasKey("Id");

                    b.ToTable("DailyWorkouts");
                });

            modelBuilder.Entity("Workoutplaner.Server.Models.Exercise", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("MuscleGroup");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Exercises");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Exercise");
                });

            modelBuilder.Entity("Workoutplaner.Server.Models.MonthlyWorkout", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<int?>("WeekFourId");

                    b.Property<int?>("WeekOneId");

                    b.Property<int?>("WeekThreeId");

                    b.Property<int?>("WeekTwoId");

                    b.Property<int>("WorkoutType");

                    b.HasKey("Id");

                    b.HasIndex("WeekFourId");

                    b.HasIndex("WeekOneId");

                    b.HasIndex("WeekThreeId");

                    b.HasIndex("WeekTwoId");

                    b.ToTable("MonthlyWorkouts");
                });

            modelBuilder.Entity("Workoutplaner.Server.Models.WeeklyWorkout", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("DayFiveId");

                    b.Property<int?>("DayFourId");

                    b.Property<int?>("DayOneId");

                    b.Property<int?>("DaySevenId");

                    b.Property<int?>("DaySixId");

                    b.Property<int?>("DayThreeId");

                    b.Property<int?>("DayTwoId");

                    b.Property<string>("Name");

                    b.Property<int>("WorkoutType");

                    b.HasKey("Id");

                    b.HasIndex("DayFiveId");

                    b.HasIndex("DayFourId");

                    b.HasIndex("DayOneId");

                    b.HasIndex("DaySevenId");

                    b.HasIndex("DaySixId");

                    b.HasIndex("DayThreeId");

                    b.HasIndex("DayTwoId");

                    b.ToTable("WeeklyWorkouts");
                });

            modelBuilder.Entity("Workoutplaner.Server.Models.ExerciseItem", b =>
                {
                    b.HasBaseType("Workoutplaner.Server.Models.Exercise");

                    b.Property<int?>("DailyWorkoutId");

                    b.Property<int>("Reps");

                    b.Property<int>("SerialNumber");

                    b.HasIndex("DailyWorkoutId");

                    b.ToTable("ExerciseItem");

                    b.HasDiscriminator().HasValue("ExerciseItem");
                });

            modelBuilder.Entity("Workoutplaner.Server.Models.MonthlyWorkout", b =>
                {
                    b.HasOne("Workoutplaner.Server.Models.WeeklyWorkout", "WeekFour")
                        .WithMany()
                        .HasForeignKey("WeekFourId");

                    b.HasOne("Workoutplaner.Server.Models.WeeklyWorkout", "WeekOne")
                        .WithMany()
                        .HasForeignKey("WeekOneId");

                    b.HasOne("Workoutplaner.Server.Models.WeeklyWorkout", "WeekThree")
                        .WithMany()
                        .HasForeignKey("WeekThreeId");

                    b.HasOne("Workoutplaner.Server.Models.WeeklyWorkout", "WeekTwo")
                        .WithMany()
                        .HasForeignKey("WeekTwoId");
                });

            modelBuilder.Entity("Workoutplaner.Server.Models.WeeklyWorkout", b =>
                {
                    b.HasOne("Workoutplaner.Server.Models.DailyWorkout", "DayFive")
                        .WithMany()
                        .HasForeignKey("DayFiveId");

                    b.HasOne("Workoutplaner.Server.Models.DailyWorkout", "DayFour")
                        .WithMany()
                        .HasForeignKey("DayFourId");

                    b.HasOne("Workoutplaner.Server.Models.DailyWorkout", "DayOne")
                        .WithMany()
                        .HasForeignKey("DayOneId");

                    b.HasOne("Workoutplaner.Server.Models.DailyWorkout", "DaySeven")
                        .WithMany()
                        .HasForeignKey("DaySevenId");

                    b.HasOne("Workoutplaner.Server.Models.DailyWorkout", "DaySix")
                        .WithMany()
                        .HasForeignKey("DaySixId");

                    b.HasOne("Workoutplaner.Server.Models.DailyWorkout", "DayThree")
                        .WithMany()
                        .HasForeignKey("DayThreeId");

                    b.HasOne("Workoutplaner.Server.Models.DailyWorkout", "DayTwo")
                        .WithMany()
                        .HasForeignKey("DayTwoId");
                });

            modelBuilder.Entity("Workoutplaner.Server.Models.ExerciseItem", b =>
                {
                    b.HasOne("Workoutplaner.Server.Models.DailyWorkout")
                        .WithMany("Exercises")
                        .HasForeignKey("DailyWorkoutId");
                });
        }
    }
}
