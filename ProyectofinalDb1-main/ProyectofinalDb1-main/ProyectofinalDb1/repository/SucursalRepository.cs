using ProyectofinalDb1.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectofinalDb1.repository
{
    public class SucursalRepository : Repository<Sucursal>
    {
        private readonly DataContext _dataContext;

        public SucursalRepository(DataContext dataContext) : base(dataContext)
        {
            _dataContext = dataContext;
        }

        public bool Delete(int codigo)
        {
            var entity = _dataContext.Sucursal.Find(codigo);
            if (entity != null)
            {
                base.Delete(entity);
                return Save();
            }
            return false; // Opcional: Manejar el caso en el que la entidad no existe
        }

        public bool Update(Sucursal Sucursal)
        {
            var entity = Get(b => b.Codigo == Sucursal.Codigo);
            if (entity != null)
            {
                entity.Nombre = Sucursal.Nombre;
                entity.Presupuesto = Sucursal.Presupuesto;
                entity.Director = Sucursal.Director;
                entity.Municipio = Sucursal.Municipio;
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
