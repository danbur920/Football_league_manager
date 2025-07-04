﻿using AutoMapper;
using System_do_zarządzania_ligą_piłkarską.Server.Models;
using System_do_zarządzania_ligą_piłkarską.Shared.DTOs;
using System_do_zarządzania_ligą_piłkarską.Shared.DTOs.Footballers;
using System_do_zarządzania_ligą_piłkarską.Shared.DTOs.Images;
using System_do_zarządzania_ligą_piłkarską.Shared.DTOs.Leagues;
using System_do_zarządzania_ligą_piłkarską.Shared.DTOs.Matches;
using System_do_zarządzania_ligą_piłkarską.Shared.DTOs.Referees;
using System_do_zarządzania_ligą_piłkarską.Shared.DTOs.Teams;
using System_do_zarządzania_ligą_piłkarską.Shared.DTOs.Trophies;
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
            CreateMap<Match, MatchDetailsDTO>();
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
            CreateMap<TeamStat, TeamStatDTO>()
                .ForMember(dest => dest.TeamName,
                 opt => opt.MapFrom(src => src.Team.Name))
                .ReverseMap();

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



            CreateMap<NewImageDTO, Image>();
            CreateMap<Image, ImageDTO>();
            CreateMap<NewRefereeDTO, Referee>();

            CreateMap<LeagueSeason, LeagueSeasonProfilDTO>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.LeagueInfo.Name))
                .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.LeagueInfo.Country))
                .ForMember(dest => dest.Level, opt => opt.MapFrom(src => src.LeagueInfo.Level))
                .ForMember(dest => dest.Image, opt => opt.MapFrom(src => src.LeagueInfo.Image));

            CreateMap<LeagueSeason, LeagueSeasonDateDTO>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.LeagueInfo.Name));

            CreateMap<FootballerStat, FootballerStatProfileDTO>();
            CreateMap<Footballer, FootballerProfileDTO>()
                .ForMember(dest => dest.TeamName, opt => opt.MapFrom(src => src.Team.Name));
            CreateMap<LeagueSeason, SeasonTeamStatsDTO>();
            CreateMap<LeagueInfo, ShortLeagueInfoDTO>();
            CreateMap<TeamStat, TeamStatInfoDTO>()
                .ForMember(dest => dest.TeamName, opt => opt.MapFrom(src => src.Team.Name));
            CreateMap<Referee, RefereeInfoDTO>().ReverseMap();

            CreateMap<Footballer, FootballerTrophyCandidateDTO>();
            CreateMap<Team, TeamTrophyCandidateDTO>();
            CreateMap<NewTrophyDTO, Trophy>();
        }
    }
}
