using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IMascotaService
    {
        public ICollection<Mascota> List();
        public Mascota Add(Mascota mascota);
        public void Update(Mascota mascota);
        public Mascota FindById(int id);
        public void Delete(int id);

        public ICollection<Mascota> FindByRazas(List<String> razas);
    }
}
