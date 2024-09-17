using ProyectofinalDb1.data;
using ProyectofinalDb1.repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectofinalDb1.controller
{
    public class PrioridadController : Controller<PrioridadRepository, Prioridad>
    {
        private readonly PrioridadRepository _PrioridadRepository;
        public PrioridadController(PrioridadRepository PrioridadRepository) : base(PrioridadRepository)
        {
            _PrioridadRepository = PrioridadRepository;
        }

        public string AddPrioridad(int codigo, string nombre)
        {
            if (!ExistePrioridad(codigo))
            {
                Prioridad Prioridad = new Prioridad
                {
                    Codigo = codigo,
                    Nombre = nombre
                };

                Agregar(Prioridad);
                return "Prioridad Agregada";
            }
            else
            {
                return "El codigo existe en la base de datos";
            }
        }

        public string DeletePrioridad(int codigo, string nombre)
        {
            Prioridad Prioridad = new Prioridad
            {
                Codigo = codigo,
                Nombre = nombre
            };
            if (ExistePrioridad(Prioridad))
            {
                _PrioridadRepository.Delete(codigo);
                return "Prioridad Eliminada";
            }
            else
            {
                return "La Prioridad no existe";
            }
        }

        public string ActualizarPrioridad(int codigo, string nombre)
        {
            if (ExistePrioridad(codigo))
            {
                Prioridad Prioridad = new Prioridad
                {
                    Codigo = codigo,
                    Nombre = nombre
                };
                _PrioridadRepository.Update(Prioridad);
                return "Prioridad Actualizada";
            }
            else
            {
                return "La Prioridad no existe";
            }
        }

        private bool ExistePrioridad(Prioridad Prioridad)
        {
            return _PrioridadRepository.Any(b => b == Prioridad);
        }

        private bool ExistePrioridad(int codigo)
        {
            return _PrioridadRepository.Any(b => b.Codigo == codigo);
        }

        internal void asignarNivel(string nivel)
        {
            throw new NotImplementedException();
        }
    }
}
