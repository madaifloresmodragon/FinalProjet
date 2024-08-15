using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IProductService
    {
        public ICollection<Product> List();
        public Product Add(Product product);
        public void Update(Product product);
        public Product FindById(int id);
        public void Delete(int id);
    }
}
