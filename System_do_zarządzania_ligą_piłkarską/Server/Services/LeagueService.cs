using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System_do_zarządzania_ligą_piłkarską.Client.Areas.Admin.Pages;
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
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;

        public LeagueService(ILeagueRepository leagueRepository, IMapper mapper, UserManager<ApplicationUser> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _leagueRepository = leagueRepository;
            _mapper = mapper;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<List<LeagueSeasonDTO>> GetLeaguesByPage(int pageNumber, int pageSize)
        {
            var leagueSeasons = await _leagueRepository.GetLeaguesByPage(pageNumber, pageSize);
            return _mapper.Map<List<LeagueSeasonDTO>>(leagueSeasons);
        }

        public async Task<LeagueSeasonProfilDTO> GetLeagueById(int id)
        {
            var league = await _leagueRepository.GetLeagueById(id);
            return _mapper.Map<LeagueSeasonProfilDTO>(league);
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

        // League Master Panel:

        public async Task<List<LeagueInfoDTO>> GetAllLeaguesByLeagueMaster(string userId)
        {
            var leagues = await _leagueRepository.GetAllLeaguesByLeagueMaster(userId);
            return _mapper.Map<List<LeagueInfoDTO>>(leagues);
        }

        public async Task<List<LeagueSeasonDTO>> GetLeagueByLeagueMaster(string userId, int leagueInfoId)
        {
            var league = await _leagueRepository.GetLeagueByLeagueMaster(userId, leagueInfoId);
            return _mapper.Map<List<LeagueSeasonDTO>>(league);
        }

        public async Task<LeagueSeasonDTO> GetSeasonByLeagueMaster(string userId, int leagueInfoId, int leagueSeasonId)
        {
            var season = await _leagueRepository.GetSeasonByLeagueMaster(userId, leagueInfoId, leagueSeasonId);
            return _mapper.Map<LeagueSeasonDTO>(season);
        }

        public async Task DeleteLeague(int leagueId)
        {
            await _leagueRepository.DeleteLeague(leagueId);
        }

        public async Task<bool> HasLeagueManagementRights(string userId)
        {
            var leagues = await _leagueRepository.GetLeaguesWithSeasons();

            if (leagues.Any(x => x.LeagueMasterPrimaryId == userId))
                return true;

            return leagues.Any(league => league.LeagueSeasons.Any(season => season.LeagueMasterSecondaryId == userId));
        }

        public async Task<bool> IsUserPrimaryLeagueMasterForLeague(string userId, int leagueInfoId)
        {
            var league = await _leagueRepository.GetLeagueInfoById(leagueInfoId);
            return league != null && league.LeagueMasterPrimaryId == userId;
        }

        public async Task DeleteUserFromManagement(int leagueSeasonId, string leagueMasterPrimaryId)
        {
            var leagueSeasonToUpdate = await _leagueRepository.GetLeagueSeasonById(leagueSeasonId);
            var currentLeagueMasterSecondaryId = leagueSeasonToUpdate.LeagueMasterSecondaryId;
            leagueSeasonToUpdate.LeagueMasterSecondaryId = leagueMasterPrimaryId;
            await _leagueRepository.UpdateLeagueSeason(leagueSeasonToUpdate);

            var hasOtherLeagueRights = await HasLeagueManagementRights(currentLeagueMasterSecondaryId);

            if (!hasOtherLeagueRights)
            {
                var user = await _userManager.FindByIdAsync(currentLeagueMasterSecondaryId);
                bool isAdmin = await _userManager.IsInRoleAsync(user, "Admin");

                if (!isAdmin)
                {
                    await _userManager.RemoveFromRoleAsync(user, "LeagueMaster");
                    await _userManager.AddToRoleAsync(user, "User");
                }
            }
        }

        public async Task AssignUserToManagement(int leagueSeasonId, string leagueMasterSecondaryEmail)
        {
            var userToAssign = await _userManager.FindByEmailAsync(leagueMasterSecondaryEmail);

            if (userToAssign != null)
            {
                var leagueSeasonToUpdate = await _leagueRepository.GetLeagueSeasonById(leagueSeasonId);
                leagueSeasonToUpdate.LeagueMasterSecondaryId = userToAssign.Id;
                await _leagueRepository.UpdateLeagueSeason(leagueSeasonToUpdate);

                bool isLeagueMaster = await _userManager.IsInRoleAsync(userToAssign, "LeagueMaster");
                bool isAdmin = await _userManager.IsInRoleAsync(userToAssign, "Admin");

                if (!isLeagueMaster && !isAdmin)
                {
                    await _userManager.RemoveFromRoleAsync(userToAssign, "User");
                    await _userManager.AddToRoleAsync(userToAssign, "LeagueMaster");
                }
            }
        }

        public async Task CreateNewLeagueSeason(NewLeagueSeasonDTO newLeagueSeason)
        {
            var userId = _httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (userId == null)
            {
                throw new UnauthorizedAccessException("Nieautoryzowany dostęp.");
            }

            var hasPermissions = await IsUserPrimaryLeagueMasterForLeague(userId, (int)newLeagueSeason.LeagueInfoId);

            if(!hasPermissions)
            {
                throw new UnauthorizedAccessException("Nie masz odpowiednich praw aby dodać sezon do tej ligi.");
            }

            var mappedLeagueSeason = _mapper.Map<LeagueSeason>(newLeagueSeason);
            mappedLeagueSeason.LeagueMasterSecondaryId = userId;
            await _leagueRepository.AddNewLeagueSeason(mappedLeagueSeason);
        }
    }
}
