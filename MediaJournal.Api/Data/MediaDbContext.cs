using MediaJournal.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace MediaJournal.Api.Data;

public class MediaDbContext(DbContextOptions<MediaDbContext> options) : DbContext(options)
{
    public DbSet<Game> Games => Set<Game>();
    public DbSet<GameGenre> GameGenres => Set<GameGenre>();
}
