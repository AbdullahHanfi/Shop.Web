using Shop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        public IUserRepository user { get; }
        public IBaseRepository<ProductPhotos> ProductPhotos { get; }
        public IBaseRepository<Product> Product { get; }
        int Complete();
    }
}