using System;
using System.Collections.Generic;

namespace ElMercaditoWeb.Models
{
    public partial class Categoria
    {
        public Categoria()
        {
            Productos = new HashSet<Productos>();
        }

        public int IdCategoria { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Productos> Productos { get; set; }
    }
}
