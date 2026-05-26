using MediaJournal.Api.Models;

namespace MediaJournal.Api.Repositories;

public interface IGameRepository
{
    Task<Game> CreateAsync(Game game);
    Task<List<Game>> GetAllAsync(string? filterName = null, string? filterGenre = null, 
        string? filterPlatform = null, decimal? minScore = null, string? sortBy = null, bool isAscending = true, 
        int pageNumber = 1, int pageSize = 5);
    Task<Game?> GetByIdAsync(int id);
    Task<Game?> UpdateAsync(int id, Game game);
    Task<Game?> DeleteAsync(int id);
}
