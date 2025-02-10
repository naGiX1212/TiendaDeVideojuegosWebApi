using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TiendaDeVideojuegosWebApi.Data;
using TiendaDeVideojuegosWebApi.Models.Dto;
using TiendaDeVideojuegosWebApi.Repository.Interfaces;

namespace TiendaDeVideojuegosWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly ICarritoRepository _carritoRepository;

        public UsuarioController(IUsuarioRepository usuarioRepository,ICarritoRepository carritoRepository)
        {
            _usuarioRepository = usuarioRepository;
            _carritoRepository = carritoRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var usuarios = _usuarioRepository.GetAll();
            if(usuarios.Count == 0)
            {
                return NotFound();
            }
            
            var usuariosDto = usuarios.Select(u => new GetUsuarioDto
            {
                Id = u.Id,
                Nombre = u.Nombre,
                CarritoId = u.Carrito.Id

            }).ToList();
            return Ok(usuariosDto);
        }
        [HttpGet("{usuarioId:int}")]
        public IActionResult GetById(int usuarioId)
        {
            var usuario = _usuarioRepository.GetById(usuarioId);
            if (usuario == null)
            {
                return NotFound();
            }
            var usuarioDto = new GetUsuarioDto
            {
                Id = usuario.Id,
                Nombre = usuario.Nombre,
                CarritoId = usuario.Carrito.Id
            };
            return Ok(usuarioDto);
        }
        [HttpGet("/{id:int}/Carrito")]
        public IActionResult GetUserCarrito(int id)
        {
            var usuario = _usuarioRepository.GetById(id);


            if (usuario == null || usuario.Carrito == null)
            {
                return NotFound();
            }
           var response = new GetUsuarioCarrito
           {
               Id = usuario.Id,
               Nombre = usuario.Nombre,
               Carrito = new GetCarritoDto
               {
                   Id = usuario.Carrito.Id,
                   UsuarioId = usuario.Carrito.UsuarioId,
                   Juegos = usuario.Carrito.Juegos.Select(j => new GetJuegoCarritoDto
                   {
                       Id = j.Juego.Id,
                       Nombre = j.Juego.Nombre,
                       Precio = j.Juego.Precio,
                       Cantidad = j.Cantidad
                   }).ToList(),
                   Total = usuario.Carrito.Juegos.Sum(j => j.Juego.Precio * j.Cantidad)
               }

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
            if(usuario.Carrito != null)
            {
                return BadRequest();
            }
            var carrito = new Carrito
            {
                UsuarioId = usuario.Id,
                Usuario = usuario,
                Juegos = null

            };
            usuario.Carrito = carrito;
            _carritoRepository.Add(carrito);
            _usuarioRepository.Update(usuario);
            _usuarioRepository.Save();///GUARDA LOS 2
            return Ok(new {Id = usuario.Id,Nombre = usuario.Nombre ,CarritoId = carrito.Id});
        }
        [HttpPost]
        public IActionResult PostUsuario(CreateUsuarioDto usuarioDto)
        {
            if(!ModelState.IsValid)
            { return BadRequest(); }
            if (usuarioDto == null)
            {
                return BadRequest();
            }
            var usuario = new Usuario
            {
                Nombre = usuarioDto.Nombre
            };
            _usuarioRepository.Add(usuario);
            _usuarioRepository.Save();
            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteUsuario([FromQuery] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var usuario = _usuarioRepository.GetById(id);
            if (usuario == null)
            {
                return NotFound();
            }
            

            _usuarioRepository.Remove(usuario);

            _usuarioRepository.Save();

            return Ok();

        }
        [HttpPut]
        public IActionResult PutUsuario([FromQuery]int id,[FromBody] CreateUsuarioDto usuarioDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var usuario = _usuarioRepository.GetById(id);
            if (usuario == null)
            {
                return NotFound();
            }
            usuario.Nombre = usuarioDto.Nombre;
            _usuarioRepository.Update(usuario);
            _usuarioRepository.Save();
            return Ok();
        }
    }
}
