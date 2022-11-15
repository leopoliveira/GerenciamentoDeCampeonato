using GerenciamentoDeCampeonato.Models.DTOs;
using GerenciamentoDeCampeonato.Models.Entities;

namespace GerenciamentoDeCampeonato.Mapping
{
    public class DefaultDtoToEntityMap<TDto, TEntity>
        where TDto : DtoDefault
        where TEntity : DefaultEntity
    {
        public virtual TEntity DefaultDtoConvert(TDto dto, TEntity entity)
        {
            entity.Id = dto.Id;
            return entity;
        }
    }
}
