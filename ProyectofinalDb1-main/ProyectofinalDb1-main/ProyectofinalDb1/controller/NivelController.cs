using ProyectofinalDb1.data;
using ProyectofinalDb1.repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectofinalDb1.controller
{
    public class NivelController : Controller<NivelRepository, Nivel>
    {
        private readonly NivelRepository _NivelRepository;
        public NivelController(NivelRepository NivelRepository) : base(NivelRepository)
        {
            _NivelRepository = NivelRepository;
        }

        public string AddNivel(int codigo, string nombre)
        {
            if (!ExisteNivel(codigo))
            {
                Nivel Nivel = new Nivel
                {
                    Codigo = codigo,
                    Nombre = nombre
                };

                Agregar(Nivel);
                return "Nivel Agregado";
            }
            else
            {
                return "El codigo existe en la base de datos";
            }
        }

        public string DeleteNivel(int codigo, string nombre)
        {
            Nivel Nivel = new Nivel
            {
                Codigo = codigo,
                Nombre = nombre
            };
            if (ExisteNivel(Nivel))
            {
                _NivelRepository.Delete(codigo);
                return "Nivel Eliminado";
            }
            else
            {
                return "El Nivel no existe";
            }
        }

        public string ActualizarNivel(int codigo, string nombre)
        {
            if (ExisteNivel(codigo))
            {
                Nivel Nivel = new Nivel
                {
                    Codigo = codigo,
                    Nombre = nombre
                };
                _NivelRepository.Update(Nivel);
                return "Nivel Actualizado";
            }
            else
            {
                return "El Nivel no existe";
            }
        }

        private bool ExisteNivel(Nivel Nivel)
        {
            return _NivelRepository.Any(b => b == Nivel);
        }

        private bool ExisteNivel(int codigo)
        {
            return _NivelRepository.Any(b => b.Codigo == codigo);
        }

        internal void asignarNivel(string nivel)
        {
            throw new NotImplementedException();
        }
    }
}
