using GerenciamentoDeCampeonato.Contexts;
using GerenciamentoDeCampeonato.Models.Entities;
using GerenciamentoDeCampeonato.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentoDeCampeonato.Repositories.Repositories
{
    public class TimeTorneioRepository : DefaultRepository<TimeTorneio>, ITimeTorneioRepository 
    {
        private readonly Context _context;

        public TimeTorneioRepository(Context context) : base(context)
        {
        _context = context;
        }

        public override async Task<int> CreateOrEditAsync(TimeTorneio timeTorneio)
        {
            bool exists = _context.TEAMTOURNAMENT.Any(t =>
                        t.TeamId == timeTorneio.TeamId &&
                        t.TournamentId == timeTorneio.TournamentId);

            if (exists)
            {
                return 1;
            }
            else
            {
                _context.TEAMTOURNAMENT.Add(timeTorneio);

                return await _context.SaveChangesAsync();
            }
        }
    }
}
