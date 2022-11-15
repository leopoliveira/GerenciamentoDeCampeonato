using GerenciamentoDeCampeonato.Mapping.JogadorEntity;
using GerenciamentoDeCampeonato.Models.DTOs;
using GerenciamentoDeCampeonato.Models.Entities;
using GerenciamentoDeCampeonato.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GerenciamentoDeCampeonato.Controllers
{

    public class JogadorController : DefaultController
    {
        private readonly IJogadorRepository _repository;

        public JogadorController(IJogadorRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> GetJogador(int id = 0)
        {
            JogadorEntityToDto converter = new JogadorEntityToDto();

            if (id > 0)
            {
                Jogador jogador = await _repository.GetByIdAsync(id);

                if(jogador != null)
                {
                    DtoJogador dto = new DtoJogador();
                    //dto.Team = $"https://localhost:7249/api/Time/{jogador.TeamId}";

                    dto.Team = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}{HttpContext.Request.PathBase}/api/Time/{jogador.TeamId}";
                    dto = converter.ConvertEntity(jogador, dto);

                    return Ok(dto);
                }
                else
                {
                    return NotFound();
                }
            }
            else
            {
                List<Jogador> jogadorList = await _repository.GetAllAsync();

                if(jogadorList != null)
                {
                    List<DtoJogador> dtoList = new List<DtoJogador>();

                    foreach(Jogador jogador in jogadorList)
                    {
                        DtoJogador dto = new DtoJogador();
                        //dto.Team = $"https://localhost:7249/api/Time/{jogador.TeamId}";

                        dto.Team = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}{HttpContext.Request.PathBase}/api/Time/{jogador.TeamId}";
                        dtoList.Add(converter.ConvertEntity(jogador, dto));
                    }

                    return Ok(dtoList);
                }
                else
                {
                    return NotFound();
                }

            }
        }

        [HttpPost]
        public async Task<ActionResult> PostJogador(DtoJogador dto)
        {
            JogadorDtoToEntity converter = new JogadorDtoToEntity();

            Jogador jogador = new Jogador();

            jogador = converter.ConvertDto(dto, jogador);

            if(await _repository.CreateOrEditAsync(jogador) > 0)
            {
                return CreatedAtAction(nameof(GetJogador), new { id = jogador.Id }, dto);
            }

            return NotFound();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteJogador(int id)
        {
            if(id > 0)
            {
                Jogador jogador = await _repository.GetByIdAsync(id);

                var result = await _repository.DeleteByIdAsync(jogador);

                if(result > 0)
                {
                    return Ok();
                }
            }

            return NotFound();
        }

        [HttpHead("{id:int}")]
        public async Task<ActionResult> HeadJogador(int id)
        {
            if(id > 0)
            {
                Jogador jogador = await _repository.GetByIdAsync(id);

                if(jogador != null)
                {
                    return Ok();
                }
            }
            return NotFound();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> PutJogador(int id, DtoJogador dto)
        {
            dto.Id = id;
            Jogador jogador = await _repository.GetByIdAsync(id);

            if(jogador != null)
            {
                JogadorDtoToEntity converter = new JogadorDtoToEntity();

                jogador = converter.ConvertDto(dto, jogador);

                if (await _repository.CreateOrEditAsync(jogador) > 0)
                {
                    return Ok();
                }
            }

            return NotFound();
        }

        [HttpPatch("{id:int}")]
        public async Task<ActionResult> PatchJogador(int id, DtoJogador dto)
        {
            dto.Id = id;
            Jogador jogador = await _repository.GetByIdAsync(id);

            if (jogador != null)
            {
                JogadorDtoToEntity converter = new JogadorDtoToEntity();

                jogador = converter.ConvertDto(dto, jogador);

                if (await _repository.CreateOrEditAsync(jogador) > 0)
                {
                    return Ok();
                }
            }

            return NotFound();
        }
    }
}
