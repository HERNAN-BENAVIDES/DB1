using ProyectofinalDb1.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectofinalDb1.repository
{
    public class MunicipioRepository : Repository<Municipio>
    {
        private readonly DataContext _dataContext;

        public MunicipioRepository(DataContext dataContext) : base(dataContext)
        {
            _dataContext = dataContext;
        }

        public bool Delete(int codigo)
        {
            var entity = _dataContext.Municipio.Find(codigo);
            if (entity != null)
            {
                base.Delete(entity);
                return Save();
            }
            return false; // Opcional: Manejar el caso en el que la entidad no existe
        }

        public bool Update(Municipio Municipio)
        {
            var entity = Get(b => b.Codigo == Municipio.Codigo);
            if (entity != null)
            {
                entity.Nombre = Municipio.Nombre;
                entity.Poblacion = Municipio.Poblacion;
                entity.Prioridad = Municipio.Prioridad;
                entity.Departamento = Municipio.Departamento;
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
