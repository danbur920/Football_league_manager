using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System_do_zarządzania_ligą_piłkarską.Server.Data;
using System_do_zarządzania_ligą_piłkarską.Server.Models;
using System_do_zarządzania_ligą_piłkarską.Server.Repositories.Interfaces;
using System_do_zarządzania_ligą_piłkarską.Server.Services.Interfaces;
using System_do_zarządzania_ligą_piłkarską.Shared.DTOs;

namespace System_do_zarządzania_ligą_piłkarską.Server.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;

        public UserService(IMapper mapper, UserManager<ApplicationUser> userManager)
        {
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<bool> BlockUser(string userId)
        {
            var userToBlock = await _userManager.FindByIdAsync(userId);
            var result = await _userManager.SetLockoutEndDateAsync(userToBlock, DateTimeOffset.UtcNow.AddDays(30));

            return result.Succeeded;
        }

        public async Task<bool> UnlockUser(string userId)
        {
            var userToUnlock = await _userManager.FindByIdAsync(userId);
            var result = await _userManager.SetLockoutEndDateAsync(userToUnlock, null);

            return result.Succeeded;
        }

        public async Task<bool> DeleteUser(string userId)
        {
            var userToDelete = await _userManager.FindByIdAsync(userId);
            var result = await _userManager.DeleteAsync(userToDelete);

            return result.Succeeded;
        }

        public async Task<List<ApplicationUserDTO>> GetUsers()
        {
            var users = await _userManager.Users.ToListAsync();
            var userDtos = new List<ApplicationUserDTO>();

            foreach (var user in users)
            {
                var role = await _userManager.GetRolesAsync(user);
                var userDto = _mapper.Map<ApplicationUserDTO>(user);
                userDto.Role = role.FirstOrDefault();
                userDtos.Add(userDto);
            }

            return userDtos;
        }
        public async Task<string> GetUserIdByEmailAddress(string emailAddress)
        {
            var user = await _userManager.FindByEmailAsync(emailAddress);
            if (user != null)
            {
                return user.Id;
            }
            return string.Empty;
        }
    }
}
