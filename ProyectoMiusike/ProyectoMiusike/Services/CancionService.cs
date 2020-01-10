using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ProyectoMiusike.Data.Entity;
using ProyectoMiusike.Data.Repository;
using ProyectoMiusike.Exceptions;
using ProyectoMiusike.Models;

namespace ProyectoMiusike.Services
{
    public class CancionService : ICancionService
    {
        private IWindAppRepository windAppRepository;
        private readonly IMapper mapper;

        public CancionService(IWindAppRepository windAppRepository, IMapper mapper)
        {
            this.windAppRepository = windAppRepository;
            this.mapper = mapper;
        }


        public async Task<Cacion> ActualizarCancionAsync(int artistaId, int id, Cacion cancion)
        {
            //await validarArtistaId(artistaId);
            //if (cancion.Id != null && cancion.Id != id)
            //{
            //    throw new InvalidOperationException("song URL id and song body id should be the same");
            //}

            var artista = await validarArtistaId(artistaId);
            if (id != cancion.Id && cancion.Id != null)
            {
                throw new Exception("Id of the cancion in URL needs to be the same that the object");
            }
            if (artistaId != artista.Id)
            {
                throw new Exception("The id of Artist isn't correct");
            }
 
            cancion.Id = id;
            var cacionEntity = mapper.Map<CacionEntity>(cancion);   
            windAppRepository.UpdateCancion(cacionEntity);
            if (await windAppRepository.SaveChangesAsync())
                return mapper.Map<Cacion>(cacionEntity);

            throw new Exception("There were an error with the DB");
        }

        public async Task<bool> EliminarCancion(int artistaId, int id)
        {
            //validarArtistaId(artistaId);
            ////var cacionesDeleted = windAppRepository.GetCanciones().SingleOrDefault(b => b.Id == id);
            //if (cacionesDeleted == null)
            //{
            //    throw new NotFoundException("invalid song to delete");
            //}
            var val = await validarArtistaId(artistaId);
            await windAppRepository.DeleteCancion(id);
            if (await windAppRepository.SaveChangesAsync())
                return true;
            return false;
            //return windAppRepository.DeleteCancion(id);
        }

        public async Task<Cacion> AñadirCancionAsync(int artistaId, Cacion cancion)
        {
            if (cancion.ArtistaId != null && artistaId != cancion.ArtistaId)
            {
                throw new InvalidOperationException("URL artisttt id and artistId should be equal");
            }
            cancion.ArtistaId = artistaId;

            var artistaEntity = await validarArtistaId(artistaId);
            
            var cancionEntity = mapper.Map<CacionEntity>(cancion);
            cancionEntity.Artista = artistaEntity;
            //mapper.Map(cancion, cacnionEntity);

            windAppRepository.CreateCancion(cancionEntity);
            if (await windAppRepository.SaveChangesAsync())
            {
                return mapper.Map<Cacion>(cancionEntity);
            }
            throw new Exception("There were an error with the DB");
        }

        public async Task<IEnumerable<Cacion>> ObtenerCanciones(int artistaId)
        {
            var res = await windAppRepository.GetCanciones(artistaId);
            var cancioness = mapper.Map<IEnumerable<Cacion>>(res);
            foreach (Cacion d in cancioness)
            {
                d.ArtistaId = artistaId;
            }
            return cancioness;
            //return windAppRepository.GetCanciones(artistaId);
        }

        public async Task<Cacion> ObtenerCancionAsync(int artistaId, int id)
        {
            var res =await validarArtistaId(artistaId);
            var cacionEntity = await windAppRepository.GetCancionAsync(id);
            if (cacionEntity == null)
            {
                throw new Exception("Not Found");
            }
            var songe = mapper.Map<Cacion>(cacionEntity);
            songe.ArtistaId = artistaId;
            return songe;
        }

        private async Task<ArtistaEntity> validarArtistaId(int id)
        {
            var artista = await windAppRepository.GetArtistasAsync(id);
            if (artista == null)
            {
                throw new NotFoundException($"cannot found artista with id {id}");
            }
            windAppRepository.DetachEntity(artista);
            return artista;
        }

        private async Task<bool> ValidaArtistaYCacion(int artistaId, int cancionId)
        {

            var artista = await windAppRepository.GetArtistasAsync(artistaId);
            if (artista == null)
            {
                throw new NotFoundException($"cannot found artista with id {artistaId}");
            }

            var cancion = await windAppRepository.GetCancionAsync(cancionId, true);
            if (cancion == null || cancion.Artista.Id != artistaId)
            {
                throw new NotFoundException($"Songe not found with id {cancionId} for Artttist {artistaId}");
            }

            return true;
        }

        public async Task<bool> ActualizarVotoAsync(int artistaId, int id, Cacion cancion)
        {
            var artista = await validarArtistaId(artistaId);

            if (artistaId != artista.Id)
            {
                throw new Exception("The id of Artist isn't correct");
            }
            cancion.Id = id;
            var cancionEntity = mapper.Map<CacionEntity>(cancion);
            windAppRepository.UpdateVotos(cancionEntity, 1);
            if (await windAppRepository.SaveChangesAsync())
                return true;

            throw new Exception("There were an error with the DB");
        }

        public async Task<bool> ActualizarVentaAsync(int artistaId, int id)
        {
            var artista = await validarArtistaId(artistaId);

            if (artistaId != artista.Id)
            {
                throw new Exception("The id of Artist isn't correct");
            }

            windAppRepository.UpdateVentas(id, 1);
            if (await windAppRepository.SaveChangesAsync())
                return true;

            throw new Exception("There were an error with the DB");
        }
    }
}
