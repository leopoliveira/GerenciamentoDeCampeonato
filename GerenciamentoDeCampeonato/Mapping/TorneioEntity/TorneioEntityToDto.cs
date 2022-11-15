using GerenciamentoDeCampeonato.Models.DTOs;
using GerenciamentoDeCampeonato.Models.Entities;

namespace GerenciamentoDeCampeonato.Mapping.TorneioEntity
{
    public class TorneioEntityToDto : DefaultEntityToDtoMap<Torneio, DtoTorneio>
    {
        public DtoTorneio ConvertEntity(Torneio entity, DtoTorneio dto)
        {
            dto = base.DefaultEntityConvert(entity, dto);

            dto.Name = entity.Name;

            dto.NumberOfTeams = entity.NumberOfTeams;

            dto.ChampionReward = entity.ChampionReward;

            dto.ChampionId = entity.ChampionId;

            dto.BestPlayerId = entity.BestPlayerId;

            dto.GolderBootId = entity.GolderBootId;

            return dto;
        }
    }
}
