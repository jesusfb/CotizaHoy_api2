using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DotNet8WebAPI.Model;

public partial class Producto
{
   
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public string? Marca { get; set; }

    public decimal? Precio { get; set; }
}
