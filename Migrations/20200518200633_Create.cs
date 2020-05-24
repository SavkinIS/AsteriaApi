using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AsteriaApi.Migrations
{
    public partial class Create : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Phone = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Records",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClientId = table.Column<int>(nullable: false),
                    SpecId = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Time = table.Column<DateTime>(nullable: false),
                    TypeWork = table.Column<string>(nullable: true),
                    Price = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Records", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sheetcs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(nullable: false),
                    SpecID = table.Column<int>(nullable: false),
                    T9m00 = table.Column<int>(nullable: false),
                    T9m30 = table.Column<int>(nullable: false),
                    T10m00 = table.Column<int>(nullable: false),
                    T10m30 = table.Column<int>(nullable: false),
                    T11m00 = table.Column<int>(nullable: false),
                    T11m30 = table.Column<int>(nullable: false),
                    T12m00 = table.Column<int>(nullable: false),
                    T12m30 = table.Column<int>(nullable: false),
                    T13m00 = table.Column<int>(nullable: false),
                    T13m30 = table.Column<int>(nullable: false),
                    T14m00 = table.Column<int>(nullable: false),
                    T14m30 = table.Column<int>(nullable: false),
                    T15m00 = table.Column<int>(nullable: false),
                    T15m030 = table.Column<int>(nullable: false),
                    T16m00 = table.Column<int>(nullable: false),
                    T16m30 = table.Column<int>(nullable: false),
                    T1700 = table.Column<int>(nullable: false),
                    T17m30 = table.Column<int>(nullable: false),
                    T18m00 = table.Column<int>(nullable: false),
                    T18m30 = table.Column<int>(nullable: false),
                    T19m00 = table.Column<int>(nullable: false),
                    T19m30 = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sheetcs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Specialists",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Specialization = table.Column<string>(nullable: true),
                    Women = table.Column<bool>(nullable: false),
                    Men = table.Column<bool>(nullable: false),
                    Child = table.Column<bool>(nullable: false),
                    Phone = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specialists", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Records");

            migrationBuilder.DropTable(
                name: "Sheetcs");

            migrationBuilder.DropTable(
                name: "Specialists");
        }
    }
}
