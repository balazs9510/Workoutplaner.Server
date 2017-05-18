using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Workoutplaner.Server.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false)
                        .Annotation("MySql:ValueGeneratedOnAdd", true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false)
                        .Annotation("MySql:ValueGeneratedOnAdd", true),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    PasswordHash = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    SecurityStamp = table.Column<string>(nullable: true),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGeneratedOnAdd", true),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGeneratedOnAdd", true),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                name: "Exercises",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGeneratedOnAdd", true),
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
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_DailyWorkouts_ApplicationUserId",
                table: "DailyWorkouts",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Exercises_DailyWorkoutId",
                table: "Exercises",
                column: "DailyWorkoutId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Exercises");

            migrationBuilder.DropTable(
                name: "MonthlyWorkouts");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "WeeklyWorkouts");

            migrationBuilder.DropTable(
                name: "DailyWorkouts");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
