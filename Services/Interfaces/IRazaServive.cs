using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IRazaServive
    {
        public ICollection<Raza> List();
        public Raza Add(Raza raza);
        public void Update(Raza raza);
        public Raza FindById(int id);
        public void Delete(int id);
    }
}
