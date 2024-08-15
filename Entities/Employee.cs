using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Employee : Entity
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string CI { get; set; }
        public string Address { get; set; }
        public int PhoneNumber { get; set; }
    }
}
