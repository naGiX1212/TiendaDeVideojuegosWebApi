using System.ComponentModel.DataAnnotations;

namespace TiendaDeVideojuegosWebApi.Data
{
    public class Desarrollador
    {
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; } = string.Empty;


        public ICollection<Juego>? Juegos { get; set; } = null;
    }
}