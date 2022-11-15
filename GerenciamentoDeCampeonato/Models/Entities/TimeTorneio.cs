using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GerenciamentoDeCampeonato.Models.Entities
{
    public class TimeTorneio : DefaultEntity
    {

        [NotMapped]
        public override int Id { get; set; }

        public int TournamentId { get; set; }

        public Torneio Tournament { get; set; }

        public int TeamId { get; set; }

        public Time Team { get; set; }
    }
}
