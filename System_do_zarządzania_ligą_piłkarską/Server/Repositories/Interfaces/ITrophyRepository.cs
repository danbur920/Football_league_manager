using System_do_zarządzania_ligą_piłkarską.Server.Models;

namespace System_do_zarządzania_ligą_piłkarską.Server.Repositories.Interfaces
{
    public interface ITrophyRepository
    {
        Task<List<Trophy>> GetTrophies();
        Task AddTrophy(Trophy trophy);
        Task DeleteTrophy(int trophyId);
        Task<List<Trophy>> GetCreatedTrophiesByLeagueMaster(string userId);
    }
}
