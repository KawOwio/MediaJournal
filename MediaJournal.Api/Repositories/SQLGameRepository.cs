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

    public async Task<List<Game>> GetAllAsync()
    {
        return await dbContext.Games.ToListAsync();
    }

    public async Task<Game?> GetByIdAsync(int id)
    {
        return await dbContext.Games.FirstOrDefaultAsync(g => g.Id == id);
    }

    public async Task<Game?> UpdateAsync(int id, Game game)
    {
        Game? gameDomain = await GetByIdAsync(id);

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
        Game? gameDomain = await GetByIdAsync(id);

        if (gameDomain == null)
        {
            return null;
        }

        dbContext.Games.Remove(gameDomain);
        await dbContext.SaveChangesAsync();

        return gameDomain;
    }
}
