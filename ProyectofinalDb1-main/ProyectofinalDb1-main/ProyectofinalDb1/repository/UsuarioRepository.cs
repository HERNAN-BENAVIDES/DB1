using ProyectofinalDb1.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectofinalDb1.repository
{
    public class UsuarioRepository : Repository<Usuario>
    {
        private readonly DataContext _dataContext;

        public UsuarioRepository(DataContext dataContext) : base(dataContext)
        {
            _dataContext = dataContext;
        }

        public bool Delete(int codigo)
        {
            var entity = _dataContext.Usuario.Find(codigo);
            if (entity != null)
            {
                base.Delete(entity);
                return Save();
            }
            return false; // Opcional: Manejar el caso en el que la entidad no existe
        }

        public bool Update(Usuario Usuario)
        {
            var entity = Get(b => b.Codigo == Usuario.Codigo);
            if (entity != null)
            {
                entity.NomUsuario = Usuario.NomUsuario;
                entity.Clave = Usuario.Clave;
                entity.FechaCreacion = Usuario.FechaCreacion;
                entity.Nivel = Usuario.Nivel;
                base.Update(entity);
                return Save();
            }
            return false; // Opcional: Manejar el caso en el que la entidad no existe
        }

        internal void asignarNivel(string nivel)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Usuario> GetAll()
        {
            return _dataContext.Usuario.ToList();
        }

        public IEnumerable<Usuario> GetAllFilter(Func<Usuario, bool> predicate)
        {
            return _dataContext.Usuario.Where(predicate);
        }
    }
}
