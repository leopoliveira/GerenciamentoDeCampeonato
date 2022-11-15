using GerenciamentoDeCampeonato.Enumerators;
using GerenciamentoDeCampeonato.Models.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Swashbuckle.AspNetCore.Annotations;

namespace GerenciamentoDeCampeonato.Models.DTOs
{
    public class DtoTransferencia : DtoDefault
    {
        public int PlayerId { get; set; }

        public string Player { get; set; }

        public int NewTeamId { get; set; }

        public string NewTeam { get; set; }

        public int OldTeamId { get; set; }

        public string OldTeam { get; set; }

        public DateTime TransferDate { get; set; }

        public double TransferFee { get; set; }

        public int PaymentType { get; set; }
    }
}
