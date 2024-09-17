using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectofinalDb1.data
{
    public class Municipio
    {
        [Key]
        public int Codigo { get; set; }

        [Required]
        [StringLength(64)]
        public string Nombre { get; set; }

        public int? Poblacion { get; set; }

        [Required]
        public int Prioridad { get; set; }

        [Required]
        public int Departamento { get; set; }

        [ForeignKey("Prioridad")]
        public Prioridad PrioridadNavigation { get; set; }

        [ForeignKey("Departamento")]
        public Departamento DepartamentoNavigation { get; set; }

        public ICollection<Sucursal> Sucursales { get; set; }
    }
}
