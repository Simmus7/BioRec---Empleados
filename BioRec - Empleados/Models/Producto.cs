using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace BioRec___Empleados.Models
{
    [Table("Producto")]
    public class Producto
    {


        [Key]
        public int idProducto { get; set; }
        [Required]
        public String nombre { get; set; }
        [Required]
        public String descripcion { get; set; }
        [Required]
        public int cantidadTotal { get; set; }

        [InverseProperty("Producto")]
        public virtual ICollection<Producto_Venta> Producto_Ventas { get; set; }

        [InverseProperty("Producto")]
        public virtual ICollection<Proveedor_Producto> Proveedor_Producto{ get; set; }
    }
}
