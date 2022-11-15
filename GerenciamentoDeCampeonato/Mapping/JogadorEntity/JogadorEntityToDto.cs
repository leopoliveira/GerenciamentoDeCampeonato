using GerenciamentoDeCampeonato.Models.DTOs;
using GerenciamentoDeCampeonato.Models.Entities;

namespace GerenciamentoDeCampeonato.Mapping.JogadorEntity
{
    public class JogadorEntityToDto : DefaultEntityToDtoMap<Jogador, DtoJogador>
    {
        public DtoJogador ConvertEntity(Jogador entity, DtoJogador dto)
        {
            dto = base.DefaultEntityConvert(entity, dto);

            dto.Name = entity.Name;

            dto.BirthDate = entity.BirthDate;

            dto.Salary = entity.Salary;

            dto.Country = entity.Country;

            dto.TeamId = entity.TeamId;

            dto.MarketValue = entity.MarketValue;

            return dto;
        }
    }
}
