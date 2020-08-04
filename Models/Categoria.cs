using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ElMercaditoWeb.Models
{
    public partial class Categoria
    {
        public Categoria()
        {
            Productos = new HashSet<Productos>();
        }
         [Key]
        public int IdCategoria { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string Descripcion { get; set; }

        public virtual ICollection<Productos> Productos { get; set; }
    }
}
