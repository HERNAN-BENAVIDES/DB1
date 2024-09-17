using iText.Kernel.Crypto.Securityhandler;
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
    public class EmpleadoController : Controller<EmpleadoRepository, Empleado>
    {
        private readonly EmpleadoRepository _EmpleadoRepository;
        private readonly UsuarioRepository _usuarioRepository;
        private string nivel;

        public EmpleadoController(EmpleadoRepository EmpleadoRepository, UsuarioRepository usuarioRepository) : base(EmpleadoRepository)
        {
            _EmpleadoRepository = EmpleadoRepository;
            _usuarioRepository = usuarioRepository;
        }

        public string AddEmpleado(int codigo, string cedula, string nombre, string direccion, string telefono,
            string usuario)
        {
            if(this.nivel == "1")
            {
                if (!ExisteEmpleado(codigo))
                {
                    Empleado Empleado = new Empleado
                    {
                        Codigo = codigo,
                        Cedula = cedula,
                        Nombre = nombre,
                        DireccionResidencia = direccion,
                        Telefono = telefono,
                        Usuario = _usuarioRepository.Get(f => f.NomUsuario.Equals(usuario)).Codigo,
                    };

                    Agregar(Empleado);
                    return "Empleado Agregado";
                }
                else
                {
                    return "El codigo existe en la base de datos";
                }

            }
            else
            {
                mostarMensaje("Su nivel no es apto para este funcionalidad");
                return "Nivel invalido";
            }

           
        }

        public string DeleteEmpleado(int codigo, string cedula, string nombre, string direccion, string telefono,
            string usuario)
        {
            if(this.nivel == "1")
            {
                Empleado Empleado = new Empleado
                {
                    Codigo = codigo,
                    Cedula = cedula,
                    Nombre = nombre,
                    DireccionResidencia = direccion,
                    Telefono = telefono,
                    Usuario = _usuarioRepository.Get(f => f.NomUsuario.Equals(usuario)).Codigo,
                };
                if (ExisteEmpleado(Empleado))
                {
                    _EmpleadoRepository.Delete(codigo);
                    return "Empleado Eliminado";
                }
                else
                {
                    return "El Empleado no existe";
                }
            }
            else
            {
                mostarMensaje("Su nivel no es apto para este funcionalidad");
                return "Nivel invalido";
            }
           
        }

        public string ActualizarEmpleado(int codigo, string cedula, string nombre, string direccion, string telefono,
            string usuario)
        {
            if (this.nivel == "1")
            {
                if (ExisteEmpleado(codigo))
                {
                    Empleado Empleado = new Empleado
                    {
                        Codigo = codigo,
                        Cedula = cedula,
                        Nombre = nombre,
                        DireccionResidencia = direccion,
                        Telefono = telefono,
                        Usuario = _usuarioRepository.Get(f => f.NomUsuario.Equals(usuario)).Codigo,
                    };
                    _EmpleadoRepository.Update(Empleado);
                    return "Empleado Actualizado";
                }
                else
                {
                    return "El Empleado no existe";
                }

            }
            else
            {
                mostarMensaje("Su nivel no es apto para este funcionalidad");
                return "Nivel invalido";

            }
            
        }

        public void asignarNivel(string nivel)
        {
            this.nivel = nivel;
        }

        private void mostarMensaje(string Mensaje)
        {
            MessageBox.Show(Mensaje, "Mensaje");
        }

        private bool ExisteEmpleado(Empleado Empleado)
        {
            return _EmpleadoRepository.Any(b => b == Empleado);
        }

        private bool ExisteEmpleado(int codigo)
        {
            return _EmpleadoRepository.Any(b => b.Codigo == codigo);
        }

        public List<Empleado> obtenerTodos() 
        {
            return _EmpleadoRepository.GetAll().ToList();

        }

        public string obtenerNivel()
        {
            return this.nivel;
        }
    }
}
