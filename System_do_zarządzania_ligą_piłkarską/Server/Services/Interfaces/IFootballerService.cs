using System_do_zarządzania_ligą_piłkarską.Shared.DTOs;
using System_do_zarządzania_ligą_piłkarską.Shared.DTOs.Footballers;
using System_do_zarządzania_ligą_piłkarską.Shared.DTOs.Matches;

namespace System_do_zarządzania_ligą_piłkarską.Server.Services.Interfaces
{
    public interface IFootballerService
    {
        Task<List<FootballerDTO>>GetPlayersByPage(int pageNumber, int pageSize);
        Task<int> GetTotalPlayersCount();
        Task<FootballerStatDTO> GetFootballerInfoById(int footballerId);
        Task<List<ShortFootballerInfoDTO>> GetFootballersFromSpecificTeam(int teamId);
        Task AddNewFootballerToTeam(NewFootballerDTO newFootballer);
    }
}
