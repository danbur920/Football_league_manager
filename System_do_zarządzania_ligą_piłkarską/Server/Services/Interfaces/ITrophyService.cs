using System_do_zarządzania_ligą_piłkarską.Server.Models;
using System_do_zarządzania_ligą_piłkarską.Shared.DTOs;

namespace System_do_zarządzania_ligą_piłkarską.Server.Services.Interfaces
{
    public interface ITrophyService
    {
        Task<List<TrophyDTO>> GetTrophies();
    }
}
