using TiendaDeVideojuegosWebApi.Models;
using TiendaDeVideojuegosWebApi.Repository.Interfaces;

namespace TiendaDeVideojuegosWebApi.Repository
{
    public class CarritoJuegoRepository : ICarritoJuegoRepository
    {
        private readonly TiendaContext _tiendaContext;
        public CarritoJuegoRepository(TiendaContext tiendaContext)
        {
            _tiendaContext = tiendaContext;
        }
        public void Add(CarritoJuego carritoJuego)
        {
            _tiendaContext.CarritoJuegos.Add(carritoJuego);
        }
        public void Delete(CarritoJuego carritoJuego)
        {
            _tiendaContext.CarritoJuegos.Remove(carritoJuego);
        }
        public List<CarritoJuego> GetAll()
        {
            return _tiendaContext.CarritoJuegos.ToList();
        }
        public CarritoJuego GetById(int id)
        {
            return _tiendaContext.CarritoJuegos.Find(id);
        }
        public CarritoJuego GetByCarritoIdAndJuegoId(int carritoId, int juegoId)
        {
            return _tiendaContext.CarritoJuegos.Where(o => o.CarritoId == carritoId && o.JuegoId == juegoId).SingleOrDefault();
        }
        public void Save()
        {
            _tiendaContext.SaveChanges();
        }
        public void Update(CarritoJuego carritoJuego)
        {
            _tiendaContext.CarritoJuegos.Update(carritoJuego);
        }


    }
}
