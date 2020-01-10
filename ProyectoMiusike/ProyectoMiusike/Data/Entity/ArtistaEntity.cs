using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoMiusike.Data.Entity
{
    public class ArtistaEntity
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string nombre { get; set; }
        public int edad { get; set; }
        public string biografia { get; set; }
        public string imgPath { get; set; }
        public virtual ICollection<CacionEntity> Canciones { get; set; }
    }
}
