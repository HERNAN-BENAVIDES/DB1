using ProyectofinalDb1.repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProyectofinalDb1.controller
{
    public class Controller<R, C> where R : Repository<C> where C : class
    {
        private readonly R _repository;

        public Controller(R repository)
        {
            _repository = repository;    
        }

        public bool Agregar(C c)
        {
            return _repository.Add(c);
        }

        public bool Eliminar(C c)
        {
            return _repository.Delete(c);
        }

        public IEnumerable<C> BuscarTodos()
        {
            return _repository.GetAll();
        }

        public C Buscar(Expression<Func<C, bool>> filter)
        {
            return _repository.Get(filter);
        }
    }
}
