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
    public class ProveedorControllerAux2 : Controller
    {
        private readonly DatabaseContext _context;

        public ProveedorControllerAux2(DatabaseContext context)
        {
            _context = context;
        }

        // GET: ProveedorControllerAux2
        public async Task<IActionResult> Index()
        {
            var databaseContext = _context.Proveedor.Include(p => p.CiudadDepPais);
            return View(await databaseContext.ToListAsync());
        }

        // GET: ProveedorControllerAux2/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proveedor = await _context.Proveedor
                .Include(p => p.CiudadDepPais)
                .FirstOrDefaultAsync(m => m.idProveedor == id);
            if (proveedor == null)
            {
                return NotFound();
            }

            return View(proveedor);
        }

        // GET: ProveedorControllerAux2/Create
        public IActionResult Create()
        {
            ViewData["idCiudadDepPais"] = new SelectList(_context.CiudadDepPais, "idCiudadDepPais", "ciudad");
            return View();
        }

        // POST: ProveedorControllerAux2/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idProveedor,nombreProveedor,tipoVia,numeroVia,numeroViaSecundario,numeroCasa,tipoInmueble,numeroInmueble,idCiudadDepPais")] Proveedor proveedor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(proveedor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["idCiudadDepPais"] = new SelectList(_context.CiudadDepPais, "idCiudadDepPais", "ciudad", proveedor.idCiudadDepPais);
            return View(proveedor);
        }

        // GET: ProveedorControllerAux2/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proveedor = await _context.Proveedor.FindAsync(id);
            if (proveedor == null)
            {
                return NotFound();
            }
            ViewData["idCiudadDepPais"] = new SelectList(_context.CiudadDepPais, "idCiudadDepPais", "ciudad", proveedor.idCiudadDepPais);
            return View(proveedor);
        }

        // POST: ProveedorControllerAux2/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idProveedor,nombreProveedor,tipoVia,numeroVia,numeroViaSecundario,numeroCasa,tipoInmueble,numeroInmueble,idCiudadDepPais")] Proveedor proveedor)
        {
            if (id != proveedor.idProveedor)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(proveedor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProveedorExists(proveedor.idProveedor))
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
            ViewData["idCiudadDepPais"] = new SelectList(_context.CiudadDepPais, "idCiudadDepPais", "ciudad", proveedor.idCiudadDepPais);
            return View(proveedor);
        }

        // GET: ProveedorControllerAux2/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proveedor = await _context.Proveedor
                .Include(p => p.CiudadDepPais)
                .FirstOrDefaultAsync(m => m.idProveedor == id);
            if (proveedor == null)
            {
                return NotFound();
            }

            return View(proveedor);
        }

        // POST: ProveedorControllerAux2/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var proveedor = await _context.Proveedor.FindAsync(id);
            _context.Proveedor.Remove(proveedor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProveedorExists(int id)
        {
            return _context.Proveedor.Any(e => e.idProveedor == id);
        }
    }
}
