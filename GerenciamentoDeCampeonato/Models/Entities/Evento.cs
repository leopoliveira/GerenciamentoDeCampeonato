using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using GerenciamentoDeCampeonato.Enumerators;

namespace GerenciamentoDeCampeonato.Models.Entities
{
    public class Evento : DefaultEntity
    {
        [Required]
        [Column(TypeName = "int")]
        public EventType EventType { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string EventDescription { get; set; }

        [Required]
        [Column(TypeName = "datetime2")]
        public DateTime EventDate { get; set; }

        [Required]
        public int MatchId { get; set; }

        [ForeignKey("MatchId")]
        public Partida Match { get; set; }
    }
}
