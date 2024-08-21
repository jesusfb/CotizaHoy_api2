using DotNet8WebAPI.Model;

namespace CotizaHoyAPI.Services.Clientes
{
    public interface IClientesService
    {
        Task<List<DotNet8WebAPI.Model.Clientes>> GetAll();
        Task<DotNet8WebAPI.Model.Clientes?> GetByID(int id);
        Task<DotNet8WebAPI.Model.Clientes?> Add(AddUpdateClientes obj);
        Task<DotNet8WebAPI.Model.Clientes?> Update(int id, AddUpdateClientes obj);
        Task<bool> DeleteByID(int id);
    }
}
