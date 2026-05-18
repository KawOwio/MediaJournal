using AutoMapper;
using MediaJournal.Api.Dtos.GameGenres;
using MediaJournal.Api.Models;
using MediaJournal.Api.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MediaJournal.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameGenresController(IGameGenreRepository gameGenreRepository, IMapper mapper) : ControllerBase
    {
        private readonly IGameGenreRepository gameGenreRepository = gameGenreRepository;
        private readonly IMapper mapper = mapper;

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddGameGenreDto addGameGenreDto)
        {
            GameGenre gameGenreDomain = mapper.Map<GameGenre>(addGameGenreDto);

            gameGenreDomain = await gameGenreRepository.CreateAsync(gameGenreDomain);

            GameGenreDto gameGenreDto = mapper.Map<GameGenreDto>(gameGenreDomain);

            return CreatedAtAction(nameof(GetById), new { id = gameGenreDto.Id }, gameGenreDto);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            List<GameGenre> gameGenreDomains = await gameGenreRepository.GetAllAsync();

            return Ok(mapper.Map<List<GameGenreDto>>(gameGenreDomains));
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            GameGenre? gameGenreDomain = await gameGenreRepository.GetByIdAsync(id);

            if (gameGenreDomain == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<GameGenreDto>(gameGenreDomain));
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateGameGenreDto updateGameGenreDto)
        {
            GameGenre? gameGenreDomain = await gameGenreRepository.UpdateAsync(id, mapper.Map<GameGenre>(updateGameGenreDto));

            if (gameGenreDomain == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<GameGenreDto>(gameGenreDomain));
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            GameGenre? gameGenreDomain = await gameGenreRepository.DeleteAsync(id);

            if (gameGenreDomain == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
