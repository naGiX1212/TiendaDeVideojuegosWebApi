using TiendaDeVideojuegosWebApi.Data;

namespace TiendaDeVideojuegosWebApi.Repository.Interfaces
{
    public interface IDesarrolladorRepository
    {
        void Add(Desarrollador desarrollador);
        IEnumerable<Desarrollador>? GetAll();
        Desarrollador? GetById(int id);
        void Update(Desarrollador desarrollador);

        void Save();
        Desarrollador? GetByName(string nombre);
        void Remove(Desarrollador desarrollador);
    }
}
