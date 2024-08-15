using DataAccess.Repositories.Interfaces;
using Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly IdentityDbContext _dbContext;
        public ProductRepository(IdentityDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Product Add(Product product)
        {
            if (product.Category != null) 
            {
                var category = _dbContext.Set<Category>().Find(product.Category.Id);
                if (category != null) 
                {
                    product.Category = category;
                }
            }

            _dbContext.Set<Product>().Add(product);
            _dbContext.SaveChanges();

            return product;
        }

        public void Delete(Product product)
        {
            _dbContext.Set<Product>().Remove(product);
            _dbContext.SaveChanges();
        }

        public Product FindById(int id)
        {
           var product = _dbContext.Set<Product>().Include(p => p.Category).First(p => p.Id == id);
           return product;
        }

        public ICollection<Product> list()
        {
            return _dbContext.Set<Product>().Include(p => p.Category).ToList();
        }

        public void Update(Product product)
        {
            var currentProduct = _dbContext.Set<Product>()
                .Include(p => p.Category)
                .First(p => p.Id == product.Id);

            if (product.Category != null)
            {
                var category = _dbContext.Set<Category>().Find(product.Category.Id);
                if (category != null)
                {
                    currentProduct.Category = category;
                }else
                {
                    currentProduct.Category = null;
                }
            }

            currentProduct.Name = product.Name;
            currentProduct.Description = product.Description;
            currentProduct.Price = product.Price;

            _dbContext.SaveChanges();
        }
    }
}
