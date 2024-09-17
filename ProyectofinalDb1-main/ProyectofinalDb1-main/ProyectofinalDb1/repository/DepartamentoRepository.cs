using ProyectofinalDb1.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectofinalDb1.repository
{
    public class DepartamentoRepository : Repository<Departamento>
    {
        private readonly DataContext dataContext;

        public DepartamentoRepository(DataContext dataContext) : base(dataContext)
        {
            this.dataContext = dataContext;
        }

        public bool Delete(int codigo)
        {
            var entity = dataContext.Departamento.Find(codigo);
            if (entity != null)
            {
                base.Delete(entity);
                return Save();
            }
            return false; // Opcional: Manejar el caso en el que la entidad no existe
        }

        public bool Update(Departamento Departamento)
        {
            var entity = Get(b => b.Codigo == Departamento.Codigo);
            if (entity != null)
            {
                entity.Nombre = Departamento.Nombre;
                entity.Poblacion = Departamento.Poblacion;
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
