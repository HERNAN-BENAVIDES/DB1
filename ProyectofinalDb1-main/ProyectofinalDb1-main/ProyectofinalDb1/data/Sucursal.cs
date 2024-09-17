using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectofinalDb1.data
{
    public class Sucursal
    {
        [Key]
        public int Codigo { get; set; }

        [Required]
        [StringLength(64)]
        public string Nombre { get; set; }

        public double Presupuesto { get; set; }

        [Required]
        public int Director { get; set; }

        [Required]
        public int Municipio { get; set; }

        [ForeignKey("Municipio")]
        public Municipio MunicipioNavigation { get; set; }

        [ForeignKey("Director")]
        public Usuario DirectorNavigation { get; set; }

        public ICollection<Contrato> Contratos { get; set; }
    }
}
