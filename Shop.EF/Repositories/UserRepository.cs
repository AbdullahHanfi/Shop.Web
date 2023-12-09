using Microsoft.AspNetCore.Identity;
using Shop.Core.Interfaces;
using Shop.EF.Data;
using Shop.Core.Models;
using System.Security.Claims;

namespace Shop.EF.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<User> _userManager;
        public UserRepository(UserManager<User> userManager) => _userManager = userManager;


        public async Task<User?> FindByIdAsync(string userId) => await _userManager.FindByIdAsync(userId);

        public async Task<User?> FindByEmailAsync(string Email) => await _userManager.FindByEmailAsync(Email);

        public async Task<User?> FindByNameAsync(string userName) => await _userManager.FindByNameAsync(userName);
        public async Task<User?> GetUserAsync(ClaimsPrincipal user) => await _userManager.GetUserAsync(user);
            
        public async Task<bool> IsEmailConfirmedAsync(User user) => await _userManager.IsEmailConfirmedAsync(user);

        public async Task<string> GenerateEmailConfirmationTokenAsync(User user) => await _userManager.GenerateEmailConfirmationTokenAsync(user);
        public async Task<string> GeneratePasswordResetTokenAsync(User user) => await _userManager.GeneratePasswordResetTokenAsync(user);
        public async Task<IdentityResult> CreateAsync(User user) => await _userManager.CreateAsync(user);
        public async Task<IdentityResult> CreateAsync(User user, string password) => await _userManager.CreateAsync(user, password);
        public async Task<IdentityResult> ResetPasswordAsync(User user, string token, string newPassword) => await _userManager.ResetPasswordAsync(user, token, newPassword);

        public async Task<IdentityResult> AddToRoleAsync(User user, string Role) => await _userManager.AddToRoleAsync(user, Role);

        public async Task<IdentityResult> AddToRolesAsync(User user, IEnumerable<string> Roles) => await _userManager.AddToRolesAsync(user, Roles);

        public async Task<IdentityResult> RemoveFromRolesAsync(User user, IEnumerable<string> Roles) => await _userManager.RemoveFromRolesAsync(user, Roles);

        public async Task<IdentityResult> ChangePasswordAsync(User user, string currentPassword, string newPassword) => await _userManager.ChangePasswordAsync(user, currentPassword, newPassword);

        public async Task<IdentityResult> ChangeEmailAsync(User user, string newEmail, string token) => await _userManager.ChangeEmailAsync(user, newEmail, token);

        public async Task<IdentityResult> ConfirmEmailAsync(User user, string token) => await _userManager.ConfirmEmailAsync(user, token);

        public async Task<IdentityResult> UpdateAsync(User user) => await _userManager.UpdateAsync(user);

        public async Task<IdentityResult> DeleteAsync(User user) => await _userManager.DeleteAsync(user);

    }
}
