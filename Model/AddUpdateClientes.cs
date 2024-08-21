namespace DotNet8WebAPI.Model
{
    public class AddUpdateClientes
    {
        public required string Nombres { get; set; }
        public string ApellidoPaterno { get; set; } = string.Empty;
        public string ApellidoMaterno { get; set; } = string.Empty;
        public string Direccion { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public string CorreoElectronico { get; set; } = string.Empty;
        
    }
}
