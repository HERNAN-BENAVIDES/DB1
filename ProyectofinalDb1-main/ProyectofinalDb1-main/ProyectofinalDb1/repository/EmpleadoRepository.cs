using ProyectofinalDb1.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectofinalDb1.repository
{
    public class EmpleadoRepository : Repository<Empleado>
    {
        private readonly DataContext _dataContext;

        public EmpleadoRepository(DataContext dataContext) : base(dataContext)
        {
            _dataContext = dataContext;
        }

        public bool Delete(int codigo)
        {
            var entity = _dataContext.Empleado.Find(codigo);
            if (entity != null)
            {
                base.Delete(entity);
                return Save();
            }
            return false; // Opcional: Manejar el caso en el que la entidad no existe
        }

        public bool Update(Empleado Empleado)
        {
            var entity = Get(b => b.Codigo == Empleado.Codigo);
            if (entity != null)
            {
                entity.Cedula = Empleado.Cedula;
                entity.Nombre = Empleado.Nombre;
                entity.DireccionResidencia = Empleado.DireccionResidencia;
                entity.Telefono = Empleado.Telefono;
                entity.Usuario = Empleado.Usuario;
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
