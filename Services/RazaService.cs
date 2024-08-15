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
    public class RazaService : IRazaServive
    {
        private readonly IRazaRepository _razaRepository;
        public RazaService(IRazaRepository razaRepository) 
        {
            _razaRepository = razaRepository;
        }
        public Raza Add(Raza raza)
        {
            return _razaRepository.Add(raza);
        }

        public void Delete(int id)
        {
            var raza = _razaRepository.FindById(id);

            if (raza != null) 
            {
                _razaRepository.Delete(raza);
            }
        }

        public Raza FindById(int id)
        {
            return _razaRepository.FindById(id);
        }

        public ICollection<Raza> List()
        {
            return _razaRepository.list();
        }

        public void Update(Raza raza)
        {
            var result = _razaRepository.FindById(raza.Id);

            if (result != null)
            {
                _razaRepository.Update(raza);
            }
        }
    }
}
