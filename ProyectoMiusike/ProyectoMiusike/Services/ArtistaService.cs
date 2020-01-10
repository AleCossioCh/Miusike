using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ProyectoMiusike.Data;
using ProyectoMiusike.Data.Entity;
using ProyectoMiusike.Data.Repository;
using ProyectoMiusike.Exceptions;
using ProyectoMiusike.Models;

namespace ProyectoMiusike.Services
{
    public class ArtistaService : IArtistaService
    {
        private IWindAppRepository artistaRapository;
        private readonly IMapper mapper;
        public ArtistaService(IWindAppRepository windAppRepository, IMapper mapper)
        {
            this.artistaRapository = windAppRepository;
            this.mapper = mapper;
        }
        public async Task<Artista> ActualizarArtistaAsync(int id, Artista newArtista)
        {
            if (id != newArtista.Id)
            {
                throw new InvalidOperationException("URL id needs to be the same as Author id");
            }
            await ValidateArtista(id);

            newArtista.Id = id;
            var artistaEntity = mapper.Map<ArtistaEntity>(newArtista);
            artistaRapository.UpdateArtistaAsync(artistaEntity);
            if (await artistaRapository.SaveChangesAsync())
            {
                return mapper.Map<Artista>(artistaEntity);
            }

            throw new Exception("There were an error with the DB");
        }
        
        private HashSet<string> allowedOrderByQueries = new HashSet<string>()
        {
            "id",
            "nombre",
            "edad",
            "biografia",
        };

        public async Task<bool> BorrarArtistaAsync(int id)
        {
            await ValidateArtista(id);
            await artistaRapository.DeleteArtistaAsync(id);
            if (await artistaRapository.SaveChangesAsync())
            {
                return true;
            }
            return false;
        }

        public async Task<Artista> CrearArtistaAsync(Artista newArtista)
        {
            var artistaEntity = mapper.Map<ArtistaEntity>(newArtista);

            artistaRapository.AddArtistaAsync(artistaEntity);
            if (await artistaRapository.SaveChangesAsync())
            {
                return mapper.Map<Artista>(artistaEntity);
            }

            throw new Exception("There were an error with the DB");
        }

        public async Task<Artista> ObtenerArtistaAsync(int id, bool showCaciones)
        {
            var artistaEntity = await artistaRapository.GetArtistasAsync(id, showCaciones);

            if (artistaEntity == null)
            {
                throw new NotFoundException("author not found");
            }

            return mapper.Map<Artista>(artistaEntity);
        }

        public async Task<IEnumerable<Artista>> ObtenerArtistasAsync(string orderBy, bool showCaciones)
        {
            orderBy = orderBy.ToLower();
            if (!allowedOrderByQueries.Contains(orderBy))
            {
                throw new InvalidOperationException($"Invalid \" {orderBy} \" orderBy query param. The allowed values are {string.Join(",", allowedOrderByQueries)}");
            }

            var artistaEntities = await artistaRapository.GetArtistas(orderBy, showCaciones);
            return mapper.Map<IEnumerable<Artista>>(artistaEntities);
        }

        private async Task ValidateArtista(int id)
        {
            var author = await artistaRapository.GetArtistasAsync(id);
            if (author == null)
            {
                throw new NotFoundException("invalid author to delete");
            }
            artistaRapository.DetachEntity(author);
        }
    }
}
