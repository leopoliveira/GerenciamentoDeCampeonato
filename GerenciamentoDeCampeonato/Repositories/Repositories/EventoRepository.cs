using GerenciamentoDeCampeonato.Contexts;
using GerenciamentoDeCampeonato.Models.Entities;
using GerenciamentoDeCampeonato.Repositories.Interfaces;

namespace GerenciamentoDeCampeonato.Repositories.Repositories
{
    public class EventoRepository : DefaultRepository<Evento>, IEventoRepository
    {
        public EventoRepository(Context context) : base(context)
        {
        }
    }
}
