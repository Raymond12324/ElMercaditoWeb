using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ElMercaditoWeb.Models
{
    public class ShoppingCartItem
    {
        [Key]
        public int ShoppingCartItemId { get; set; }
        public Productos Producto { get; set; }
        public int Cantidad { get; set; }
       public string ShoppingCartId { get; set; }
    }
}
