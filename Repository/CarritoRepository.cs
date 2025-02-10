using Microsoft.EntityFrameworkCore;
using TiendaDeVideojuegosWebApi.Data;
using TiendaDeVideojuegosWebApi.Models;
using TiendaDeVideojuegosWebApi.Repository.Interfaces;

namespace TiendaDeVideojuegosWebApi.Repository
{
    public class CarritoRepository : ICarritoRepository
    {
        private readonly TiendaContext _tiendaContext;
        public CarritoRepository(TiendaContext tiendaContext)
        {
            _tiendaContext = tiendaContext;
        }

        public void Add(Carrito carrito)
        {
            _tiendaContext.Add(carrito);
        }

        public ICollection<Carrito>? GetAll()
        {
            return _tiendaContext.Carritos.Include(o => o.Juegos).ThenInclude(o => o.Juego).ToList();
        }
        public Carrito? GetById(int carrito)
        {
            return _tiendaContext.Carritos.Include(o => o.Juegos).ThenInclude(o => o.Juego).Where(o => o.Id == carrito).FirstOrDefault();
        }

        public void Save()
        {
            _tiendaContext.SaveChanges();
        }

        public void Update(Carrito carrito)
        {
            _tiendaContext.Update(carrito);
        }
    }
}
