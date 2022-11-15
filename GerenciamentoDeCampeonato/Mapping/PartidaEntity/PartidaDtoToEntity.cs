using GerenciamentoDeCampeonato.Models.DTOs;
using GerenciamentoDeCampeonato.Models.Entities;

namespace GerenciamentoDeCampeonato.Mapping.PartidaEntity
{
    public class PartidaDtoToEntity : DefaultDtoToEntityMap<DtoPartida, Partida>
    {
        public Partida ConvertDto(DtoPartida dto, Partida entity)
        {
            entity = base.DefaultDtoConvert(dto, entity);

            entity.TournamentId = dto.TournamentId;

            entity.HomeTeamId = dto.HomeTeamId;

            entity.AwayTeamId = dto.AwayTeamId;

            entity.WinnerTeamId = dto.WinnerTeamId;

            entity.StartDate = dto.StartDate;

            entity.EndDate = dto.EndDate;

            return entity;
        }
    }
}
