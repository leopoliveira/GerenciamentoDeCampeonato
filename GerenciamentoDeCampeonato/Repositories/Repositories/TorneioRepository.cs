using GerenciamentoDeCampeonato.Contexts;
using GerenciamentoDeCampeonato.Models.Entities;
using GerenciamentoDeCampeonato.Repositories.Interfaces;

namespace GerenciamentoDeCampeonato.Repositories.Repositories
{
    public class TorneioRepository : DefaultRepository<Torneio>, ITorneioRepository
    {
        public TorneioRepository(Context context) : base(context)
        {
        }
    }
}
