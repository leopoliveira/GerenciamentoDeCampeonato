using GerenciamentoDeCampeonato.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentoDeCampeonato.Contexts
{
    public class Context : DbContext
    {

        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        public DbSet<Jogador> PLAYERS { get; set; }

        public DbSet<Time> TEAM { get; set; }

        public DbSet<Transferencia> TRANSFER { get; set; }

        public DbSet<Torneio> TOURNAMENT { get; set; }

        public DbSet<Partida> MATCH { get; set; }

        public DbSet<TimeTorneio> TEAMTOURNAMENT { get; set; }

        public DbSet<Evento> EVENTO { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TimeTorneio>()
                .HasKey(key => new { key.TournamentId, key.TeamId });
        }
    }
}
