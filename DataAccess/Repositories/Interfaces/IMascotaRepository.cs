using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Interfaces
{
    public interface IMascotaRepository
    {
        public ICollection<Mascota> list();
        public Mascota Add(Mascota mascota);
        public void Update(Mascota mascota);
        public Mascota FindById(int id);
        public ICollection<Mascota> FindByRazas(List<String> razas);
        public void Delete(Mascota mascota);
    }
}
