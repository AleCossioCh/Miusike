using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoMiusike.Exceptions;
using ProyectoMiusike.Models;
using ProyectoMiusike.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoMiusike.Controllers
{
    [Route("api/artista/{artistaId:int}/canciones")]
    //[Route("api/canciones")]
    public class CancionController : ControllerBase
    {
        private ICancionService cancionService;

        public CancionController(ICancionService cancionService)
        {
            this.cancionService = cancionService;
        }

        [HttpGet()]
        public async Task<ActionResult<IEnumerable<Cacion>>> getCanciones(int artistaId)
        {
            try
            {
                return Ok(await cancionService.ObtenerCanciones(artistaId));
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }

        }

        [HttpPost()]
        public async Task<ActionResult<Cacion>> PostCancion(int artistaId, [FromBody] Cacion cancion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var newSonge = await cancionService.AñadirCancionAsync(artistaId, cancion);
                return Created($"/api/artista/{artistaId}/canciones/{cancion.Id}", newSonge);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Cacion>> getCancion(int artistaId, int id)
        {
            try
            {
                var songe = await cancionService.ObtenerCancionAsync(artistaId, id);
                return Ok(songe);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpDelete("{cancionId:int}")]
        public async Task<ActionResult<bool>> DeleteCancion(int cancionId, int artistaId)
        {
            try
            {
                var NoMoreSonge = await cancionService.EliminarCancion(artistaId, cancionId);
                return Ok(NoMoreSonge);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Something bad happened: {ex.Message}");
            }
        }



        [HttpPut("{cancionId:int}")]
        public async Task<ActionResult<Cacion>> PutCancion(int artistaId, int cancionId, [FromBody] Cacion cancion)
        {
            try
            {
                return Ok(await cancionService.ActualizarCancionAsync(artistaId, cancionId, cancion));
            }
            catch
            {
                throw new Exception("Not possible to show");
            }
        }
        [HttpPut("{cancionId:int}/voto")]
        public async Task<ActionResult<bool>> PutCancionVoto(int artistaId, int cancionId, [FromBody] Cacion cancion)
        {
            try
            {
                return Ok(await cancionService.ActualizarVotoAsync(artistaId, cancionId, cancion));
            }
            catch
            {
                throw new Exception("Not possible to show");
            }
        }
        [HttpPut("{cancionId:int}/venta")]
        public async Task<ActionResult<bool>> PutCancionVenta(int artistaId, int cancionId)
        {
            try
            {
                return Ok(await cancionService.ActualizarVentaAsync(artistaId, cancionId));
            }
            catch
            {
                throw new Exception("Not possible to show");
            }
        }
    }
}
