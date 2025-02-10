using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace TiendaDeVideojuegosWebApi.Data
{
    public class Juego
    {
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; } = string.Empty;

        public int DesarrolladorId { get; set; } // Clave foránea al Desarrollador
        public Desarrollador Desarrollador { get; set; } 

        [Required]
        [Precision(18, 2)]
        public decimal Precio { get; set; }

        public int Stock { get;set; }

    }
}
