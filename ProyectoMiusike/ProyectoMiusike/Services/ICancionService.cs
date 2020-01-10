using ProyectoMiusike.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoMiusike.Services
{
    public interface ICancionService
    {
        Task<IEnumerable<Cacion>> ObtenerCanciones(int artistaId);
        Task<Cacion> ObtenerCancionAsync(int artistaId, int id);
        Task<Cacion> AñadirCancionAsync(int artistaId, Cacion cancion);
        Task<Cacion> ActualizarCancionAsync(int artistaId, int id, Cacion cancion);
        Task<bool> ActualizarVotoAsync(int artistaId, int id, Cacion cancion);
        Task<bool> ActualizarVentaAsync(int artistaId, int id);
        Task<bool> EliminarCancion(int artistaId, int id);
    }
}
