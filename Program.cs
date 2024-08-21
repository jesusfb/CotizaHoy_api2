using CotizaHoyAPI.Services.Clientes;
using CotizaHoyAPI.Services.Cotizaciones;
using CotizaHoyAPI.Services.Productos;
using DotNet8WebAPI;
using DotNet8WebAPI.Helpers;
using DotNet8WebAPI.Model;
using DotNet8WebAPI.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
string connectionString = builder.Configuration.GetConnectionString("OurHeroConnectionString");

builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));

builder.Services.AddDbContext<OurHeroDbContext>(options => options.UseSqlite(connectionString), ServiceLifetime.Singleton);

//builder.Services.AddIdentity<OurHeroDbContext, IdentityRole>(
//    options =>
//        options.Password = new PasswordOptions
//        {
//            RequireDigit = true,
//            RequiredLength = 6,
//            RequireLowercase = true,
//            RequireUppercase = true,
//            RequireNonAlphanumeric = false
//        });

//builder.Services.AddSingleton<IOurHeroService, OurHeroService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IProductosService, ProductosService>();
builder.Services.AddScoped<IClientesService, ClientesService>();
builder.Services.AddScoped<ICotizacionesService, CotizacionesService>();




//builder.Services.AddTransient<IOurHeroService, OurHeroService>();
//builder.Services.AddScoped<IOurHeroService, OurHeroService>();

builder.Services.AddSwaggerGen(swagger =>
{
    //This is to generate the Default UI of Swagger Documentation  
    swagger.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "CotizaHoy API",
        Description = "VELOZIDEA.NET"
    });
    // To Enable authorization using Swagger (JWT)  
    swagger.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        //Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345abcdef\"",
    });
    swagger.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                          new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                            new string[] {}

                    }
                });
});


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<OurHeroDbContext>();
    context.Database.Migrate();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseMiddleware<JwtMiddleware>();
app.MapControllers();
app.UseSwagger();
app.UseSwaggerUI();

//app.UseSwaggerUI(options =>
//{
//    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
//    options.RoutePrefix = string.Empty;
//});


app.Run();
