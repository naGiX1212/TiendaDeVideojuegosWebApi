using Microsoft.EntityFrameworkCore;
using TiendaDeVideojuegosWebApi.Data;
using TiendaDeVideojuegosWebApi.Repository.Interfaces;

namespace TiendaDeVideojuegosWebApi.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly TiendaContext _tiendaContext;
        public UsuarioRepository(TiendaContext tiendaContext)
        {
            _tiendaContext = tiendaContext;
        }

        public void Add(Usuario usuario)
        {
            _tiendaContext.Add(usuario);
        }

        public ICollection<Usuario>? GetAll()
        {
            return _tiendaContext.Usuarios.Include(o => o.Carrito).ThenInclude(p => p.Juegos).ToList();
        }

        public Usuario? GetById(int usuarioId)
        {
            return _tiendaContext.Usuarios.Include(o => o.Carrito).ThenInclude(o => o.Juegos).Where(o => o.Id == usuarioId).FirstOrDefault();  
        }

        public void Update(Usuario usuario)
        {
            _tiendaContext.Usuarios.Update(usuario);
        }
        public void Remove(Usuario usuario)
        {
            _tiendaContext.Usuarios.Remove(usuario);
        }
        public void Save()
        {
            _tiendaContext.SaveChanges();
        }
        
    }
}
