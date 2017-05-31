using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Workoutplaner.Server.Migrations
{
    public partial class AddedDoneWorkoutWithRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId1",
                table: "DonedDailyWorkouts",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DonedDailyWorkouts_ApplicationUserId1",
                table: "DonedDailyWorkouts",
                column: "ApplicationUserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_DonedDailyWorkouts_AspNetUsers_ApplicationUserId1",
                table: "DonedDailyWorkouts",
                column: "ApplicationUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DonedDailyWorkouts_AspNetUsers_ApplicationUserId1",
                table: "DonedDailyWorkouts");

            migrationBuilder.DropIndex(
                name: "IX_DonedDailyWorkouts_ApplicationUserId1",
                table: "DonedDailyWorkouts");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId1",
                table: "DonedDailyWorkouts");
        }
    }
}
