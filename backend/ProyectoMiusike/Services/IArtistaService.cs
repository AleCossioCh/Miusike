using ProyectoMiusike.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoMiusike.Services
{
    public interface IArtistaService
    {
        Task<Artista> CrearArtistaAsync(Artista newArtista);        
        Task<IEnumerable<Artista>> ObtenerArtistasAsync(string orderBy, bool showCaciones);
        Task<Artista> ObtenerArtistaAsync(int id, bool showCaciones);
        Task<Artista> ActualizarArtistaAsync(int id, Artista newArtista);
        Task<bool> BorrarArtistaAsync(int id);

    }
}
