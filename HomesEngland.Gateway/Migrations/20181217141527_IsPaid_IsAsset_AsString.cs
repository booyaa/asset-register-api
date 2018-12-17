using Microsoft.EntityFrameworkCore.Migrations;

namespace HomesEngland.Gateway.Migrations
{
    public partial class IsPaid_IsAsset_AsString : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ispaid",
                table: "assets",
                nullable: true,
                oldClrType: typeof(bool),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "isasset",
                table: "assets",
                nullable: true,
                oldClrType: typeof(bool),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "ispaid",
                table: "assets",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "isasset",
                table: "assets",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
