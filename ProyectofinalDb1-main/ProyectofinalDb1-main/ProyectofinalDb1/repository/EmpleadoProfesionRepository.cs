using ProyectofinalDb1.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectofinalDb1.repository
{
    public class EmpleadoProfesionRepository : Repository<DetalleEmpleadoProfesion>
    {
        private readonly DataContext _dataContext;

        public EmpleadoProfesionRepository(DataContext dataContext) : base(dataContext)
        {
            _dataContext = dataContext;
        }

        public bool Delete(DetalleEmpleadoProfesion detalleEmpleadoProfesion)
        {
            var entity = Get(d => d.Empleado == detalleEmpleadoProfesion.Empleado &&
                d.Profesion == detalleEmpleadoProfesion.Profesion);
            if (entity != null)
            {
                base.Delete(entity);
                return Save();
            }
            return false; // Opcional: Manejar el caso en el que la entidad no existe
        }
    }
}
