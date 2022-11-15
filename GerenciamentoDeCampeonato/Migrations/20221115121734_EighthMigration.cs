using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GerenciamentoDeCampeonato.Migrations
{
    public partial class EighthMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MatchId",
                table: "EVENTO",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_EVENTO_MatchId",
                table: "EVENTO",
                column: "MatchId");

            migrationBuilder.AddForeignKey(
                name: "FK_EVENTO_MATCH_MatchId",
                table: "EVENTO",
                column: "MatchId",
                principalTable: "MATCH",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EVENTO_MATCH_MatchId",
                table: "EVENTO");

            migrationBuilder.DropIndex(
                name: "IX_EVENTO_MatchId",
                table: "EVENTO");

            migrationBuilder.DropColumn(
                name: "MatchId",
                table: "EVENTO");
        }
    }
}
