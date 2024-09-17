using ProyectofinalDb1.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectofinalDb1.repository
{
    public class NivelRepository : Repository<Nivel>
    {
        private readonly DataContext _dataContext;

        public NivelRepository(DataContext dataContext) : base(dataContext)
        {
            _dataContext = dataContext;
        }

        public bool Delete(int codigo)
        {
            var entity = _dataContext.Nivel.Find(codigo);
            if (entity != null)
            {
                base.Delete(entity);
                return Save();
            }
            return false; // Opcional: Manejar el caso en el que la entidad no existe
        }

        public bool Update(Nivel Nivel)
        {
            var entity = Get(b => b.Codigo == Nivel.Codigo);
            if (entity != null)
            {
                entity.Nombre = Nivel.Nombre;
                base.Update(entity);
                return Save();
            }
            return false; // Opcional: Manejar el caso en el que la entidad no existe
        }

        internal void asignarNivel(string nivel)
        {
            throw new NotImplementedException();
        }
    }
}
