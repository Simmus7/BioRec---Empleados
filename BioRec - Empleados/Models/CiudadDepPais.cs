using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace BioRec___Empleados.Models
{
    [Table("CiudadDepPais")]
    public class CiudadDepPais
    {
        [Key]
        public int idCiudadDepPais { get; set; }

        [Required]
        public String ciudad { get; set; }

        [InverseProperty("CiudadDepPais")]
        public virtual Direccion Direccion { get; set; }

        [ForeignKey("Departamento")]
        public int idDepartamento { get; set; }
        public virtual Departamento Departamento { get; set; }
    }
}
