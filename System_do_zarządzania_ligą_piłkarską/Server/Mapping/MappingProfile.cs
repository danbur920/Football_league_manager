using AutoMapper;
using System_do_zarządzania_ligą_piłkarską.Server.Models;
using System_do_zarządzania_ligą_piłkarską.Shared.DTOs;

namespace System_do_zarządzania_ligą_piłkarską.Server.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<League, LeagueDTO>().ReverseMap();
            CreateMap<FootballerStat, FootballerStatDTO>().ReverseMap();
            CreateMap<Footballer, FootballerDTO>().ReverseMap();
            CreateMap<Favourite, FavouriteDTO>().ReverseMap();
            CreateMap<Team, TeamDTO>().ReverseMap();
            CreateMap<Referee, RefereeDTO>().ReverseMap();
            CreateMap<Match, MatchDTO>().ReverseMap();

            CreateMap<TeamStat, TeamStatDTO>()
                .ForMember(dest => dest.TeamName, opt => opt.MapFrom(src => src.Team.Name))
                .ReverseMap();
        }
    }
}
