using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace GerenciamentoDeCampeonato.Models.DTOs
{
    public class DtoPartida : DtoDefault
    {
        public int TournamentId { get; set; }

        [SwaggerSchema(ReadOnly = true)]
        public string? Tournament { get; set; }

        public int HomeTeamId { get; set; }

        [SwaggerSchema(ReadOnly = true)]
        public string? HomeTeam { get; set; }

        public int AwayTeamId { get; set; }

        [SwaggerSchema(ReadOnly = true)]
        public string? AwayTeam { get; set; }

        public int WinnerTeamId { get; set; }

        [SwaggerSchema(ReadOnly = true)]
        public string? WinnerTeam { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}
