using ProyectofinalDb1.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectofinalDb1.repository
{
    public class ContratoRepository : Repository<Contrato>
    {
        private readonly DataContext _dataContext;

        public ContratoRepository(DataContext dataContext) : base(dataContext)
        {
            _dataContext = dataContext;
        }

        public bool Delete(int codigo)
        {
            var entity = _dataContext.Contrato.Find(codigo);
            if (entity != null)
            {
                base.Delete(entity);
                return Save();
            }
            return false; // Opcional: Manejar el caso en el que la entidad no existe
        }

        public bool Update(Contrato Contrato)
        {
            var entity = Get(b => b.Codigo == Contrato.Codigo);
            if (entity != null)
            {
                entity.Empleado = Contrato.Empleado;
                entity.Cargo = Contrato.Cargo;
                entity.Sucursal = Contrato.Sucursal;
                entity.FechaInicio = Contrato.FechaInicio;
                entity.FechaFin = Contrato.FechaFin;
                base.Update(entity);
                return Save();
            }
            return false; // Opcional: Manejar el caso en el que la entidad no existe
        }
    }
}
