using Microsoft.EntityFrameworkCore;
using TiendaDeVideojuegosWebApi.Data;
using TiendaDeVideojuegosWebApi.Repository.Interfaces;

namespace TiendaDeVideojuegosWebApi.Repository
{
    public class DesarrolladorRepository : IDesarrolladorRepository
    {
        private readonly TiendaContext _tiendaContext;
        public DesarrolladorRepository(TiendaContext tiendaContext)
        {
            _tiendaContext = tiendaContext;
        }
        public void Add(Desarrollador desarrollador)
        {
            _tiendaContext.Desarrolladores.Add(desarrollador);
        }

        public void Delete(Desarrollador desarrollador)
        {
            _tiendaContext.Remove(desarrollador);
        }

        public IEnumerable<Desarrollador>? GetAll()
        {
            return _tiendaContext.Desarrolladores.Include(o => o.Juegos).ToList();
        }

        public Desarrollador? GetById(int id)
        {
            return _tiendaContext.Desarrolladores.Include(o => o.Juegos).Where(o => o.Id == id).FirstOrDefault();
        }

        public void Update(Desarrollador desarrollador)
        {
            _tiendaContext.Update(desarrollador);
        }
        public void Save()
        {
            _tiendaContext.SaveChanges();
        }

        public Desarrollador? GetByName(string nombre)
        {
            return _tiendaContext.Desarrolladores.Include(o => o.Juegos).Where(o => o.Nombre == nombre).FirstOrDefault();
        }

        public void Remove(Desarrollador desarrollador)
        {
            _tiendaContext.Desarrolladores.Remove(desarrollador);
        }
    }
}
