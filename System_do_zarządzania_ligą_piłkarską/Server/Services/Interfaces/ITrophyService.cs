using System_do_zarządzania_ligą_piłkarską.Server.Models;
using System_do_zarządzania_ligą_piłkarską.Shared.DTOs;
using System_do_zarządzania_ligą_piłkarską.Shared.DTOs.Trophies;

namespace System_do_zarządzania_ligą_piłkarską.Server.Services.Interfaces
{
    public interface ITrophyService
    {
        Task<List<TrophyDTO>> GetTrophies();
        Task AddNewTrophy(NewTrophyDTO newTrophy);
        Task DeleteTrophy(int trophyId);
        Task<List<TrophyDTO>> GetCreatedTrophiesByLeagueMaster(string userId);
    }
}
