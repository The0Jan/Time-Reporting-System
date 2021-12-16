using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.Data.EntityFrameworkCore.Metadata;

namespace NTR.Migrations
{
    public partial class TimeStamp2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<DateTime>(
                name: "Timestamp",
                table: "Projects",
                nullable: false)
                .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.ComputedColumn);

            migrationBuilder.AddColumn<DateTime>(
                name: "Timestamp",
                table: "ProjectPartakes",
                nullable: false)
                .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.ComputedColumn);

            migrationBuilder.AddColumn<DateTime>(
                name: "Timestamp",
                table: "Activities",
                type: "datetime(3)",
                nullable: false)
                .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.ComputedColumn);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Timestamp",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "Timestamp",
                table: "ProjectPartakes");

            migrationBuilder.DropColumn(
                name: "Timestamp",
                table: "Activities");

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Projects",
                type: "varbinary(4000)",
                rowVersion: true,
                nullable: true)
                .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.ComputedColumn);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "ProjectPartakes",
                type: "varbinary(4000)",
                rowVersion: true,
                nullable: true)
                .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.ComputedColumn);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Activities",
                type: "varbinary(4000)",
                rowVersion: true,
                nullable: true)
                .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.ComputedColumn);
        }
    }
}
