using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Interfaces
{
    public interface IProductRepository
    {
        public ICollection<Product> list();
        public Product Add(Product product);
        public void Update(Product product);
        public Product FindById(int id);
        public void Delete(Product product);
    }
}
