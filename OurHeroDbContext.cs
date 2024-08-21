using DotNet8WebAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace DotNet8WebAPI
{
    public class OurHeroDbContext : DbContext
    {
        public OurHeroDbContext(DbContextOptions<OurHeroDbContext> options) : base(options)
        {

        }

        
        public DbSet<User> Users { get; set; }
        public DbSet<Producto> Productos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        
            modelBuilder.Entity<Producto>().HasKey(x => x.Id);
            modelBuilder.Entity<User>().HasKey(x => x.Id);

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    FirstName = "Jesus",
                    LastName = "Figueroa",
                    Username = "jfigueroa.beltran@gmail.com",
                    Password = BCrypt.Net.BCrypt.HashPassword("123qwe"),
                });
            modelBuilder.Entity<Producto>().HasData(
               new Producto
               {
                   Id = 1,
                   Nombre = "Paquetaxos",
                   Marca = "Sabritas",
                   Precio = Convert.ToDecimal(15.00),
                   
               });
        }

    }
}
