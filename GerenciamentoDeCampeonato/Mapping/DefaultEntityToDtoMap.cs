using GerenciamentoDeCampeonato.Models.DTOs;
using GerenciamentoDeCampeonato.Models.Entities;

namespace GerenciamentoDeCampeonato.Mapping
{
    public class DefaultEntityToDtoMap<TEntity, TDto> 
        where TEntity : DefaultEntity
        where TDto : DtoDefault
    {

        public virtual TDto DefaultEntityConvert(TEntity entity, TDto dto)
        {
            dto.Id = entity.Id;
            return dto;
        }
    }
}
