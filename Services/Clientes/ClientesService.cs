using DotNet8WebAPI;
using DotNet8WebAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace CotizaHoyAPI.Services.Clientes
{
    public class ClientesService : IClientesService
    {
        private readonly OurHeroDbContext _db;

        public ClientesService(OurHeroDbContext db)
        {
            _db = db;
        }
        public async Task<List<DotNet8WebAPI.Model.Clientes>> GetAll()
        {

            return await _db.Clientes.ToListAsync();
        }

        public async Task<DotNet8WebAPI.Model.Clientes?> GetByID(int id)
        {
            return await _db.Clientes.FirstOrDefaultAsync(prod => prod.Id == id);
        }

        public async Task<DotNet8WebAPI.Model.Clientes?> Add(AddUpdateClientes obj)
        {
            var addHero = new DotNet8WebAPI.Model.Clientes()
            {
                Nombres = obj.Nombres,
                ApellidoPaterno = obj.ApellidoPaterno,
                ApellidoMaterno = obj.ApellidoMaterno,
            };

            _db.Clientes.Add(addHero);
            var result = await _db.SaveChangesAsync();
            return result >= 0 ? addHero : null;
        }

        public async Task<DotNet8WebAPI.Model.Clientes?> Update(int id, AddUpdateClientes obj)
        {
            var hero = await _db.Clientes.FirstOrDefaultAsync(index => index.Id == id);
            if (hero != null)
            {
                hero.Nombres = obj.Nombres;
                hero.ApellidoPaterno = obj.ApellidoPaterno;
                hero.ApellidoMaterno = obj.ApellidoMaterno;

                var result = await _db.SaveChangesAsync();
                return result >= 0 ? hero : null;
            }
            return null;
        }

        public async Task<bool> DeleteByID(int id)
        {
            var hero = await _db.Clientes.FirstOrDefaultAsync(index => index.Id == id);
            if (hero != null)
            {
                _db.Clientes.Remove(hero);
                var result = await _db.SaveChangesAsync();
                return result >= 0;
            }
            return false;
        }

    }
}
