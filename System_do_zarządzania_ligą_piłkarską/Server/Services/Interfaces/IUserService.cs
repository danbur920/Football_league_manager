using System_do_zarządzania_ligą_piłkarską.Shared.DTOs;

namespace System_do_zarządzania_ligą_piłkarską.Server.Services.Interfaces
{
    public interface IUserService 
    {
        Task<List<ApplicationUserDTO>> GetUsers();
    }
}
