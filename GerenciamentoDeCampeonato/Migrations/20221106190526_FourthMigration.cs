using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GerenciamentoDeCampeonato.Migrations
{
    public partial class FourthMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalOfPlayers",
                table: "TEAM");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TotalOfPlayers",
                table: "TEAM",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
