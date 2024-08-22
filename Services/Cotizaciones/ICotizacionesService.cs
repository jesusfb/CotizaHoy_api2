using DotNet8WebAPI.Model;

namespace CotizaHoyAPI.Services.Cotizaciones
{
    public interface ICotizacionesService
    {
        Task<List<DotNet8WebAPI.Model.Cotizaciones>> GetAll();
        Task<DotNet8WebAPI.Model.Cotizaciones?> GetByID(int id);
        //Task<DotNet8WebAPI.Model.Cotizaciones?> Add(AddUpdateCotizaciones obj);
        //Task<DotNet8WebAPI.Model.Cotizaciones?> Update(int id, AddUpdateCotizaciones obj);
        //Task<bool> DeleteByID(int id);
    }
}
