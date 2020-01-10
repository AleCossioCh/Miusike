using ProyectoMiusike.Data.Entity;
using ProyectoMiusike.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoMiusike.Data.Repository
{
    public interface IWindAppRepository
    {
        //artistas
        Task<ArtistaEntity> GetArtistasAsync(int id, bool showCaciones = true);
        Task<IEnumerable<ArtistaEntity>> GetArtistas(string orderBy = "id", bool showCaciones = true);
        Task DeleteArtistaAsync(int id);
        void UpdateArtistaAsync(ArtistaEntity artista);
        void AddArtistaAsync(ArtistaEntity artista);

        //caciones
        Task<IEnumerable<CacionEntity>> GetCanciones(int artistaId);
        Task<CacionEntity> GetCancionAsync(int id, bool showArtista= false);
        void CreateCancion(CacionEntity cancion);
        void UpdateCancion(CacionEntity cancion);
        void UpdateVentas(int id, int venta);
        void UpdateVotos(CacionEntity cancion, int voto);
        Task DeleteCancion(int id);


        //esto que no recuerdo
        void DetachEntity<t>(t entity) where t : class;
        Task<bool> SaveChangesAsync();

    }
}
