using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProyectoMiusike.Data.Entity;
using ProyectoMiusike.Models;
using Microsoft.EntityFrameworkCore;

namespace ProyectoMiusike.Data.Repository
{
    public class WindAppRepository : IWindAppRepository
    {

        private WindAppDBContext windDBContext;

        public WindAppRepository(WindAppDBContext windAppDBContext)
        {
            this.windDBContext = windAppDBContext;
        }

        public async Task<ArtistaEntity> GetArtistasAsync(int id, bool showCaciones)
        {
            IQueryable<ArtistaEntity> query = windDBContext.Artistas;
            query = query.AsNoTracking();
            //if (showCaciones)
            //{
            //    query = query.Include(a => a.Canciones);
            //}

            return await query.SingleOrDefaultAsync(a => a.Id == id);
        }
        public async Task<IEnumerable<ArtistaEntity>> GetArtistas(string orderBy, bool showCaciones)
        {
            IQueryable<ArtistaEntity> query = windDBContext.Artistas;
            if (showCaciones)
            {
                query = query.Include(a => a.Canciones);
            }
            switch (orderBy)
            {
                case "id":
                    query = query.OrderBy(a => a.Id);
                    break;
                case "nombre":
                    query = query.OrderBy(a => a.nombre);
                    break;
                case "edad":
                    query = query.OrderBy(a => a.edad);
                    break;
                default:
                    break;
            }

            return await query.ToArrayAsync();
        }

        public void AddArtistaAsync(ArtistaEntity artista)
        {
            var saveArtista = windDBContext.Artistas.Add(artista);
        }       

        public void UpdateArtistaAsync(ArtistaEntity artista)
        {
            //windDBContext.Artistas.Update(artista);
            var artistaPut = windDBContext.Artistas.Single(c => c.Id == artista.Id);
            artistaPut.nombre = artista.nombre;
            artistaPut.edad = artista.edad;
            artistaPut.biografia = artista.biografia;
            artistaPut.imgPath = artista.imgPath;
        }

        public async Task DeleteArtistaAsync(int id)
        {
            var artista = await windDBContext.Artistas.SingleAsync(a => a.Id == id);
            windDBContext.Artistas.Remove(artista);
        }

        public Task<CacionEntity> GetCancionAsync(int id, bool showArtista)
        {
            IQueryable<CacionEntity> query = windDBContext.Cansiones;
            //query = query.AsNoTracking();
            //if (showArtista)
            //{
            //    query = query.Include(b => b.Artista);
            //}
            query = query.AsNoTracking();
            return query.SingleAsync(b => b.Id == id);
        }

        public async Task<IEnumerable<CacionEntity>> GetCanciones(int artistaId)
        {
            IQueryable<CacionEntity> query = windDBContext.Cansiones;
            query = query.AsNoTracking();
            return await query.Where(b => b.Artista.Id == artistaId).ToArrayAsync();

            //return canciones.Where(b=>b.ArtistaId==artistaId);
        }
       
        public void CreateCancion(CacionEntity cancion)
        {
            windDBContext.Entry(cancion.Artista).State = EntityState.Unchanged;
            windDBContext.Cansiones.Add(cancion);
        }

        public void UpdateCancion(CacionEntity cancion)
        {
            //windDBContext.Entry(cancion.Artista).State = EntityState.Unchanged;
            //windDBContext.Cansiones.Update(cancion);
            var cancionPut = windDBContext.Cansiones.Single(c => c.Id == cancion.Id);
            cancionPut.Nombre = cancion.Nombre;
            cancionPut.Duracio = cancion.Duracio;
            cancionPut.Genero = cancion.Genero;
            cancionPut.Votacion = cancion.Votacion;
            cancionPut.Ventas= cancion.Ventas;
            //cancionPut.Artista = cancion.Artista;

        }

        public async Task DeleteCancion(int id)
        {
            //por si necesitamos que sea Task
            //var songesDeletes = await windDBContext.Cansiones.SingleAsync(d => d.Id == id);
            //windDBContext.Cansiones.Remove(songesDeletes);


            //var cans = canciones.Single(b => b.Id == id);
            //canciones.Remove(cans);
            //return true;

            var songeDeleted = await windDBContext.Cansiones.SingleAsync(d => d.Id == id);
            windDBContext.Cansiones.Remove(songeDeleted);
        }
        public void DetachEntity<t>(t entity) where t : class
        {
            windDBContext.Entry(entity).State = EntityState.Detached;
        }

        public async Task<bool> SaveChangesAsync()
        {
            try
            {
                return (await windDBContext.SaveChangesAsync()) > 0;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public void UpdateVentas(int id, int venta)
        {
            var cancionPut = windDBContext.Cansiones.Single(c => c.Id == id);
            cancionPut.Ventas = cancionPut.Ventas+venta;
        }

        public void UpdateVotos(CacionEntity cancion, int voto)
        {
            var cancionPut = windDBContext.Cansiones.Single(f => f.Id == cancion.Id);
            var sum = cancionPut.Votacion + voto;
            cancionPut.Votacion = sum;
        }
    }
}
