using MediaJournal.Api.Models;

namespace MediaJournal.Api.Repositories;

public interface IGameGenreRepository
{
    Task<GameGenre> CreateAsync(GameGenre genre);
    Task<List<GameGenre>> GetAllAsync();
    Task<GameGenre?> GetByIdAsync(int id);
    Task<GameGenre?> UpdateAsync(int id, GameGenre genre);
    Task<GameGenre?> DeleteAsync(int id);
}
