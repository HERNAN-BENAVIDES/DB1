using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectofinalDb1.data
{
    public class Contrato
    {
        [Key]
        public int Codigo { get; set; }

        [Required]
        public int Empleado { get; set; }

        [Required]
        public int Cargo { get; set; }

        [Required]
        public int Sucursal { get; set; }

        public DateTime? FechaInicio { get; set; }

        public DateTime? FechaFin { get; set; }

        [ForeignKey("Empleado")]
        public Empleado EmpleadoNavigation { get; set; }

        [ForeignKey("Cargo")]
        public Cargo CargoNavigation { get; set; }

        [ForeignKey("Sucursal")]
        public Sucursal SucursalNavigation { get; set; }
    }
}
