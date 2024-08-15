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
    public class CategoryRepository : ICategoryRepository
    {
        private readonly IdentityDbContext _dbContext;
        public CategoryRepository(IdentityDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Category Add(Category category)
        {
            _dbContext.Set<Category>().Add(category);
            _dbContext.SaveChanges();

            return category;
        }

        public void Delete(Category category)
        {
            _dbContext.Set<Category>().Remove(category);
            _dbContext.SaveChanges();
        }

        public Category FindById(int id)
        {
            var category = _dbContext.Set<Category>().First(c => c.Id == id);

            return category;
        }

        public ICollection<Category> list()
        {
            return _dbContext.Set<Category>().ToList(); 
        }

        public void Update(Category category)
        {
            var categoryToUpdate = FindById(category.Id);

            categoryToUpdate.Name = category.Name;
            categoryToUpdate.Description = category.Description;

            _dbContext.SaveChanges();
        }
    }
}
