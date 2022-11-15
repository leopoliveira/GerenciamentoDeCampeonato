using GerenciamentoDeCampeonato.Mapping.PartidaEntity;
using GerenciamentoDeCampeonato.Models.DTOs;
using GerenciamentoDeCampeonato.Models.Entities;
using GerenciamentoDeCampeonato.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GerenciamentoDeCampeonato.Controllers
{
    public class PartidaController : DefaultController
    {
        private readonly IPartidaRepository _repository;
        private readonly ITimeRepository _timeRepository;
        private readonly ITimeTorneioRepository _timeTorneioRepository;
        private readonly ITorneioRepository _torneioRepository;

        public PartidaController(IPartidaRepository repository, ITimeRepository timeRepository, ITimeTorneioRepository timeTorneioRepository, ITorneioRepository torneioRepository)
        {
            _repository = repository;
            _timeRepository = timeRepository;
            _timeTorneioRepository = timeTorneioRepository;
            _torneioRepository = torneioRepository;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> GetPartida(int id = 0)
        {
            if(id > 0)
            {
                Partida partida = await _repository.GetByIdAsync(id);

                if(partida != null)
                {
                    PartidaEntityToDto converter = new PartidaEntityToDto();

                    DtoPartida dto = new DtoPartida();

                    /*dto.Tournament = $"https://localhost:7249/api/Torneio/{partida.TournamentId}";
                    dto.AwayTeam = $"https://localhost:7249/api/Time/{partida.AwayTeamId}";
                    dto.HomeTeam = $"https://localhost:7249/api/Time/{partida.HomeTeamId}";
                    dto.WinnerTeam = $"https://localhost:7249/api/Time/{partida.WinnerTeamId}";
                    dto.Tournament = $"https://localhost:7249/api/Torneio/{partida.TournamentId}";*/

                    dto.Tournament = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}{HttpContext.Request.PathBase}/api/Time/{partida.TournamentId}";
                    dto.AwayTeam = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}{HttpContext.Request.PathBase}/api/Time/{partida.AwayTeamId}";
                    dto.HomeTeam = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}{HttpContext.Request.PathBase}/api/Time/{partida.HomeTeamId}";
                    dto.WinnerTeam = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}{HttpContext.Request.PathBase}/api/Time/{partida.WinnerTeamId}";
                    dto.Tournament = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}{HttpContext.Request.PathBase}/api/Time/{partida.TournamentId}";
                    dto = converter.ConvertEntity(partida, dto);

                    return Ok(dto);
                }

                return NotFound();
            }
            
            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult> PostPartida(DtoPartida dto)
        {
            Time homeTeam = await _timeRepository.GetByIdAsync(dto.HomeTeamId);
            Time awayTeam = await _timeRepository.GetByIdAsync(dto.AwayTeamId);
            Torneio tourneament = await _torneioRepository.GetByIdAsync(dto.TournamentId);

            string validacoes = ValidacoesPartida(dto, homeTeam, awayTeam, tourneament);

            if (validacoes != null)
            {
                return Content(validacoes);
            }

            PartidaDtoToEntity converter = new PartidaDtoToEntity();
            Partida partida = new Partida();

            partida = converter.ConvertDto(dto, partida);

            TimeTorneio timeTorneioHome = new TimeTorneio
            {
                TournamentId = partida.TournamentId,
                TeamId  = partida.HomeTeamId
            };
            int result1 = await _timeTorneioRepository.CreateOrEditAsync(timeTorneioHome);

            TimeTorneio timeTorneioAway = new TimeTorneio
            {
                TournamentId = partida.TournamentId,
                TeamId = partida.AwayTeamId
            };
            int result2 = await _timeTorneioRepository.CreateOrEditAsync(timeTorneioAway);

            if (result1 > 0 && result2 > 0)
            {
                if (await _repository.CreateOrEditAsync(partida) > 0)
                {
                    return CreatedAtAction(nameof(GetPartida), new { id = partida.Id }, dto);
                }
            }

            return NoContent();
        }

        private static string ValidacoesPartida(DtoPartida dto, Time homeTeam, Time awayTeam, Torneio tourneament)
        {
            if(homeTeam == null || awayTeam == null)
            {
                return "Os times da partida devem existir na base de dados: https://localhost:7249/api/Time/0";
            }

            if (tourneament == null)
            {
                return "Uma partida deve pertencer a um torneio cadastrado na base de dados: https://localhost:7249/api/Torneio/0\"";
            }

            if (dto.AwayTeamId == 0 || dto.HomeTeamId == 0)
            {
                return "Uma partida deve ter dois times";
            }

            if (dto.AwayTeamId == dto.HomeTeamId)
            {
                return "Time iguais";
            }

            if(dto.WinnerTeamId != dto.AwayTeamId && dto.WinnerTeamId != dto.HomeTeamId && dto.WinnerTeamId != 0)
            {
                return "A partida tem que terminar empatada ou com um vencedor";
            }

            return null;
        }
    }
}
