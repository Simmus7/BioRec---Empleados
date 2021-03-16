using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace BioRec___Empleados.Models
{
    [Table("Venta")]
    public class Venta
    {
        [Key]
        public int idVenta { get; set; }
        [Required]
        public DateTime fechaYHoraVenta{ get; set; }

        [ForeignKey("Usuario")]
        public int idUsuario { get; set; }
        public virtual Usuario Usuario { get; set; }

        [InverseProperty("Venta")]
        public virtual ICollection<Producto_Venta> Producto_Ventas { get; set; }

    }
}
