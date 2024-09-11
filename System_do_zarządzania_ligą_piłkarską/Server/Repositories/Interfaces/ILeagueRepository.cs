
using System_do_zarządzania_ligą_piłkarską.Server.Models;

namespace System_do_zarządzania_ligą_piłkarską.Server.Repositories.Interfaces
{
    public interface ILeagueRepository
    {
        Task<List<League>> GetLeaguesByPage(int pageNumber, int pageSize);
        Task<League> GetLeagueById(int id);
        Task<List<TeamStat>> GetLeagueTable(int leagueId);
        Task<List<FootballerStat>> GetLeagueScorers(int leagueId);
    }
}
