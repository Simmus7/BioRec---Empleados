using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace BioRec___Empleados.Models
{
    [Table("Telefono")]
    public class Telefono
    {
        [Key]
        public int idTelefono { get; set; }


        [ForeignKey("Proveedor")]
        public int idProveedor{ get; set; }
        public virtual Proveedor Proveedor { get; set; }
    }
}
