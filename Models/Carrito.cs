using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using TiendaDeVideojuegosWebApi.Models;

namespace TiendaDeVideojuegosWebApi.Data
{
    public class Carrito
    {
        public int Id { get; set; }

        [Required]
        public int UsuarioId { get; set; } 

        public Usuario Usuario { get; set; } 

        public ICollection<CarritoJuego>? Juegos { get; set; } = new List<CarritoJuego>();
    }
}
