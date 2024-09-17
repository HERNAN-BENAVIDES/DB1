using ProyectofinalDb1.controller;
using ProyectofinalDb1.repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectofinalDb1.forms
{
    public partial class LoginForm : Form
    {
        private readonly UsuarioController _usuarioController;
        private readonly BitacoraRepository _bitacoraRepository;
        private readonly DepartamentoController _departamentoController;
        private readonly BitacoraController _bitacoraController;
        private readonly ProfesionController _profesionController;
        private readonly NivelController _nivelController;
        private readonly FuncionController _funcionController;
        private readonly PrioridadController _prioridadController;
        private readonly CargoController _cargoController;
        private readonly FuncionRepository _funcionRepository;
        private readonly NivelRepository _nivelRepository;
        private readonly UsuarioRepository _usuarioRepository;
        private readonly EmpleadoController _elempleadoController;
        private readonly MunicipioController _municipioController;
        private readonly DepartamentoRepository _departamentoRepository;
        private readonly PrioridadRepository _prioridadRepository;
        private readonly MunicipioRepository _municipioRepository;
        private readonly SucursalController _sucursalController;
        private readonly ContratoController _contratoController;
        private readonly EmpleadoRepository _empleadoRepository;
        private readonly SucursalRepository _sucursalRepository;
        private readonly CargoRepository _cargoRepository;
        private readonly EmpleadoProfesionController _empleadoProfesionController;
        private readonly ProfesionRepository _profesionRepository;

        public LoginForm(BitacoraController bitacoraController,
            DepartamentoController departamentoController,
            ProfesionController profesionController,
            NivelController nivelController,
            FuncionController funcionController,
            PrioridadController prioridadController,
            CargoController cargoController,
            FuncionRepository funcionRepository,
            UsuarioController usuarioController,
            NivelRepository nivelRepository,
            UsuarioRepository usuarioRepository,
            EmpleadoController empleadoController,
            MunicipioController municipioController,
            DepartamentoRepository departamentoRepository,
            PrioridadRepository prioridadRepository,
            MunicipioRepository municipioRepository,
            SucursalController sucursalController,
            ContratoController contratoController,
            EmpleadoRepository empleadoRepository,
            SucursalRepository sucursalRepository,
            CargoRepository cargoRepository,
            EmpleadoProfesionController empleadoProfesionController,
            ProfesionRepository profesionRepository,
            BitacoraRepository bitacoraRepository)
        {
            InitializeComponent();
            _bitacoraController = bitacoraController;
            _departamentoController = departamentoController;
            _profesionController = profesionController;
            _nivelController = nivelController;
            _funcionController = funcionController;
            _prioridadController = prioridadController;
            _cargoController = cargoController;
            _funcionRepository = funcionRepository;
            _usuarioController = usuarioController;
            _nivelRepository = nivelRepository;
            _usuarioRepository = usuarioRepository;
            _elempleadoController = empleadoController;
            _municipioController = municipioController;
            _departamentoRepository = departamentoRepository;
            _prioridadRepository = prioridadRepository;
            _municipioRepository = municipioRepository;
            _sucursalController = sucursalController;
            _contratoController = contratoController;
            _empleadoRepository = empleadoRepository;
            _sucursalRepository = sucursalRepository;
            _cargoRepository = cargoRepository;
            _empleadoProfesionController = empleadoProfesionController;
            _profesionRepository = profesionRepository;
            _usuarioController = usuarioController;
            _bitacoraRepository = bitacoraRepository;
        }

        bool validateField()
        {
            Console.WriteLine(usernameTextBox.Text);
            Console.WriteLine(passwordTextBox.Text);
            return usernameTextBox.Text != "" && passwordTextBox.Text != "";
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            if(validateField())
            {
                var usuario = _usuarioController.Login(usernameTextBox.Text, passwordTextBox.Text);
                if(usuario != null)
                {
                    // Oculta el LoginForm
                    this.Hide();

                    new MainForm(_bitacoraController,
                        _departamentoController,
                        _profesionController,
                        _nivelController,
                        _funcionController,
                        _prioridadController,
                        _cargoController,
                        _funcionRepository,
                        _usuarioController,
                        _nivelRepository,
                        _usuarioRepository,
                        _elempleadoController,
                        _municipioController,
                        _departamentoRepository,
                        _prioridadRepository,
                        _municipioRepository,
                        _sucursalController,
                        _contratoController,
                        _empleadoRepository,
                        _sucursalRepository,
                        _cargoRepository,
                        _empleadoProfesionController,
                        _profesionRepository).Show();
                    try
                    {
                        registrarIngreso();
                        asignarNivel();

                    }
                    catch
                    {
                        mostarMensaje("Imposible registrar ingreso en la bitacora");
                    }
                    
                }
                else
                {
                    mostarMensaje("Usuario no encontrado");
                }
            }
            else
            {
                mostarMensaje("Campos no validos");
            }
        }

        private void registrarIngreso()

        {
            var ultimoIndice = _bitacoraController.ultimoIndice();
            _bitacoraController.AddBitacora(ultimoIndice+1, DateTime.Now, DateTime.Now, new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second), new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second), usernameTextBox.Text);

        }

        private void asignarNivel()

        {
            var nivel = _usuarioController.obtenerNivel(usernameTextBox.Text);
            _elempleadoController.asignarNivel(nivel);
            _departamentoController.asignarNivel(nivel);
            _profesionController.asignarNivel(nivel);
            _funcionController.asignarNivel(nivel);
            _cargoController.asignarNivel(nivel);
            _usuarioController.asignarNivel(nivel);
            _municipioController.asignarNivel(nivel);
            _sucursalController.asignarNivel(nivel);
            _contratoController.asignarNivel(nivel);

            mostarMensaje( "Su nivel es: " + nivel.ToString());
           
        }

        private void mostarMensaje(string Mensaje)
        {
            MessageBox.Show(Mensaje, "Mensaje");
        }
    }
}
