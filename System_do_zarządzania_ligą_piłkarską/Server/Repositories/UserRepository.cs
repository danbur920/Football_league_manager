using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System_do_zarządzania_ligą_piłkarską.Server.Data;
using System_do_zarządzania_ligą_piłkarską.Server.Models;
using System_do_zarządzania_ligą_piłkarską.Server.Repositories.Interfaces;

namespace System_do_zarządzania_ligą_piłkarską.Server.Repositories
{

    // repo dla usera jest nieużywane, gdyż wbudowany UserManager "scala" serwis i repo dla usera
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task DeleteUser(ApplicationUser user)
        {
            var userToDelete = _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }

        public async Task<ApplicationUser> GetUserById(string userId)
        {
            var user = await _context.Users.FindAsync(userId);
            return user;
        }

        public async Task<List<ApplicationUser>> GetUsers()
        {
            var users = await _context.ApplicationUsers
                .ToListAsync();
            return users;
        }
    }
}
