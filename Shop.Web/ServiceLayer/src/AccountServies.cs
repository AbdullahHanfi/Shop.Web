using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using Shop.Core.Interfaces;
using Shop.Core.Models;
using Shop.Web.ServiceLayer.Abstraction;
using System.Security.Policy;

namespace Shop.Web.ServiceLayer.src
{
    public class AccountServies : IAccountServies
    {
        private readonly IMailServies _mailSender;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IUrlHelperFactory _urlHelperFactory;
        private readonly IActionContextAccessor _actionContextAccessor;
        public AccountServies(IActionContextAccessor actionContextAccessor, IUrlHelperFactory urlHelperFactory, IUnitOfWork UnitOfWork, IHttpContextAccessor httpContextAccessor, IMailServies mailServies)
        {
            _UnitOfWork = UnitOfWork;
            _httpContextAccessor = httpContextAccessor;
            _mailSender = mailServies;
            _urlHelperFactory = urlHelperFactory;
            _actionContextAccessor = actionContextAccessor;

        }
        public async Task<bool> ConfirmationMail(string? mailTo)
        {
            User? user = await UserByEmailOrName(mailTo);

            var urlHelper = _urlHelperFactory.GetUrlHelper(_actionContextAccessor.ActionContext);

            if (user is not null)
            {
                string code = await _UnitOfWork.user.GenerateEmailConfirmationTokenAsync(user);
                string BaseUrl = string.Format("{0}://{1}", _httpContextAccessor.HttpContext.Request.Scheme.ToString(), _httpContextAccessor.HttpContext.Request.Host.ToString());
                string url = urlHelper.Action("ConfirmEmail", new { userId = user.Id, token = code });

                await _mailSender.SendEmailAsync(user.Email, "Confirm your account.", $"Please use the link to confirm your email account <a href='{BaseUrl}{url}'> Click.</a>");
                return true;
            }
            return false;
        }

        public async Task<User?> UserByEmailOrName(string? item)
        {
            if (string.IsNullOrEmpty(item))
                return default;
            User? user;
            var nameOrEmail = item.Any(b => b == '@');
            if (nameOrEmail)
                user = await _UnitOfWork.user.FindByEmailAsync(item);
            else
                user = await _UnitOfWork.user.FindByNameAsync(item);
            return user;
        }

        public async Task<bool> ResetPasswordToken(string? mailTo)
        {
            User? user = await UserByEmailOrName(mailTo);

            var urlHelper = _urlHelperFactory.GetUrlHelper(_actionContextAccessor.ActionContext);

            if (user is not null)
            {
                string code = await _UnitOfWork.user.GeneratePasswordResetTokenAsync(user);
                string BaseUrl = string.Format("{0}://{1}", _httpContextAccessor.HttpContext.Request.Scheme.ToString(), _httpContextAccessor.HttpContext.Request.Host.ToString());
                string url = urlHelper.Action("ResetPassword", new { userId = user.Id, token = code });

                await _mailSender.SendEmailAsync(user.Email, "Reset Password.", $"Please use the link to Reset your Password account <a href='{BaseUrl}{url}'> Click.</a>");
                return true;
            }
            return false;
        }
    }
}
