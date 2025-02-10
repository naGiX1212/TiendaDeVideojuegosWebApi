namespace TiendaDeVideojuegosWebApi.Models.Dto
{
    public class GetJuegoCarritoDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }

    }
}
