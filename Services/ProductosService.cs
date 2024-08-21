using DotNet8WebAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace DotNet8WebAPI.Services
{
    public class ProductosService : IProductosService
    {
        private readonly OurHeroDbContext _db;
        public ProductosService(OurHeroDbContext db)
        {
            _db = db;
        }
        public async Task<List<Producto>> GetAll()
        {
          
            return await _db.Productos.ToListAsync();
        }

        public async Task<Producto?> GetByID(int id)
        {
            return await _db.Productos.FirstOrDefaultAsync(prod => prod.Id == id);
        }

        public async Task<Producto?> Add(AddUpdateProductos obj)
        {
            var addHero = new Producto()
            {
                Nombre = obj.Nombre,
                Marca = obj.Marca,
                Precio = obj.Precio,
            };

            _db.Productos.Add(addHero);
            var result = await _db.SaveChangesAsync();
            return result >= 0 ? addHero : null;
        }

        public async Task<Producto?> Update(int id, AddUpdateProductos obj)
        {
            var hero = await _db.Productos.FirstOrDefaultAsync(index => index.Id == id);
            if (hero != null)
            {
                hero.Nombre = obj.Nombre;
                hero.Marca = obj.Marca;
                hero.Precio = obj.Precio;

                var result = await _db.SaveChangesAsync();
                return result >= 0 ? hero : null;
            }
            return null;
        }

        public async Task<bool> DeleteByID(int id)
        {
            var hero = await _db.Productos.FirstOrDefaultAsync(index => index.Id == id);
            if (hero != null)
            {
                _db.Productos.Remove(hero);
                var result = await _db.SaveChangesAsync();
                return result >= 0;
            }
            return false;
        }

    }
}
