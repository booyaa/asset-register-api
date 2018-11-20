using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace HomesEngland.Gateway.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "assets",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    modifieddatetime = table.Column<DateTime>(nullable: false),
                    monthpaid = table.Column<string>(nullable: true),
                    accountingyear = table.Column<string>(nullable: true),
                    schemeid = table.Column<string>(nullable: true),
                    locationlaregionname = table.Column<string>(nullable: true),
                    imsoldregion = table.Column<string>(nullable: true),
                    noofbeds = table.Column<string>(nullable: true),
                    address = table.Column<string>(nullable: true),
                    developingrslname = table.Column<string>(nullable: true),
                    completiondateforhpistart = table.Column<DateTime>(nullable: true),
                    imsactualcompletiondate = table.Column<DateTime>(nullable: true),
                    imsexpectedcompletiondate = table.Column<DateTime>(nullable: true),
                    imslegalcompletiondate = table.Column<DateTime>(nullable: true),
                    hopcompletiondate = table.Column<DateTime>(nullable: true),
                    deposit = table.Column<decimal>(nullable: true),
                    agencyequityloan = table.Column<decimal>(nullable: true),
                    developerequityloan = table.Column<decimal>(nullable: true),
                    shareofrestrictedequity = table.Column<decimal>(nullable: true),
                    differencefromimsexpectedcompletiontohopcompletiondate = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_assets", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "assets");
        }
    }
}
