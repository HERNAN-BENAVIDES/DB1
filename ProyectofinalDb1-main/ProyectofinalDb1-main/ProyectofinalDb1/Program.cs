using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;
using ProyectofinalDb1.config;
using ProyectofinalDb1.controller;
using ProyectofinalDb1.repository;
using System.Windows.Forms;
using ProyectofinalDb1.data;
using ProyectofinalDb1.forms;

namespace ProyectofinalDb1
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var dataContext = DataContextConfig.GetDataContext();

            var nivelRepository = new NivelRepository(dataContext);
            var nivelController = new NivelController(nivelRepository);

            var usuarioRepository = new UsuarioRepository(dataContext);
            var usuarioController = new UsuarioController(usuarioRepository, nivelRepository);

            var bitacoraRepository = new BitacoraRepository(dataContext);
            var bitacoraController = new BitacoraController(bitacoraRepository, usuarioRepository);

            var departamentoRepository = new DepartamentoRepository(dataContext);
            var departamentoController = new DepartamentoController(departamentoRepository);

            var profesionRepository = new ProfesionRepository(dataContext);
            var profesionController = new ProfesionController(profesionRepository);

            var funcionRepository = new FuncionRepository(dataContext);
            var funcionController = new FuncionController(funcionRepository);

            var prioridadRepository = new PrioridadRepository(dataContext);
            var prioridadController = new PrioridadController(prioridadRepository);

            var cargoRepository = new CargoRepository(dataContext);
            var cargoController = new CargoController(cargoRepository, funcionRepository);

            var empleadoRepository = new EmpleadoRepository(dataContext);
            var empleadoController = new EmpleadoController(empleadoRepository, usuarioRepository);

            var municipioRepository = new MunicipioRepository(dataContext);
            var municipioController = new MunicipioController(municipioRepository, prioridadRepository, departamentoRepository);

            var sucursalRepository = new SucursalRepository(dataContext);
            var sucursalController = new SucursalController(sucursalRepository, usuarioRepository, municipioRepository);

            var contratoRepository = new ContratoRepository(dataContext);
            var contratoController = new ContratoController(contratoRepository, 
                empleadoRepository, cargoRepository, sucursalRepository);

            var empleadoProfesionRepository = new EmpleadoProfesionRepository(dataContext);
            var empleadoProfesionController = new EmpleadoProfesionController(empleadoProfesionRepository,
                empleadoRepository, profesionRepository);

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new LoginForm(bitacoraController,
                departamentoController,
                profesionController,
                nivelController,
                funcionController,
                prioridadController,
                cargoController,
                funcionRepository,
                usuarioController,
                nivelRepository,
                usuarioRepository,
                empleadoController,
                municipioController,
                departamentoRepository,
                prioridadRepository,
                municipioRepository,
                sucursalController,
                contratoController,
                empleadoRepository,
                sucursalRepository,
                cargoRepository,
                empleadoProfesionController,
                profesionRepository,
                bitacoraRepository));
        }
    }
}