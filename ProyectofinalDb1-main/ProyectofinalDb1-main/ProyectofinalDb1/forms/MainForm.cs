using ProyectofinalDb1.controller;
using ProyectofinalDb1.data;
using ProyectofinalDb1.repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop;
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;


namespace ProyectofinalDb1.forms
{
    public partial class MainForm : Form
    {
        private readonly DepartamentoController _departamentoController;
        private readonly BitacoraController _bitacoraController;
        private readonly ProfesionController _profesionController;
        private readonly NivelController _nivelController;
        private readonly FuncionController _funcionController;
        private readonly PrioridadController _prioridadController;
        private readonly CargoController _cargoController;
        private readonly FuncionRepository _funcionRepository;
        private readonly UsuarioController _usuarioController;
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

        public MainForm(BitacoraController bitacoraController,
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
            ProfesionRepository profesionRepository)
        {
            InitializeComponent();
            initSubmenu();
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
        }

        private void initSubmenu()
        {
            consultaPanel.Visible = false;
            utilidadesPanel.Visible = false;
        }

        private void hideSubmenu()
        {
            if (consultaPanel.Visible)
            {
                consultaPanel.Visible = false;
            }
            if (utilidadesPanel.Visible)
            {
                utilidadesPanel.Visible = false;
            }
        }

        private void showSubmenu(Panel subMenu)
        {
            if (subMenu.Visible)
            {
                hideSubmenu();
            }
            else
            {
                subMenu.Visible = true;
            }
        }

        private void consultasButton_Click(object sender, EventArgs e)
        {
            showSubmenu(consultaPanel);
        }

        private Form activeForm = null;

        private void openChild(Form childForm)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }

            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            s.Controls.Add(childForm);
            s.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }



        private void departamentoButton_Click(object sender, EventArgs e)
        {
            openChild(new DepartamentoForm(_departamentoController));
        }

        private void bitacoraButton_Click(object sender, EventArgs e)
        {
            openChild(new BitacoraForm(_bitacoraController, _usuarioRepository));
        }

        private void profesionButton_Click(object sender, EventArgs e)
        {
            openChild(new ProfesionForm(_profesionController));
        }

        private void nivelButton_Click(object sender, EventArgs e)
        {
            openChild(new NivelForm(_nivelController));
        }

        private void funcionButton_Click(object sender, EventArgs e)
        {
            openChild(new FuncionForm(_funcionController));
        }

        private void prioridadButton_Click(object sender, EventArgs e)
        {
            openChild(new PrioridadForm(_prioridadController));
        }

        private void cargoButton_Click(object sender, EventArgs e)
        {
            openChild(new CargoForm(_cargoController, _funcionRepository));
        }

        private void usuarioButton_Click(object sender, EventArgs e)
        {
            openChild(new UsuarioForm(_usuarioController, _nivelRepository));
        }

        private void empleadoButton_Click(object sender, EventArgs e)
        {
            openChild(new EmpleadoForm(_elempleadoController, _usuarioRepository));
        }

        private void municipioButton_Click(object sender, EventArgs e)
        {
            openChild(new MunicipioForm(_municipioController, _departamentoRepository, _prioridadRepository));
        }

        private void sucursalButton_Click(object sender, EventArgs e)
        {
            openChild(new SucursalForm(_sucursalController, _municipioRepository, _usuarioRepository, _nivelRepository));
        }

        private void ContratoButton_Click(object sender, EventArgs e)
        {
            openChild(new ContratoForm(_contratoController, _empleadoRepository, _cargoRepository, _sucursalRepository));
        }

        private void empleadoProfesionButton_Click(object sender, EventArgs e)
        {
            openChild(new EmpleadoProfesionForm(_empleadoProfesionController, _empleadoRepository, _profesionRepository));
        }

        private void UtilidadesButton_Click(object sender, EventArgs e)
        {
            showSubmenu(utilidadesPanel);
        }


        private void calculadoraButton_Click(object sender, EventArgs e)
        {
            string calculadora = @"C:\Windows\System32\calc.exe";
            Process.Start(calculadora);
        }

        private void excelButton_Click(object sender, EventArgs e)
        {
            Excel.Application excelApp = new Excel.Application();
            excelApp.Visible = true;
            Excel.Workbook workbook = excelApp.Workbooks.Add();
            Excel.Worksheet worksheet = (Excel.Worksheet)workbook.Worksheets[1];
            worksheet.Name = "Hoja1";
            worksheet.Cells[1, 1] = "Hola, Excel!";

            Marshal.ReleaseComObject(worksheet);
            Marshal.ReleaseComObject(workbook);
            Marshal.ReleaseComObject(excelApp);

            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        private void ReportesButton_Click(object sender, EventArgs e)
        {
            openChild(new ReporteForm(_usuarioController, _bitacoraController, _elempleadoController, _funcionController, _municipioController, _departamentoController));
        }
    }
}
