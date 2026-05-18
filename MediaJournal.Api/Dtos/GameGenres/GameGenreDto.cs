using System.ComponentModel.DataAnnotations;

namespace MediaJournal.Api.Dtos.GameGenres;

public record GameGenreDto(
    int Id,
    string Name
);
