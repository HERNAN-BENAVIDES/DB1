﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectofinalDb1.data
{
    public class DetalleEmpleadoProfesion
    {
        [Key, Column(Order = 0)]
        public int Empleado { get; set; }

        [Key, Column(Order = 1)]
        public int Profesion { get; set; }

        [ForeignKey("Empleado")]
        public Empleado EmpleadoNavigation { get; set; }

        [ForeignKey("Profesion")]
        public Profesion ProfesionNavigation { get; set; }
    }
}
