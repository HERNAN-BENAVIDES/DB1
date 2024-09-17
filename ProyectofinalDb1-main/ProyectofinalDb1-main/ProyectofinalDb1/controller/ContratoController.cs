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
    public class ContratoController : Controller<ContratoRepository, Contrato>
    {
        private readonly ContratoRepository _ContratoRepository;
        private readonly EmpleadoRepository _empleadoRepository;
        private readonly CargoRepository _cargoRepository;
        private readonly SucursalRepository _sucursalRepository;
        private string permiso;

        public ContratoController(ContratoRepository ContratoRepository, EmpleadoRepository empleadoRepository,
            CargoRepository cargoRepository, SucursalRepository sucursalRepository) : base(ContratoRepository)
        {
            _ContratoRepository = ContratoRepository;
            _empleadoRepository = empleadoRepository;
            _cargoRepository = cargoRepository;
            _sucursalRepository = sucursalRepository;
        }

        public string AddContrato(int codigo, string empleado, string cargo, string sucursal,
            DateTime fechaInicio, DateTime fechaFin)
        {
            if(this.permiso == "1" || this.permiso == "2")
            {
                if (!ExisteContrato(codigo))
                {
                    Contrato Contrato = new Contrato
                    {
                        Codigo = codigo,
                        Empleado = _empleadoRepository.Get(f => f.Nombre.Equals(empleado)).Codigo,
                        Cargo = _cargoRepository.Get(f => f.Nombre.Equals(cargo)).Codigo,
                        Sucursal = _sucursalRepository.Get(f => f.Nombre.Equals(sucursal)).Codigo,
                        FechaInicio = fechaInicio.ToUniversalTime(),
                        FechaFin = fechaFin.ToUniversalTime(),
                    };

                    Agregar(Contrato);
                    return "Contrato Agregado";
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

        public string DeleteContrato(int codigo, string empleado, string cargo, string sucursal,
            DateTime fechaInicio, DateTime fechaFin)
        {
            if (this.permiso == "1" || this.permiso == "2")
            {
                Contrato Contrato = new Contrato
                {
                    Codigo = codigo,
                    Empleado = _empleadoRepository.Get(f => f.Nombre.Equals(empleado)).Codigo,
                    Cargo = _cargoRepository.Get(f => f.Nombre.Equals(cargo)).Codigo,
                    Sucursal = _sucursalRepository.Get(f => f.Nombre.Equals(sucursal)).Codigo,
                    FechaInicio = fechaInicio.ToUniversalTime(),
                    FechaFin = fechaFin.ToUniversalTime(),
                };
                if (ExisteContrato(Contrato))
                {
                    _ContratoRepository.Delete(codigo);
                    return "Contrato Eliminado";
                }
                else
                {
                    return "El Contrato no existe";
                }

            }
            else
            {
                return "Su nivel no es apto para la funcionalidad";
            }
          
        }

        public string ActualizarContrato(int codigo, string empleado, string cargo, string sucursal,
            DateTime fechaInicio, DateTime fechaFin)
        {
            if (this.permiso == "1" || this.permiso == "2")
            {
                if (ExisteContrato(codigo))
                {
                    Contrato Contrato = new Contrato
                    {
                        Codigo = codigo,
                        Empleado = _empleadoRepository.Get(f => f.Nombre.Equals(empleado)).Codigo,
                        Cargo = _cargoRepository.Get(f => f.Nombre.Equals(cargo)).Codigo,
                        Sucursal = _sucursalRepository.Get(f => f.Nombre.Equals(sucursal)).Codigo,
                        FechaInicio = fechaInicio.ToUniversalTime(),
                        FechaFin = fechaFin.ToUniversalTime(),
                    };
                    _ContratoRepository.Update(Contrato);
                    return "Contrato Actualizado";
                }
                else
                {
                    return "El Contrato no existe";
                }

            }
            else
            {
                return "Su nivel no es apto para la funcionalidad";
            }
          
        }

        private bool ExisteContrato(Contrato Contrato)
        {
            return _ContratoRepository.Any(b => b == Contrato);
        }

        private bool ExisteContrato(int codigo)
        {
            return _ContratoRepository.Any(b => b.Codigo == codigo);
        }

        internal void asignarNivel(string nivel)
        {
            this.permiso = nivel;
        }
    }
}
