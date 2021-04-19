using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BioRec___Empleados.Models;
using Microsoft.AspNetCore.Mvc;
using BioRec___Empleados.ViewModel;

namespace BioRec___Empleados.Controllers
{
    public class UsuarioController : Controller
    {

        private readonly DatabaseContext _context;

        public UsuarioController(DatabaseContext context)
        {
            _context = context;
        }
        public IActionResult Registro()
        {
            return View();
        }
        public IActionResult InicioDeSesion()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Registrar([Bind("nombre,apellido,fechanacimiento,edad,correo,contraseña,rol,tipoVia,numeroVia,numeroViaSecundario,numeroCasa,tipoInmueble,numeroInmueble,ciudad,departamento,pais")] RegistroUsuarioViewModel usuarioCompuesto)
        {
            if (ModelState.IsValid)
            {
                Usuario user = new Usuario();
                user.nombre = usuarioCompuesto.nombre;
                user.apellido = usuarioCompuesto.apellido;
                user.correo = usuarioCompuesto.correo;
                user.contraseña = usuarioCompuesto.contraseña;
                //Hay que calcular la edad
                user.edad = usuarioCompuesto.edad;
                user.fechanacimiento = usuarioCompuesto.fechanacimiento;
                user.rol = 0;

                user.tipoVia = usuarioCompuesto.tipoVia;
                user.numeroVia = usuarioCompuesto.numeroVia;
                user.numeroViaSecundario = usuarioCompuesto.numeroViaSecundario;
                user.numeroCasa = usuarioCompuesto.numeroCasa;
                user.tipoInmueble = usuarioCompuesto.tipoInmueble;
                user.numeroInmueble = usuarioCompuesto.numeroInmueble;

                CiudadDepPais ciudad = new CiudadDepPais();
                ciudad.ciudad = usuarioCompuesto.ciudad;

                Departamento dep = new Departamento();
                dep.departamento = usuarioCompuesto.departamento;

                Pais pais = new Pais();
                pais.pais = usuarioCompuesto.pais;
                

                _context.Pais.Add(pais);
                await _context.SaveChangesAsync();
                dep.idPais = pais.idPais;
                

                _context.Departamentos.Add(dep);
                await _context.SaveChangesAsync();
                ciudad.idDepartamento = dep.idDepartamento;

                _context.CiudadDepPais.Add(ciudad);
                await _context.SaveChangesAsync();
                user.idCiudadDepPais = ciudad.idCiudadDepPais;

                _context.Usuario.Add(user);
                await _context.SaveChangesAsync();


                return RedirectToAction("InicioDeSesion", "Usuario");
            }
            return RedirectToAction("Registro", "Usuario");


        }

    }
}
