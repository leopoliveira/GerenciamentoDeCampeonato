using GerenciamentoDeCampeonato.Models.DTOs;
using GerenciamentoDeCampeonato.Models.Entities;

namespace GerenciamentoDeCampeonato.Mapping.TorneioEntity
{
    public class TorneioDtoToEntity : DefaultDtoToEntityMap<DtoTorneio, Torneio>
    {
        public Torneio ConvertDto(DtoTorneio dto, Torneio entity)
        {
            entity = base.DefaultDtoConvert(dto, entity);

            entity.Name = dto.Name;

            entity.NumberOfTeams = dto.NumberOfTeams;

            entity.ChampionReward = dto.ChampionReward;

            entity.ChampionId = dto.ChampionId;

            entity.BestPlayerId = dto.BestPlayerId;

            entity.GolderBootId = dto.GolderBootId;

            return entity;
        }
    }
}
