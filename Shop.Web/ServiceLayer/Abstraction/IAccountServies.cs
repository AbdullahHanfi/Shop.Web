using Shop.Core.Models;

namespace Shop.Web.ServiceLayer.Abstraction
{
    public interface IAccountServies
    {
        Task<bool> ConfirmationMail(string? mailTo);
        Task<bool> ResetPasswordToken(string? mailTo);
        Task<User?> UserByEmailOrName(string? item);

    }
}
