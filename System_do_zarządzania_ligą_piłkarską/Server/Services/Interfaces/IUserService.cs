using System_do_zarządzania_ligą_piłkarską.Shared.DTOs;

namespace System_do_zarządzania_ligą_piłkarską.Server.Services.Interfaces
{
    public interface IUserService
    {
        Task<List<ApplicationUserDTO>> GetUsers();
        Task<bool> DeleteUser(string userId);
        Task<bool> BlockUser(string userId);
        Task<bool> UnlockUser(string userId);
    }
}
