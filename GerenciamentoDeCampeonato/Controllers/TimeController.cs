using GerenciamentoDeCampeonato.Mapping.TimeEntity;
using GerenciamentoDeCampeonato.Models.DTOs;
using GerenciamentoDeCampeonato.Models.Entities;
using GerenciamentoDeCampeonato.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GerenciamentoDeCampeonato.Controllers
{
    public class TimeController : DefaultController
    {
        private readonly ITimeRepository _repository;

        public TimeController(ITimeRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> GetTime(int id = 0)
        {
            TimeEntityToDto converter = new TimeEntityToDto();         

            if(id > 0)
            {
                Time time = await _repository.GetByIdAsync(id);

                if(time != null)
                {
                    DtoTime dto = new DtoTime();

                    dto = converter.ConvertEntity(time, dto);

                    return Ok(dto);
                }
                else
                {
                    return NotFound();
                }
                
            }
            else
            {
                List<Time> timeList = await _repository.GetAllAsync();

                if(timeList != null)
                {
                    List<DtoTime> dtoList = new List<DtoTime>();

                    foreach (Time time in timeList)
                    {
                        DtoTime dto = new DtoTime();
                        dtoList.Add(converter.ConvertEntity(time, dto));
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
        public async Task<ActionResult> PostTime(DtoTime dto)
        {
            TimeDtoToEntity converter = new TimeDtoToEntity();
            Time time = new Time();

            time = converter.ConvertDto(dto, time);

            if(await _repository.CreateOrEditAsync(time) > 0)
            {
                return CreatedAtAction(nameof(GetTime), new { id = time.Id }, dto);
            }

            return NotFound();
        }
    }
}
