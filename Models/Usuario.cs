using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TiendaDeVideojuegosWebApi.Data
{
    public class Usuario
    {
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; } = string.Empty;

        public Carrito Carrito { get; set; }



    }
}
