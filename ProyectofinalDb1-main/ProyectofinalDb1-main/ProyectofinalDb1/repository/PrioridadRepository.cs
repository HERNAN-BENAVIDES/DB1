﻿using ProyectofinalDb1.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectofinalDb1.repository
{
    public class PrioridadRepository : Repository<Prioridad>
    {
        private readonly DataContext _dataContext;

        public PrioridadRepository(DataContext dataContext) : base(dataContext)
        {
            _dataContext = dataContext;
        }

        public bool Delete(int codigo)
        {
            var entity = _dataContext.Prioridad.Find(codigo);
            if (entity != null)
            {
                base.Delete(entity);
                return Save();
            }
            return false; // Opcional: Manejar el caso en el que la entidad no existe
        }

        public bool Update(Prioridad Prioridad)
        {
            var entity = Get(b => b.Codigo == Prioridad.Codigo);
            if (entity != null)
            {
                entity.Nombre = Prioridad.Nombre;
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
