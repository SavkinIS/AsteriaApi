using Microsoft.EntityFrameworkCore.Migrations;

namespace AsteriaApi.Migrations
{
    public partial class RecordPriceNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Price",
                table: "Records",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Price",
                table: "Records",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}
