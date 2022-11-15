using GerenciamentoDeCampeonato.Enumerators;
using GerenciamentoDeCampeonato.Mapping.EventoEntity;
using GerenciamentoDeCampeonato.Models.DTOs;
using GerenciamentoDeCampeonato.Models.Entities;
using GerenciamentoDeCampeonato.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GerenciamentoDeCampeonato.Controllers
{
    public class EventoController : DefaultController
    {
        private readonly IEventoRepository _repository;
        private readonly ITorneioRepository _torneioRepository;
        private readonly IPartidaRepository _partidaRepository;

        public EventoController(IEventoRepository repository, ITorneioRepository torneioRepository, IPartidaRepository partidaRepository)
        {
            _repository = repository;
            _torneioRepository = torneioRepository;
            _partidaRepository = partidaRepository;
        }

        [HttpGet("~/api/Torneio/{torneioId:int}/Partida/{partidaId:int}/[controller]/{id:int}")]
        public async Task<ActionResult> GetEvento(int torneioId = 0, int partidaId = 0, int id = 0)
        {
            if(torneioId == 0 || partidaId == 0 || id == 0)
            {
                return NotFound();
            }

            Torneio torneio = await _torneioRepository.GetByIdAsync(torneioId);
            Partida partida = await _partidaRepository.GetByIdAsync(partidaId);

            if(torneio != null && partida != null)
            {
                
                Evento evento = await _repository.GetByIdAsync(id);

                if(evento != null)
                {
                    EventoEntityToDto converter = new EventoEntityToDto();
                    DtoEvento dto = new DtoEvento();

                    dto.Match = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}{HttpContext.Request.PathBase}/api/Partida/{evento.MatchId}";
                    dto.Tournament = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}{HttpContext.Request.PathBase}/api/Torneio/{evento.Match.TournamentId}";

                    dto = converter.ConvertEntity(evento, dto);

                    return Ok(dto);
                }
            }

            return NotFound();

        }


        #region "POST"
        [HttpPost("~/api/Torneio/{torneioId:int}/Partida/{partidaId}/[controller]/Inicio")]
        public async Task<ActionResult> PostInicio(DtoEvento dto, int torneioId = 0, int partidaId = 0)
        {
            if(torneioId == 0 || partidaId == 0)
            {
                return Content("Partida e Torneio devem estar cadastrados na base de dados");
            }

            Evento evento = new Evento();
            Torneio torneio = await _torneioRepository.GetByIdAsync(torneioId);
            Partida partida = await _partidaRepository.GetByIdAsync(partidaId);

            EventoDtoToEntity converter = new EventoDtoToEntity();

            if(torneio != null && partida != null)
            {
                evento.EventType = EventType.INICIO;
                evento = converter.ConvertDto(dto, evento);

                if(await _repository.CreateOrEditAsync(evento) > 0)
                {
                    return Ok(dto);
                }
            }

            return NoContent();

        }

        [HttpPost("~/api/Torneio/{torneioId:int}/Partida/{partidaId}/[controller]/Gol")]
        public async Task<ActionResult> PostGol(DtoEvento dto, int torneioId = 0, int partidaId = 0)
        {
            if (torneioId == 0 || partidaId == 0)
            {
                return Content("Partida e Torneio devem estar cadastrados na base de dados");
            }

            Evento evento = new Evento();
            Torneio torneio = await _torneioRepository.GetByIdAsync(torneioId);
            Partida partida = await _partidaRepository.GetByIdAsync(partidaId);

            EventoDtoToEntity converter = new EventoDtoToEntity();

            if (torneio != null && partida != null)
            {
                evento.EventType = EventType.GOL;
                evento = converter.ConvertDto(dto, evento);

                if (await _repository.CreateOrEditAsync(evento) > 0)
                {
                    return Ok(evento);
                }
            }

            return NoContent();

        }

        [HttpPost("~/api/Torneio/{torneioId:int}/Partida/{partidaId}/[controller]/Intervalo")]
        public async Task<ActionResult> PostIntervalo(DtoEvento dto, int torneioId = 0, int partidaId = 0)
        {
            if (torneioId == 0 || partidaId == 0)
            {
                return Content("Partida e Torneio devem estar cadastrados na base de dados");
            }

            Evento evento = new Evento();
            Torneio torneio = await _torneioRepository.GetByIdAsync(torneioId);
            Partida partida = await _partidaRepository.GetByIdAsync(partidaId);

            EventoDtoToEntity converter = new EventoDtoToEntity();

            if (torneio != null && partida != null)
            {
                evento.EventType = EventType.INTERVALO;
                evento = converter.ConvertDto(dto, evento);

                if (await _repository.CreateOrEditAsync(evento) > 0)
                {
                    return Ok(evento);
                }
            }

            return NoContent();

        }

        [HttpPost("~/api/Torneio/{torneioId:int}/Partida/{partidaId}/[controller]/Acrescimo")]
        public async Task<ActionResult> PostAcrescimo(DtoEvento dto, int torneioId = 0, int partidaId = 0)
        {
            if (torneioId == 0 || partidaId == 0)
            {
                return Content("Partida e Torneio devem estar cadastrados na base de dados");
            }

            Evento evento = new Evento();
            Torneio torneio = await _torneioRepository.GetByIdAsync(torneioId);
            Partida partida = await _partidaRepository.GetByIdAsync(partidaId);

            EventoDtoToEntity converter = new EventoDtoToEntity();

            if (torneio != null && partida != null)
            {
                evento.EventType = EventType.ACRESCIMO;
                evento = converter.ConvertDto(dto, evento);

                if (await _repository.CreateOrEditAsync(evento) > 0)
                {
                    return Ok(evento);
                }
            }

            return NoContent();

        }

        [HttpPost("~/api/Torneio/{torneioId:int}/Partida/{partidaId}/[controller]/Substituicao")]
        public async Task<ActionResult> PostSubstituicao(DtoEvento dto, int torneioId = 0, int partidaId = 0)
        {
            if (torneioId == 0 || partidaId == 0)
            {
                return Content("Partida e Torneio devem estar cadastrados na base de dados");
            }

            Evento evento = new Evento();
            Torneio torneio = await _torneioRepository.GetByIdAsync(torneioId);
            Partida partida = await _partidaRepository.GetByIdAsync(partidaId);

            EventoDtoToEntity converter = new EventoDtoToEntity();

            if (torneio != null && partida != null)
            {
                evento.EventType = EventType.SUBSTITUICAO;
                evento = converter.ConvertDto(dto, evento);

                if (await _repository.CreateOrEditAsync(evento) > 0)
                {
                    return Ok(evento);
                }
            }

            return NoContent();

        }

        [HttpPost("~/api/Torneio/{torneioId:int}/Partida/{partidaId}/[controller]/CartaoAmarelo")]
        public async Task<ActionResult> PostCartaoAmarelo(DtoEvento dto, int torneioId = 0, int partidaId = 0)
        {
            if (torneioId == 0 || partidaId == 0)
            {
                return Content("Partida e Torneio devem estar cadastrados na base de dados");
            }

            Evento evento = new Evento();
            Torneio torneio = await _torneioRepository.GetByIdAsync(torneioId);
            Partida partida = await _partidaRepository.GetByIdAsync(partidaId);

            EventoDtoToEntity converter = new EventoDtoToEntity();

            if (torneio != null && partida != null)
            {
                evento.EventType = EventType.CARTAO_AMARELO;
                evento = converter.ConvertDto(dto, evento);

                if (await _repository.CreateOrEditAsync(evento) > 0)
                {
                    return Ok(evento);
                }
            }

            return NoContent();

        }

        [HttpPost("~/api/Torneio/{torneioId:int}/Partida/{partidaId}/[controller]/CartaoVermelho")]
        public async Task<ActionResult> PostCartaoVermelho(DtoEvento dto, int torneioId = 0, int partidaId = 0)
        {
            if (torneioId == 0 || partidaId == 0)
            {
                return Content("Partida e Torneio devem estar cadastrados na base de dados");
            }

            Evento evento = new Evento();
            Torneio torneio = await _torneioRepository.GetByIdAsync(torneioId);
            Partida partida = await _partidaRepository.GetByIdAsync(partidaId);

            EventoDtoToEntity converter = new EventoDtoToEntity();

            if (torneio != null && partida != null)
            {
                evento.EventType = EventType.CARTAO_VERMELHO;
                evento = converter.ConvertDto(dto, evento);

                if (await _repository.CreateOrEditAsync(evento) > 0)
                {
                    return Ok(evento);
                }
            }

            return NoContent();

        }

        [HttpPost("~/api/Torneio/{torneioId:int}/Partida/{partidaId}/[controller]/Var")]
        public async Task<ActionResult> PostVar(DtoEvento dto, int torneioId = 0, int partidaId = 0)
        {
            if (torneioId == 0 || partidaId == 0)
            {
                return Content("Partida e Torneio devem estar cadastrados na base de dados");
            }

            Evento evento = new Evento();
            Torneio torneio = await _torneioRepository.GetByIdAsync(torneioId);
            Partida partida = await _partidaRepository.GetByIdAsync(partidaId);

            EventoDtoToEntity converter = new EventoDtoToEntity();

            if (torneio != null && partida != null)
            {
                evento.EventType = EventType.VAR;
                evento = converter.ConvertDto(dto, evento);

                if (await _repository.CreateOrEditAsync(evento) > 0)
                {
                    return Ok(evento);
                }
            }

            return NoContent();

        }
        #endregion
    }
}
