using System_do_zarządzania_ligą_piłkarską.Shared.DTOs;

namespace System_do_zarządzania_ligą_piłkarską.Server.Services.Interfaces
{
    public interface IRefereeService
    {
        Task<List<RefereeDTO>> GetRefereesByPage(int pageNumber, int pageSize);
    }
}
