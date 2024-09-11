using System_do_zarządzania_ligą_piłkarską.Server.Models;

namespace System_do_zarządzania_ligą_piłkarską.Server.Repositories.Interfaces
{
    public interface IFootballerRepository
    {
        Task<List<Footballer>> GetPlayersByPage(int pageNumber, int pageSize);
        Task<int> GetTotalPlayersCount();
    }
}
