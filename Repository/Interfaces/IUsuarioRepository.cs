using TiendaDeVideojuegosWebApi.Data;

namespace TiendaDeVideojuegosWebApi.Repository.Interfaces
{
    public interface IUsuarioRepository 
    {
        Usuario? GetById(int usuarioId);
        ICollection<Usuario>? GetAll();

        void Add(Usuario usuario);
        void Save();
        void Update(Usuario usuario);
        void Remove(Usuario usuario);
    }
}
