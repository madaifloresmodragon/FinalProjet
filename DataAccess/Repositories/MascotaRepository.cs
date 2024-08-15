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
    public class MascotaRepository : IMascotaRepository
    {
        private readonly IdentityDbContext _dbContext;
        public MascotaRepository(IdentityDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Mascota Add(Mascota mascota)
        {
            if (mascota.Raza != null) 
            {
                var category = _dbContext.Set<Raza>().Find(mascota.Raza.Id);
                if (category != null) 
                {
                    mascota.Raza = category;
                }
            }

            _dbContext.Set<Mascota>().Add(mascota);
            _dbContext.SaveChanges();

            return mascota;
        }

        public void Delete(Mascota mascota)
        {
            _dbContext.Set<Mascota>().Remove(mascota);
            _dbContext.SaveChanges();
        }

        public Mascota FindById(int id)
        {
           var mascota = _dbContext.Set<Mascota>().Include(p => p.Raza).First(p => p.Id == id);
           return mascota;
        }

        public ICollection<Mascota> list()
        {
            return _dbContext.Set<Mascota>().Include(p => p.Raza).ToList();
        }

        public void Update(Mascota mascota)
        {
            var currentMascota = _dbContext.Set<Mascota>()
                .Include(p => p.Raza)
                .First(p => p.Id == mascota.Id);

            if (mascota.Raza != null)
            {
                var category = _dbContext.Set<Raza>().Find(mascota.Raza.Id);
                if (category != null)
                {
                    currentMascota.Raza = category;
                }else
                {
                    currentMascota.Raza = null;
                }
            }

            currentMascota.Nombre = mascota.Nombre;
            currentMascota.FechaNacimiento = mascota.FechaNacimiento;
            currentMascota.TipoAnimal = mascota.TipoAnimal;
            currentMascota.Color = mascota.Color;
            currentMascota.Peso = mascota.Peso;
            currentMascota.Genero = mascota.Genero;

            _dbContext.SaveChanges();
        }
    }
}
