using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
namespace BioRec___Empleados.Models
{
    [Table("Proveedor")]
    public class Proveedor
    {
        [Key]
        public int idProveedor { get; set; }
        [Required]
        public String nombreProveedor { get; set; }
        [Required]
        public String telefono { get; set; }


        //Dirección:

        [Required]
        public String tipoVia { get; set; }

        [Required]
        public String numeroVia { get; set; }

        [Required]
        public String numeroViaSecundario { get; set; }

        [Required]
        public String numeroCasa { get; set; }
        public String tipoInmueble { get; set; }

        public String numeroInmueble { get; set; }



        [ForeignKey("CiudadDepPais")]
        public int idCiudadDepPais { get; set; }
        public virtual CiudadDepPais CiudadDepPais { get; set; }


        [InverseProperty("Proveedor")]
        public virtual ICollection<Proveedor_Producto> Proveedor_Producto { get; set; }

    }
}
