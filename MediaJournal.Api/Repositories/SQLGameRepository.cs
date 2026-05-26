using MediaJournal.Api.Data;
using MediaJournal.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace MediaJournal.Api.Repositories;

public class SQLGameRepository(MediaDbContext dbContext) : IGameRepository
{
    private readonly MediaDbContext dbContext = dbContext;

    public async Task<Game> CreateAsync(Game game)
    {
        await dbContext.Games.AddAsync(game);
        await dbContext.SaveChangesAsync();
        return game;
    }

    public async Task<List<Game>> GetAllAsync(string? filterName = null, string? filterGenre = null, 
        string? filterPlatform = null, decimal? minScore = null, string? sortBy = null, bool isAscending = true, 
        int pageNumber = 1, int pageSize = 5)
    {
        IQueryable<Game> query = dbContext.Games
            .Include(g => g.Genre)
            .AsQueryable();

        // Filtering
        if (!string.IsNullOrEmpty(filterName))
        {
            query = query.Where(x => x.Name.Contains(filterName));
        }

        if (!string.IsNullOrEmpty(filterGenre))
        {
            query = query.Where(x => x.Genre != null && x.Genre.Name.Contains(filterGenre));
        }

        if (!string.IsNullOrEmpty(filterPlatform))
        {
            query = query.Where(x => x.Platform != null && x.Platform.Contains(filterPlatform));
        }

        if (minScore.HasValue)
        {
            query = query.Where(x => x.Score >= minScore);
        }

        // Sorting
        if (!string.IsNullOrEmpty(sortBy))
        {
            if (sortBy.Equals("Name", StringComparison.OrdinalIgnoreCase))
            {
                query = isAscending ? query.OrderBy(x => x.Name) : query.OrderByDescending(x => x.Name);
            }
            else if (sortBy.Equals("Genre", StringComparison.OrdinalIgnoreCase))
            {
                query = isAscending ? query.OrderBy(x => x.Genre) : query.OrderByDescending(x => x.Genre);
            }
            else if (sortBy.Equals("Platform", StringComparison.OrdinalIgnoreCase))
            {
                query = isAscending ? query.OrderBy(x => x.Platform) : query.OrderByDescending(x => x.Platform);
            }
            else if (sortBy.Equals("Score", StringComparison.OrdinalIgnoreCase))
            {
                query = isAscending ? query.OrderBy(x => x.Score) : query.OrderByDescending(x => x.Score);
            }
        }

        // Pagination
        int skipResults = (pageNumber - 1) * pageSize;

        return await query.Skip(skipResults).Take(pageSize).ToListAsync();
    }

    public async Task<Game?> GetByIdAsync(int id)
    {
        return await dbContext.Games
            .Include(g => g.Genre)
            .FirstOrDefaultAsync(g => g.Id == id);
    }

    public async Task<Game?> UpdateAsync(int id, Game game)
    {
        Game? gameDomain = await dbContext.Games
            .Include(g => g.Genre)
            .FirstOrDefaultAsync(g => g.Id == id);

        if (gameDomain == null)
        {
            return null;
        }

        gameDomain.Name = game.Name;
        gameDomain.GenreId = game.GenreId;
        gameDomain.Platform = game.Platform;
        gameDomain.Score = game.Score;
        gameDomain.CompletionDate = game.CompletionDate;

        await dbContext.SaveChangesAsync();

        return gameDomain;
    }

    public async Task<Game?> DeleteAsync(int id)
    {
        Game? gameDomain = await dbContext.Games
            .Include(g => g.Genre)
            .FirstOrDefaultAsync(g => g.Id == id);

        if (gameDomain == null)
        {
            return null;
        }

        dbContext.Games.Remove(gameDomain);
        await dbContext.SaveChangesAsync();

        return gameDomain;
    }
}
