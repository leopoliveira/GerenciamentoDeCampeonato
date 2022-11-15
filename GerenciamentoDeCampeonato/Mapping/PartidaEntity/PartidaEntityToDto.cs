using GerenciamentoDeCampeonato.Models.DTOs;
using GerenciamentoDeCampeonato.Models.Entities;

namespace GerenciamentoDeCampeonato.Mapping.PartidaEntity
{
    public class PartidaEntityToDto : DefaultEntityToDtoMap<Partida, DtoPartida>
    {
        public DtoPartida ConvertEntity(Partida entity, DtoPartida dto)
        {
            dto = base.DefaultEntityConvert(entity, dto);

            dto.TournamentId = entity.TournamentId;

            dto.HomeTeamId = entity.HomeTeamId;

            dto.AwayTeamId = entity.AwayTeamId;

            dto.WinnerTeamId = entity.WinnerTeamId;

            dto.StartDate = entity.StartDate;

            dto.EndDate = entity.EndDate;

            return dto;
        }
    }
}
