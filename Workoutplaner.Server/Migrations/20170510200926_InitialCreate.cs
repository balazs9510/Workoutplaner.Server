using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Workoutplaner.Server.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DailyWorkouts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    WorkoutType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyWorkouts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Exercises",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    MuscleGroup = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    DailyWorkoutId = table.Column<int>(nullable: true),
                    Reps = table.Column<int>(nullable: true),
                    SerialNumber = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercises", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Exercises_DailyWorkouts_DailyWorkoutId",
                        column: x => x.DailyWorkoutId,
                        principalTable: "DailyWorkouts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WeeklyWorkouts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DayFiveId = table.Column<int>(nullable: true),
                    DayFourId = table.Column<int>(nullable: true),
                    DayOneId = table.Column<int>(nullable: true),
                    DaySevenId = table.Column<int>(nullable: true),
                    DaySixId = table.Column<int>(nullable: true),
                    DayThreeId = table.Column<int>(nullable: true),
                    DayTwoId = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    WorkoutType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeeklyWorkouts", x => x.Id);
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
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
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
                name: "IX_Exercises_DailyWorkoutId",
                table: "Exercises",
                column: "DailyWorkoutId");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Exercises");

            migrationBuilder.DropTable(
                name: "MonthlyWorkouts");

            migrationBuilder.DropTable(
                name: "WeeklyWorkouts");

            migrationBuilder.DropTable(
                name: "DailyWorkouts");
        }
    }
}
