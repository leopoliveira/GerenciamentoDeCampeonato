using GerenciamentoDeCampeonato.Models.DTOs;
using GerenciamentoDeCampeonato.Models.Entities;

namespace GerenciamentoDeCampeonato.Mapping.JogadorEntity
{
    public class JogadorDtoToEntity : DefaultDtoToEntityMap<DtoJogador, Jogador>
    {
        public Jogador ConvertDto(DtoJogador dto, Jogador entity)
        {
            entity = base.DefaultDtoConvert(dto, entity);

            entity.Name = dto.Name;

            entity.BirthDate = DateTime.Parse(dto.BirthDate.ToString());

            entity.Salary = dto.Salary;

            entity.Country = dto.Country;

            entity.TeamId = dto.TeamId;

            entity.MarketValue = dto.MarketValue;

            return entity;
        }
    }
}
