using System.Text.Json.Serialization;

namespace TiendaDeVideojuegosWebApi.Models.Dto
{
    public class GetJuegoDto
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public decimal Precio { get; set; }

        public int Stock { get; set; }
    }
}
