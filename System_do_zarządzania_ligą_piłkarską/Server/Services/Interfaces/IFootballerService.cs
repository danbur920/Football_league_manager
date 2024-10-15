using System_do_zarządzania_ligą_piłkarską.Shared.DTOs;

namespace System_do_zarządzania_ligą_piłkarską.Server.Services.Interfaces
{
    public interface IFootballerService
    {
        Task<List<FootballerDTO>>GetPlayersByPage(int pageNumber, int pageSize);
        Task<int> GetTotalPlayersCount();
        Task<FootballerStatDTO> GetFootballerInfoById(int footballerId);
    }
}
