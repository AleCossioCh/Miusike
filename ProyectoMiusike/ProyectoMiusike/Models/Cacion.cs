using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoMiusike.Models
{
    public class Cacion
    {
        public int? Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public float Duracio { get; set; }
        [Required]
        public string Genero { get; set; }
        public int Votacion { get; set; }
        public int Ventas { get; set; }
        public int? ArtistaId { get; set; }
    }
}
