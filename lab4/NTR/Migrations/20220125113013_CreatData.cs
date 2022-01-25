using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NTR.Migrations
{
    public partial class CreatData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    First_Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    ProjectCode = table.Column<string>(type: "varchar(95)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Active = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Budget = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.ProjectCode);
                    table.ForeignKey(
                        name: "FK_Projects_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ProjectPartakes",
                columns: table => new
                {
                    ProjectPartakeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    SubmittedTime = table.Column<int>(type: "int", nullable: false),
                    AcceptedTime = table.Column<int>(type: "int", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Month = table.Column<int>(type: "int", nullable: false),
                    Submitted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ProjectCode = table.Column<string>(type: "varchar(95)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectPartakes", x => x.ProjectPartakeId);
                    table.ForeignKey(
                        name: "FK_ProjectPartakes_Projects_ProjectCode",
                        column: x => x.ProjectCode,
                        principalTable: "Projects",
                        principalColumn: "ProjectCode",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectPartakes_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Subcodes",
                columns: table => new
                {
                    Name = table.Column<string>(type: "varchar(95)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProjectCode = table.Column<string>(type: "varchar(95)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subcodes", x => x.Name);
                    table.ForeignKey(
                        name: "FK_Subcodes_Projects_ProjectCode",
                        column: x => x.ProjectCode,
                        principalTable: "Projects",
                        principalColumn: "ProjectCode",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Activities",
                columns: table => new
                {
                    ActivityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(type: "datetime", nullable: false),
                    Time = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Frozen = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ProjectCode = table.Column<string>(type: "varchar(95)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SubcodeName = table.Column<string>(type: "varchar(95)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activities", x => x.ActivityId);
                    table.ForeignKey(
                        name: "FK_Activities_Projects_ProjectCode",
                        column: x => x.ProjectCode,
                        principalTable: "Projects",
                        principalColumn: "ProjectCode",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Activities_Subcodes_SubcodeName",
                        column: x => x.SubcodeName,
                        principalTable: "Subcodes",
                        principalColumn: "Name");
                    table.ForeignKey(
                        name: "FK_Activities_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "First_Name" },
                values: new object[] { 1, "kowalski" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "First_Name" },
                values: new object[] { 2, "szeregowy" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "First_Name" },
                values: new object[] { 3, "rico" });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "ProjectCode", "Active", "Budget", "Title", "UserId" },
                values: new object[,]
                {
                    { "ARG", true, 1000, "ARGUS-15", 1 },
                    { "BARK", true, 1000, "BARKUS-16", 1 },
                    { "DARK", false, 1000, "DARKUS-18", 3 },
                    { "SMARK", true, 1000, "SMARKUS-17", 2 }
                });

            migrationBuilder.InsertData(
                table: "ProjectPartakes",
                columns: new[] { "ProjectPartakeId", "AcceptedTime", "Month", "ProjectCode", "Submitted", "SubmittedTime", "UserId", "Year" },
                values: new object[,]
                {
                    { 1, 0, 1, "ARG", false, 400, 1, 2022 },
                    { 2, 120, 1, "BARK", false, 400, 1, 2022 },
                    { 3, 200, 1, "SMARK", false, 200, 1, 2022 }
                });

            migrationBuilder.InsertData(
                table: "Subcodes",
                columns: new[] { "Name", "ProjectCode" },
                values: new object[,]
                {
                    { "compiling", "BARK" },
                    { "consulting", "BARK" },
                    { "debugging", "ARG" },
                    { "deploying", "BARK" },
                    { "downtime", "DARK" },
                    { "lunch-break", "ARG" },
                    { "programming", "SMARK" },
                    { "refactor", "ARG" },
                    { "testing", "ARG" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "ActivityId", "Date", "Description", "Frozen", "ProjectCode", "SubcodeName", "Time", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fun Times", false, "ARG", "refactor", 100, 1 },
                    { 2, new DateTime(2022, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Funnier Times", false, "ARG", "debugging", 100, 1 },
                    { 3, new DateTime(2022, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Funniest Times", false, "ARG", "debugging", 100, 1 },
                    { 4, new DateTime(2022, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Funnnos Timos", false, "ARG", "lunch-break", 100, 1 },
                    { 5, new DateTime(2022, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Funmosity Timosity", false, "BARK", "deploying", 100, 1 },
                    { 6, new DateTime(2022, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Programming in C", false, "SMARK", "programming", 100, 1 },
                    { 7, new DateTime(2022, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Programming in C#", false, "SMARK", "programming", 100, 1 },
                    { 8, new DateTime(2022, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Waiting", false, "BARK", "compiling", 100, 1 },
                    { 9, new DateTime(2022, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Done waiting", false, "BARK", "compiling", 100, 1 },
                    { 10, new DateTime(2022, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Boss came", false, "BARK", "consulting", 100, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Activities_ProjectCode",
                table: "Activities",
                column: "ProjectCode");

            migrationBuilder.CreateIndex(
                name: "IX_Activities_SubcodeName",
                table: "Activities",
                column: "SubcodeName");

            migrationBuilder.CreateIndex(
                name: "IX_Activities_UserId",
                table: "Activities",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectPartakes_ProjectCode",
                table: "ProjectPartakes",
                column: "ProjectCode");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectPartakes_UserId",
                table: "ProjectPartakes",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_UserId",
                table: "Projects",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Subcodes_ProjectCode",
                table: "Subcodes",
                column: "ProjectCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Activities");

            migrationBuilder.DropTable(
                name: "ProjectPartakes");

            migrationBuilder.DropTable(
                name: "Subcodes");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
