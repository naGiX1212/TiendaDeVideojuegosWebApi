using Microsoft.EntityFrameworkCore;
using TiendaDeVideojuegosWebApi.Data;
using TiendaDeVideojuegosWebApi.Repository.Interfaces;

namespace TiendaDeVideojuegosWebApi.Repository
{
    public class JuegoRepository : IJuegoRepository
    {
        private readonly TiendaContext _tiendaContext;
        public JuegoRepository(TiendaContext tiendaContext)
        {
            _tiendaContext = tiendaContext;
        }
        public void Add(Juego juego)
        {
            _tiendaContext.Add(juego);
        }

        public void Delete(Juego juego)
        {
            _tiendaContext.Remove(juego);
        }

        public List<Juego>? GetAll()
        {
            return _tiendaContext.Juegos.Include(o => o.Desarrollador).ToList();
        }

        public Juego? GetById(int id)
        {
            return _tiendaContext.Juegos.Include(o => o.Desarrollador).Where(o => o.Id == id).FirstOrDefault();
        }
        
        public Juego? GetByName(string name)
        {
            return _tiendaContext.Juegos.Include(o => o.Desarrollador).Where(o => o.Nombre == name).FirstOrDefault();
        }

        public void Save()
        {
            _tiendaContext.SaveChanges();
        }

        public void Update(Juego juego)
        {
            _tiendaContext.Update(juego);
        }
    }
}
