using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DotNet8WebAPI.Model;



public partial class Cotizaciones
    {

    
    public int Id { get; set; }

    [Required]
    public int ClienteFk { get; set; }

    [Required]
    public int ProductoFk { get; set; }

    [Required]
    public double Cantidad { get; set; }

    [Required]
    public decimal Precio { get; set; }

    [Required]
    public decimal CostoTotal { get; set; }

    [Required]
    public bool Iva { get; set; }

    [Required]
    public DateTime Fecha { get; set; }



}

