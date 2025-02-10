namespace TiendaDeVideojuegosWebApi.Models.Dto
{
    public class GetJuegoWithDesarrolladorDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public GetDesarrolladorDto Desarrollador { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }
    }
}
