using DotNet8WebAPI.Model;

namespace CotizaHoyAPI.Services.Cotizaciones
{
    public interface IvCotizacionesService
    {
        Task<List<CotizaHoyAPI.Model.vCotizaciones>> GetAll();
    //    Task<DotNet8WebAPI.Model.Cotizaciones?> GetByID(int id);
    //    Task<DotNet8WebAPI.Model.Cotizaciones?> Add(AddUpdateCotizaciones obj);
    //    Task<DotNet8WebAPI.Model.Cotizaciones?> Update(int id, AddUpdateCotizaciones obj);
    //    Task<bool> DeleteByID(int id);
    }
}
