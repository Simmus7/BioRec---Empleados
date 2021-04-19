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
    public class ProveedorControllerAux : Controller
    {
        private readonly DatabaseContext _context;

        public ProveedorControllerAux(DatabaseContext context)
        {
            _context = context;
        }

        // GET: ProveedorControllerAux
        public async Task<IActionResult> Index()
        {
            return View(await _context.RegistroProveedorViewModel.ToListAsync());
        }

        // GET: ProveedorControllerAux/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registroProveedorViewModel = await _context.RegistroProveedorViewModel
                .FirstOrDefaultAsync(m => m.idProveedor == id);
            if (registroProveedorViewModel == null)
            {
                return NotFound();
            }

            return View(registroProveedorViewModel);
        }

        // GET: ProveedorControllerAux/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProveedorControllerAux/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idProveedor,nombreProveedor,tipoVia,numeroVia,numeroViaSecundario,numeroCasa,tipoInmueble,numeroInmueble,ciudad,departamento,pais")] RegistroProveedorViewModel registroProveedorViewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(registroProveedorViewModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(registroProveedorViewModel);
        }

        // GET: ProveedorControllerAux/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registroProveedorViewModel = await _context.RegistroProveedorViewModel.FindAsync(id);
            if (registroProveedorViewModel == null)
            {
                return NotFound();
            }
            return View(registroProveedorViewModel);
        }

        // POST: ProveedorControllerAux/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idProveedor,nombreProveedor,tipoVia,numeroVia,numeroViaSecundario,numeroCasa,tipoInmueble,numeroInmueble,ciudad,departamento,pais")] RegistroProveedorViewModel registroProveedorViewModel)
        {
            if (id != registroProveedorViewModel.idProveedor)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(registroProveedorViewModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RegistroProveedorViewModelExists(registroProveedorViewModel.idProveedor))
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
            return View(registroProveedorViewModel);
        }

        // GET: ProveedorControllerAux/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registroProveedorViewModel = await _context.RegistroProveedorViewModel
                .FirstOrDefaultAsync(m => m.idProveedor == id);
            if (registroProveedorViewModel == null)
            {
                return NotFound();
            }

            return View(registroProveedorViewModel);
        }

        // POST: ProveedorControllerAux/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var registroProveedorViewModel = await _context.RegistroProveedorViewModel.FindAsync(id);
            _context.RegistroProveedorViewModel.Remove(registroProveedorViewModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RegistroProveedorViewModelExists(int id)
        {
            return _context.RegistroProveedorViewModel.Any(e => e.idProveedor == id);
        }
    }
}
