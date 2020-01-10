using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoMiusike.Data.Entity
{
    public class CacionEntity
    {
        [Key]
        [Required]
        public int? Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public float Duracio { get; set; }
        [Required]
        public string Genero { get; set; }
        public int Votacion { get; set; }
        public int Ventas { get; set; }
        [ForeignKey("ArtistaId")]
        public virtual ArtistaEntity Artista { get; set; }
    }
}
