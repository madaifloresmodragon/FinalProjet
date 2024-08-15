using Authentication.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.DataAccess.Context
{
    public abstract class AuthContext : IdentityDbContext
    {
        public AuthContext(DbContextOptions options) : base(options) { }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>().HasData(new 
            {
                Id = 1,
                UserName = "admin",
                FirstName = "admin",
                LastName = "admin",
                Email = "admin@gmail.com",
                IsEnabled = true
            });
            base.OnModelCreating(builder);
        }
    }
}
