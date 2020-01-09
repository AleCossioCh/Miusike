using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace ProyectoMiusike.Models
{
    public class Artista
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El nombre es requerido")]
        public string Nombre { get; set; }
        public int edad { get; set; } //años en el ambito artistico
        public string biografia { get; set; }
        public string imgPath { get; set; }
        public IEnumerable<Cacion> canciones{ get; set; }
    }
}
