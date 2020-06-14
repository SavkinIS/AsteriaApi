using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AsteriaApi.Migrations
{
    public partial class EightSix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sheetcs");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sheetcs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(nullable: false),
                    SpecID = table.Column<int>(nullable: false),
                    T10m00 = table.Column<int>(nullable: true),
                    T10m30 = table.Column<int>(nullable: true),
                    T11m00 = table.Column<int>(nullable: true),
                    T11m30 = table.Column<int>(nullable: true),
                    T12m00 = table.Column<int>(nullable: true),
                    T12m30 = table.Column<int>(nullable: true),
                    T13m00 = table.Column<int>(nullable: true),
                    T13m30 = table.Column<int>(nullable: true),
                    T14m00 = table.Column<int>(nullable: true),
                    T14m30 = table.Column<int>(nullable: true),
                    T15m00 = table.Column<int>(nullable: true),
                    T15m30 = table.Column<int>(nullable: true),
                    T16m00 = table.Column<int>(nullable: true),
                    T16m30 = table.Column<int>(nullable: true),
                    T17m00 = table.Column<int>(nullable: true),
                    T17m30 = table.Column<int>(nullable: true),
                    T18m00 = table.Column<int>(nullable: true),
                    T18m30 = table.Column<int>(nullable: true),
                    T19m00 = table.Column<int>(nullable: true),
                    T19m30 = table.Column<int>(nullable: true),
                    T9m00 = table.Column<int>(nullable: true),
                    T9m30 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sheetcs", x => x.Id);
                });
        }
    }
}
