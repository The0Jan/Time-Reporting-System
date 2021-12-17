using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NTR.Migrations
{
    public partial class TimeStamp6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "SubcodeModelId",
                table: "Activities",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Activities",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "SubcodeModelId",
                table: "Activities",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Activities",
                type: "datetime",
                nullable: true,
                oldClrType: typeof(DateTime));
        }
    }
}
