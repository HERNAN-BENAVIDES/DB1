using ProyectofinalDb1.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectofinalDb1.repository
{
    public class CargoRepository : Repository<Cargo>
    {
        private readonly DataContext _dataContext;

        public CargoRepository(DataContext dataContext) : base(dataContext)
        {
            _dataContext = dataContext;
        }

        public bool Delete(int codigo)
        {
            var entity = _dataContext.Cargo.Find(codigo);
            if (entity != null)
            {
                base.Delete(entity);
                return Save();
            }
            return false; // Opcional: Manejar el caso en el que la entidad no existe
        }

        public bool Update(Cargo Cargo)
        {
            var entity = Get(b => b.Codigo == Cargo.Codigo);
            if (entity != null)
            {
                entity.Nombre = Cargo.Nombre;
                entity.Salario = Cargo.Salario;
                entity.Funcion = Cargo.Funcion;
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
