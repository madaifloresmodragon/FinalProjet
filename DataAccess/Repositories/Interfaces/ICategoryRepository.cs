using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        public ICollection<Category> list();
        public Category Add(Category category);
        public void Update(Category category);
        public Category FindById(int id);
        public void Delete(Category category);
    }
}
