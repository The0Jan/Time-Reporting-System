using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.Data.EntityFrameworkCore.Metadata;

namespace NTR.Migrations
{
    public partial class TimeStamp3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Timestamp",
                table: "Projects",
                type: "datetime(3)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime")
                .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.ComputedColumn)
                .OldAnnotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.ComputedColumn);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Timestamp",
                table: "ProjectPartakes",
                type: "datetime(3)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime")
                .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.ComputedColumn)
                .OldAnnotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.ComputedColumn);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Timestamp",
                table: "Projects",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(3)")
                .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.ComputedColumn)
                .OldAnnotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.ComputedColumn);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Timestamp",
                table: "ProjectPartakes",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(3)")
                .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.ComputedColumn)
                .OldAnnotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.ComputedColumn);
        }
    }
}
