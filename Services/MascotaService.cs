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
    public class MascotaService : IMascotaService
    {
        private readonly IMascotaRepository _mascotaRepository;
        public MascotaService(IMascotaRepository mascotaRepository)
        {
            _mascotaRepository = mascotaRepository;
        }
        public Mascota Add(Mascota mascota)
        {
            return _mascotaRepository.Add(mascota);
        }

        public void Delete(int id)
        {
            var mascota = _mascotaRepository.FindById(id);

            if (mascota != null) 
            {
                _mascotaRepository.Delete(mascota);
            }
        }

        public Mascota FindById(int id)
        {
            return _mascotaRepository.FindById(id);
        }

        public ICollection<Mascota> List()
        {
            return _mascotaRepository.list();
        }

        public void Update(Mascota mascota)
        {
            var result = _mascotaRepository.FindById(mascota.Id);

            if (result != null) 
            {
                _mascotaRepository.Update(mascota);
            }
        }
    }
}
