using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectofinalDb1.data
{
    public class Usuario
    {
        [Key]
        public int Codigo { get; set; }

        [Required]
        [StringLength(64)]
        public string NomUsuario { get; set; }

        [Required]
        [StringLength(64)]
        public string Clave { get; set; }

        public DateTime? FechaCreacion { get; set; }

        [Required]
        public int Nivel { get; set; }

        [ForeignKey("Nivel")]
        public Nivel NivelNavigation { get; set; }

        public ICollection<Empleado> Empleados { get; set; }

        public ICollection<Bitacora> Bitacoras { get; set; }
    }
}
