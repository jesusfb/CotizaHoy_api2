using CotizaHoyAPI.Services.Cotizaciones;
using DotNet8WebAPI;
using DotNet8WebAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace CotizaHoyAPI.Services.Cotizaciones
{
    public class CotizacionesService : ICotizacionesService
    {
        private readonly OurHeroDbContext _db;

        public CotizacionesService(OurHeroDbContext db)
        {
            _db = db;
        }
        public async Task<List<DotNet8WebAPI.Model.Cotizaciones>> GetAll()
        {
         
            return await _db.Cotizaciones.ToListAsync();
        }

        public async Task<DotNet8WebAPI.Model.Cotizaciones?> GetByID(int id)
        {
           return await _db.Cotizaciones.FirstOrDefaultAsync(prod => prod.Id == id);
        }
    
        //public async Task<DotNet8WebAPI.Model.Cotizaciones?> Add(AddUpdateCotizaciones obj)
        //{
        //    var addHero = new DotNet8WebAPI.Model.Cotizaciones()
        //    {
        //        Nombres = obj.Nombres,
        //        ApellidoPaterno = obj.ApellidoPaterno,
        //        ApellidoMaterno = obj.ApellidoMaterno,
        //    };

        //    _db.Cotizaciones.Add(addHero);
        //    var result = await _db.SaveChangesAsync();
        //    return result >= 0 ? addHero : null;
        //}

        //public async Task<DotNet8WebAPI.Model.Clientes?> Update(int id, AddUpdateClientes obj)
        //{
        //    var hero = await _db.Clientes.FirstOrDefaultAsync(index => index.Id == id);
        //    if (hero != null)
        //    {
        //        hero.Nombres = obj.Nombres;
        //        hero.ApellidoPaterno = obj.ApellidoPaterno;
        //        hero.ApellidoMaterno = obj.ApellidoMaterno;

        //        var result = await _db.SaveChangesAsync();
        //        return result >= 0 ? hero : null;
        //    }
        //    return null;
        //}

        //public async Task<bool> DeleteByID(int id)
        //{
        //    var hero = await _db.Clientes.FirstOrDefaultAsync(index => index.Id == id);
        //    if (hero != null)
        //    {
        //        _db.Clientes.Remove(hero);
        //        var result = await _db.SaveChangesAsync();
        //        return result >= 0;
        //    }
        //    return false;
        //}

    }
}
