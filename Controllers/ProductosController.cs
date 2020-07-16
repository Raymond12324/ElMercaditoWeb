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

namespace ElMercaditoWeb.Controllers
{
    public class ProductosController : Controller
    {
        private readonly SupermercadoContext _context;
     

        public ProductosController(SupermercadoContext context)
        {
            _context = context;
        }

        // GET: Productos
        public async Task<IActionResult> Index()
        {
            var supermercadoContext = _context.Productos.Include(p => p.IdCategoriaNavigation);
            return View(await supermercadoContext.ToListAsync());
        }

        public IEnumerable<Productos> GetTodo()
        {
            var todo = _context.Productos.FromSqlRaw("Select * from productos").ToList();
            return todo;


        }

        public IEnumerable<Productos> GetFrutas()
        {
            var frutas = _context.Productos.FromSqlRaw("Select * from productos where idCategoria = 1").ToList();
            return frutas;

            
        }

        public IEnumerable<Productos> GetCarnes()
        {
            var carnes = _context.Productos.FromSqlRaw("Select * from productos where idCategoria = 2").ToList();
            return carnes;
        }

        public IEnumerable<Productos> GetEmbutidos()
        {
            var carnes = _context.Productos.FromSqlRaw("Select * from productos where idCategoria = 4").ToList();
            return carnes;
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
