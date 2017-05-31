using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Workoutplaner.Server.Migrations
{
    public partial class AddedDoneWorkout : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DonedDailyWorkouts",
                columns: table => new
                {
                    Date = table.Column<DateTime>(nullable: false),
                    ApplicationUserId = table.Column<string>(nullable: true),
                    DonedWorkoutId = table.Column<int>(nullable: true),
                    LastInMinute = table.Column<double>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonedDailyWorkouts", x => x.Date);
                    table.ForeignKey(
                        name: "FK_DonedDailyWorkouts_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DonedDailyWorkouts_BaseWorkout_DonedWorkoutId",
                        column: x => x.DonedWorkoutId,
                        principalTable: "BaseWorkout",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DonedDailyWorkouts_ApplicationUserId",
                table: "DonedDailyWorkouts",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_DonedDailyWorkouts_DonedWorkoutId",
                table: "DonedDailyWorkouts",
                column: "DonedWorkoutId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DonedDailyWorkouts");
        }
    }
}
