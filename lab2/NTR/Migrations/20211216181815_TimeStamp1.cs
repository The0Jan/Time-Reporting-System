using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.Data.EntityFrameworkCore.Metadata;

namespace NTR.Migrations
{
    public partial class TimeStamp1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Projects",
                rowVersion: true,
                nullable: true)
                .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.ComputedColumn);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "ProjectPartakes",
                rowVersion: true,
                nullable: true)
                .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.ComputedColumn);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Activities",
                rowVersion: true,
                nullable: true)
                .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.ComputedColumn);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "ProjectPartakes");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Activities");
        }
    }
}
