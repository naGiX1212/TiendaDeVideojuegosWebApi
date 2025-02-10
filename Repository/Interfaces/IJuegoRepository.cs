using TiendaDeVideojuegosWebApi.Data;

namespace TiendaDeVideojuegosWebApi.Repository.Interfaces
{
    public interface IJuegoRepository
    {
        public Juego? GetById(int id);

        public Juego? GetByName(string name);
        public List<Juego>? GetAll();

        public void Add(Juego juego);

        public void Update(Juego juego);

        public void Delete(Juego juego);

        public void Save();
    }
}
