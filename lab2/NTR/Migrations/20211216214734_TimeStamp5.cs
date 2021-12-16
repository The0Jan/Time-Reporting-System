using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.Data.EntityFrameworkCore.Metadata;

namespace NTR.Migrations
{
    public partial class TimeStamp5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Timestamp",
                table: "Projects",
                type: "datetime(0)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(3)")
                .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.ComputedColumn)
                .OldAnnotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.ComputedColumn);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Timestamp",
                table: "ProjectPartakes",
                type: "datetime(0)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(3)")
                .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.ComputedColumn)
                .OldAnnotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.ComputedColumn);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Timestamp",
                table: "Activities",
                type: "datetime(0)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(3)")
                .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.ComputedColumn)
                .OldAnnotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.ComputedColumn);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Timestamp",
                table: "Projects",
                type: "datetime(3)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(0)")
                .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.ComputedColumn)
                .OldAnnotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.ComputedColumn);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Timestamp",
                table: "ProjectPartakes",
                type: "datetime(3)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(0)")
                .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.ComputedColumn)
                .OldAnnotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.ComputedColumn);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Timestamp",
                table: "Activities",
                type: "datetime(3)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(0)")
                .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.ComputedColumn)
                .OldAnnotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.ComputedColumn);
        }
    }
}
