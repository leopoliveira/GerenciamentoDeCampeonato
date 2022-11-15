using GerenciamentoDeCampeonato.Models.Entities;

namespace GerenciamentoDeCampeonato.Repositories.Interfaces
{
    public interface ITransferenciaRepository : IDefaultRepository<Transferencia>
    {
        public Task<List<Transferencia>> GetAllTeamTransfersByIdAsync(int teamId);
    }
}
