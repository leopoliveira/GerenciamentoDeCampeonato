using GerenciamentoDeCampeonato.Enumerators;
using GerenciamentoDeCampeonato.Models.DTOs;
using GerenciamentoDeCampeonato.Models.Entities;

namespace GerenciamentoDeCampeonato.Mapping.TransferenciaEntity
{
    public class TransferenciaDtoToEntity : DefaultDtoToEntityMap<DtoTransferencia, Transferencia>
    {
        public Transferencia ConvertDto(DtoTransferencia dto, Transferencia entity)
        {
            entity = base.DefaultDtoConvert(dto, entity);

            entity.PlayerId = dto.PlayerId;

            entity.NewTeamId = dto.NewTeamId;

            entity.OldTeamId = dto.OldTeamId;

            entity.TransferDate = dto.TransferDate;

            entity.TransferFee = dto.TransferFee;

            entity.PaymentType = (PaymenteType)dto.PaymentType;

            return entity;
        }
    }
}
