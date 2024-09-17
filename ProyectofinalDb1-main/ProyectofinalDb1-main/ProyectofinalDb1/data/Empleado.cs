using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectofinalDb1.data
{
    public class Empleado
    {
        [Key]
        public int Codigo { get; set; }

        [Required]
        [StringLength(20)]
        public string Cedula { get; set; }

        [Required]
        [StringLength(64)]
        public string Nombre { get; set; }

        public string DireccionResidencia { get; set; }

        [StringLength(20)]
        public string Telefono { get; set; }

        [Required]
        public int Usuario { get; set; }

        [ForeignKey("Usuario")]
        public Usuario UsuarioNavigation { get; set; }

        public ICollection<DetalleEmpleadoProfesion> DetallesEmpleadoProfesion { get; set; }

        public ICollection<Contrato> Contratos { get; set; }
    }
}
