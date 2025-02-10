namespace TiendaDeVideojuegosWebApi.Models.Dto
{
    public class GetUsuarioCarrito
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public GetCarritoDto Carrito{ get; set; }
}
}
