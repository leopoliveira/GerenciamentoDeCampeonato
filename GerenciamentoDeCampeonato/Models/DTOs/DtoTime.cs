using GerenciamentoDeCampeonato.Models.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Swashbuckle.AspNetCore.Annotations;

namespace GerenciamentoDeCampeonato.Models.DTOs
{
    public class DtoTime : DtoDefault
    {
        public string Name { get; set; }

        public string City { get; set; }

        [SwaggerSchema(ReadOnly = true)]
        public byte[]? Emblem { get; set; }

        public string? StadiumName { get; set; }

    }
}
