using GerenciamentoDeCampeonato.Models.DTOs;
using GerenciamentoDeCampeonato.Models.Entities;

namespace GerenciamentoDeCampeonato.Mapping.TimeEntity
{
    public class TimeEntityToDto : DefaultEntityToDtoMap<Time, DtoTime>
    {
        public DtoTime ConvertEntity(Time entity, DtoTime dto)
        {
            dto = base.DefaultEntityConvert(entity, dto);

            dto.Name = entity.Name;

            dto.City = entity.City;

            dto.Emblem = entity.Emblem;

            dto.StadiumName = entity.StadiumName; 

            return dto;
        }
    }
}
