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
    public class CategoryService : ICategoryServive
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository) 
        {
            _categoryRepository = categoryRepository;
        }
        public Category Add(Category category)
        {
            return _categoryRepository.Add(category);
        }

        public void Delete(int id)
        {
            var category = _categoryRepository.FindById(id);

            if (category != null) 
            {
                _categoryRepository.Delete(category);
            }
        }

        public Category FindById(int id)
        {
            return _categoryRepository.FindById(id);
        }

        public ICollection<Category> List()
        {
            return _categoryRepository.list();
        }

        public void Update(Category category)
        {
            var result = _categoryRepository.FindById(category.Id);

            if (result != null)
            {
                _categoryRepository.Update(category);
            }
        }
    }
}
