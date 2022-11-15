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

        [SwaggerSchema(ReadOnly = true)]
        public string? Player { get; set; }

        public int NewTeamId { get; set; }

        [SwaggerSchema(ReadOnly = true)]
        public string? NewTeam { get; set; }

        public int OldTeamId { get; set; }

        [SwaggerSchema(ReadOnly = true)]
        public string? OldTeam { get; set; }

        public DateTime TransferDate { get; set; }

        public double TransferFee { get; set; }

        public int PaymentType { get; set; }
    }
}
