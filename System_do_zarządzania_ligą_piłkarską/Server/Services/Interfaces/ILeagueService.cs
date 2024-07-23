using System_do_zarządzania_ligą_piłkarską.Shared.Models;

namespace System_do_zarządzania_ligą_piłkarską.Server.Services.Interfaces
{
    public interface ILeagueService
    {
        Task<List<LeagueDTO>> GetAllLeagues();
    }
}
