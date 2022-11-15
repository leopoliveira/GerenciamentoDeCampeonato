using Swashbuckle.AspNetCore.Annotations;

namespace GerenciamentoDeCampeonato.Models.DTOs
{
    public class DtoTorneio : DtoDefault
    {
        public string Name { get; set; }

        public int NumberOfTeams { get; set; }

        public double ChampionReward { get; set; }

        public int? ChampionId { get; set; }

        [SwaggerSchema(ReadOnly = true)]
        public string? Champion { get; set; }

        public int? BestPlayerId { get; set; }

        [SwaggerSchema(ReadOnly = true)]
        public string? BestPlayer { get; set; }

        public int? GolderBootId { get; set; }

        [SwaggerSchema(ReadOnly = true)]
        public string? GoldenBoot { get; set; }

    }
}
