using GerenciamentoDeCampeonato.Models.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GerenciamentoDeCampeonato.Models.Entities
{
    public class Time : DefaultEntity
    {
        [Required]
        [MaxLength(100)]
        [Column(TypeName = "varchar(100)")]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        [Column(TypeName = "varchar(50)")]
        public string City { get; set; }

        public byte[]? Emblem { get; set; }

        [MaxLength(50)]
        [Column(TypeName = "varchar(50)")]
        public string? StadiumName { get; set; }

        public ICollection<Jogador> Players { get; set; }

        public ICollection<TimeTorneio> TeamTournament { get; set; }

    }
}
