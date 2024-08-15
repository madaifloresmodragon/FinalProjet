using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Mascota : Entity
    {
        //public string Name { get; set; }
        //public string Description { get; set; }
        //public decimal Price { get; set; }

        //public Category Category { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string TipoAnimal { get; set; }
        //public int RazaId { get; set; }
        public string Color { get; set; }
        public float Peso { get; set; }
        public string Genero { get; set; }


        public Raza Raza { get; set; }
    }
}
