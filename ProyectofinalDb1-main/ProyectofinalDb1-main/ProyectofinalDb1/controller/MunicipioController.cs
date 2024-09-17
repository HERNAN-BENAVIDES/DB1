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
    public class MunicipioController : Controller<MunicipioRepository, Municipio>
    {
        private readonly MunicipioRepository _MunicipioRepository;
        private readonly PrioridadRepository _prioridadRepository;
        private readonly DepartamentoRepository _departamentoRepository;
        private string permiso;

        public MunicipioController(MunicipioRepository MunicipioRepository, PrioridadRepository prioridadRepository, DepartamentoRepository departamentoRepository) : base(MunicipioRepository)
        {
            _MunicipioRepository = MunicipioRepository;
            _prioridadRepository = prioridadRepository;
            _departamentoRepository = departamentoRepository;
        }

        public string AddMunicipio(int codigo, string nombre, int poblacion,
            string prioridad, string departamento)
        {
            if(this.permiso == "1")
            {
                if (!ExisteMunicipio(codigo))
                {
                    Municipio Municipio = new Municipio
                    {
                        Codigo = codigo,
                        Nombre = nombre,
                        Poblacion = poblacion,
                        Prioridad = _prioridadRepository.Get(f => f.Nombre.Equals(prioridad)).Codigo,
                        Departamento = _departamentoRepository.Get(f => f.Nombre.Equals(departamento)).Codigo,
                    };

                    Agregar(Municipio);
                    return "Municipio Agregado";
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

        public string DeleteMunicipio(int codigo, string nombre, int poblacion,
            string prioridad, string departamento)
        {
            if (this.permiso == "1")
            {
                Municipio Municipio = new Municipio
                {
                    Codigo = codigo,
                    Nombre = nombre,
                    Poblacion = poblacion,
                    Prioridad = _prioridadRepository.Get(f => f.Nombre.Equals(prioridad)).Codigo,
                    Departamento = _departamentoRepository.Get(f => f.Nombre.Equals(departamento)).Codigo,
                };
                if (ExisteMunicipio(Municipio))
                {
                    _MunicipioRepository.Delete(codigo);
                    return "Municipio Eliminado";
                }
                else
                {
                    return "El Municipio no existe";
                }

            }
            else
            {
                return "Su nivel no es apto para esta funcionalidad";
            }
           
        }

        public string ActualizarMunicipio(int codigo, string nombre, int poblacion,
            string prioridad, string departamento)
        {
            if (this.permiso == "1")
            {
                if (ExisteMunicipio(codigo))
                {
                    Municipio Municipio = new Municipio
                    {
                        Codigo = codigo,
                        Nombre = nombre,
                        Poblacion = poblacion,
                        Prioridad = _prioridadRepository.Get(f => f.Nombre.Equals(prioridad)).Codigo,
                        Departamento = _departamentoRepository.Get(f => f.Nombre.Equals(departamento)).Codigo,
                    };
                    _MunicipioRepository.Update(Municipio);
                    return "Municipio Actualizado";
                }
                else
                {
                    return "El Municipio no existe";
                }

            }
            else
            {
                return "Su nivel no es apto para esta funcionalidad";
            }
         
        }

        private bool ExisteMunicipio(Municipio Municipio)
        {
            return _MunicipioRepository.Any(b => b == Municipio);
        }

        private bool ExisteMunicipio(int codigo)
        {
            return _MunicipioRepository.Any(b => b.Codigo == codigo);
        }

        internal void asignarNivel(string nivel)
        {
            this.permiso = nivel;
        }

        public List<Municipio> obtenerTodos()
        {
            return _MunicipioRepository.GetAll().ToList();
        }
    }
}
