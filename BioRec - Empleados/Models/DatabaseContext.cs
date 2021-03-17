using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BioRec___Empleados.Models
{
    public class DatabaseContext:DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        public DbSet<Usuario> Usuario { get; set; }
       
        public DbSet<CiudadDepPais> CiudadDepPais { get; set; }
        public DbSet<Departamento> Departamentos{ get; set; }
        public DbSet<Pais> Pais { get; set; }

        public DbSet<Venta> Venta{ get; set; }

    }
    
}
