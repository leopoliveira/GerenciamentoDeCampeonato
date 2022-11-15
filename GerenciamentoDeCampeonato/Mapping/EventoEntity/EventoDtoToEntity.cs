using GerenciamentoDeCampeonato.Enumerators;
using GerenciamentoDeCampeonato.Models.DTOs;
using GerenciamentoDeCampeonato.Models.Entities;

namespace GerenciamentoDeCampeonato.Mapping.EventoEntity
{
    public class EventoDtoToEntity : DefaultDtoToEntityMap<DtoEvento, Evento>
    {
        public Evento ConvertDto(DtoEvento dto, Evento entity)
        {
            entity = base.DefaultDtoConvert(dto, entity);

            entity.EventDescription = dto.EventDescription;

            entity.EventDate = dto.EventDate;

            entity.MatchId = dto.MatchId;

            return entity;
        }
    }
}
