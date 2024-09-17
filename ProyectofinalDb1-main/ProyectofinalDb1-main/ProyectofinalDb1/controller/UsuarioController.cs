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
    public class UsuarioController : Controller<UsuarioRepository, Usuario>
    {
        private readonly UsuarioRepository _UsuarioRepository;
        private readonly NivelRepository _nivelRepository;
        private string permiso;

        public UsuarioController(UsuarioRepository UsuarioRepository, NivelRepository nivelRepository) : base(UsuarioRepository)
        {
            _UsuarioRepository = UsuarioRepository;
            _nivelRepository = nivelRepository;
        }

        public Usuario Login(string username, string password)
        {
            return Buscar(u => u.NomUsuario.Equals(username) && u.Clave.Equals(password));
        }

        public string AddUsuario(int codigo, string nombre, string clave, DateTime fechaCreacion,
            string nivel)
        {
            if(this.permiso == "1" || this.permiso == "2")
            {
                if (!ExisteUsuario(codigo))
                {
                    Usuario Usuario = new Usuario
                    {
                        Codigo = codigo,
                        NomUsuario = nombre,
                        Clave = clave,
                        FechaCreacion = fechaCreacion.ToUniversalTime(),
                        Nivel = _nivelRepository.Get(f => f.Nombre.Equals(nivel)).Codigo,
                    };

                    Agregar(Usuario);
                    return "Usuario Agregado";
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

        public string DeleteUsuario(int codigo, string nombre, string clave, DateTime fechaCreacion,
            string nivel)
        {
            if (this.permiso == "1" || this.permiso == "2")
            {
                Usuario Usuario = new Usuario
                {
                    Codigo = codigo,
                    NomUsuario = nombre,
                    Clave = clave,
                    FechaCreacion = fechaCreacion.ToUniversalTime(),
                    Nivel = _nivelRepository.Get(f => f.Nombre.Equals(nivel)).Codigo,
                };
                if (ExisteUsuario(Usuario))
                {
                    _UsuarioRepository.Delete(codigo);
                    return "Usuario Eliminado";
                }
                else
                {
                    return "El Usuario no existe";
                }

            }
            else
            {
                return "Su nivel no es apto para esta funcionalidad";
            }
          
        }

        public string ActualizarUsuario(int codigo, string nombre, string clave, DateTime fechaCreacion,
            string nivel)
        {
            if (this.permiso == "1" || this.permiso == "2")
            {
                if (ExisteUsuario(codigo))
                {
                    Usuario Usuario = new Usuario
                    {
                        Codigo = codigo,
                        NomUsuario = nombre,
                        Clave = clave,
                        FechaCreacion = fechaCreacion.ToUniversalTime(),
                        Nivel = _nivelRepository.Get(f => f.Nombre.Equals(nivel)).Codigo,
                    };
                    _UsuarioRepository.Update(Usuario);
                    return "Usuario Actualizado";
                }
                else
                {
                    return "El Usuario no existe";
                }

            }
            else
            {
                return "Su nivel no es apto para esta funcionalidad";
            }
         
        }

        public string obtenerNivel(string username)
        {
            Usuario usuario = _UsuarioRepository.Get(u => u.NomUsuario.Equals(username));
            return usuario.Nivel.ToString();


        }

        private bool ExisteUsuario(Usuario Usuario)
        {
            return _UsuarioRepository.Any(b => b == Usuario);
        }

        private bool ExisteUsuario(int codigo)
        {
            return _UsuarioRepository.Any(b => b.Codigo == codigo);
        }

        public List<Usuario> ObtenerUsuariosConNivel2()
        {
            return _UsuarioRepository.GetAllFilter(u => u.Nivel == 2).ToList();
        }

        internal void asignarNivel(string nivel)
        {
            this.permiso = nivel;
        }
    }

    
}
