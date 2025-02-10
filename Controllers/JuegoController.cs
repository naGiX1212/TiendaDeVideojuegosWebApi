using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;
using TiendaDeVideojuegosWebApi.Data;
using TiendaDeVideojuegosWebApi.Models.Dto;
using TiendaDeVideojuegosWebApi.Repository.Interfaces;

namespace TiendaDeVideojuegosWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JuegoController : ControllerBase
    {
        
        private readonly IJuegoRepository _juegoRepository;
        private readonly IDesarrolladorRepository _desarrolladorRepository;
        public JuegoController(IJuegoRepository juegoRepository,IDesarrolladorRepository desarrolladorRepository)
        {
            _juegoRepository = juegoRepository;
            _desarrolladorRepository = desarrolladorRepository;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var juegos = _juegoRepository.GetAll();
            if (juegos == null)
            {
                return NotFound();
            }
            var response = juegos.Select(o => new GetJuegoWithDesarrolladorDto
            {
                Id = o.Id,
                Nombre = o.Nombre,
                Precio = o.Precio,
                Desarrollador = new GetDesarrolladorDto
                {
                    Id = o.Desarrollador.Id,
                    Nombre = o.Desarrollador.Nombre
                }
            }).ToList();
            return Ok(response);
        }
        /*  GET /Juego/id */
        [HttpGet("{juegoId:int}")]
        public IActionResult GetById(int juegoId)
        {
            var juego = _juegoRepository.GetById(juegoId);
            if (juego == null)
            {
                return NotFound();
            }
            var response = new GetJuegoWithDesarrolladorDto
            {
                Id = juego.Id,
                Nombre = juego.Nombre,
                Desarrollador = new GetDesarrolladorDto
                {
                    Id = juego.DesarrolladorId,
                    Nombre = juego.Desarrollador.Nombre
                },
                Precio = juego.Precio
            };
            return Ok(response);
        }
        [HttpPost]
        public IActionResult PostJuego(JuegoDto juegoDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            if (_juegoRepository.GetByName(juegoDto.Nombre) != null)
            {
                return BadRequest("El juego ya existe.");
            }
            var desarrollador = _desarrolladorRepository.GetById(juegoDto.DesarrolladorId);
            if (desarrollador == null)
            {
                return BadRequest("El desarrollador no existe.");
            }
            Juego juego = new Juego
            {
                Nombre = juegoDto.Nombre,
                DesarrolladorId = desarrollador.Id,
                Desarrollador = desarrollador,
                Precio = juegoDto.Precio,
                Stock = juegoDto.Stock
            };
            _juegoRepository.Add(juego);
            _juegoRepository.Save();
            return Ok(
                new { id = juego.Id, nombre = juego.Nombre,precio = juego.Precio, stock = juego.Stock });
        }
        [HttpPut("{juegoId:int}")]
        public IActionResult PutJuego(int juegoId,JuegoDto request)
        {
            var juego = _juegoRepository.GetById(juegoId);
            if (juego == null)
            {
                return NotFound();
            }
            juego.Nombre = request.Nombre;
            juego.Precio = request.Precio;
            juego.Stock = request.Stock;
            if(request.DesarrolladorId != juego.DesarrolladorId)
            {
                var desarrollador = _desarrolladorRepository.GetById(request.DesarrolladorId);
                if (desarrollador == null)
                {
                    return BadRequest("El desarrollador no existe.");
                }
                juego.DesarrolladorId = request.DesarrolladorId;
                juego.Desarrollador = desarrollador;
            }
            _juegoRepository.Update(juego);
            _juegoRepository.Save();

            return NoContent();

        }
        [HttpDelete("{juegoId:int}")]
        public IActionResult DeleteJuego(int juegoId)
        {
            var juego = _juegoRepository.GetById(juegoId);
            if (juego == null)
            {
                return NotFound();
            }
            _juegoRepository.Delete(juego);
            _juegoRepository.Save();
            return NoContent();
        }

    }
}
