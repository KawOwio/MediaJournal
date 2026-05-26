using AutoMapper;
using MediaJournal.Api.Dtos.Games;
using MediaJournal.Api.Dtos.GameGenres;
using MediaJournal.Api.Models;

namespace MediaJournal.Api.Mappings;

public class AutoMapperProfiles : Profile
{
    public AutoMapperProfiles()
    {
        CreateMap<GameGenre, GameGenreDto>().ReverseMap();
        CreateMap<GameGenre, CreateGameGenreDto>().ReverseMap();
        CreateMap<GameGenre, UpdateGameGenreDto>().ReverseMap();

        CreateMap<Game, GameDto>().ReverseMap();
        CreateMap<Game, CreateGameDto>().ReverseMap();
        CreateMap<Game, UpdateGameDto>().ReverseMap();
    }

}
