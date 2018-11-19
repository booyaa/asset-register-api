using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace HomesEngland.Gateway.Migrations
{
    public partial class initialmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Assets",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    ModifiedDateTime = table.Column<DateTime>(nullable: false),
                    MonthPaid = table.Column<string>(nullable: true),
                    AccountingYear = table.Column<string>(nullable: true),
                    SchemeId = table.Column<string>(nullable: true),
                    LocationLaRegionName = table.Column<string>(nullable: true),
                    ImsOldRegion = table.Column<string>(nullable: true),
                    NoOfBeds = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    DevelopingRslName = table.Column<string>(nullable: true),
                    CompletionDateForHpiStart = table.Column<DateTime>(nullable: true),
                    ImsActualCompletionDate = table.Column<DateTime>(nullable: true),
                    ImsExpectedCompletionDate = table.Column<DateTime>(nullable: true),
                    ImsLegalCompletionDate = table.Column<DateTime>(nullable: true),
                    HopCompletionDate = table.Column<DateTime>(nullable: true),
                    Deposit = table.Column<decimal>(nullable: true),
                    AgencyEquityLoan = table.Column<decimal>(nullable: true),
                    DeveloperEquityLoan = table.Column<decimal>(nullable: true),
                    ShareOfRestrictedEquity = table.Column<decimal>(nullable: true),
                    DifferenceFromImsExpectedCompletionToHopCompletionDate = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assets", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Assets");
        }
    }
}
