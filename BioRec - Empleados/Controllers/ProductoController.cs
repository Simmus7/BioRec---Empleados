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
    public class ProductoController : Controller
    {
        private readonly DatabaseContext _context;
        public ProductoController(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> IndexProducto()
        {
            var lista = await _context.Producto.Include(p => p.ProductoPublicado).ToListAsync();
            return View(lista);
        }

        public IActionResult Create()
        {
            return View();
        }

        //CREACIÓN DE PRODUCTO
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idProducto,nombre,descripcion")] Producto producto)
        {
            producto.cantidadTotal = 0;
            if (ModelState.IsValid)
            {
                _context.Add(producto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(IndexProducto));
            }
            return View(producto);
        }

        //EDICIÓN DE PRODUCTO
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producto = await _context.Producto.FindAsync(id);
            if (producto == null)
            {
                return NotFound();
            }
            return View(producto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //No entiendo quién le manda int id al método
        public async Task<IActionResult> Edit(int id, [Bind("idProducto,nombre,descripcion,cantidadTotal")] Producto producto)
        {
            if (id != producto.idProducto)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(producto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductoExists(producto.idProducto))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(IndexProducto));
            }
            return View(producto);
        }
        private bool ProductoExists(int id)
        {
            return _context.Producto.Any(e => e.idProducto == id);
        }


        //DETALLES:

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            
            var producto = await _context.Producto
                .FirstOrDefaultAsync(m => m.idProducto == id);
            if (producto == null)
            {
                return NotFound();
            }

            return View(producto);
        }

        //BORRAR:
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producto = await _context.Producto
                .FirstOrDefaultAsync(m => m.idProducto == id);
            if (producto == null)
            {
                return NotFound();
            }

            return View(producto);
        }

        // BORRAR:
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var producto = await _context.Producto.FindAsync(id);
            _context.Producto.Remove(producto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(IndexProducto));
        }

    }
}
