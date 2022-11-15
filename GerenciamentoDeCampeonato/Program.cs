using GerenciamentoDeCampeonato.Contexts;
using GerenciamentoDeCampeonato.Repositories.Interfaces;
using GerenciamentoDeCampeonato.Repositories.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentoDeCampeonato
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            #region "Database Dependency Injection"
            // Get DataBase Connection String
            string _DataBaseConnectionString = builder.Configuration.GetConnectionString("DevConnString");

            // Dependency Injection
            builder.Services.AddDbContext<Context>(
                options => options.UseSqlServer(_DataBaseConnectionString)
            );
            #endregion

            #region "Repositories Dependency Injection"
            //Serviços de Injeção de Dependência dos Repositories
            //Scoped para manter a instância do Objeto durante toda a requisição, ou request.
            //Poderia ser Singleton, caso eu fosse manter a instância por toda a vida útil da aplicação.
            //Ou Transient, onde eu crio a instância a cada solicitação do serviço.
            builder.Services
                .AddTransient<IJogadorRepository, JogadorRepository>();

            builder.Services
                .AddTransient<IPartidaRepository, PartidaRepository>();

            builder.Services
                .AddTransient<ITimeRepository, TimeRepository>();

            builder.Services
                .AddTransient<ITimeTorneioRepository, TimeTorneioRepository>();

            builder.Services
                .AddTransient<ITorneioRepository, TorneioRepository>();

            builder.Services
                .AddTransient<ITransferenciaRepository, TransferenciaRepository>();

            builder.Services
                .AddTransient<IEventoRepository, EventoRepository>();
            #endregion

            // Enable Swagger Annotations
            builder.Services.AddSwaggerGen(options => options.EnableAnnotations());

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}