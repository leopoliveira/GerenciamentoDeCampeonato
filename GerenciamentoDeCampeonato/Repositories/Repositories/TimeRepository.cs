using GerenciamentoDeCampeonato.Contexts;
using GerenciamentoDeCampeonato.Models.Entities;
using GerenciamentoDeCampeonato.Repositories.Interfaces;

namespace GerenciamentoDeCampeonato.Repositories.Repositories
{
    public class TimeRepository : DefaultRepository<Time>, ITimeRepository
    {
        public TimeRepository(Context context) : base(context)
        {
        }
    }
}
