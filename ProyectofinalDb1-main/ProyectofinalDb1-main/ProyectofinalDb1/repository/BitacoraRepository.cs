using ProyectofinalDb1.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectofinalDb1.repository
{
    public class BitacoraRepository : Repository<Bitacora>
    {
        private readonly DataContext _dataContext;

        public BitacoraRepository(DataContext dataContext) : base(dataContext)
        {
            _dataContext = dataContext;
        }

        public bool Delete(int codigo)
        {
            var entity = _dataContext.Bitacora.Find(codigo);
            if (entity != null)
            {
                base.Delete(entity);
                return Save();
            }
            return false; // Opcional: Manejar el caso en el que la entidad no existe
        }

        public bool Update(Bitacora bitacora)
        {
            var entity = Get(b => b.Codigo == bitacora.Codigo);
            if (entity != null)
            {
                entity.FechaSalida = bitacora.FechaSalida;
                entity.FechaIngreso = bitacora.FechaIngreso;
                entity.HoraSalida = bitacora.HoraSalida;
                entity.HoraIngreso = bitacora.HoraIngreso;
                entity.Usuario = bitacora.Usuario;
                base.Update(entity);
                return Save();
            }
            return false; // Opcional: Manejar el caso en el que la entidad no existe
        }
    }
}
