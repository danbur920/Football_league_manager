using System_do_zarządzania_ligą_piłkarską.Shared.DTOs;
using System_do_zarządzania_ligą_piłkarską.Shared.DTOs.Referees;

namespace System_do_zarządzania_ligą_piłkarską.Server.Services.Interfaces
{
    public interface IRefereeService
    {
        Task<List<RefereeDTO>> GetRefereesByPage(int pageNumber, int pageSize);
        Task<RefereeDTO> GetRefereeInfoById(int refereeId);

        // League Master Panel:

        Task<List<ShortRefereeInfoDTO>> GetAllRefereesForLeagueMaster();
        Task<List<ShortRefereeInfoDTO>> GetAllRefereesFromSpecificSeason(int leagueSeasonId);
        Task AddRefereeToTheSeason(NewRefereeStatDTO newRefereeDTO);
        Task AddNewReferee(NewRefereeDTO newReferee);
    }
}
