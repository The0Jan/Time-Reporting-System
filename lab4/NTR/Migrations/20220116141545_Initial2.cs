using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NTR.Migrations
{
    public partial class Initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activities_Subcodes_ProjectCode",
                table: "Activities");

            migrationBuilder.AlterColumn<string>(
                name: "SubcodeName",
                table: "Activities",
                type: "varchar(95)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Activities_SubcodeName",
                table: "Activities",
                column: "SubcodeName");

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_Subcodes_SubcodeName",
                table: "Activities",
                column: "SubcodeName",
                principalTable: "Subcodes",
                principalColumn: "Name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activities_Subcodes_SubcodeName",
                table: "Activities");

            migrationBuilder.DropIndex(
                name: "IX_Activities_SubcodeName",
                table: "Activities");

            migrationBuilder.AlterColumn<string>(
                name: "SubcodeName",
                table: "Activities",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(95)",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_Subcodes_ProjectCode",
                table: "Activities",
                column: "ProjectCode",
                principalTable: "Subcodes",
                principalColumn: "Name",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
