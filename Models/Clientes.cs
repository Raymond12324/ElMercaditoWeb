using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string NombrePersona { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string FechaCumpleanos { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string Telefono { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string Direccion { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public decimal? Lat { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public decimal? Long { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string Estado { get; set; }
    }
}
