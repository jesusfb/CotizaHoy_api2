namespace DotNet8WebAPI.Model
{
    public class AddUpdateProductos
    {
        public required string Nombre { get; set; }
        public string Marca { get; set; } = string.Empty;
        public decimal? Precio { get; set; } 
    }
}
