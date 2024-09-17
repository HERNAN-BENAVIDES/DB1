using ProyectofinalDb1.data;
using ProyectofinalDb1.repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectofinalDb1.controller
{
    public class ProfesionController : Controller<ProfesionRepository, Profesion>
    {
        private readonly ProfesionRepository _profesionRepository;
        private string permiso;
        public ProfesionController(ProfesionRepository profesionRepository) : base(profesionRepository)
        {
            _profesionRepository = profesionRepository;
        }

        public string AddProfesion(int codigo, string nombre, string descripcion)
        {
            if (this.permiso == "1")
            {
                if (!ExisteProfesion(codigo))
                {
                    Profesion Profesion = new Profesion
                    {
                        Codigo = codigo,
                        Nombre = nombre,
                        Descripcion = descripcion
                    };

                    Agregar(Profesion);
                    return "Profesion Agregada";
                }
                else
                {
                    return "El codigo existe en la base de datos";
                }

            }
            else
            {
            
                return "Su nivel no es apto para esta funcionalidad";
            }
           
        }

        public string DeleteProfesion(int codigo, string nombre, string descripcion)
        {
            if (this.permiso == "1")
            {
                Profesion Profesion = new Profesion
                {
                    Codigo = codigo,
                    Nombre = nombre,
                    Descripcion = descripcion
                };
                if (ExisteProfesion(Profesion))
                {
                    _profesionRepository.Delete(codigo);
                    return "Profesion Eliminada";
                }
                else
                {
                    return "La Profesion no existe";
                }
            }
            else
            {

                return "Su nivel no es apto para esta funcionalidad";
            }
           
        }

        public string ActualizarProfesion(int codigo, string nombre, string descripcion)
        {
            if (this.permiso == "1")
            {
                if (ExisteProfesion(codigo))
                {
                    Profesion Profesion = new Profesion
                    {
                        Codigo = codigo,
                        Nombre = nombre,
                        Descripcion = descripcion
                    };
                    _profesionRepository.Update(Profesion);
                    return "Profesion Actualizada";
                }
                else
                {
                    return "La Profesion no existe";
                }

            }
            else
            {

                return "Su nivel no es apto para esta funcionalidad";
            }
            
        }

        private bool ExisteProfesion(Profesion Profesion)
        {
            return _profesionRepository.Any(b => b == Profesion);
        }

        private bool ExisteProfesion(int codigo)
        {
            return _profesionRepository.Any(b => b.Codigo == codigo);
        }

        internal void asignarNivel(string nivel)
        {
            this.permiso = nivel;
        }
    }
}
