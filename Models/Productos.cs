using System;
using System.Collections.Generic;

namespace ElMercaditoWeb.Models
{
    public partial class Productos
    {
        public int IdProductos { get; set; }
        public int IdCategoria { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public string Imagen { get; set; }
        public int? Disponibilidad { get; set; }

        

        public virtual Categoria IdCategoriaNavigation { get; set; }
    }
}
