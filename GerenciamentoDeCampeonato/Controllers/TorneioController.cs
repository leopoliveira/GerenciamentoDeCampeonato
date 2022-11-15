using GerenciamentoDeCampeonato.Mapping.TorneioEntity;
using GerenciamentoDeCampeonato.Models.DTOs;
using GerenciamentoDeCampeonato.Models.Entities;
using GerenciamentoDeCampeonato.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;

namespace GerenciamentoDeCampeonato.Controllers
{
    public class TorneioController : DefaultController
    {
        private readonly ITorneioRepository _repository;
        private readonly IJogadorRepository _jogadorRepository;
        private readonly ITimeRepository _timeRepository;

        public TorneioController(ITorneioRepository repository, IJogadorRepository jogadorRepository, ITimeRepository timeRepository)
        {
            _repository = repository;
            _jogadorRepository = jogadorRepository;
            _timeRepository = timeRepository;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<DtoTorneio>> GetTorneio(int id = 0)
        {
            TorneioEntityToDto converter = new TorneioEntityToDto();

            if (id > 0)
            {
                DtoTorneio dto = new DtoTorneio();
                Torneio torneio = await _repository.GetByIdAsync(id);

                if(torneio != null)
                {
                    /*dto.Champion = $"https://localhost:7249/api/Time/{torneio.ChampionId}";
                    dto.BestPlayer = $"https://localhost:7249/api/Jogador/{torneio.BestPlayerId}";
                    dto.GoldenBoot = $"https://localhost:7249/api/Jogador/{torneio.GolderBootId}";*/

                    dto.Champion = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}{HttpContext.Request.PathBase}/api/Time/{torneio.ChampionId}";
                    dto.BestPlayer = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}{HttpContext.Request.PathBase}/api/Jogador/{torneio.BestPlayerId}";
                    dto.GoldenBoot = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}{HttpContext.Request.PathBase}/api/Jogador/{torneio.GolderBootId}";
                    dto = converter.ConvertEntity(torneio, dto);

                    return Ok(dto);
                }
                else
                {
                    return NotFound();
                }
            }
            else
            {
                List<Torneio> torneioList = await _repository.GetAllAsync();

                if(torneioList != null)
                {
                    List<DtoTorneio> dtoList = new List<DtoTorneio>();

                    foreach(Torneio torneio in torneioList)
                    {
                        DtoTorneio dto = new DtoTorneio();

                        /*dto.Champion = $"https://localhost:7249/api/Time/{torneio.ChampionId}";
                        dto.BestPlayer = $"https://localhost:7249/api/Jogador/{torneio.BestPlayerId}";
                        dto.GoldenBoot = $"https://localhost:7249/api/Jogador/{torneio.GolderBootId}";*/

                        dto.Champion = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}{HttpContext.Request.PathBase}/api/Time/{torneio.ChampionId}";
                        dto.BestPlayer = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}{HttpContext.Request.PathBase}/api/Jogador/{torneio.BestPlayerId}";
                        dto.GoldenBoot = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}{HttpContext.Request.PathBase}/api/Jogador/{torneio.GolderBootId}";
                        dtoList.Add(converter.ConvertEntity(torneio, dto));
                    }

                    return Ok(dtoList);
                }
                else
                {
                    return NoContent();
                }
            }
        }

        [HttpPost]
        public async Task<ActionResult> PostTorneio(DtoTorneio dto)
        {
            Time champion = new Time();
            Jogador goldenBoot = new Jogador();
            Jogador bestPlayer = new Jogador();
            Torneio torneio = new Torneio();
            TorneioDtoToEntity converter = new TorneioDtoToEntity();


            if(dto.ChampionId.HasValue && dto.ChampionId.Value > 0)
            {
                champion = await _timeRepository.GetByIdAsync(dto.ChampionId.Value);
            }

            dto.ChampionId = champion != null ? dto.ChampionId : 0;

            if (dto.BestPlayerId.HasValue && dto.BestPlayerId.Value > 0)
            {
                bestPlayer = await _jogadorRepository.GetByIdAsync(dto.BestPlayerId.Value);
            }

            dto.BestPlayerId = bestPlayer != null ? dto.BestPlayerId : 0;

            if (dto.GolderBootId.HasValue && dto.GolderBootId.Value > 0)
            {
                goldenBoot = await _jogadorRepository.GetByIdAsync(dto.GolderBootId.Value);
            }

            dto.GolderBootId = goldenBoot != null ? dto.GolderBootId : 0;

            torneio = converter.ConvertDto(dto, torneio);
            
            if(await _repository.CreateOrEditAsync(torneio) > 0)
            {
                return CreatedAtAction(nameof(GetTorneio), new { id = torneio.Id }, dto);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
