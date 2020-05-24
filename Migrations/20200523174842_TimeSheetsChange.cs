using Microsoft.EntityFrameworkCore.Migrations;

namespace AsteriaApi.Migrations
{
    public partial class TimeSheetsChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "T1700",
                table: "Sheetcs",
                newName: "T17m00");

            migrationBuilder.RenameColumn(
                name: "T15m030",
                table: "Sheetcs",
                newName: "T15m30");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "T17m00",
                table: "Sheetcs",
                newName: "T1700");

            migrationBuilder.RenameColumn(
                name: "T15m30",
                table: "Sheetcs",
                newName: "T15m030");
        }
    }
}
