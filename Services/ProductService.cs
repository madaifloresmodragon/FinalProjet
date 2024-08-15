using DataAccess.Repositories.Interfaces;
using Entities;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public Product Add(Product product)
        {
            return _productRepository.Add(product);
        }

        public void Delete(int id)
        {
            var product = _productRepository.FindById(id);

            if (product != null) 
            {
                _productRepository.Delete(product);
            }
        }

        public Product FindById(int id)
        {
            return _productRepository.FindById(id);
        }

        public ICollection<Product> List()
        {
            return _productRepository.list();
        }

        public void Update(Product product)
        {
            var result = _productRepository.FindById(product.Id);

            if (result != null) 
            {
                _productRepository.Update(product);
            }
        }
    }
}
