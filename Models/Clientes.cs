using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ElMercaditoWeb.Models
{
    public partial class Clientes
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrdenId { get; set; }
        public string Usuario { get; set; }
        public string Productonombre { get; set; }
        public string Productocantidad { get; set; }
        public string NombrePersona { get; set; }
        public string FechaCumpleanos { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public decimal? Lat { get; set; }
        public decimal? Long { get; set; }
        public string Estado { get; set; }
    }
}
