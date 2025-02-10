using TiendaDeVideojuegosWebApi.Data;
using TiendaDeVideojuegosWebApi.Models;

namespace TiendaDeVideojuegosWebApi.Repository.Interfaces
{
    public interface ICarritoRepository
    {
        void Add(Carrito carrito);  
        ICollection<Carrito>? GetAll();
        Carrito? GetById(int carritoId);
        void Save();
        void Update(Carrito carrito);
    }
}
