namespace DotNet8WebAPI.Model
{
    public class AddUpdateCotizaciones
    {
        public int ClienteFk { get; set; }


        public int ProductoFk { get; set; }


        public double Cantidad { get; set; }


        public decimal Precio { get; set; }


        public decimal CostoTotal { get; set; }


        public bool Iva { get; set; }


        public DateTime Fecha { get; set; }

    }
}
