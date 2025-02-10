namespace TiendaDeVideojuegosWebApi.Models.Dto
{
    public class GetDesarrolladorWithJuegoDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public ICollection<GetJuegoDto> Juegos { get; set; } = new List<GetJuegoDto>();
    }

}
