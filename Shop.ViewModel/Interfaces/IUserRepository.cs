using Microsoft.AspNetCore.Identity;
using Shop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;


namespace Shop.Core.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> FindByIdAsync(string userId);
        Task<User?> FindByEmailAsync(string Email);
        Task<User?> FindByNameAsync(string userName);
        Task<User?> GetUserAsync(ClaimsPrincipal principal);
        Task<IdentityResult> CreateAsync(User user);
        Task<IdentityResult> CreateAsync(User user, string password);
        Task<string> GenerateEmailConfirmationTokenAsync(User user);
        Task<string> GeneratePasswordResetTokenAsync(User user);
        Task<IdentityResult> ResetPasswordAsync(User user, string token, string newPassword);
        Task<bool> IsEmailConfirmedAsync(User user);
        Task<IdentityResult> AddToRoleAsync(User user, string Role);
        Task<IdentityResult> AddToRolesAsync(User user, IEnumerable<string> Roles);
        Task<IdentityResult> RemoveFromRolesAsync(User user, IEnumerable<string> Roles);
        Task<IdentityResult> ChangeEmailAsync(User user, string newEmail, string token);
        Task<IdentityResult> ConfirmEmailAsync(User user, string token);
        Task<IdentityResult> ChangePasswordAsync(User user, string currentPassword, string newPassword);
        Task<IdentityResult> UpdateAsync(User user);
        Task<IdentityResult> DeleteAsync(User user);
    }
}
