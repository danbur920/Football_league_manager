using AutoMapper;
using System_do_zarządzania_ligą_piłkarską.Server.Models;
using System_do_zarządzania_ligą_piłkarską.Shared.DTOs;
using System_do_zarządzania_ligą_piłkarską.Shared.DTOs.Footballers;
using System_do_zarządzania_ligą_piłkarską.Shared.DTOs.Images;
using System_do_zarządzania_ligą_piłkarską.Shared.DTOs.Leagues;
using System_do_zarządzania_ligą_piłkarską.Shared.DTOs.Matches;
using System_do_zarządzania_ligą_piłkarską.Shared.DTOs.Referees;
using System_do_zarządzania_ligą_piłkarską.Shared.DTOs.Teams;
using System_do_zarządzania_ligą_piłkarską.Shared.Enums;

namespace System_do_zarządzania_ligą_piłkarską.Server.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<LeagueSeason, LeagueSeasonDTO>().ReverseMap();
            CreateMap<LeagueInfo, LeagueInfoDTO>().ReverseMap();
            CreateMap<FootballerStat, FootballerStatDTO>().ReverseMap();
            CreateMap<Footballer, FootballerDTO>().ReverseMap();
            CreateMap<Favourite, FavouriteDTO>().ReverseMap();
            CreateMap<Team, TeamDTO>().ReverseMap();
            CreateMap<Referee, RefereeDTO>().ReverseMap();
            CreateMap<RefereeStat, RefereeStatDTO>().ReverseMap();
            CreateMap<Match, MatchDTO>().ReverseMap();
            CreateMap<Trophy, TrophyDTO>().ReverseMap();

            CreateMap<NewLeagueInfoDTO, LeagueInfo>();
            CreateMap<NewLeagueSeasonDTO, LeagueSeason>();

            CreateMap<Referee, ShortRefereeInfoDTO>();
            CreateMap<RefereeStat, ShortRefereeInfoDTO>();
            CreateMap<NewRefereeStatDTO, RefereeStat>();

            CreateMap<Team, ShortTeamInfoDTO>();
            CreateMap<Team, TeamInfoDTO>();
            CreateMap<NewTeamStatDTO, TeamStat>();

            CreateMap<NewMatchDTO, Match>();
            CreateMap<Match, ShortMatchInfoDTO>();
            CreateMap<Match, EditMatchDTO>();
            CreateMap<MatchEvent, MatchEventDTO>().ReverseMap();
            CreateMap<Footballer, ShortFootballerInfoDTO>();
            CreateMap<NewTeamDTO, Team>();
            CreateMap<ApplicationUser, ShortCoachInfoDTO>();
            CreateMap<NewMatchFootballerDTO, MatchFootballer>();
            CreateMap<MatchFootballer, MatchFootballerDTO>()
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.Footballer.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.Footballer.LastName))
                .ForMember(dest => dest.Position, opt => opt.MapFrom(src => src.Footballer.Position))
                .ForMember(dest => dest.ShirtNumber, opt => opt.MapFrom(src => src.Footballer.ShirtNumber));

            CreateMap<Team, TeamManageDTO>();
            CreateMap<NewFootballerDTO, Footballer>();
            CreateMap<EditTeamDTO, Team>();

            CreateMap<ApplicationUser, ApplicationUserDTO>()
                      .ForMember(dest => dest.LockoutEndDateUtc, opt => opt.MapFrom(src => src.LockoutEnd != null ? (DateTime?)src.LockoutEnd.Value.DateTime : null))
                      .ReverseMap()
                      .ForMember(dest => dest.LockoutEnd, opt => opt.MapFrom(src => src.LockoutEndDateUtc));

            CreateMap<TeamStat, TeamStatDTO>()
                .ForMember(dest => dest.TeamName, opt => opt.MapFrom(src => src.Team.Name))
                .ReverseMap();

            CreateMap<NewImageDTO, Image>();
            CreateMap<Image, ImageDTO>();
            CreateMap<NewRefereeDTO, Referee>();
        }
    }
}
