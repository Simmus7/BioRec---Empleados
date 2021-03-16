using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace BioRec___Empleados.Models
{
    [Table("Proveedor_Producto")]
    public class Proveedor_Producto
    {
        [Key]
        public int idProveedor_Producto { get; set; }
        [Required]
        public DateTime fecha { get; set; }
        [Required]
        public int cantidadTotal { get; set; }
        [Required]
        public int costoPorUnidad { get; set; }

        [ForeignKey("Producto")]
        public int idProducto { get; set; }
        public virtual Producto Producto { get; set; }

        [ForeignKey("Proveedor")]
        public int idProveedor { get; set; }
        public virtual Proveedor Proveedor { get; set; }
    }
}
