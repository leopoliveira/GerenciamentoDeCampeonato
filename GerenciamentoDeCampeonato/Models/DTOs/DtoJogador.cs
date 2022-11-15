using GerenciamentoDeCampeonato.Models.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Swashbuckle.AspNetCore.Annotations;

namespace GerenciamentoDeCampeonato.Models.DTOs
{
    public class DtoJogador : DtoDefault
    {
        public string Name { get; set; }

        public DateTime BirthDate { get; set; }

        public double Salary { get; set; }

        public string Country { get; set; }

        public int TeamId { get; set; }

        [SwaggerSchema(ReadOnly = true)]
        public string? Team { get; set; }

        public double? MarketValue { get; set; }
    }
}
