using GerenciamentoDeCampeonato.Mapping.TransferenciaEntity;
using GerenciamentoDeCampeonato.Models.DTOs;
using GerenciamentoDeCampeonato.Models.Entities;
using GerenciamentoDeCampeonato.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GerenciamentoDeCampeonato.Controllers
{
    public class TransferenciaController : DefaultController
    {
        private readonly ITransferenciaRepository _repository;
        private readonly ITimeRepository _timeRepository;
        private readonly IJogadorRepository _jogadorRepository;

        public TransferenciaController(ITransferenciaRepository repository, ITimeRepository timeRepository, IJogadorRepository jogadorRepository)
        {
            _repository = repository;
            _timeRepository = timeRepository;
            _jogadorRepository = jogadorRepository;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> GetTransferencia(int id = 0)
        {
            TransferenciaEntityToDto converter = new TransferenciaEntityToDto();            

            if(id > 0)
            {
                Transferencia transferencia = await _repository.GetByIdAsync(id);

                if(transferencia != null)
                {
                    DtoTransferencia dto = new DtoTransferencia();

                    /*dto.Player = $"https://localhost:7249/api/Jogador/{transferencia.PlayerId}";
                    dto.NewTeam = $"https://localhost:7249/api/Time/{transferencia.NewTeamId}";
                    dto.OldTeam = $"https://localhost:7249/api/Time/{transferencia.OldTeamId}";*/

                    dto.Player = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}{HttpContext.Request.PathBase}/api/Jogador/{transferencia.PlayerId}";
                    dto.NewTeam = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}{HttpContext.Request.PathBase}/api/Time/{transferencia.NewTeamId}";
                    dto.OldTeam = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}{HttpContext.Request.PathBase}/api/Time/{transferencia.OldTeamId}";
                    dto = converter.ConvertEntity(dto, transferencia);

                    return Ok(dto);
                }
                else
                {
                    return NotFound();
                }
                
            }
            else
            {
                List<Transferencia> transferenciaList = await _repository.GetAllAsync();
                
                if(transferenciaList != null)
                {
                    List<DtoTransferencia> dtoList = new List<DtoTransferencia>();

                    foreach(Transferencia transferencia in transferenciaList)
                    {
                        DtoTransferencia dto = new DtoTransferencia();

                        /*dto.Player = $"https://localhost:7249/api/Jogador/{transferencia.PlayerId}";
                        dto.NewTeam = $"https://localhost:7249/api/Time/{transferencia.NewTeamId}";
                        dto.OldTeam = $"https://localhost:7249/api/Time/{transferencia.OldTeamId}";*/

                        dto.Player = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}{HttpContext.Request.PathBase}/api/Jogador/{transferencia.PlayerId}";
                        dto.NewTeam = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}{HttpContext.Request.PathBase}/api/Time/{transferencia.NewTeamId}";
                        dto.OldTeam = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}{HttpContext.Request.PathBase}/api/Time/{transferencia.OldTeamId}";
                        dtoList.Add(converter.ConvertEntity(dto, transferencia));
                    }

                    return Ok(dtoList);
                }
                else
                {
                    return NotFound();
                }
            }
        }

        [HttpGet("~/api/[controller]/Time/{teamId:int}")]
        public async Task<ActionResult> GetTransferenciaTime(int teamId = 1)
        {
            Time time = await _timeRepository.GetByIdAsync(teamId);
            
            if(time != null)
            {
                List<Transferencia> transferenciaList = await _repository.GetAllTeamTransfersByIdAsync(teamId);
                List<DtoTransferencia> dtoList = new List<DtoTransferencia>();

                TransferenciaEntityToDto converter = new TransferenciaEntityToDto();

                foreach(Transferencia transferencia in transferenciaList)
                {
                    DtoTransferencia dto = new DtoTransferencia();

                    /*dto.Player = $"https://localhost:7249/api/Jogador/{transferencia.PlayerId}";
                    dto.NewTeam = $"https://localhost:7249/api/Time/{transferencia.NewTeamId}";
                    dto.OldTeam = $"https://localhost:7249/api/Time/{transferencia.OldTeamId}";*/

                    dto.Player = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}{HttpContext.Request.PathBase}/api/Time/{transferencia.PlayerId}";
                    dto.NewTeam = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}{HttpContext.Request.PathBase}/api/Time/{transferencia.NewTeamId}";
                    dto.OldTeam = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}{HttpContext.Request.PathBase}/api/Time/{transferencia.OldTeamId}";
                    dtoList.Add(converter.ConvertEntity(dto, transferencia));
                }

                return Ok(dtoList);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<ActionResult> PostTransferencia(DtoTransferencia dto)
        {
            Time newTeam = await _timeRepository.GetByIdAsync(dto.NewTeamId);
            Time oldTeam = await _timeRepository.GetByIdAsync(dto.OldTeamId);
            Jogador player = await _jogadorRepository.GetByIdAsync(dto.PlayerId);

            if(newTeam != null && oldTeam != null && player != null)
            {
                TransferenciaDtoToEntity converter = new TransferenciaDtoToEntity();
                Transferencia transferencia = new Transferencia();

                transferencia = converter.ConvertDto(dto, transferencia);

                if(await _repository.CreateOrEditAsync(transferencia) > 0)
                {
                    return CreatedAtAction(nameof(GetTransferencia), new { id = transferencia.Id }, dto);
                }

                return NotFound();

            }
            else
            {
                return NoContent();
            }
        }
    }
}
