using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GerenciamentoDeCampeonato.Models.Entities
{
    public class Partida : DefaultEntity
    {
        [Required]
        public int TournamentId { get; set; }

        [ForeignKey("TournamentId")]
        public Torneio Tournament { get; set; }

        [Required]
        public int HomeTeamId { get; set; }

        [ForeignKey("HomeTeamId")]
        public Time HomeTeam { get; set; }

        [Required]
        public int AwayTeamId { get; set; }

        [ForeignKey("AwayTeamId")]
        public Time AwayTeam { get; set; }

        public int WinnerTeamId { get; set; }

        [ForeignKey("WinnerTeamId")]
        public Time WinnerTeam { get; set; }

        [Required]
        [Column(TypeName = "datetime2")]
        public DateTime StartDate { get; set; }

        [Required]
        [Column(TypeName = "datetime2")]
        public DateTime EndDate { get; set; }

    }
}
