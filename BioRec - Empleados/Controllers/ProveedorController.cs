using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BioRec___Empleados.Models;
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

        public async Task<IActionResult> Index()
        {
            var databaseContext = _context.Proveedor.Include(p => p.CiudadDepPais);
            return View(await databaseContext.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proveedor = await _context.Proveedor
                .Include(p => p.CiudadDepPais.Departamento.Pais)
                .FirstOrDefaultAsync(m => m.idProveedor == id);
            if (proveedor == null)
            {
                return NotFound();
            }

            return View(proveedor);
        }

        public IActionResult Create()
        {          
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RegistrarProveedor([Bind("nombreProveedor,telefono,tipoVia,numeroVia,numeroViaSecundario,numeroCasa,tipoInmueble,numeroInmueble,ciudad,departamento,pais")] RegistroProveedorViewModel proveedorCompuesto)
        {
            if (proveedorCompuesto.nombreProveedor != null && proveedorCompuesto.telefono != null && proveedorCompuesto.tipoVia != null && proveedorCompuesto.numeroVia != null && proveedorCompuesto.numeroViaSecundario != null && proveedorCompuesto.numeroCasa != null && proveedorCompuesto.tipoInmueble != null && proveedorCompuesto.numeroInmueble != null && proveedorCompuesto.ciudad != null && proveedorCompuesto.departamento != null && proveedorCompuesto.pais != null)
            {

                if (ModelState.IsValid)
                {
                    Proveedor prov = new Proveedor();
                    prov.nombreProveedor = proveedorCompuesto.nombreProveedor;
                    prov.telefono = proveedorCompuesto.telefono;
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

                    ciudad.Departamento = dep;
                    dep.Pais = pais;
                    prov.CiudadDepPais = ciudad;

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
            }
            return View("Create", proveedorCompuesto);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proveedor = await _context.Proveedor
                .Include(p => p.CiudadDepPais.Departamento.Pais)
                .FirstOrDefaultAsync(m => m.idProveedor == id);
            RegistroProveedorViewModel r = new RegistroProveedorViewModel();
            if (proveedor == null)
            {
                return NotFound();
            }
            else
            {
                r.nombreProveedor = proveedor.nombreProveedor;
                r.telefono = proveedor.telefono;
                r.tipoVia = proveedor.tipoVia;
                r.numeroVia = proveedor.numeroVia;
                r.numeroViaSecundario = proveedor.numeroViaSecundario;
                r.numeroCasa = proveedor.numeroCasa;
                r.tipoInmueble = proveedor.tipoInmueble;
                r.numeroInmueble = proveedor.numeroInmueble;
                /* Ciudad me trae null cuando en la vista Details si traigo la ciudad no trae null:
                r.ciudad = proveedor.CiudadDepPais.ciudad; */  
                r.ciudad = proveedor.CiudadDepPais.ciudad;               
                r.departamento = proveedor.CiudadDepPais.Departamento.departamento;               
                r.pais = proveedor.CiudadDepPais.Departamento.Pais.pais;
            }
            return View(r);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("nombreProveedor,telefono,tipoVia,numeroVia,numeroViaSecundario,numeroCasa,tipoInmueble,numeroInmueble,ciudad,departamento,pais")] RegistroProveedorViewModel proveedorCompuesto)
        {
            if (ModelState.IsValid)
            {
                Proveedor prov = await _context.Proveedor
                .Include(p => p.CiudadDepPais.Departamento.Pais)
                .FirstOrDefaultAsync(m => m.idProveedor == id);
                prov.nombreProveedor = proveedorCompuesto.nombreProveedor;
                prov.telefono = proveedorCompuesto.telefono;
                prov.tipoVia = proveedorCompuesto.tipoVia;
                prov.numeroVia = proveedorCompuesto.numeroVia;
                prov.numeroViaSecundario = proveedorCompuesto.numeroViaSecundario;
                prov.numeroCasa = proveedorCompuesto.numeroCasa;
                prov.tipoInmueble = proveedorCompuesto.tipoInmueble;
                prov.numeroInmueble = proveedorCompuesto.numeroInmueble;               
                prov.CiudadDepPais.ciudad = proveedorCompuesto.ciudad;
                prov.CiudadDepPais.Departamento.departamento = proveedorCompuesto.departamento;
                prov.CiudadDepPais.Departamento.Pais.pais = proveedorCompuesto.pais;

                try
                {                    
                    _context.Proveedor.Update(prov);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction("Edit", "Proveedor");
        }


        private bool ProveedorExists(int id)
        {
            return _context.Proveedor.Any(e => e.idProveedor == id);
        }
    }
}
