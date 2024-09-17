using ProyectofinalDb1.data;
using ProyectofinalDb1.repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ProyectofinalDb1.controller
{
    public class SucursalController : Controller<SucursalRepository, Sucursal>
    {
        private readonly SucursalRepository _SucursalRepository;
        private readonly UsuarioRepository _usuarioRepository;
        private readonly MunicipioRepository _municipioRepository;
        private string permiso;

        public SucursalController(SucursalRepository SucursalRepository, UsuarioRepository usuarioRepository,
            MunicipioRepository municipioRepository) : base(SucursalRepository)
        {
            _SucursalRepository = SucursalRepository;
            _usuarioRepository = usuarioRepository;
            _municipioRepository = municipioRepository;
        }

        public string AddSucursal(int codigo, string nombre, int presupuesto,
            string director, string municipio)
        {
            if(this.permiso == "1")
            {
                if (!ExisteSucursal(codigo))
                {
                    Sucursal Sucursal = new Sucursal
                    {
                        Codigo = codigo,
                        Nombre = nombre,
                        Presupuesto = presupuesto,
                        Director = _usuarioRepository.Get(u => u.NomUsuario.Equals(director)).Codigo,
                        Municipio = _municipioRepository.Get(f => f.Nombre.Equals(municipio)).Codigo,
                    };

                    Agregar(Sucursal);
                    return "Sucursal Agregada";
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

        public string DeleteSucursal(int codigo, string nombre, int presupuesto,
            string director, string municipio)
        {
            if (this.permiso == "1")
            {
                Sucursal Sucursal = new Sucursal
                {
                    Codigo = codigo,
                    Nombre = nombre,
                    Presupuesto = presupuesto,
                    Director = _usuarioRepository.Get(u => u.NomUsuario.Equals(director)).Codigo,
                    Municipio = _municipioRepository.Get(f => f.Nombre.Equals(municipio)).Codigo,
                };
                if (ExisteSucursal(Sucursal))
                {
                    _SucursalRepository.Delete(codigo);
                    return "Sucursal Eliminada";
                }
                else
                {
                    return "El Sucursal no existe";
                }

            }
            else
            {
                return "Su nivel no es apto para esta funcionalidad";
            }
          
        }

        public string ActualizarSucursal(int codigo, string nombre, int presupuesto,
            string director, string municipio)
        {
            if (this.permiso == "1")
            {
                if (ExisteSucursal(codigo))
                {
                    Sucursal Sucursal = new Sucursal
                    {
                        Codigo = codigo,
                        Nombre = nombre,
                        Presupuesto = presupuesto,
                        Director = _usuarioRepository.Get(u => u.NomUsuario.Equals(director)).Codigo,
                        Municipio = _municipioRepository.Get(f => f.Nombre.Equals(municipio)).Codigo,
                    };
                    _SucursalRepository.Update(Sucursal);
                    return "Sucursal Actualizada";
                }
                else
                {
                    return "El Sucursal no existe";
                }

            }
            else
            {
                return "Su nivel no es apto para esta funcionalidad";
            }
          
        }

        private bool ExisteSucursal(Sucursal Sucursal)
        {
            return _SucursalRepository.Any(b => b == Sucursal);
        }

        private bool ExisteSucursal(int codigo)
        {
            return _SucursalRepository.Any(b => b.Codigo == codigo);
        }

        internal void asignarNivel(string nivel)
        {
            this.permiso = nivel;
        }
    }
}
