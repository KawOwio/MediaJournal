using System.ComponentModel.DataAnnotations;

namespace MediaJournal.Api.Dtos.Games;

public record GameDto(
    int Id,
    string Name,
    int GenreId,
    string Platform,
    decimal Score,
    DateOnly CompletionDate
);
