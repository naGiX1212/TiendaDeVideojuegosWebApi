using Microsoft.EntityFrameworkCore;
using TiendaDeVideojuegosWebApi.Repository;
using TiendaDeVideojuegosWebApi.Repository.Interfaces;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<TiendaContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ICarritoJuegoRepository, CarritoJuegoRepository>();
builder.Services.AddScoped<IDesarrolladorRepository, DesarrolladorRepository>();
builder.Services.AddScoped<IJuegoRepository, JuegoRepository>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<ICarritoRepository, CarritoRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.MapControllers();

app.Run();
