using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Workoutplaner.Server.Migrations
{
    public partial class TryingTPH : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExerciseItem_DailyWorkouts_DailyWorkoutId",
                table: "ExerciseItem");

            migrationBuilder.DropTable(
                name: "MonthlyWorkouts");

            migrationBuilder.DropTable(
                name: "WeeklyWorkouts");

            migrationBuilder.DropTable(
                name: "DailyWorkouts");

            migrationBuilder.CreateTable(
                name: "BaseWorkout",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGeneratedOnAdd", true),
                    Name = table.Column<string>(nullable: true),
                    UserID = table.Column<string>(nullable: true),
                    WorkoutType = table.Column<int>(nullable: false),
                    Workout_Type = table.Column<string>(nullable: false),
                    ApplicationUserId = table.Column<string>(nullable: true),
                    WeekFourId = table.Column<int>(nullable: true),
                    WeekOneId = table.Column<int>(nullable: true),
                    WeekThreeId = table.Column<int>(nullable: true),
                    WeekTwoId = table.Column<int>(nullable: true),
                    DayFiveId = table.Column<int>(nullable: true),
                    DayFourId = table.Column<int>(nullable: true),
                    DayOneId = table.Column<int>(nullable: true),
                    DaySevenId = table.Column<int>(nullable: true),
                    DaySixId = table.Column<int>(nullable: true),
                    DayThreeId = table.Column<int>(nullable: true),
                    DayTwoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseWorkout", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BaseWorkout_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BaseWorkout_BaseWorkout_WeekFourId",
                        column: x => x.WeekFourId,
                        principalTable: "BaseWorkout",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BaseWorkout_BaseWorkout_WeekOneId",
                        column: x => x.WeekOneId,
                        principalTable: "BaseWorkout",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BaseWorkout_BaseWorkout_WeekThreeId",
                        column: x => x.WeekThreeId,
                        principalTable: "BaseWorkout",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BaseWorkout_BaseWorkout_WeekTwoId",
                        column: x => x.WeekTwoId,
                        principalTable: "BaseWorkout",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BaseWorkout_BaseWorkout_DayFiveId",
                        column: x => x.DayFiveId,
                        principalTable: "BaseWorkout",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BaseWorkout_BaseWorkout_DayFourId",
                        column: x => x.DayFourId,
                        principalTable: "BaseWorkout",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BaseWorkout_BaseWorkout_DayOneId",
                        column: x => x.DayOneId,
                        principalTable: "BaseWorkout",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BaseWorkout_BaseWorkout_DaySevenId",
                        column: x => x.DaySevenId,
                        principalTable: "BaseWorkout",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BaseWorkout_BaseWorkout_DaySixId",
                        column: x => x.DaySixId,
                        principalTable: "BaseWorkout",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BaseWorkout_BaseWorkout_DayThreeId",
                        column: x => x.DayThreeId,
                        principalTable: "BaseWorkout",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BaseWorkout_BaseWorkout_DayTwoId",
                        column: x => x.DayTwoId,
                        principalTable: "BaseWorkout",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BaseWorkout_ApplicationUserId",
                table: "BaseWorkout",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_BaseWorkout_WeekFourId",
                table: "BaseWorkout",
                column: "WeekFourId");

            migrationBuilder.CreateIndex(
                name: "IX_BaseWorkout_WeekOneId",
                table: "BaseWorkout",
                column: "WeekOneId");

            migrationBuilder.CreateIndex(
                name: "IX_BaseWorkout_WeekThreeId",
                table: "BaseWorkout",
                column: "WeekThreeId");

            migrationBuilder.CreateIndex(
                name: "IX_BaseWorkout_WeekTwoId",
                table: "BaseWorkout",
                column: "WeekTwoId");

            migrationBuilder.CreateIndex(
                name: "IX_BaseWorkout_DayFiveId",
                table: "BaseWorkout",
                column: "DayFiveId");

            migrationBuilder.CreateIndex(
                name: "IX_BaseWorkout_DayFourId",
                table: "BaseWorkout",
                column: "DayFourId");

            migrationBuilder.CreateIndex(
                name: "IX_BaseWorkout_DayOneId",
                table: "BaseWorkout",
                column: "DayOneId");

            migrationBuilder.CreateIndex(
                name: "IX_BaseWorkout_DaySevenId",
                table: "BaseWorkout",
                column: "DaySevenId");

            migrationBuilder.CreateIndex(
                name: "IX_BaseWorkout_DaySixId",
                table: "BaseWorkout",
                column: "DaySixId");

            migrationBuilder.CreateIndex(
                name: "IX_BaseWorkout_DayThreeId",
                table: "BaseWorkout",
                column: "DayThreeId");

            migrationBuilder.CreateIndex(
                name: "IX_BaseWorkout_DayTwoId",
                table: "BaseWorkout",
                column: "DayTwoId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExerciseItem_BaseWorkout_DailyWorkoutId",
                table: "ExerciseItem",
                column: "DailyWorkoutId",
                principalTable: "BaseWorkout",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExerciseItem_BaseWorkout_DailyWorkoutId",
                table: "ExerciseItem");

            migrationBuilder.DropTable(
                name: "BaseWorkout");

            migrationBuilder.CreateTable(
                name: "DailyWorkouts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGeneratedOnAdd", true),
                    ApplicationUserId = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    UserID = table.Column<string>(nullable: true),
                    WorkoutType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyWorkouts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DailyWorkouts_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WeeklyWorkouts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGeneratedOnAdd", true),
                    ApplicationUserId = table.Column<string>(nullable: true),
                    DayFiveId = table.Column<int>(nullable: true),
                    DayFourId = table.Column<int>(nullable: true),
                    DayOneId = table.Column<int>(nullable: true),
                    DaySevenId = table.Column<int>(nullable: true),
                    DaySixId = table.Column<int>(nullable: true),
                    DayThreeId = table.Column<int>(nullable: true),
                    DayTwoId = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    UserID = table.Column<string>(nullable: true),
                    WorkoutType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeeklyWorkouts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WeeklyWorkouts_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WeeklyWorkouts_DailyWorkouts_DayFiveId",
                        column: x => x.DayFiveId,
                        principalTable: "DailyWorkouts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WeeklyWorkouts_DailyWorkouts_DayFourId",
                        column: x => x.DayFourId,
                        principalTable: "DailyWorkouts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WeeklyWorkouts_DailyWorkouts_DayOneId",
                        column: x => x.DayOneId,
                        principalTable: "DailyWorkouts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WeeklyWorkouts_DailyWorkouts_DaySevenId",
                        column: x => x.DaySevenId,
                        principalTable: "DailyWorkouts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WeeklyWorkouts_DailyWorkouts_DaySixId",
                        column: x => x.DaySixId,
                        principalTable: "DailyWorkouts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WeeklyWorkouts_DailyWorkouts_DayThreeId",
                        column: x => x.DayThreeId,
                        principalTable: "DailyWorkouts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WeeklyWorkouts_DailyWorkouts_DayTwoId",
                        column: x => x.DayTwoId,
                        principalTable: "DailyWorkouts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MonthlyWorkouts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGeneratedOnAdd", true),
                    ApplicationUserId = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    UserID = table.Column<string>(nullable: true),
                    WeekFourId = table.Column<int>(nullable: true),
                    WeekOneId = table.Column<int>(nullable: true),
                    WeekThreeId = table.Column<int>(nullable: true),
                    WeekTwoId = table.Column<int>(nullable: true),
                    WorkoutType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonthlyWorkouts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MonthlyWorkouts_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MonthlyWorkouts_WeeklyWorkouts_WeekFourId",
                        column: x => x.WeekFourId,
                        principalTable: "WeeklyWorkouts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MonthlyWorkouts_WeeklyWorkouts_WeekOneId",
                        column: x => x.WeekOneId,
                        principalTable: "WeeklyWorkouts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MonthlyWorkouts_WeeklyWorkouts_WeekThreeId",
                        column: x => x.WeekThreeId,
                        principalTable: "WeeklyWorkouts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MonthlyWorkouts_WeeklyWorkouts_WeekTwoId",
                        column: x => x.WeekTwoId,
                        principalTable: "WeeklyWorkouts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DailyWorkouts_ApplicationUserId",
                table: "DailyWorkouts",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_MonthlyWorkouts_ApplicationUserId",
                table: "MonthlyWorkouts",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_MonthlyWorkouts_WeekFourId",
                table: "MonthlyWorkouts",
                column: "WeekFourId");

            migrationBuilder.CreateIndex(
                name: "IX_MonthlyWorkouts_WeekOneId",
                table: "MonthlyWorkouts",
                column: "WeekOneId");

            migrationBuilder.CreateIndex(
                name: "IX_MonthlyWorkouts_WeekThreeId",
                table: "MonthlyWorkouts",
                column: "WeekThreeId");

            migrationBuilder.CreateIndex(
                name: "IX_MonthlyWorkouts_WeekTwoId",
                table: "MonthlyWorkouts",
                column: "WeekTwoId");

            migrationBuilder.CreateIndex(
                name: "IX_WeeklyWorkouts_ApplicationUserId",
                table: "WeeklyWorkouts",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_WeeklyWorkouts_DayFiveId",
                table: "WeeklyWorkouts",
                column: "DayFiveId");

            migrationBuilder.CreateIndex(
                name: "IX_WeeklyWorkouts_DayFourId",
                table: "WeeklyWorkouts",
                column: "DayFourId");

            migrationBuilder.CreateIndex(
                name: "IX_WeeklyWorkouts_DayOneId",
                table: "WeeklyWorkouts",
                column: "DayOneId");

            migrationBuilder.CreateIndex(
                name: "IX_WeeklyWorkouts_DaySevenId",
                table: "WeeklyWorkouts",
                column: "DaySevenId");

            migrationBuilder.CreateIndex(
                name: "IX_WeeklyWorkouts_DaySixId",
                table: "WeeklyWorkouts",
                column: "DaySixId");

            migrationBuilder.CreateIndex(
                name: "IX_WeeklyWorkouts_DayThreeId",
                table: "WeeklyWorkouts",
                column: "DayThreeId");

            migrationBuilder.CreateIndex(
                name: "IX_WeeklyWorkouts_DayTwoId",
                table: "WeeklyWorkouts",
                column: "DayTwoId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExerciseItem_DailyWorkouts_DailyWorkoutId",
                table: "ExerciseItem",
                column: "DailyWorkoutId",
                principalTable: "DailyWorkouts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
