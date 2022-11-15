using GerenciamentoDeCampeonato.Models.DTOs;
using GerenciamentoDeCampeonato.Models.Entities;

namespace GerenciamentoDeCampeonato.Mapping.TimeEntity
{
    public class TimeDtoToEntity : DefaultDtoToEntityMap<DtoTime, Time>
    {
        public Time ConvertDto(DtoTime dto, Time entity)
        {
            entity = base.DefaultDtoConvert(dto, entity);

            entity.Name = dto.Name;

            entity.City = dto.City;

            entity.Emblem = dto.Emblem;

            entity.StadiumName = dto.StadiumName;

            return entity;
        }
    }
}
