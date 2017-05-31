using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Workoutplaner.Server.Migrations.Exercise
{
    public partial class InitHiLoSeqDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence<int>(
                name: "HiLoSeq",
                startValue: 1000L,
                incrementBy: 10);

            migrationBuilder.CreateTable(
                name: "Exercises",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    MuscleGroup = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Reps = table.Column<int>(nullable: true),
                    SerialNumber = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercises", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Exercises");

            migrationBuilder.DropSequence(
                name: "HiLoSeq");
        }
    }
}
