using GerenciamentoDeCampeonato.Enumerators;
using GerenciamentoDeCampeonato.Models.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GerenciamentoDeCampeonato.Models.Entities
{
    public class Transferencia : DefaultEntity
    {        
        [Required]
        public int PlayerId { get; set; }

        [ForeignKey("PlayerId")]
        public Jogador Player { get; set; }

        [Required]
        public int NewTeamId { get; set; }

        [ForeignKey("NewTeamId")]
        public Time NewTeam { get; set; }

        [Required]
        public int OldTeamId { get; set; }

        [ForeignKey("OldTeamId")]
        public Time OldTeam { get; set; }

        [Required]
        [Column(TypeName = "datetime2")]
        public DateTime TransferDate { get; set; }

        [Required]
        [Column(TypeName = "decimal(12, 2)")]
        public double TransferFee { get; set; }

        [Required]
        [Column(TypeName = "int")]
        public PaymenteType PaymentType { get; set; }
    }
}
