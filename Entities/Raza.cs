using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Raza : Entity
    {
        public string Nombre { get; set; }
        public string TamanioPromedio { get; set; }
        public string CaracteristicasFisicas { get; set; }
        public string PredisposicionSalud { get; set; }
    }
}
