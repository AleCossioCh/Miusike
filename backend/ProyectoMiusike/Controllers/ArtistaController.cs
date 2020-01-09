using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoMiusike.Models;
using ProyectoMiusike.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Routing;
using ProyectoMiusike.Exceptions;

namespace ProyectoMiusike.Controllers
{
    [Route("api/[controller]")]
    public class ArtistaController : ControllerBase
    {
        private IArtistaService artistaService;
        private ICancionService cancionService;

        public ArtistaController(IArtistaService artistaService, ICancionService cancionService)
        {
            this.artistaService = artistaService;
            this.cancionService= cancionService;

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Artista>>> Get(string orderBy = "Id", bool showCanciones = false)
        {
            try
            {
                return Ok(await artistaService.ObtenerArtistasAsync(orderBy, showCanciones));
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Something bad happened: {ex.Message}");

            }
        }
        [HttpGet("allcanciones/{orderBy:int}")]
        public async Task<ActionResult<IEnumerable<Cacion>>> GetCacniones(int orderBy)
        {
            try
            {
                return Ok(await cancionService.ObtenerTodasCanciones(orderBy));
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Something bad happened: {ex.Message}");

            }
        }
        [HttpGet("{artistaID:int}")]
        public async Task<ActionResult<Artista>> Get(int artistaID, bool showCanciones = true)
        {
            try
            {
                var artista = await this.artistaService.ObtenerArtistaAsync(artistaID, showCanciones);
                return Ok(artista);

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
        [HttpPost]
        public async Task<ActionResult<Artista>> Post([FromBody] Artista artista)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newArtista = await this.artistaService.CrearArtistaAsync(artista);
            return Created($"/api/artistas/{newArtista.Id}", newArtista);
        }

        [HttpDelete("{artistaId:int}")]
        public async Task<ActionResult<bool>> Delete(int artistaId)
        {
            try
            {
                return Ok(await this.artistaService.BorrarArtistaAsync(artistaId));
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

        [HttpPut("{artistaId}")]
        public async Task<ActionResult<Artista>> Update(int artistaId, [FromBody] Artista artista)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var artistaUpdated = await this.artistaService.ActualizarArtistaAsync(artistaId, artista);
                return Ok(artistaUpdated);
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
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Something bad happened: {ex.Message}");
            }
        }
    }
}
