using System.ComponentModel.DataAnnotations;

namespace MediaJournal.Api.Dtos.GameGenres;

public record  AddGameGenreDto(
    [Length(3, 20, ErrorMessage = "Genre has to be 3-20 characters long")]
    string Name
);
