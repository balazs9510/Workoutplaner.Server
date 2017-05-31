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
    [Migration("20170531082844_ChangedPrimaryKey")]
    partial class ChangedPrimaryKey
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2");

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Workoutplaner.Server.Models.BaseWorkout", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<string>("UserID");

                    b.Property<int>("WorkoutType");

                    b.Property<string>("Workout_Type")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("BaseWorkout");

                    b.HasDiscriminator<string>("Workout_Type").HasValue("BaseWorkout");
                });

            modelBuilder.Entity("Workoutplaner.Server.Models.DoneDailyWorkout", b =>
                {
                    b.Property<DateTime>("Date");

                    b.Property<string>("UserId");

                    b.Property<string>("ApplicationUserId");

                    b.Property<string>("ApplicationUserId1");

                    b.Property<int?>("DonedWorkoutId");

                    b.Property<double>("LastInMinute");

                    b.HasKey("Date", "UserId");

                    b.HasIndex("ApplicationUserId");

                    b.HasIndex("ApplicationUserId1");

                    b.HasIndex("DonedWorkoutId");

                    b.ToTable("DonedDailyWorkouts");
                });

            modelBuilder.Entity("Workoutplaner.Server.Models.ExerciseItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("DailyWorkoutId");

                    b.Property<string>("Description");

                    b.Property<string>("MuscleGroup");

                    b.Property<string>("Name");

                    b.Property<int>("Reps");

                    b.Property<int>("SerialNumber");

                    b.HasKey("Id");

                    b.HasIndex("DailyWorkoutId");

                    b.ToTable("ExerciseItem");
                });

            modelBuilder.Entity("Workoutplaner.Server.Models.Identity.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.HasIndex("UserName")
                        .IsUnique();

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Workoutplaner.Server.Models.DailyWorkout", b =>
                {
                    b.HasBaseType("Workoutplaner.Server.Models.BaseWorkout");

                    b.Property<string>("ApplicationUserId");

                    b.HasIndex("ApplicationUserId");

                    b.ToTable("DailyWorkout");

                    b.HasDiscriminator().HasValue("Daily");
                });

            modelBuilder.Entity("Workoutplaner.Server.Models.MonthlyWorkout", b =>
                {
                    b.HasBaseType("Workoutplaner.Server.Models.BaseWorkout");

                    b.Property<string>("ApplicationUserId");

                    b.Property<int?>("WeekFourId");

                    b.Property<int?>("WeekOneId");

                    b.Property<int?>("WeekThreeId");

                    b.Property<int?>("WeekTwoId");

                    b.HasIndex("ApplicationUserId");

                    b.HasIndex("WeekFourId");

                    b.HasIndex("WeekOneId");

                    b.HasIndex("WeekThreeId");

                    b.HasIndex("WeekTwoId");

                    b.ToTable("MonthlyWorkout");

                    b.HasDiscriminator().HasValue("Monthly");
                });

            modelBuilder.Entity("Workoutplaner.Server.Models.WeeklyWorkout", b =>
                {
                    b.HasBaseType("Workoutplaner.Server.Models.BaseWorkout");

                    b.Property<string>("ApplicationUserId");

                    b.Property<int?>("DayFiveId");

                    b.Property<int?>("DayFourId");

                    b.Property<int?>("DayOneId");

                    b.Property<int?>("DaySevenId");

                    b.Property<int?>("DaySixId");

                    b.Property<int?>("DayThreeId");

                    b.Property<int?>("DayTwoId");

                    b.HasIndex("ApplicationUserId");

                    b.HasIndex("DayFiveId");

                    b.HasIndex("DayFourId");

                    b.HasIndex("DayOneId");

                    b.HasIndex("DaySevenId");

                    b.HasIndex("DaySixId");

                    b.HasIndex("DayThreeId");

                    b.HasIndex("DayTwoId");

                    b.ToTable("WeeklyWorkout");

                    b.HasDiscriminator().HasValue("Weekly");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Claims")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Workoutplaner.Server.Models.Identity.ApplicationUser")
                        .WithMany("Claims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Workoutplaner.Server.Models.Identity.ApplicationUser")
                        .WithMany("Logins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Workoutplaner.Server.Models.Identity.ApplicationUser")
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Workoutplaner.Server.Models.DoneDailyWorkout", b =>
                {
                    b.HasOne("Workoutplaner.Server.Models.Identity.ApplicationUser")
                        .WithMany("DonedDailyWorkouts")
                        .HasForeignKey("ApplicationUserId");

                    b.HasOne("Workoutplaner.Server.Models.Identity.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("ApplicationUserId1");

                    b.HasOne("Workoutplaner.Server.Models.DailyWorkout", "DonedWorkout")
                        .WithMany()
                        .HasForeignKey("DonedWorkoutId");
                });

            modelBuilder.Entity("Workoutplaner.Server.Models.ExerciseItem", b =>
                {
                    b.HasOne("Workoutplaner.Server.Models.DailyWorkout")
                        .WithMany("Exercises")
                        .HasForeignKey("DailyWorkoutId");
                });

            modelBuilder.Entity("Workoutplaner.Server.Models.DailyWorkout", b =>
                {
                    b.HasOne("Workoutplaner.Server.Models.Identity.ApplicationUser")
                        .WithMany("DailyWorkouts")
                        .HasForeignKey("ApplicationUserId");
                });

            modelBuilder.Entity("Workoutplaner.Server.Models.MonthlyWorkout", b =>
                {
                    b.HasOne("Workoutplaner.Server.Models.Identity.ApplicationUser")
                        .WithMany("MonthlyWorkouts")
                        .HasForeignKey("ApplicationUserId");

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
                    b.HasOne("Workoutplaner.Server.Models.Identity.ApplicationUser")
                        .WithMany("WeeklyWorkouts")
                        .HasForeignKey("ApplicationUserId");

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
        }
    }
}
