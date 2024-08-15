using Authentication.DataAccess.Context;
using Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Context
{
    public class APIContext : AuthContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Raza> Razas { get; set; }

        public DbSet<Mascota> Mascotas { get; set; }

        public APIContext(DbContextOptions<APIContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    }

}
