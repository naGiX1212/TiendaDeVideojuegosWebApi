namespace TiendaDeVideojuegosWebApi.Models.Dto
{
    public class GetCarritoDto
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }

        public ICollection<GetJuegoCarritoDto> Juegos { get; set; } = new List<GetJuegoCarritoDto>();

        public decimal Total { get; set; }
    }


}
