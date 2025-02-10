using Microsoft.EntityFrameworkCore;
using TiendaDeVideojuegosWebApi.Data;
using TiendaDeVideojuegosWebApi.Models;

public class TiendaContext : DbContext
{
public TiendaContext(DbContextOptions<TiendaContext> options) : base(options)
    {
        
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Carrito>()
            .HasOne(c => c.Usuario)
            .WithOne(u => u.Carrito)
            .HasForeignKey<Carrito>(c => c.UsuarioId); 
        
        modelBuilder.Entity<CarritoJuego>()
            .HasKey(cj => new { cj.CarritoId, cj.JuegoId });
        modelBuilder.Entity<Usuario>().HasOne(o => o.Carrito).WithOne(o => o.Usuario).OnDelete(DeleteBehavior.Cascade);



    }
    public DbSet<Carrito> Carritos { get; set; }
    public DbSet<Desarrollador> Desarrolladores { get; set; }
    public DbSet<Juego> Juegos { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<CarritoJuego> CarritoJuegos { get; set; }


}