using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ElMercaditoWeb.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

namespace ElMercaditoWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SupermercadoContext _context;
       
        public HomeController(ILogger<HomeController> logger, SupermercadoContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            HttpContext.Session.SetString("Test", "Session Value");

            var todo = _context.Slider.FromSqlRaw("Select * from slider").ToList();
            ViewBag.numeroDatos = todo.Count();
            ViewBag.datos = todo;
            return View();
           
        }

        public IActionResult Privacy()
        {
            ViewBag.sessionv = HttpContext.Session.GetString("Test");
            return View();
        }

      

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
