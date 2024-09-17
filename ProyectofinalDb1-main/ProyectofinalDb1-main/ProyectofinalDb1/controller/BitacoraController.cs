using ProyectofinalDb1.data;
using ProyectofinalDb1.repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectofinalDb1.controller
{
    public class BitacoraController : Controller<BitacoraRepository, Bitacora>
    {
        private readonly BitacoraRepository _bitacoraRepository;
        private readonly UsuarioRepository _usuarioRepository;
        public BitacoraController(BitacoraRepository bitacoraRepository, UsuarioRepository usuarioRepository) : base(bitacoraRepository)
        {
            _bitacoraRepository = bitacoraRepository;
            _usuarioRepository = usuarioRepository;
        }

        public string AddBitacora(int codigo, DateTime fechaIngreso, DateTime fechaSalida,
            TimeSpan horaIngreso, TimeSpan horaSalida, string usuario)
        {
            if(!ExisteBitacora(codigo)){
                Bitacora bitacora = new Bitacora
                {
                    Codigo = codigo,
                    FechaIngreso = fechaIngreso.ToUniversalTime(),
                    FechaSalida = fechaSalida.ToUniversalTime(),
                    HoraIngreso = horaIngreso,
                    HoraSalida = horaSalida,
                    Usuario = _usuarioRepository.Get(u => u.NomUsuario.Equals(usuario)).Codigo,
                };

                Agregar(bitacora);
                return "Bitacora Agregada";
            }else
            {
                return "El codigo existe en la base de datos";
            }
        }

        public string DeleteBitacora(int codigo, DateTime fechaIngreso, DateTime fechaSalida,
            TimeSpan horaIngreso, TimeSpan horaSalida, string usuario)
        {
            Bitacora bitacora = new Bitacora
            {
                Codigo = codigo,
                FechaIngreso = fechaIngreso.ToUniversalTime(),
                FechaSalida = fechaSalida.ToUniversalTime(),
                HoraIngreso = horaIngreso,
                HoraSalida = horaSalida,
                Usuario = _usuarioRepository.Get(u => u.NomUsuario.Equals(usuario)).Codigo,
            };
            if (ExisteBitacora(bitacora))
            {
                _bitacoraRepository.Delete(codigo);
                return "Bitacora Eliminada";
            }
            else
            {
                return "La bitacora no existe";
            }
        }

        public int ultimoIndice()
        {
            // Ordena las entradas por el código de forma descendente y toma el primero
            var ultimaBitacora = _bitacoraRepository.GetAll().OrderByDescending(b => b.Codigo).FirstOrDefault();

            if (ultimaBitacora != null)
            {
                return ultimaBitacora.Codigo;
            }
            else
            {
                // Si no hay ninguna entrada en la tabla de bitácora, retorna un valor predeterminado
                return 0; // O cualquier otro valor que desees
            }
        }

        internal void asignarNivel(string nivel)
        {
            throw new NotImplementedException();
        }

        private bool ExisteBitacora(Bitacora bitacora)
        {
            return _bitacoraRepository.Any(b => b  == bitacora);
        }

        private bool ExisteBitacora(int codigo)
        {
            return _bitacoraRepository.Any(b => b.Codigo == codigo);
        }

        public List<Bitacora> obtenerTodas()
        {
            return _bitacoraRepository.GetAll().ToList();
        }
    }
}
