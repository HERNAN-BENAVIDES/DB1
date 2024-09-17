using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectofinalDb1.data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<Bitacora> Bitacora { get; set; }
        public DbSet<Cargo> Cargo { get; set; }
        public DbSet<Contrato> Contrato { get; set; }
        public DbSet<Departamento> Departamento { get; set; }
        public DbSet<DetalleEmpleadoProfesion> DetalleEmpleadoProfesion { get; set; }
        public DbSet<Empleado> Empleado { get; set; }
        public DbSet<Funcion> Funcion { get; set; }
        public DbSet<Municipio> Municipio { get; set; }
        public DbSet<Nivel> Nivel { get; set; }
        public DbSet<Prioridad> Prioridad { get; set; }
        public DbSet<Profesion> Profesion { get; set; }
        public DbSet<Sucursal> Sucursal { get; set; }
        public DbSet<Usuario> Usuario { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<DetalleEmpleadoProfesion>()
            .HasKey(d => new { d.Profesion, d.Empleado });
            modelBuilder.Entity<DetalleEmpleadoProfesion>()
                .HasOne(d => d.ProfesionNavigation)
                .WithMany(d => d.DetallesEmpleadoProfesion)
                .HasForeignKey(ne => ne.Profesion);
            modelBuilder.Entity<DetalleEmpleadoProfesion>()
                .HasOne(d => d.EmpleadoNavigation)
                .WithMany(d => d.DetallesEmpleadoProfesion)
                .HasForeignKey(d => d.Empleado);
        }
    }
}
