using ProyectofinalDb1.controller;
using ProyectofinalDb1.data;
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
    public partial class ContratoForm : Form
    {
        private readonly ContratoController _ContratoController;
        private readonly EmpleadoRepository _empleadoRepository;
        private readonly CargoRepository _cargoRepository;
        private readonly SucursalRepository _sucursalRepository;

        public ContratoForm(ContratoController ContratoController, EmpleadoRepository empleadoRepository,
            CargoRepository cargoRepository, SucursalRepository sucursalRepository)
        {
            InitializeComponent();
            _ContratoController = ContratoController;
            resetButton.Enabled = false;
            _empleadoRepository = empleadoRepository;
            _cargoRepository = cargoRepository;
            _sucursalRepository = sucursalRepository;
            crearItemsCombo();
        }

        private void crearItemsCombo()
        {
            foreach (var funcion in _empleadoRepository.GetAll())
            {
                empleadoComboBox.Items.Add(funcion.Nombre);
            }
            foreach (var funcion in _cargoRepository.GetAll())
            {
                cargoComboBox.Items.Add(funcion.Nombre);
            }
            foreach (var funcion in _sucursalRepository.GetAll())
            {
                sucursalComboBox.Items.Add(funcion.Nombre);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void ContratoForm_Load(object sender, EventArgs e)
        {
            actualizarData();
        }

        void actualizarData()
        {
            var Contratos = _ContratoController.BuscarTodos();

            var ContratosSinCampo = Contratos.Select(b => new
            {
                b.Codigo,
                Empleado = b.EmpleadoNavigation.Nombre,
                Cargo = b.CargoNavigation.Nombre,
                Sucursal = b.SucursalNavigation.Nombre,
                b.FechaInicio,
                b.FechaFin,
            }).ToList();
            dataGridView1.DataSource = ContratosSinCampo;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void fechaIngresoTimePicker_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        bool validateField()
        {
            return (int)codigoNumeric.Value > 0 && empleadoComboBox.SelectedItem != null
                && sucursalComboBox.SelectedItem != null && cargoComboBox.SelectedItem != null;
        }

        private void agregarButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (validateField())
                {
                    var message = _ContratoController.AddContrato(
                        (int)codigoNumeric.Value,
                        empleadoComboBox.Text,
                        cargoComboBox.Text,
                        sucursalComboBox.Text,
                        fechaInicioTimePicker.Value.Date,
                        fechaFinTimePicker.Value.Date);

                    mostarMensaje(message);

                    actualizarData();
                }
                else
                {
                    mostarMensaje("Campos no validos");
                }
            }
            catch (Exception ex)
            {
                mostarMensaje(ex.Message);
            }
        }

        private void mostarMensaje(string Mensaje)
        {
            MessageBox.Show(Mensaje, "Mensaje");
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void consultarButton_Click(object sender, EventArgs e)
        {
            var Contratos = _ContratoController.BuscarTodos();

            var ContratosSinCampo = Contratos.Where(b => b.Codigo == (int)codigoNumeric.Value
                && b.Empleado == _empleadoRepository.Get(u => u.Nombre.Equals(empleadoComboBox.Text)).Codigo
                && b.Sucursal == _sucursalRepository.Get(u => u.Nombre.Equals(sucursalComboBox.Text)).Codigo
                && b.Cargo == _cargoRepository.Get(f => f.Nombre.Equals(cargoComboBox.Text)).Codigo
                && b.FechaInicio.Value.Date == fechaInicioTimePicker.Value.Date.Date &&
                b.FechaFin.Value.Date == fechaFinTimePicker.Value.Date.Date )
                .Select(b => new
                {
                    b.Codigo,
                    Empleado = b.EmpleadoNavigation.Nombre,
                    Cargo = b.CargoNavigation.Nombre,
                    Sucursal = b.SucursalNavigation.Nombre,
                    b.FechaInicio,
                    b.FechaFin,
                }).ToList();
            dataGridView1.DataSource = ContratosSinCampo;

            resetButton.Enabled = true;
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            actualizarData();
            resetButton.Enabled = false;
        }

        private void actualizarButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (validateField())
                {
                    var message = _ContratoController.ActualizarContrato(
                        (int)codigoNumeric.Value,
                        empleadoComboBox.Text,
                        cargoComboBox.Text,
                        sucursalComboBox.Text,
                        fechaInicioTimePicker.Value.Date,
                        fechaFinTimePicker.Value.Date);

                    mostarMensaje(message);

                    actualizarData();
                }
                else
                {
                    mostarMensaje("Campos no validos");
                }
            }
            catch (Exception ex)
            {
                mostarMensaje(ex.Message);
            }
        }

        private void eliminarButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (validateField())
                {
                    var message = _ContratoController.DeleteContrato(
                        (int)codigoNumeric.Value,
                        empleadoComboBox.Text,
                        cargoComboBox.Text,
                        sucursalComboBox.Text,
                        fechaInicioTimePicker.Value.Date,
                        fechaFinTimePicker.Value.Date);

                    mostarMensaje(message);

                    actualizarData();
                }
                else
                {
                    mostarMensaje("Campos no validos");
                }
            }
            catch (Exception ex)
            {
                mostarMensaje(ex.Message);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
