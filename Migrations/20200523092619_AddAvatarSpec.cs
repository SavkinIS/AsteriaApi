using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AsteriaApi.Migrations
{
    public partial class AddAvatarSpec : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SpecAvatar",
                table: "Specialists",
                nullable: true);

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "Time",
                table: "Records",
                nullable: false,
                oldClrType: typeof(DateTime));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SpecAvatar",
                table: "Specialists");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Time",
                table: "Records",
                nullable: false,
                oldClrType: typeof(TimeSpan));
        }
    }
}
