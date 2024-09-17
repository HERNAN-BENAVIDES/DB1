using ProyectofinalDb1.data;
using ProyectofinalDb1.repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ProyectofinalDb1.controller
{
    public class EmpleadoProfesionController : Controller<EmpleadoProfesionRepository, DetalleEmpleadoProfesion>
    {
        private readonly EmpleadoProfesionRepository _EmpleadoProfesionRepository;
        private readonly EmpleadoRepository _empleadoRepository;
        private readonly ProfesionRepository _profesionRepository;

        public EmpleadoProfesionController(EmpleadoProfesionRepository EmpleadoProfesionRepository,
            EmpleadoRepository empleadoRepository,
            ProfesionRepository profesionRepository) : base(EmpleadoProfesionRepository)
        {
            _EmpleadoProfesionRepository = EmpleadoProfesionRepository;
            _empleadoRepository = empleadoRepository;
            _profesionRepository = profesionRepository;
        }

        public string AddEmpleadoProfesion(string empleado, string profesion)
        {
            var empleadoE = _empleadoRepository.Get(e => e.Nombre.Equals(empleado));
            var profesionE = _profesionRepository.Get(e => e.Nombre.Equals(profesion));
            if (!ExisteEmpleadoProfesion(empleadoE.Codigo, profesionE.Codigo))
            {
                DetalleEmpleadoProfesion EmpleadoProfesion = new DetalleEmpleadoProfesion
                {
                    Empleado = empleadoE.Codigo,
                    Profesion = profesionE.Codigo,
                };

                Agregar(EmpleadoProfesion);
                return "Empleado - Profesion Agregado";
            }
            else
            {
                return "La combinacion en la base de datos";
            }
        }

        public string DeleteEmpleadoProfesion(string empleado, string profesion)
        {
            var empleadoE = _empleadoRepository.Get(e => e.Nombre.Equals(empleado));
            var profesionE = _profesionRepository.Get(e => e.Nombre.Equals(profesion));
            DetalleEmpleadoProfesion EmpleadoProfesion = new DetalleEmpleadoProfesion
            {
                Empleado = empleadoE.Codigo,
                Profesion = profesionE.Codigo,
            };
            if (ExisteEmpleadoProfesion(EmpleadoProfesion))
            {
                _EmpleadoProfesionRepository.Delete(EmpleadoProfesion);
                return "Empleado - Profesion Eliminado";
            }
            else
            {
                return "El Empleado - Profesion no existe";
            }
        }

        internal void asignarNivel(string nivel)
        {
            throw new NotImplementedException();
        }

        private bool ExisteEmpleadoProfesion(DetalleEmpleadoProfesion EmpleadoProfesion)
        {
            return _EmpleadoProfesionRepository.Any(b => b == EmpleadoProfesion);
        }

        private bool ExisteEmpleadoProfesion(int empleado, int profesion)
        {
            return _EmpleadoProfesionRepository.Any(b => b.Empleado == empleado && b.Profesion == profesion);
        }
    }
}
