using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Core.Interfaces
{
    public interface IMailServies
    {
        Task SendEmailAsync(string mailto, string subject, string body);
        Task SendEmailAsync(string mailto, string subject, string body, List<IFormFile> files);
    }
}
