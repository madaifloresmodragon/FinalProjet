using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Interfaces
{
    public interface IRazaRepository
    {
        public ICollection<Raza> list();
        public Raza Add(Raza raza);
        public void Update(Raza raza);
        public Raza FindById(int id);
        public void Delete(Raza raza);
    }
}
