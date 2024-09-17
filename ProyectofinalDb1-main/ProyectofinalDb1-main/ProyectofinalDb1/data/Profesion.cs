using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectofinalDb1.data
{
    public class Profesion
    {
        [Key]
        public int Codigo { get; set; }

        [Required]
        [StringLength(64)]
        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public ICollection<DetalleEmpleadoProfesion> DetallesEmpleadoProfesion { get; set; }
    }
}
