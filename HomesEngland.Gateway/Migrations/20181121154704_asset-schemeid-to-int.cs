using Microsoft.EntityFrameworkCore.Migrations;

namespace HomesEngland.Gateway.Migrations
{
    public partial class assetschemeidtoint : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "schemeid",
                table: "assets"
            );

            migrationBuilder.AddColumn<int>(
                name: "schemeid",
                table: "assets",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "schemeid",
                table: "assets"
            );
            migrationBuilder.AddColumn<string>(
                name: "schemeid",
                table: "assets",
                nullable: true);
        }
    }
}
