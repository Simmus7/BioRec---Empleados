using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace BioRec___Empleados.Models
{
    [Table("Departamento")]
    public class Departamento
    {
        [Key]
        public int idDepartamento { get; set; }

        [Required]
        public String departamento { get; set; }

        [InverseProperty("Departamento")]
        public virtual CiudadDepPais CiudadDepPais{ get; set; }

        [ForeignKey("Pais")]
        public int idPais { get; set; }
        public virtual Pais Pais { get; set; }


    }
}

