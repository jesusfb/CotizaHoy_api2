using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotNet8WebAPI.Model
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "El Nombre es requerido")]
        public required string FirstName { get; set; }

        [Display(Name = "Apellido")]
        [Required(ErrorMessage = "El Apellido es requerido")]
        public string LastName { get; set; }


        [Display(Name = "Correo electrónico")]
        [Required(ErrorMessage = "El correo electrónico es requerido")]
        [EmailAddress(ErrorMessage = "Correo electrónico no valido")]
        public required string Username { get; set; }

        [Required(ErrorMessage = "La contraseña es requerida")]
        [StringLength(100, ErrorMessage = "La {0} debe tener al menos {2} caracteres.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }
        public bool isActive { get; set; }

    }
}
