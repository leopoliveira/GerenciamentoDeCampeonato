using GerenciamentoDeCampeonato.Contexts;
using GerenciamentoDeCampeonato.Models.Entities;
using GerenciamentoDeCampeonato.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentoDeCampeonato.Repositories.Repositories
{
    public class JogadorRepository : DefaultRepository<Jogador>, IJogadorRepository
    {
        private readonly Context _context;
        public JogadorRepository(Context context) : base(context)
        {
            _context = context;
        }
    }
}
