using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BioRec___Empleados.Models;

namespace BioRec___Empleados.Controllers
{
    public class ProductoPublicadoesController : Controller
    {
        private readonly DatabaseContext _context;

        public ProductoPublicadoesController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: ProductoPublicadoes
        public async Task<IActionResult> Index()
        {
            var databaseContext = _context.ProductoPublicado.Include(p => p.Producto);
            return View(await databaseContext.ToListAsync());
        }

        // GET: ProductoPublicadoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productoPublicado = await _context.ProductoPublicado
                .Include(p => p.Producto)
                .FirstOrDefaultAsync(m => m.id == id);
            if (productoPublicado == null)
            {
                return NotFound();
            }

            return View(productoPublicado);
        }

        // GET: ProductoPublicadoes/Create
        public IActionResult Create(int idProducto)
        {
            ViewBag.idProducto = idProducto;
            return View();
        }

        // POST: ProductoPublicadoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,nombre,descripcion,precio")] ProductoPublicado productoPublicado)
        {
            if (ModelState.IsValid)
            {
                _context.Add(productoPublicado);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index",new{idProducto=productoPublicado.id });
            }
            ViewData["id"] = new SelectList(_context.Producto, "idProducto", "descripcion", productoPublicado.id);
            return View(productoPublicado);
        }

        // GET: ProductoPublicadoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productoPublicado = await _context.ProductoPublicado.FindAsync(id);
            if (productoPublicado == null)
            {
                return NotFound();
            }
            ViewData["id"] = new SelectList(_context.Producto, "idProducto", "descripcion", productoPublicado.id);
            return View(productoPublicado);
        }

        // POST: ProductoPublicadoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,nombre,descripcion,precio")] ProductoPublicado productoPublicado)
        {
            if (id != productoPublicado.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productoPublicado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductoPublicadoExists(productoPublicado.id))
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
            ViewData["id"] = new SelectList(_context.Producto, "idProducto", "descripcion", productoPublicado.id);
            return View(productoPublicado);
        }

        // GET: ProductoPublicadoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productoPublicado = await _context.ProductoPublicado
                .Include(p => p.Producto)
                .FirstOrDefaultAsync(m => m.id == id);
            if (productoPublicado == null)
            {
                return NotFound();
            }
            
            return View(productoPublicado);
        }

        // POST: ProductoPublicadoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var productoPublicado = await _context.ProductoPublicado.FindAsync(id);
            _context.ProductoPublicado.Remove(productoPublicado);
            await _context.SaveChangesAsync();
            return RedirectToAction("IndexProducto","Producto");
        }

        private bool ProductoPublicadoExists(int id)
        {
            return _context.ProductoPublicado.Any(e => e.id == id);
        }
    }
}
