using GerenciamentoDeCampeonato.Enumerators;
using GerenciamentoDeCampeonato.Models.DTOs;
using GerenciamentoDeCampeonato.Models.Entities;

namespace GerenciamentoDeCampeonato.Mapping.TransferenciaEntity
{
    public class TransferenciaEntityToDto : DefaultEntityToDtoMap<Transferencia, DtoTransferencia>
    {
        public DtoTransferencia ConvertEntity(DtoTransferencia dto, Transferencia entity)
        {
            dto = base.DefaultEntityConvert(entity, dto);

            dto.PlayerId = entity.PlayerId;

            dto.NewTeamId = entity.NewTeamId;

            dto.OldTeamId = entity.OldTeamId;

            dto.TransferDate = entity.TransferDate;

            dto.TransferFee = entity.TransferFee;

            dto.PaymentType = (int)entity.PaymentType;

            return dto;
        }
    }
}
