using Swashbuckle.AspNetCore.Annotations;

namespace GerenciamentoDeCampeonato.Models.DTOs
{
    public class DtoTorneio : DtoDefault
    {
        public string Name { get; set; }

        public int NumberOfTeams { get; set; }

        public double ChampionReward { get; set; }

        public int? ChampionId { get; set; }

        public string Champion { get; set; }

        public int? BestPlayerId { get; set; }

        public string BestPlayer { get; set; }

        public int? GolderBootId { get; set; }

        public string GoldenBoot { get; set; }

    }
}
