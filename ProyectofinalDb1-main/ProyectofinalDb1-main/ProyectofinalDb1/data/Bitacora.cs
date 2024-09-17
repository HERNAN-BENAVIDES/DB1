using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectofinalDb1.data
{
    public class Bitacora
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Codigo { get; set; }

        public DateTime? FechaIngreso { get; set; }

        public TimeSpan? HoraIngreso { get; set; }

        public DateTime? FechaSalida { get; set; }

        public TimeSpan? HoraSalida { get; set; }

        [Required]
        public int Usuario{ get; set; }

        [ForeignKey("Usuario")]
        public Usuario UsuarioNavigation { get; set; }


    }
}
