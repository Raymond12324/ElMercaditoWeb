using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ElMercaditoWeb.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Newtonsoft.Json;
using System.Globalization;
using Microsoft.AspNetCore.Session;
using Microsoft.AspNetCore.Http;


namespace ElMercaditoWeb.Controllers
{
    public class ProductosController : Controller
    {
        SupermercadoContext ctx = new SupermercadoContext();

        private readonly SupermercadoContext _context;
     

        public ProductosController(SupermercadoContext context)
        {
            _context = context;
        }

        public ActionResult AddCart (int IdProductos)
        {
            var cart = new List<ItemCart>();
            var product = ctx.Productos.Find(IdProductos);
            cart.Add(new ItemCart() {
                ProductoCart = product,
                Cantidad = 1
            });

            
            return View();
        }

        public  IActionResult pago(int Cantidad)
        {
            var todo = _context.Productos.FromSqlRaw("Select * from productos").ToList();
            ViewBag.numeroDatos = todo.Count();
            ViewBag.datos = todo;
            ViewBag.Cantidad = Cantidad;
         
            return View();
        }

        // GET: Productos

        public async Task<IActionResult> Index()
        {
            var supermercadoContext = _context.Productos.Include(p => p.IdCategoriaNavigation);
            return View(await supermercadoContext.ToListAsync());
        }

        public IActionResult Carrito(int IdProductos,int Cantidad)
        {
            var cart = new List<CarritoItems>();

            var product = ctx.Productos.Find(IdProductos);

            cart.Add(new CarritoItems()
            {
                Producto = product,
                Cantidad = Cantidad

            });
            ViewBag.carro = (List<CarritoItems>)cart;
            ViewBag.cuenta = cart.Count;
            //for(int i = 0; i < cart.Count; i++)
            //{

            //}
            // ViewBag.deedf = cart[0].Cantidad;
            // ViewBag.deedf = cart[0].Producto.Nombre;


           HttpContext.Session.SetString("Nombre", cart[0].Producto.Nombre);
           HttpContext.Session.SetInt32("Cantidad", cart[0].Cantidad);

            //HttpContext.Session.SetInt32("Cantidad", cart[0].Cantidad);


            //var list = (List<int>)ISession["test"];
            // Sess["Palabra"] = cart;


            return RedirectToAction("Create", "Clientes");


        }


        public IActionResult GetTodos()
        {
            var todo = _context.Productos.FromSqlRaw("Select * from productos").ToList();
            ViewBag.numeroDatos = todo.Count();
            ViewBag.datos = todo;
            return View();


        }

      

        [HttpPost]
        public IActionResult Getespecifico(string nombre)
        {
            
            var ProductoEspecifico = _context.Productos.FromSqlRaw($"Select * from productos where nombre ='{nombre}'").ToList();
            ViewBag.numeroDatos = ProductoEspecifico.Count();
            ViewBag.datos = ProductoEspecifico;

            return View();


        }

        public IActionResult GetFrutas()
        {
            var frutas = _context.Productos.FromSqlRaw("Select * from productos where idCategoria = 1").ToList();


            ViewBag.numeroDatos = frutas.Count();
            ViewBag.datos = frutas;

           

            return View();

            
        }

        public IActionResult GetCarnes()
        {
            var carnes = _context.Productos.FromSqlRaw("Select * from productos where idCategoria = 2").ToList();


            ViewBag.numeroDatos = carnes.Count();
            ViewBag.datos = carnes;



            return View();
        }

        public IActionResult GetEmbutidos()
        {
            var embutidos = _context.Productos.FromSqlRaw("Select * from productos where idCategoria = 4").ToList();


            ViewBag.numeroDatos = embutidos.Count();
            ViewBag.datos = embutidos;



            return View();
        }

        public IActionResult GetBebidas()
        {
            var bebidas= _context.Productos.FromSqlRaw("Select * from productos where idCategoria = 5").ToList();


            ViewBag.numeroDatos = bebidas.Count();
            ViewBag.datos = bebidas;



            return View();
        }



        public async Task<IActionResult> ClientesProductos()
        {
            var supermercadoContext = _context.Productos.Include(p => p.IdCategoriaNavigation);
            return View(await supermercadoContext.ToListAsync());
        }


        // GET: Productos/Details/5

        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            

            if (id == null)
            {
                return NotFound();
            }

            var productos = await _context.Productos
                .Include(p => p.IdCategoriaNavigation)
                .FirstOrDefaultAsync(m => m.IdProductos == id);
            if (productos == null)
            {
                return NotFound();
            }

            return View(productos);
        }

        // GET: Productos/Create
        public IActionResult Create()
        {
            ViewData["IdCategoria"] = new SelectList(_context.Categoria, "IdCategoria", "Nombre");
            return View();
        }

        // POST: Productos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdProductos,IdCategoria,Nombre,Descripcion,Precio,Imagen,Disponibilidad")] Productos productos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(productos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCategoria"] = new SelectList(_context.Categoria, "IdCategoria", "Nombre", productos.IdCategoria);
            return View(productos);
        }

        // GET: Productos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productos = await _context.Productos.FindAsync(id);
            if (productos == null)
            {
                return NotFound();
            }
            ViewData["IdCategoria"] = new SelectList(_context.Categoria, "IdCategoria", "Nombre", productos.IdCategoria);
            return View(productos);
        }

        // POST: Productos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdProductos,IdCategoria,Nombre,Descripcion,Precio,Imagen,Disponibilidad")] Productos productos)
        {
            if (id != productos.IdProductos)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductosExists(productos.IdProductos))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCategoria"] = new SelectList(_context.Categoria, "IdCategoria", "Nombre", productos.IdCategoria);
            return View(productos);
        }

        // GET: Productos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productos = await _context.Productos
                .Include(p => p.IdCategoriaNavigation)
                .FirstOrDefaultAsync(m => m.IdProductos == id);
            if (productos == null)
            {
                return NotFound();
            }

            return View(productos);
        }

        // POST: Productos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var productos = await _context.Productos.FindAsync(id);
            _context.Productos.Remove(productos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductosExists(int id)
        {
            return _context.Productos.Any(e => e.IdProductos == id);
        }

     
    }
}
