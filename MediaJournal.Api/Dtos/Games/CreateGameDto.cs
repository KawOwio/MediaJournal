using System.ComponentModel.DataAnnotations;

namespace MediaJournal.Api.Dtos.Games;

public record CreateGameDto(
    [Required][Length(1, 100, ErrorMessage = "Game name has to be 1-100 characters long")] 
    string Name,

    [Range(1, 100, ErrorMessage = "Genre ID has to be between 1 and 100")] 
    int GenreId,

    string Platform,

    [Range(0.1, 10.0, ErrorMessage = "Score has to be between 0.1 and 10.0")] 
    decimal Score,

    DateOnly CompletionDate
);
