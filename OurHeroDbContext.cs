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
        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<Cotizaciones> Cotizaciones { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        
            modelBuilder.Entity<Producto>().HasKey(x => x.Id);
            modelBuilder.Entity<User>().HasKey(x => x.Id);
            modelBuilder.Entity<Clientes>().HasKey(x => x.Id);
            modelBuilder.Entity<Cotizaciones>().HasKey(x => x.Id);
            
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
            modelBuilder.Entity<Clientes>().HasData(
              new Clientes
              {
                  Id = 1,
                  Nombres = "Jesus",
                  ApellidoPaterno = "Figueroa",
                  ApellidoMaterno = "Figueroa",
                  Direccion = "Campo 5",
                  Telefono = "6645400921",
                  CorreoElectronico = "jfigueroa.beltran@gmail.com",

              });
            modelBuilder.Entity<Cotizaciones>().HasData(
              new Cotizaciones
              {
                  Id = 1,
                  ClienteFk = 1,
                  ProductoFk = 1,
                  Cantidad = 1,
                  Precio = 444,
                  CostoTotal = 444,
                  Iva = true,
                  Fecha = DateTime.Now

              });

            //modelBuilder.Entity<VAlumnosProgramaPromocion>(entity =>
            //{
            //    entity.HasKey(e => e.AlumnoFk)
            //  .HasName("PRIMARY");

            //    entity.ToView("vAlumnosProgramaPromocion");
            //    entity.Property(e => e.AlumnoNombre).HasColumnType("mediumtext");
            //    entity.Property(e => e.CorreoElectronico).HasMaxLength(256);
            //    entity.Property(e => e.Matricula).HasMaxLength(50);
            //    entity.Property(e => e.ProgramaNombre).HasColumnType("text");
            //    entity.Property(e => e.ProgramaNombreCorto).HasColumnType("text");
            //    entity.Property(e => e.ProgramaPromocionNombre).HasColumnType("text");
            //    entity.Property(e => e.PromocionNombre).HasColumnType("text");
            //});

        }

    }
}
