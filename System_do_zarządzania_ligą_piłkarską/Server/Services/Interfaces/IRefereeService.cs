using System_do_zarządzania_ligą_piłkarską.Shared.DTOs;
using System_do_zarządzania_ligą_piłkarską.Shared.DTOs.Referees;

namespace System_do_zarządzania_ligą_piłkarską.Server.Services.Interfaces
{
    public interface IRefereeService
    {
        Task<List<RefereeDTO>> GetRefereesByPage(int pageNumber, int pageSize);
        Task<RefereeDTO> GetRefereeInfoById(int refereeId);

        // League Master Panel:

        Task<List<ShortRefereeInfoDTO>> GetAllReferees();
        Task AddRefereeToTheSeason(NewRefereeStatDTO newRefereeDTO);
    }
}
