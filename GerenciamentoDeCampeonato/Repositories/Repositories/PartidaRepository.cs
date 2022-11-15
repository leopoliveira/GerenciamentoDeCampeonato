using GerenciamentoDeCampeonato.Contexts;
using GerenciamentoDeCampeonato.Models.Entities;
using GerenciamentoDeCampeonato.Repositories.Interfaces;

namespace GerenciamentoDeCampeonato.Repositories.Repositories
{
    public class PartidaRepository : DefaultRepository<Partida>, IPartidaRepository
    {
        public PartidaRepository(Context context) : base(context)
        {
        }
    }
}
