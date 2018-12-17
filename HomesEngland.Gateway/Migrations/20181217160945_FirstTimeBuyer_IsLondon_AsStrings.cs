using Microsoft.EntityFrameworkCore.Migrations;

namespace HomesEngland.Gateway.Migrations
{
    public partial class FirstTimeBuyer_IsLondon_AsStrings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "notlimitedbyfirstcharge",
                table: "assets",
                nullable: true,
                oldClrType: typeof(bool),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "islondon",
                table: "assets",
                nullable: true,
                oldClrType: typeof(bool),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "firsttimebuyer",
                table: "assets",
                nullable: true,
                oldClrType: typeof(bool),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "notlimitedbyfirstcharge",
                table: "assets",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "islondon",
                table: "assets",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "firsttimebuyer",
                table: "assets",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
