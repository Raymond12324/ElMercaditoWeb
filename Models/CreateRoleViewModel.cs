using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ElMercaditoWeb.Models
{
    public class CreateRoleViewModel
    {
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string RoleName { get; set; }
    }
}
