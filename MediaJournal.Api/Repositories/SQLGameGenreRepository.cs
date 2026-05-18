using MediaJournal.Api.Data;
using MediaJournal.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace MediaJournal.Api.Repositories;

public class SQLGameGenreRepository : IGameGenreRepository
{
    private readonly MediaDbContext dbContext;

    public SQLGameGenreRepository(MediaDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<GameGenre> CreateAsync(GameGenre genre)
    {
         await dbContext.GameGenres.AddAsync(genre);
         await dbContext.SaveChangesAsync();
         return genre;
    }

    public async Task<List<GameGenre>> GetAllAsync()
    {
        return await dbContext.GameGenres.ToListAsync();
    }

    public async Task<GameGenre?> GetByIdAsync(int id)
    {
        return await dbContext.GameGenres.FirstOrDefaultAsync(g => g.Id == id);
    }

    public async Task<GameGenre?> UpdateAsync(int id, GameGenre genre)
    {
        GameGenre? genreDomain = GetByIdAsync(id).Result;

        if (genreDomain == null)
        {
            return null;
        }

        genreDomain.Name = genre.Name;

        await dbContext.SaveChangesAsync();

        return genre;
    }

    public async Task<GameGenre?> DeleteAsync(int id)
    {
        GameGenre? genreDomain = GetByIdAsync(id).Result;

        if (genreDomain == null)
        {
            return null;
        }

        dbContext.GameGenres.Remove(genreDomain);
        await dbContext.SaveChangesAsync();

        return genreDomain;
    }
}
