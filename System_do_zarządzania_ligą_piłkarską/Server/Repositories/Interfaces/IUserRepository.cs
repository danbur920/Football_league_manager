using System_do_zarządzania_ligą_piłkarską.Server.Models;

namespace System_do_zarządzania_ligą_piłkarską.Server.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<List<ApplicationUser>> GetUsers();
        Task<ApplicationUser> GetUserById(string userId);
        Task DeleteUser(ApplicationUser user);
    }
}
