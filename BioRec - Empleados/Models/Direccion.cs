using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace BioRec___Empleados.Models
{
    [Table("Direccion")]
    public class Direccion
    {
        [Key]
        public int idDireccion { get; set; }
        [Required]
        public String tipoVia { get; set; }

        [Required]
        public String numeroVia { get; set; }

        [Required]
        public String numeroViaSecundario{ get; set; }

        [Required]
        public int numeroCasa { get; set; }

        [Required]
        public String tipoInmueble { get; set; }

        public int numeroInmueble { get; set; }

        [InverseProperty("Direccion")]
        public virtual Usuario Usuario { get; set; }

        [InverseProperty("Direccion")]
        public virtual Proveedor Proveedor { get; set; }


        [ForeignKey("CiudadDepPais")]
        public int idCiudadDepPais { get; set; }
        public virtual CiudadDepPais CiudadDepPais{ get; set; }
    }
}
