using System_do_zarządzania_ligą_piłkarską.Server.Models;

namespace System_do_zarządzania_ligą_piłkarską.Server.Repositories.Interfaces
{
    public interface IRefereeRepository
    {
        Task<List<Referee>> GetReferees();
    }
}
