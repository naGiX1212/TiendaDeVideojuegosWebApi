namespace TiendaDeVideojuegosWebApi.Models.Dto
{
    public class JuegoDto
    {
        public string Nombre { get; set; } = string.Empty;
        public int DesarrolladorId { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }
    }
}
