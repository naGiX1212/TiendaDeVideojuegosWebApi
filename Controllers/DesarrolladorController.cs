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
    public class DesarrolladorController : ControllerBase
    {
        private readonly IDesarrolladorRepository _desarrolladorRepository;
        public DesarrolladorController(IDesarrolladorRepository desarrolladorRepository)
        {
            _desarrolladorRepository = desarrolladorRepository;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var desarrolladores = _desarrolladorRepository.GetAll();
            if (!desarrolladores.Any())
            {
                return NotFound();
            }
            var response = desarrolladores.Select(o => new GetDesarrolladorWithJuegoDto
            {
                Id = o.Id,
                Nombre = o.Nombre,
                Juegos = o.Juegos.Select(j => new GetJuegoDto
                {
                    Id = j.Id,
                    Nombre = j.Nombre,
                    Precio = j.Precio,
                    Stock = j.Stock
                    
                }).ToList()


            }).ToList();
            return Ok(response);
        }
        [HttpGet("{desarrolladorId:int}")]
        public IActionResult GetById(int desarrolladorId)
        {
            

            var desarrollador = _desarrolladorRepository.GetById(desarrolladorId);
            if (desarrollador == null)
            {
                return NotFound();
            }
            var response = new GetDesarrolladorWithJuegoDto
            {
                Id = desarrollador.Id,
                Nombre = desarrollador.Nombre,
                Juegos = desarrollador.Juegos.Select(j => new GetJuegoDto
                {
                    Id = j.Id,
                    Nombre = j.Nombre,
                    Precio = j.Precio,
                    Stock = j.Stock

                }).ToList()
            };

            return Ok(response);
        }
        [HttpPost]
        public IActionResult PostDesarrollador(CreateDesarrolladorDto desarrolladorDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (_desarrolladorRepository.GetByName(desarrolladorDto.Nombre) == null)
            {
                return BadRequest("El desarrollador ya existe.");
            }
            Desarrollador desarrollador = new Desarrollador
            {
                Nombre = desarrolladorDto.Nombre
            };

            _desarrolladorRepository.Add(desarrollador);

            _desarrolladorRepository.Save();    
            return Ok(new {id = desarrollador.Id ,nombre = desarrollador.Nombre });

        }
        [HttpDelete("{desarrolladorId:int}")]
        public IActionResult DeleteDesarrollador(int desarrolladorId)
        {
            var desarrollador = _desarrolladorRepository.GetById(desarrolladorId);
            if (desarrollador == null)
            {
                return NotFound();
            }
            if(desarrollador.Juegos != null && desarrollador.Juegos.Any() == true)
            {
                return BadRequest("El desarrollador tiene juegos asociados.");
            }
            _desarrolladorRepository.Remove(desarrollador);
            _desarrolladorRepository.Save();
            return Ok();
        }
        [HttpPut("{desarrolladorId:int}")]
        public IActionResult PutDesarrollador(int desarrolladorId, [FromBody]CreateDesarrolladorDto request)
        {
            var desarrollador = _desarrolladorRepository.GetById(desarrolladorId);
            if (desarrollador == null)
            {
                return NotFound();
            }
            desarrollador.Nombre = request.Nombre;

            _desarrolladorRepository.Update(desarrollador);

            _desarrolladorRepository.Save();

            return Ok(desarrollador);
        }

    }
}
