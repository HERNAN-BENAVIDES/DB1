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
    public class DepartamentoController : Controller<DepartamentoRepository, Departamento>
    {
        private readonly DepartamentoRepository _DepartamentoRepository;
        private string permiso;
        public DepartamentoController(DepartamentoRepository DepartamentoRepository) : base(DepartamentoRepository)
        {
            _DepartamentoRepository = DepartamentoRepository;
        }

        public string AddDepartamento(int codigo, string nombre, int poblacion)
        {
            if(this.permiso == "1")
            {
                if (!ExisteDepartamento(codigo))
                {
                    Departamento Departamento = new Departamento
                    {
                        Codigo = codigo,
                        Nombre = nombre,
                        Poblacion = poblacion
                    };

                    Agregar(Departamento);
                    return "Departamento Agregado";
                }
                else
                {
                    return "El codigo existe en la base de datos";
                }

            }
            else
            {
                return "Su nivel no es apto para la funcionalidad";
            }
          
        }

        public string DeleteDepartamento(int codigo, string nombre, int poblacion)
        {
            if (this.permiso == "1")
            {
                Departamento Departamento = new Departamento
                {
                    Codigo = codigo,
                    Nombre = nombre,
                    Poblacion = poblacion
                };
                if (ExisteDepartamento(Departamento))
                {
                    _DepartamentoRepository.Delete(codigo);
                    return "Departamento Eliminado";
                }
                else
                {
                    return "El Departamento no existe";
                }

            }
            else
            {
                return "Su nivel no es apto para la funcionalidad";
            }
          
        }

        public string ActualizarDepartamento(int codigo, string nombre, int poblacion)
        {
            if (this.permiso == "1")
            {
                if (ExisteDepartamento(codigo))
                {
                    Departamento Departamento = new Departamento
                    {
                        Codigo = codigo,
                        Nombre = nombre,
                        Poblacion = poblacion
                    };
                    _DepartamentoRepository.Update(Departamento);
                    return "Departamento Actualizado";
                }
                else
                {
                    return "El Departamento no existe";
                }

            }
            else
            {
                return "Su nivel no es apto para la funcionalidad";
            }
          
        }

        private bool ExisteDepartamento(Departamento Departamento)
        {
            return _DepartamentoRepository.Any(b => b == Departamento);
        }

        private bool ExisteDepartamento(int codigo)
        {
            return _DepartamentoRepository.Any(b => b.Codigo == codigo);
        }

        internal void asignarNivel(string nivel)
        {
            this.permiso = nivel;
        }

        public List<Departamento> obtenerTodos()
        {
            return _DepartamentoRepository.GetAll().ToList();
        }
    }
}
