using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace BioRec___Empleados.Models
{
    [Table("Pais")]
    public class Pais
    {
        [Key]
        public int idPais { get; set; }

        [Required]
        public String pais { get; set; }

        [InverseProperty("Pais")]
        public virtual Departamento Departamento { get; set; }
    }
}
