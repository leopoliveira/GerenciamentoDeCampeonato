using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GerenciamentoDeCampeonato.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "TEAMTOURNAMENT",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "TEAMTOURNAMENT");
        }
    }
}
