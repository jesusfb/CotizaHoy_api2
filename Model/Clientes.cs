using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DotNet8WebAPI.Model;



public partial class Clientes
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nombres { get; set; } = string.Empty;
        [Required]
        public string ApellidoPaterno { get; set; } = string.Empty;

        public string ApellidoMaterno { get; set; } = string.Empty;

        [Required]
        public string Direccion { get; set; } = string.Empty;

        [Required]
        public string Telefono { get; set; } = string.Empty;


        [Display(Name = "Correo electrónico")]
        [Required(ErrorMessage = "El correo electrónico es requerido")]
        [EmailAddress(ErrorMessage = "Correo electrónico no valido")]
        public string CorreoElectronico { get; set; } = string.Empty ;

        

    }

