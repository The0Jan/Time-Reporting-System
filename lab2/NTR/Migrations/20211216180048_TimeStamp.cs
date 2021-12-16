using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.Data.EntityFrameworkCore.Metadata;

namespace NTR.Migrations
{
    public partial class TimeStamp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Activities",
                columns: table => new
                {
                    ActivityModelId = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    UserModelId = table.Column<int>(nullable: false),
                    ProjectModelId = table.Column<int>(nullable: false),
                    SubcodeModelId = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: true),
                    Time = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Frozen = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activities", x => x.ActivityModelId);
                });

            migrationBuilder.CreateTable(
                name: "ProjectPartakes",
                columns: table => new
                {
                    ProjectPartakeId = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    ProjectModelId = table.Column<int>(nullable: false),
                    UserModelId = table.Column<int>(nullable: false),
                    SubmittedTime = table.Column<int>(nullable: false),
                    AcceptedTime = table.Column<int>(nullable: false),
                    Year = table.Column<int>(nullable: false),
                    Month = table.Column<int>(nullable: false),
                    Submitted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectPartakes", x => x.ProjectPartakeId);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    ProjectModelId = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    UserModelId = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Active = table.Column<bool>(nullable: false),
                    Budget = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.ProjectModelId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserModelId = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    First_Name = table.Column<string>(nullable: true),
                    Last_Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserModelId);
                });

            migrationBuilder.CreateTable(
                name: "Subcodes",
                columns: table => new
                {
                    SubcodeModelId = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    ProjectModelId = table.Column<int>(nullable: false),
                    name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subcodes", x => x.SubcodeModelId);
                    table.ForeignKey(
                        name: "FK_Subcodes_Projects_ProjectModelId",
                        column: x => x.ProjectModelId,
                        principalTable: "Projects",
                        principalColumn: "ProjectModelId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Subcodes_ProjectModelId",
                table: "Subcodes",
                column: "ProjectModelId");
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
                name: "Users");

            migrationBuilder.DropTable(
                name: "Projects");
        }
    }
}
