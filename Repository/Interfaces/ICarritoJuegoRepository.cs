using TiendaDeVideojuegosWebApi.Models;

namespace TiendaDeVideojuegosWebApi.Repository.Interfaces
{
    public interface ICarritoJuegoRepository
    {
        public CarritoJuego? GetById(int id);
        public CarritoJuego? GetByCarritoIdAndJuegoId(int carritoId, int juegoId);
        public List<CarritoJuego>? GetAll();
        public void Add(CarritoJuego carritoJuego);
        public void Update(CarritoJuego carritoJuego);
        public void Delete(CarritoJuego carritoJuego);
        public void Save();

    }
}
