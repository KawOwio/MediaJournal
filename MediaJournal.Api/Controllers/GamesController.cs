using AutoMapper;
using MediaJournal.Api.Dtos.Games;
using MediaJournal.Api.Models;
using MediaJournal.Api.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace MediaJournal.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController(IGameRepository gameRepository, IMapper mapper) : ControllerBase
    {
        private readonly IGameRepository gameRepository = gameRepository;
        private readonly IMapper mapper = mapper;

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateGameDto createGameDto)
        {
            Game gameDomain = mapper.Map<Game>(createGameDto);

            gameDomain = await gameRepository.CreateAsync(gameDomain);

            GameDto gameDto = mapper.Map<GameDto>(gameDomain);

            return CreatedAtAction(nameof(GetById), new { id = gameDto.Id }, gameDto);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            List<Game> gameDomains = await gameRepository.GetAllAsync();

            return Ok(mapper.Map<List<GameDto>>(gameDomains));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            Game? gameDomain = await gameRepository.GetByIdAsync(id);

            if (gameDomain == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<GameDto>(gameDomain));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateGameDto updateGameDto)
        {
            Game? gameDomain = await gameRepository.UpdateAsync(id, mapper.Map<Game>(updateGameDto));

            if (gameDomain == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<GameDto>(gameDomain));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            Game? gameDomain = await gameRepository.DeleteAsync(id);

            if (gameDomain == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
