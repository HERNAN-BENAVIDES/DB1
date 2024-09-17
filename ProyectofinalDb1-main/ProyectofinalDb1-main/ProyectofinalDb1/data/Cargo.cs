using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectofinalDb1.data
{
    public class Cargo
    {
        [Key]
        public int Codigo { get; set; }

        [Required]
        [StringLength(64)]
        public string Nombre { get; set; }

        public double? Salario { get; set; }

        [Required]
        public int Funcion { get; set; }

        [ForeignKey("Funcion")]
        public Funcion FuncionNavigation { get; set; }

        public ICollection<Contrato> Contratos { get; set; }
    }
}
