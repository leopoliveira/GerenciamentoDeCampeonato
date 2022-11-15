using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GerenciamentoDeCampeonato.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EVENTO",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventType = table.Column<int>(type: "int", nullable: false),
                    EventDescription = table.Column<string>(type: "nvarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EVENTO", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TEAM",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    City = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    TotalOfPlayers = table.Column<int>(type: "int", nullable: false),
                    Emblem = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    StadiumName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    TournamentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TEAM", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PLAYERS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "date", nullable: false),
                    Salary = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
                    Country = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    TeamId = table.Column<int>(type: "int", nullable: false),
                    MarketValue = table.Column<decimal>(type: "decimal(12,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PLAYERS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PLAYERS_TEAM_TeamId",
                        column: x => x.TeamId,
                        principalTable: "TEAM",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TOURNAMENT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    NumberOfTeams = table.Column<int>(type: "int", nullable: false),
                    ChampionReward = table.Column<decimal>(type: "decimal(12,5)", nullable: false),
                    ChampionId = table.Column<int>(type: "int", nullable: false),
                    BestPlayerId = table.Column<int>(type: "int", nullable: false),
                    GolderBootId = table.Column<int>(type: "int", nullable: false),
                    TeamId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TOURNAMENT", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TOURNAMENT_PLAYERS_BestPlayerId",
                        column: x => x.BestPlayerId,
                        principalTable: "PLAYERS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TOURNAMENT_PLAYERS_GolderBootId",
                        column: x => x.GolderBootId,
                        principalTable: "PLAYERS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TOURNAMENT_TEAM_ChampionId",
                        column: x => x.ChampionId,
                        principalTable: "TEAM",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TRANSFER",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlayerId = table.Column<int>(type: "int", nullable: false),
                    NewTeamId = table.Column<int>(type: "int", nullable: false),
                    OldTeamId = table.Column<int>(type: "int", nullable: false),
                    TransferDate = table.Column<DateTime>(type: "date", nullable: false),
                    TransferFee = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
                    PaymentType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TRANSFER", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TRANSFER_PLAYERS_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "PLAYERS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TRANSFER_TEAM_NewTeamId",
                        column: x => x.NewTeamId,
                        principalTable: "TEAM",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TRANSFER_TEAM_OldTeamId",
                        column: x => x.OldTeamId,
                        principalTable: "TEAM",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MATCH",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TournamentId = table.Column<int>(type: "int", nullable: false),
                    HomeTeamId = table.Column<int>(type: "int", nullable: false),
                    AwayTeamId = table.Column<int>(type: "int", nullable: false),
                    MatchDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    WinnerTeamId = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MATCH", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MATCH_TEAM_AwayTeamId",
                        column: x => x.AwayTeamId,
                        principalTable: "TEAM",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MATCH_TEAM_HomeTeamId",
                        column: x => x.HomeTeamId,
                        principalTable: "TEAM",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MATCH_TEAM_WinnerTeamId",
                        column: x => x.WinnerTeamId,
                        principalTable: "TEAM",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MATCH_TOURNAMENT_TournamentId",
                        column: x => x.TournamentId,
                        principalTable: "TOURNAMENT",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TEAMTOURNAMENT",
                columns: table => new
                {
                    TournamentId = table.Column<int>(type: "int", nullable: false),
                    TeamId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TEAMTOURNAMENT", x => new { x.TournamentId, x.TeamId });
                    table.ForeignKey(
                        name: "FK_TEAMTOURNAMENT_TEAM_TeamId",
                        column: x => x.TeamId,
                        principalTable: "TEAM",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TEAMTOURNAMENT_TOURNAMENT_TournamentId",
                        column: x => x.TournamentId,
                        principalTable: "TOURNAMENT",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MATCH_AwayTeamId",
                table: "MATCH",
                column: "AwayTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_MATCH_HomeTeamId",
                table: "MATCH",
                column: "HomeTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_MATCH_TournamentId",
                table: "MATCH",
                column: "TournamentId");

            migrationBuilder.CreateIndex(
                name: "IX_MATCH_WinnerTeamId",
                table: "MATCH",
                column: "WinnerTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_PLAYERS_TeamId",
                table: "PLAYERS",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_TEAMTOURNAMENT_TeamId",
                table: "TEAMTOURNAMENT",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_TOURNAMENT_BestPlayerId",
                table: "TOURNAMENT",
                column: "BestPlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_TOURNAMENT_ChampionId",
                table: "TOURNAMENT",
                column: "ChampionId");

            migrationBuilder.CreateIndex(
                name: "IX_TOURNAMENT_GolderBootId",
                table: "TOURNAMENT",
                column: "GolderBootId");

            migrationBuilder.CreateIndex(
                name: "IX_TRANSFER_NewTeamId",
                table: "TRANSFER",
                column: "NewTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_TRANSFER_OldTeamId",
                table: "TRANSFER",
                column: "OldTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_TRANSFER_PlayerId",
                table: "TRANSFER",
                column: "PlayerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EVENTO");

            migrationBuilder.DropTable(
                name: "MATCH");

            migrationBuilder.DropTable(
                name: "TEAMTOURNAMENT");

            migrationBuilder.DropTable(
                name: "TRANSFER");

            migrationBuilder.DropTable(
                name: "TOURNAMENT");

            migrationBuilder.DropTable(
                name: "PLAYERS");

            migrationBuilder.DropTable(
                name: "TEAM");
        }
    }
}
