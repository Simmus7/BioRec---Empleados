using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;


namespace BioRec___Empleados.Models
{
    [Table("Usuario")]
    public class Usuario
    {
        [Key]
        public int idUsuario { get; set; }

        [Required]
        public String nombre { get; set; }

        [Required]
        public String apellido { get; set; }

        [Required]
        public DateTime fechanacimiento { get; set; }

        [Required]
        public int edad { get; set; }
        
        [Required]
        public String correo { get; set; }

        [Required]
        public String contraseña { get; set; }

        [Required]
        public int rol { get; set; }

        

       

        [ForeignKey("Direccion")]
        public int idDireccion { get; set; }
        public virtual Direccion Direccion { get; set; }

        [InverseProperty("Usuario")]
        public virtual ICollection<Venta> Ventas { get; set; }



    }



    }

