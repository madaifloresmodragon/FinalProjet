using DataAccess.Repositories.Interfaces;
using Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class RazaRepository : IRazaRepository
    {
        private readonly IdentityDbContext _dbContext;
        public RazaRepository(IdentityDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Raza Add(Raza raza)
        {
            _dbContext.Set<Raza>().Add(raza);
            _dbContext.SaveChanges();

            return raza;
        }

        public void Delete(Raza raza)
        {
            _dbContext.Set<Raza>().Remove(raza);
            _dbContext.SaveChanges();
        }

        public Raza FindById(int id)
        {
            var raza = _dbContext.Set<Raza>().First(c => c.Id == id);

            return raza;
        }

        public ICollection<Raza> list()
        {
            return _dbContext.Set<Raza>().ToList(); 
        }

        public void Update(Raza raza)
        {
            var razaToUpdate = FindById(raza.Id);

            razaToUpdate.Nombre = raza.Nombre;
            razaToUpdate.TamanioPromedio = raza.TamanioPromedio;
            razaToUpdate.CaracteristicasFisicas = raza.CaracteristicasFisicas;
            razaToUpdate.PredisposicionSalud = raza.PredisposicionSalud;
            

            _dbContext.SaveChanges();
        }
    }
}
