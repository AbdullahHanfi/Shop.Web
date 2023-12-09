using Microsoft.AspNetCore.Identity;
using Shop.Core.Interfaces;
using Shop.Core.Models;
using Shop.EF.Data;
using Shop.EF.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.EF
{
    public class UnitOfWork : IUnitOfWork
    {
        private ShopDbContext _context;
        public IUserRepository user { get; }
        public IBaseRepository<ProductPhotos> ProductPhotos { get; }
        public IBaseRepository<Product> Product { get; }
        public UnitOfWork(ShopDbContext context, UserManager<User> userManager)
        {
            _context = context;
            user = new UserRepository(userManager);
            ProductPhotos = new BaseRepository<ProductPhotos>(_context);
            Product = new BaseRepository<Product> (_context);
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}