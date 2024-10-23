using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System_do_zarządzania_ligą_piłkarską.Server.Models;
using System_do_zarządzania_ligą_piłkarską.Server.Repositories.Interfaces;
using System_do_zarządzania_ligą_piłkarską.Server.Services.Interfaces;
using System_do_zarządzania_ligą_piłkarską.Shared.DTOs;
using System_do_zarządzania_ligą_piłkarską.Shared.DTOs.Leagues;

namespace System_do_zarządzania_ligą_piłkarską.Server.Services
{
    public class LeagueService : ILeagueService
    {
        private readonly ILeagueRepository _leagueRepository;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;

        public LeagueService(ILeagueRepository leagueRepository, IMapper mapper, UserManager<ApplicationUser> userManager)
        {
            _leagueRepository = leagueRepository;
            _mapper = mapper;
            _userManager = userManager;
        }
        public async Task<List<LeagueSeasonDTO>> GetLeaguesByPage(int pageNumber, int pageSize)
        {
            var leagues = await _leagueRepository.GetLeaguesByPage(pageNumber, pageSize);
            var leagueSeasonDTOs = _mapper.Map<List<LeagueSeasonDTO>>(leagues);

            return leagueSeasonDTOs;
        }

        public async Task<LeagueSeasonDTO> GetLeagueById(int id)
        {
            var league = await _leagueRepository.GetLeagueById(id);
            return _mapper.Map<LeagueSeasonDTO>(league);
        }

        public async Task<List<FootballerStatDTO>> GetLeagueScorers(int leagueId)
        {
            var scorers = await _leagueRepository.GetLeagueScorers(leagueId);
            return _mapper.Map<List<FootballerStatDTO>>(scorers);
        }

        public async Task<List<TeamStatDTO>> GetLeagueTable(int leagueId)
        {
            var teamsStats = await _leagueRepository.GetLeagueTable(leagueId);
            return _mapper.Map<List<TeamStatDTO>>(teamsStats);
        }

        public async Task CreateNewLeague(NewLeagueDTO newLeagueDto, string userId)
        {
            var leagueInfo = _mapper.Map<LeagueInfo>(newLeagueDto.LeagueInfo);
            var leagueSeason = _mapper.Map<LeagueSeason>(newLeagueDto.LeagueSeason);

            await _leagueRepository.AddNewLeagueInfo(leagueInfo);
            leagueSeason.LeagueInfoId = leagueInfo.Id;
            await _leagueRepository.AddNewLeagueSeason(leagueSeason);

            var user = await _userManager.FindByIdAsync(userId);
            if (user != null && !await _userManager.IsInRoleAsync(user, "LeagueMaster"))
            {
                await _userManager.RemoveFromRoleAsync(user, "User");
                await _userManager.AddToRoleAsync(user, "LeagueMaster");
            }
        }

        public async Task<List<LeagueSeasonDTO>> GetAllLeaguesByLeagueMaster(string userId)
        {
            var leagues = await _leagueRepository.GetAllLeaguesByLeagueMaster(userId);
            return _mapper.Map<List<LeagueSeasonDTO>>(leagues);
        }
    }
}
