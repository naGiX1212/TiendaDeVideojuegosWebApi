using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TiendaDeVideojuegosWebApi.Data;
using TiendaDeVideojuegosWebApi.Models;
using TiendaDeVideojuegosWebApi.Models.Dto;
using TiendaDeVideojuegosWebApi.Repository.Interfaces;

namespace TiendaDeVideojuegosWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarritoController : ControllerBase
    {
        private readonly ICarritoRepository _carritoRepository;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IJuegoRepository _juegoRepository;
        private readonly ICarritoJuegoRepository _carritoJuegoRepository;
        public CarritoController(ICarritoRepository carritoRepository, IUsuarioRepository usuarioRepository,
            IJuegoRepository juegoRepository,ICarritoJuegoRepository carritoJuegoRepository)
        {
            _carritoRepository = carritoRepository;
            _usuarioRepository = usuarioRepository;
            _juegoRepository = juegoRepository;
            _carritoJuegoRepository = carritoJuegoRepository;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var carritos = _carritoRepository.GetAll();
            if (carritos == null)
            {
                return NotFound();
            }
            var response = carritos.Select(o => new GetCarritoDto
            {
                Id = o.Id,
                UsuarioId = o.UsuarioId,
                Juegos = o.Juegos.Select(j => new GetJuegoCarritoDto
                {
                    Id = j.Juego.Id,
                    Nombre = j.Juego.Nombre,
                    Precio = j.Juego.Precio,
                    Cantidad = j.Cantidad
                }).ToList(),
                Total = o.Juegos.Sum(j => j.Juego.Precio * j.Cantidad)

            }).ToList();
            return Ok(response);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var carrito = _carritoRepository.GetById(id);
            if (carrito == null)
            {
                return NotFound();
            }
            var response = new GetCarritoDto
            {
                Id = carrito.Id,
                UsuarioId = carrito.UsuarioId,
                Juegos = carrito.Juegos.Select(o => new GetJuegoCarritoDto
                {
                    Id = o.Juego.Id,
                    Nombre = o.Juego.Nombre,
                    Precio = o.Juego.Precio,
                    Cantidad = o.Cantidad

                }).ToList(),
                Total = carrito.Juegos.Sum(o => o.Juego.Precio * o.Cantidad)
            };
            return Ok(response);
        }
        [HttpPost("{userId:int}/CreateCarrito")]
        public IActionResult PostUserCarrito(int userId)
        {
            var usuario = _usuarioRepository.GetById(userId);
            if (usuario == null)
            {
                return NotFound();
            }
            if (usuario.Carrito != null)
            {
                return BadRequest();
            }
            var carrito = new Carrito
            {
                UsuarioId = userId
            };
            _carritoRepository.Add(carrito);
            _carritoRepository.Save();
            return Ok();
        }
        [HttpPost("{carritoId:int}/AddJuego")]
        public IActionResult PostCarritoJuego(int carritoId,[FromQuery]int juegoId)
        {
            var carrito = _carritoRepository.GetById(carritoId);
            if (carrito == null)
            {
                return NotFound();
            }

            var juego = _juegoRepository.GetById(juegoId);
            if (juego == null)
            {
                return NotFound();
            }
            var carritoJuego = _carritoJuegoRepository.GetByCarritoIdAndJuegoId(carritoId, juegoId);
            if (carritoJuego != null)
            {
                carritoJuego.Cantidad++;
                _carritoJuegoRepository.Update(carritoJuego);
            }
            else
            {
                carritoJuego = new CarritoJuego
                {
                    CarritoId = carritoId,
                    JuegoId = juegoId,
                    Cantidad = 1

                };
                _carritoJuegoRepository.Add(carritoJuego);
            }


            _carritoJuegoRepository.Save();
            return Ok();
        }


    }
}