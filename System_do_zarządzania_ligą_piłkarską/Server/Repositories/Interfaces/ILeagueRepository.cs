
using System_do_zarządzania_ligą_piłkarską.Server.Models;

namespace System_do_zarządzania_ligą_piłkarską.Server.Repositories.Interfaces
{
    public interface ILeagueRepository
    {
        Task<List<League>> GetAllLeagues();

        //Task AddAddress(Address address);
        //Task DeleteAddress(Address address);
        //Task UpdateAddress(int id, Address address);
        //Task SaveAddress();
    }
}
