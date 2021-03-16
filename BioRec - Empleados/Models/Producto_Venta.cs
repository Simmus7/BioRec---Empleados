using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
namespace BioRec___Empleados.Models
{
    [Table("Producto_Venta")]
    public class Producto_Venta
    {

        [Key]
        public int idProducto_Venta { get; set; }

        [Required]
        public int precioTotalProducto { get; set; }
        [Required]
        public int cantidadProducto { get; set; }
        [Required]
        public int precioUnidad { get; set; }


        [ForeignKey("Venta")]
        public int idVenta{ get; set; }
        public virtual Venta Venta { get; set; }

        [ForeignKey("Producto")]
        public int idProducto { get; set; }
        public virtual Producto Producto { get; set; }
    }
}
