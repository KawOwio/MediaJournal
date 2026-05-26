using MediaJournal.Api.Dtos.GameGenres;

namespace MediaJournal.Api.Dtos.Games;

public record GameDto(
    int Id,
    string Name,
    GameGenreDto Genre,
    string Platform,
    decimal Score,
    DateOnly CompletionDate
);
