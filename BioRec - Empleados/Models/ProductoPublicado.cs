using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BioRec___Empleados.Models
{
    public class ProductoPublicado
    {
        [Key]
        [ForeignKey("Producto")]
        public int id { get; set; }
        public virtual Producto Producto { get; set; }
        [Required]
        public string nombre { get; set; }
        public string descripcion { get; set; }
        [Required]
        public double precio { get; set; }
    }
}
