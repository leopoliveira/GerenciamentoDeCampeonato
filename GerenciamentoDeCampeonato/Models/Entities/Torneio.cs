using GerenciamentoDeCampeonato.Models.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GerenciamentoDeCampeonato.Models.Entities
{
    public class Torneio : DefaultEntity
    {
        [Required]
        [MaxLength(50)]
        [Column(TypeName = "varchar(50)")]
        public string Name { get; set; }

        [Required]
        public int NumberOfTeams { get; set; }

        [Required]
        [Column(TypeName = "decimal(12, 5)")]
        public double ChampionReward { get; set; }

        public int? ChampionId { get; set; }

        [ForeignKey("ChampionId")]
        public Time Champion { get; set; }

        public int? BestPlayerId { get; set; }

        [ForeignKey("BestPlayerId")]
        public Jogador BestPlayer { get; set; }

        public int? GolderBootId { get; set; }

        [ForeignKey("GolderBootId")]
        public Jogador GolderBoot { get; set; }

        public ICollection<Partida> Matches { get; set; }

        public ICollection<TimeTorneio> TeamTournament { get; set; }

    }
}
