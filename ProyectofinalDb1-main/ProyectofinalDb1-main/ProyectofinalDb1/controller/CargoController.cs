using ProyectofinalDb1.data;
using ProyectofinalDb1.repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ProyectofinalDb1.controller
{
    public class CargoController : Controller<CargoRepository, Cargo>
    {
        private readonly CargoRepository _CargoRepository;
        private readonly FuncionRepository _funcionRepository;
        private string permiso;

        public CargoController(CargoRepository CargoRepository, FuncionRepository funcionRepository) : base(CargoRepository)
        {
            _CargoRepository = CargoRepository;
            _funcionRepository = funcionRepository;
        }

        public string AddCargo(int codigo, string nombre, int salario, string funcion)
        {
            if (this.permiso == "1")
            {
                if (!ExisteCargo(codigo))
                {
                    Cargo Cargo = new Cargo
                    {
                        Codigo = codigo,
                        Nombre = nombre,
                        Salario = salario,
                        Funcion = _funcionRepository.Get(f => f.Nombre.Equals(funcion)).Codigo,
                    };

                    Agregar(Cargo);
                    return "Cargo Agregado";
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

        public string DeleteCargo(int codigo, string nombre, int salario, string funcion)
        {
            if (this.permiso == "1")
            {
                Cargo Cargo = new Cargo
                {
                    Codigo = codigo,
                    Nombre = nombre,
                    Salario = salario,
                    Funcion = _funcionRepository.Get(f => f.Nombre.Equals(funcion)).Codigo,
                };
                if (ExisteCargo(Cargo))
                {
                    _CargoRepository.Delete(codigo);
                    return "Cargo Eliminado";
                }
                else
                {
                    return "El Cargo no existe";
                }

            }
            else
            {
               
                return "Su nivel no es apto para esta funcionalidad";
            }
            
        }

        public string ActualizarCargo(int codigo, string nombre, int salario, string funcion)
        {
            if (this.permiso == "1")
            {
                if (ExisteCargo(codigo))
                {
                    Cargo Cargo = new Cargo
                    {
                        Codigo = codigo,
                        Nombre = nombre,
                        Salario = salario,
                        Funcion = _funcionRepository.Get(f => f.Nombre.Equals(funcion)).Codigo,
                    };
                    _CargoRepository.Update(Cargo);
                    return "Cargo Actualizado";
                }
                else
                {
                    return "El Cargo no existe";
                }

            }
            else
            {
              
                return "Su nivel no es apto para esta funcionalidad";
            }
            
        }

        private bool ExisteCargo(Cargo Cargo)
        {
            return _CargoRepository.Any(b => b == Cargo);
        }

        private bool ExisteCargo(int codigo)
        {
            return _CargoRepository.Any(b => b.Codigo == codigo);
        }

        internal void asignarNivel(string nivel)
        {
           this.permiso = nivel;
        }
    }
}
