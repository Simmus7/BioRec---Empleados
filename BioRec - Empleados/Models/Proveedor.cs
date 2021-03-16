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
        public String direccionBodega { get; set; }
        [ForeignKey("Direccion")]
        public int idDireccion { get; set; }
        public virtual Direccion Direccion { get; set; }

        [InverseProperty("Proveedor")]
        public virtual Telefono Telefono { get; set; }

        [InverseProperty("Proveedor")]
        public virtual ICollection<Proveedor_Producto> Proveedor_Producto { get; set; }

    }
}
