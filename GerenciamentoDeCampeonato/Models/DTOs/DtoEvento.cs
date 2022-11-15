using Swashbuckle.AspNetCore.Annotations;

namespace GerenciamentoDeCampeonato.Models.DTOs
{
    public class DtoEvento : DtoDefault
    {
        public string EventDescription { get; set; }

        public DateTime EventDate { get; set; }

        public int MatchId { get; set; }

        public string Match { get; set; }

        public string Tournament { get; set; }
    }
}
