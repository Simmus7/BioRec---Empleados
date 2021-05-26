using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BioRec___Empleados.Models;
using Microsoft.EntityFrameworkCore;

namespace BioRec___Empleados.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DatabaseContext _context;

        public HomeController(ILogger<HomeController> logger, DatabaseContext context)
        {
            _logger = logger;
            _context = context;
        }
        public IActionResult LandingPage()
        {
            return View();
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult VerVentas()
        {
            var ventas = _context.Venta.Include(v=>v.Producto_Ventas).ThenInclude(pv=>pv.Producto).Include(v=>v.Usuario).OrderBy(v=>v.fechaYHoraVenta);
            return View(ventas);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
