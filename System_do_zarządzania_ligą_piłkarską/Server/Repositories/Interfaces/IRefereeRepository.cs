using System_do_zarządzania_ligą_piłkarską.Server.Models;

namespace System_do_zarządzania_ligą_piłkarską.Server.Repositories.Interfaces
{
    public interface IRefereeRepository
    {
        Task<List<Referee>> GetRefereesByPage(int pageNumber, int pageSize);
        Task<Referee> GetRefereeInfoById(int refereeId);

        // League Master Panel:
        Task<List<Referee>> GetAllReferees();
        Task<Referee> GetRefereeToManage(int refereeId);
        Task<List<Referee>> GetAllRefereesFromSpecificSeason(int leagueSeasonId);
        Task AddRefereeToTheSeason(RefereeStat newRefereeStat);
        Task AddNewReferee(Referee newReferee);
        Task<List<Referee>> GetCreatedRefereesByLeagueMaster(string userId);
        Task UpdateReferee(Referee refereeToUpdate);
    }
}
