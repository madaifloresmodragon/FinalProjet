using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }

        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [NotMapped]
        [StringLength(100, ErrorMessage = "La contraseña debe tener al menos {2} caracteres de longitud y maximo {1}", MinimumLength =8)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [NotMapped]
        [Compare("Password", ErrorMessage = "La contraseña y la confirmacion no coinciden")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        [NotMapped]
        [StringLength(100, ErrorMessage = "La contraseña debe tener al menos {2} caracteres de longitud y maximo {1}", MinimumLength = 8)]
        [DataType(DataType.Password)]
        public string OldPossword { get; set; }

        public bool IsEnabled { get; set; }

        [NotMapped]
        public string Token { get; set; }

        [NotMapped]
        public ICollection<Role> Roles { get; set; }
    }
}
