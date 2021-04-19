using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BioRec___Empleados.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BioRec___Empleados.ViewModel;

namespace BioRec___Empleados.Controllers
{
    public class ProveedorController : Controller
    {

        private readonly DatabaseContext _context;

        public ProveedorController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: ProveedorControllerAux
        public async Task<IActionResult> Index()
        {
            return View(await _context.Proveedor.ToListAsync());
        }

        // GET: ProveedorControllerAux/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proveedor = await _context.Proveedor
                .FirstOrDefaultAsync(m => m.idProveedor == id);
            if (proveedor == null)
            {
                return NotFound();
            }

            return View(proveedor);
        }

        // GET: ProveedorControllerAux/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("nombreProveedor,tipoVia,numeroVia,numeroViaSecundario,numeroCasa,tipoInmueble,numeroInmueble,ciudad,departamento,pais")] RegistroProveedorViewModel proveedorCompuesto)
        {
            if (ModelState.IsValid)
            {
                Proveedor prov = new Proveedor();
                prov.nombreProveedor = proveedorCompuesto.nombreProveedor;

                prov.tipoVia = proveedorCompuesto.tipoVia;
                prov.numeroVia = proveedorCompuesto.numeroVia;
                prov.numeroViaSecundario = proveedorCompuesto.numeroViaSecundario;
                prov.numeroCasa = proveedorCompuesto.numeroCasa;
                prov.tipoInmueble = proveedorCompuesto.tipoInmueble;
                prov.numeroInmueble = proveedorCompuesto.numeroInmueble;

                CiudadDepPais ciudad = new CiudadDepPais();
                ciudad.ciudad = proveedorCompuesto.ciudad;

                Departamento dep = new Departamento();
                dep.departamento = proveedorCompuesto.departamento;

                Pais pais = new Pais();
                pais.pais = proveedorCompuesto.pais;


                _context.Pais.Add(pais);
                await _context.SaveChangesAsync();
                dep.idPais = pais.idPais;


                _context.Departamentos.Add(dep);
                await _context.SaveChangesAsync();
                ciudad.idDepartamento = dep.idDepartamento;

                _context.CiudadDepPais.Add(ciudad);
                await _context.SaveChangesAsync();
                prov.idCiudadDepPais = ciudad.idCiudadDepPais;

                _context.Proveedor.Add(prov);
                await _context.SaveChangesAsync();


                return RedirectToAction(nameof(Index));
            }
            return View(proveedorCompuesto);


        }

        // GET: ProveedorControllerAux/Edit/5
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
            return View(proveedor);
        }

        // POST: ProveedorControllerAux/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idProveedor,nombreProveedor,tipoVia,numeroVia,numeroViaSecundario,numeroCasa,tipoInmueble,numeroInmueble,ciudad,departamento,pais")] RegistroProveedorViewModel proveedorCompuesto)
        {
            if (id != proveedorCompuesto.idProveedor)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                Proveedor prov = new Proveedor();
                prov.nombreProveedor = proveedorCompuesto.nombreProveedor;
                prov.tipoVia = proveedorCompuesto.tipoVia;
                prov.numeroVia = proveedorCompuesto.numeroVia;
                prov.numeroViaSecundario = proveedorCompuesto.numeroViaSecundario;
                prov.numeroCasa = proveedorCompuesto.numeroCasa;
                prov.tipoInmueble = proveedorCompuesto.tipoInmueble;
                prov.numeroInmueble = proveedorCompuesto.numeroInmueble;

                CiudadDepPais ciudad = new CiudadDepPais();
                ciudad.ciudad = proveedorCompuesto.ciudad;

                Departamento dep = new Departamento();
                dep.departamento = proveedorCompuesto.departamento;

                Pais pais = new Pais();
                pais.pais = proveedorCompuesto.pais;

                try
                {
                    _context.Pais.Update(pais);
                    await _context.SaveChangesAsync();
                    dep.idPais = pais.idPais;

                   _context.Departamentos.Update(dep);
                    await _context.SaveChangesAsync();
                    ciudad.idDepartamento = dep.idDepartamento;

                    _context.CiudadDepPais.Update(ciudad);
                    await _context.SaveChangesAsync();
                    prov.idCiudadDepPais = ciudad.idCiudadDepPais;

                    _context.Proveedor.Update(prov);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProveedorExists(proveedorCompuesto.idProveedor))
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
            return View(proveedorCompuesto);
        }

    private bool ProveedorExists(int id)
    {
        return _context.Proveedor.Any(e => e.idProveedor == id);
    }
}
}
