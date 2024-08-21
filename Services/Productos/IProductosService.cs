using DotNet8WebAPI.Model;

namespace CotizaHoyAPI.Services.Productos
{
    public interface IProductosService
    {
        Task<List<Producto>> GetAll();
        Task<Producto?> GetByID(int id);
        Task<Producto?> Add(AddUpdateProductos obj);
        Task<Producto?> Update(int id, AddUpdateProductos obj);
        Task<bool> DeleteByID(int id);
    }
}
