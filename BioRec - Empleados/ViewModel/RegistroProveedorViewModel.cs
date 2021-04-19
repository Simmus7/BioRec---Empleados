using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
namespace BioRec___Empleados.Models
{
    public class RegistroProveedorViewModel
    {

        [Key]
        public int idProveedor { get; set; }

        public String nombreProveedor { get; set; }


        public String tipoVia { get; set; }

        public String numeroVia { get; set; }

        public String numeroViaSecundario { get; set; }

        public String numeroCasa { get; set; }

        public String tipoInmueble { get; set; }

        public String numeroInmueble { get; set; }

        public String ciudad { get; set; }

        public String departamento { get; set; }

        public String pais { get; set; }


    }
}
