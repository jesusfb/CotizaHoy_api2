using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CotizaHoyAPI.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombres = table.Column<string>(type: "TEXT", nullable: false),
                    ApellidoPaterno = table.Column<string>(type: "TEXT", nullable: false),
                    ApellidoMaterno = table.Column<string>(type: "TEXT", nullable: false),
                    Direccion = table.Column<string>(type: "TEXT", nullable: false),
                    Telefono = table.Column<string>(type: "TEXT", nullable: false),
                    CorreoElectronico = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cotizaciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ClienteFk = table.Column<int>(type: "INTEGER", nullable: false),
                    ProductoFk = table.Column<int>(type: "INTEGER", nullable: false),
                    Cantidad = table.Column<double>(type: "REAL", nullable: false),
                    Precio = table.Column<decimal>(type: "TEXT", nullable: false),
                    CostoTotal = table.Column<decimal>(type: "TEXT", nullable: false),
                    Iva = table.Column<bool>(type: "INTEGER", nullable: false),
                    Fecha = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cotizaciones", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", nullable: true),
                    Marca = table.Column<string>(type: "TEXT", nullable: true),
                    Precio = table.Column<decimal>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                    Username = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    isActive = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Clientes",
                columns: new[] { "Id", "ApellidoMaterno", "ApellidoPaterno", "CorreoElectronico", "Direccion", "Nombres", "Telefono" },
                values: new object[] { 1, "Figueroa", "Figueroa", "jfigueroa.beltran@gmail.com", "Campo 5", "Jesus", "6645400921" });

            migrationBuilder.InsertData(
                table: "Cotizaciones",
                columns: new[] { "Id", "Cantidad", "ClienteFk", "CostoTotal", "Fecha", "Iva", "Precio", "ProductoFk" },
                values: new object[] { 1, 1.0, 1, 444m, new DateTime(2024, 8, 25, 23, 15, 1, 338, DateTimeKind.Local).AddTicks(7201), true, 444m, 1 });

            migrationBuilder.InsertData(
                table: "Productos",
                columns: new[] { "Id", "Marca", "Nombre", "Precio" },
                values: new object[] { 1, "Sabritas", "Paquetaxos", 15m });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FirstName", "LastName", "Password", "Username", "isActive" },
                values: new object[] { 1, "Jesus", "Figueroa", "$2a$11$.VDjrCaXGxR2k4mtUgc5H.lrsnBTTmEa7FjipBgyUYTNwI.zwBViO", "jfigueroa.beltran@gmail.com", false });
           
            migrationBuilder.Sql("CREATE VIEW vCotizaciones AS SELECT c.Id,cl.Nombres NombreCliente,p.Nombre NombreProducto,c.Cantidad,c.Precio,c.CostoTotal FROM Cotizaciones c INNER JOIN Clientes cl ON cl.Id = c.ClienteFk JOIN Productos p ON p.Id = c.ProductoFk;");

        }

    

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Cotizaciones");

            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "Users");

        }

    }
}
