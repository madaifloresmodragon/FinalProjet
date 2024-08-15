using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface ICategoryServive
    {
        public ICollection<Category> List();
        public Category Add(Category category);
        public void Update(Category category);
        public Category FindById(int id);
        public void Delete(int id);
    }
}
