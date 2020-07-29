using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PayPal.Api;

namespace ElMercaditoWeb.Controllers
{
    public class PagoController : Controller
    {
        public IActionResult PagoPaypal()
        {
            return View();
        }
    }
}
