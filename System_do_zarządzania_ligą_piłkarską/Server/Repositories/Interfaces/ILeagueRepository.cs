
using System_do_zarządzania_ligą_piłkarską.Server.Models;

namespace System_do_zarządzania_ligą_piłkarską.Server.Repositories.Interfaces
{
    public interface ILeagueRepository
    {
        Task<List<LeagueInfo>> GetLeaguesWithSeasons();
        Task<List<LeagueSeason>> GetLeaguesByPage(int pageNumber, int pageSize);
        Task<LeagueSeason> GetLeagueById(int id); // zwraca leagueInfo oraz leagueSeason
        Task<LeagueSeason> GetLeagueSeasonById(int id); // zwraca tylko leagueSeason
        Task<List<TeamStat>> GetLeagueTable(int leagueId); // zwraca statystyki danej ligi (konkretnego sezonu)
        Task<List<FootballerStat>> GetLeagueScorers(int leagueId);
        
        Task AddNewLeagueInfo(LeagueInfo leagueInfo);
        Task AddNewLeagueSeason(LeagueSeason leagueSeason);

        // League Master Panel:

        Task<List<LeagueInfo>> GetAllLeaguesByLeagueMaster(string leagueMasterId);
        Task<List<LeagueSeason>> GetLeagueByLeagueMaster(string leagueMasterId, int leagueInfoId);
        Task<LeagueSeason> GetSeasonByLeagueMaster(string leagueMasterId, int leagueInfoId, int leagueSeasonId);
        Task DeleteLeague(int leagueId);
        Task UpdateLeagueSeason(LeagueSeason leagueSeason);
        Task<LeagueInfo?> GetLeagueInfoById(int leagueInfoId);
    }
}
