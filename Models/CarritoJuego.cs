using TiendaDeVideojuegosWebApi.Data;

namespace TiendaDeVideojuegosWebApi.Models
{
    public class CarritoJuego
    {
        public int CarritoId { get; set; }

        
        public Carrito Carrito { get; set; }

        public int JuegoId { get; set; }
        public Juego Juego { get; set; }

        public int Cantidad { get; set; } // Número de veces que el usuario agregó este juego
    }
}
