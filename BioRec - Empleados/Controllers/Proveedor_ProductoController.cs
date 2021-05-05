using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BioRec___Empleados.Models;

namespace BioRec___Empleados.Areas.Abastecimiento.Controllers
{
    public class Proveedor_ProductoController : Controller
    {
        private readonly DatabaseContext _context;

        public Proveedor_ProductoController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: Abastecimiento/Proveedor_Producto
        public async Task<IActionResult> Index()
        {
            var databaseContext = _context.Proveedor_Producto.Include(p => p.Producto).Include(p => p.Proveedor);
            return View(await databaseContext.ToListAsync());
        }

        // GET: Abastecimiento/Proveedor_Producto/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proveedor_Producto = await _context.Proveedor_Producto
                .Include(p => p.Producto)
                .Include(p => p.Proveedor)
                .FirstOrDefaultAsync(m => m.idProveedor_Producto == id);
            if (proveedor_Producto == null)
            {
                return NotFound();
            }

            return View(proveedor_Producto);
        }

        // GET: Abastecimiento/Proveedor_Producto/Create
        public IActionResult Create()
        {
            ViewData["idProducto"] = new SelectList(_context.Producto, "idProducto", "descripcion");
            ViewData["idProveedor"] = new SelectList(_context.Proveedor, "idProveedor", "nombreProveedor");
            return View();
        }

        // POST: Abastecimiento/Proveedor_Producto/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idProveedor_Producto,fecha,cantidadTotal,costoPorUnidad,idProducto,idProveedor")] Proveedor_Producto proveedor_Producto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(proveedor_Producto);
                var producto = _context.Producto.Find(proveedor_Producto.idProducto);
                producto.cantidadTotal += proveedor_Producto.cantidadTotal;
                _context.Update(producto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["idProducto"] = new SelectList(_context.Producto, "idProducto", "descripcion", proveedor_Producto.idProducto);
            ViewData["idProveedor"] = new SelectList(_context.Proveedor, "idProveedor", "nombreProveedor", proveedor_Producto.idProveedor);
            return View(proveedor_Producto);
        }

        // GET: Abastecimiento/Proveedor_Producto/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proveedor_Producto = await _context.Proveedor_Producto.FindAsync(id);
            if (proveedor_Producto == null)
            {
                return NotFound();
            }
            ViewData["idProducto"] = new SelectList(_context.Producto, "idProducto", "descripcion", proveedor_Producto.idProducto);
            ViewData["idProveedor"] = new SelectList(_context.Proveedor, "idProveedor", "nombreProveedor", proveedor_Producto.idProveedor);
            return View(proveedor_Producto);
        }

        // POST: Abastecimiento/Proveedor_Producto/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idProveedor_Producto,fecha,cantidadTotal,costoPorUnidad,idProducto,idProveedor")] Proveedor_Producto proveedor_Producto)
        {
            if (id != proveedor_Producto.idProveedor_Producto)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(proveedor_Producto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Proveedor_ProductoExists(proveedor_Producto.idProveedor_Producto))
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
            ViewData["idProducto"] = new SelectList(_context.Producto, "idProducto", "descripcion", proveedor_Producto.idProducto);
            ViewData["idProveedor"] = new SelectList(_context.Proveedor, "idProveedor", "nombreProveedor", proveedor_Producto.idProveedor);
            return View(proveedor_Producto);
        }

        // GET: Abastecimiento/Proveedor_Producto/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proveedor_Producto = await _context.Proveedor_Producto
                .Include(p => p.Producto)
                .Include(p => p.Proveedor)
                .FirstOrDefaultAsync(m => m.idProveedor_Producto == id);
            if (proveedor_Producto == null)
            {
                return NotFound();
            }

            return View(proveedor_Producto);
        }

        // POST: Abastecimiento/Proveedor_Producto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var proveedor_Producto = await _context.Proveedor_Producto.FindAsync(id);
            _context.Proveedor_Producto.Remove(proveedor_Producto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Proveedor_ProductoExists(int id)
        {
            return _context.Proveedor_Producto.Any(e => e.idProveedor_Producto == id);
        }
    }
}
