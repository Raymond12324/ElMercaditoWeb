using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ElMercaditoWeb.Models
{
    public partial class Productos
    {
        [Key]
        public int IdProductos { get; set; }
        public int IdCategoria { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        public decimal Precio { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string Imagen { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public int? Disponibilidad { get; set; }

        

        public virtual Categoria IdCategoriaNavigation { get; set; }
    }
}
