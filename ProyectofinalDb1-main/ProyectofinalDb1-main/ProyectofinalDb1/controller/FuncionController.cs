using ProyectofinalDb1.data;
using ProyectofinalDb1.repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectofinalDb1.controller
{
    public class FuncionController : Controller<FuncionRepository, Funcion>
    {
        private readonly FuncionRepository _funcionRepository;
        private string permiso;
        public FuncionController(FuncionRepository funcionRepository) : base(funcionRepository)
        {
            _funcionRepository = funcionRepository;
        }

        public string AddFuncion(int codigo, string nombre, string descripcion)
        {
            if(this.permiso == "1")
            {
                if (!ExisteFuncion(codigo))
                {
                    Funcion Funcion = new Funcion
                    {
                        Codigo = codigo,
                        Nombre = nombre,
                        Descripcion = descripcion
                    };

                    Agregar(Funcion);
                    return "Funcion Agregada";
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

        public string DeleteFuncion(int codigo, string nombre, string descripcion)
        {
            if (this.permiso == "1")
            {
                Funcion Funcion = new Funcion
                {
                    Codigo = codigo,
                    Nombre = nombre,
                    Descripcion = descripcion
                };
                if (ExisteFuncion(Funcion))
                {
                    _funcionRepository.Delete(codigo);
                    return "Funcion Eliminada";
                }
                else
                {
                    return "El Funcion no existe";
                }

            }
            else
            {
                return "Su nivel no es apto para esta funcionalidad";
            }
           
        }

        public string ActualizarFuncion(int codigo, string nombre, string descripcion)
        {
            if (this.permiso == "1")
            {
                if (ExisteFuncion(codigo))
                {
                    Funcion Funcion = new Funcion
                    {
                        Codigo = codigo,
                        Nombre = nombre,
                        Descripcion = descripcion
                    };
                    _funcionRepository.Update(Funcion);
                    return "Funcion Actualizada";
                }
                else
                {
                    return "El Funcion no existe";
                }

            }
            else
            {
                return "Su nivel no es apto para esta funcionalidad";
            }
           
        }

        private bool ExisteFuncion(Funcion Funcion)
        {
            return _funcionRepository.Any(b => b == Funcion);
        }

        private bool ExisteFuncion(int codigo)
        {
            return _funcionRepository.Any(b => b.Codigo == codigo);
        }

        internal void asignarNivel(string nivel)
        {
            this.permiso = nivel;
        }

        public List<Funcion> obtenerTodos()
        {
            return _funcionRepository.GetAll().ToList();
        }
    }
}
