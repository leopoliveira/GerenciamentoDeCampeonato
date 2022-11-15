using GerenciamentoDeCampeonato.Contexts;
using GerenciamentoDeCampeonato.Models.Entities;
using GerenciamentoDeCampeonato.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentoDeCampeonato.Repositories.Repositories
{
    public class TransferenciaRepository : DefaultRepository<Transferencia>, ITransferenciaRepository
    {
        private readonly Context _context;

        public TransferenciaRepository(Context context) : base(context)
        {
            _context = context;
        }

        public override async Task<List<Transferencia>> GetAllAsync()
        {
            return await _context.TRANSFER
                        .Take(20)
                        .ToListAsync();
        }

        public async Task<List<Transferencia>> GetAllTeamTransfersByIdAsync(int teamId)
        {
            return await _context.TRANSFER
                        .Where(t => t.NewTeamId == teamId || t.OldTeamId == teamId)
                        .ToListAsync();
        }
    }
}
