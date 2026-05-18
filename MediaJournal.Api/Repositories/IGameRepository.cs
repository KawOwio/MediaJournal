using MediaJournal.Api.Models;

namespace MediaJournal.Api.Repositories;

public interface IGameRepository
{
    Task<Game> CreateAsync(Game game);
    Task<List<Game>> GetAllAsync();
    Task<Game?> GetByIdAsync(int id);
    Task<Game?> UpdateAsync(int id, Game game);
    Task<Game?> DeleteAsync(int id);
}
