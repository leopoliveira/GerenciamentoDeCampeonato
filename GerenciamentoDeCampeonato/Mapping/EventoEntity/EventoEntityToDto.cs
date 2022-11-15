using GerenciamentoDeCampeonato.Enumerators;
using GerenciamentoDeCampeonato.Models.DTOs;
using GerenciamentoDeCampeonato.Models.Entities;

namespace GerenciamentoDeCampeonato.Mapping.EventoEntity
{
    public class EventoEntityToDto : DefaultEntityToDtoMap<Evento, DtoEvento>
    {
        public DtoEvento ConvertEntity(Evento entity, DtoEvento dto)
        {
            dto = base.DefaultEntityConvert(entity, dto);

            dto.EventDescription = entity.EventDescription;

            dto.EventDate = entity.EventDate;

            dto.MatchId = entity.MatchId;

            return dto;
        }
    }
}
