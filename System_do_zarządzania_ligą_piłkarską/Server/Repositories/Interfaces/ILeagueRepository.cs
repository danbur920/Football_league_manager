
using System_do_zarządzania_ligą_piłkarską.Server.Models;

namespace System_do_zarządzania_ligą_piłkarską.Server.Repositories.Interfaces
{
    public interface ILeagueRepository
    {
        Task<List<LeagueSeason>> GetLeaguesByPage(int pageNumber, int pageSize);
        Task<LeagueSeason> GetLeagueById(int id);
        Task<List<TeamStat>> GetLeagueTable(int leagueId);
        Task<List<FootballerStat>> GetLeagueScorers(int leagueId);
        
        Task AddNewLeagueInfo(LeagueInfo leagueInfo);
        Task AddNewLeagueSeason(LeagueSeason leagueSeason);

        // League Master Panel:

        Task<List<LeagueSeason>> GetAllLeaguesByLeagueMaster(string leagueMasterId);
    }
}
