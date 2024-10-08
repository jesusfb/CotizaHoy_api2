﻿using CotizaHoyAPI.Services.Cotizaciones;
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

        public async Task<DotNet8WebAPI.Model.Cotizaciones?> Add(AddUpdateCotizaciones obj)
        {
            var addHero = new DotNet8WebAPI.Model.Cotizaciones()
            {
                ClienteFk = obj.ClienteFk,
                ProductoFk = obj.ProductoFk,
                Cantidad = obj.Cantidad,
                Precio = obj.Precio,
                CostoTotal = obj.CostoTotal,    
                Iva = obj.Iva,
                Fecha = obj.Fecha,
          
            };

            _db.Cotizaciones.Add(addHero);
            var result = await _db.SaveChangesAsync();
            return result >= 0 ? addHero : null;
        }

        public async Task<DotNet8WebAPI.Model.Cotizaciones?> Update(int id, AddUpdateCotizaciones obj)
        {
            var hero = await _db.Cotizaciones.FirstOrDefaultAsync(index => index.Id == id);
            if (hero != null)
            {
                hero.ClienteFk = obj.ClienteFk;
                hero.ClienteFk = obj.ClienteFk;
                hero.Precio = obj.Precio;
                hero.Cantidad = obj.Cantidad;
                hero.CostoTotal = obj.CostoTotal;
              

                var result = await _db.SaveChangesAsync();
                return result >= 0 ? hero : null;
            }
            return null;
        }

        public async Task<bool> DeleteByID(int id)
        {
            var hero = await _db.Cotizaciones.FirstOrDefaultAsync(index => index.Id == id);
            if (hero != null)
            {
                _db.Cotizaciones.Remove(hero);
                var result = await _db.SaveChangesAsync();
                return result >= 0;
            }
            return false;
        }

    }
}
