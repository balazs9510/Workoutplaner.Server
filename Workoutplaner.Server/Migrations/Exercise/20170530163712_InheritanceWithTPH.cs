using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Workoutplaner.Server.Migrations.Exercise
{
    public partial class InheritanceWithTPH : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Discriminator",
                table: "Exercises",
                newName: "exercise_type");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "exercise_type",
                table: "Exercises",
                newName: "Discriminator");
        }
    }
}
