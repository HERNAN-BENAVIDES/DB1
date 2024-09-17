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
    public partial class EmpleadoProfesionForm : Form
    {
        private readonly EmpleadoProfesionController _EmpleadoProfesionController;
        private readonly EmpleadoRepository _empleadoRepository;
        private readonly ProfesionRepository _profesionRepository;

        public EmpleadoProfesionForm(EmpleadoProfesionController EmpleadoProfesionController, EmpleadoRepository empleadoRepository,
            ProfesionRepository profesionRepository)
        {
            InitializeComponent();
            _EmpleadoProfesionController = EmpleadoProfesionController;
            resetButton.Enabled = false;
            _empleadoRepository = empleadoRepository;
            _profesionRepository = profesionRepository;
            crearItemsCombo();
        }

        private void crearItemsCombo()
        {
            foreach (var funcion in _empleadoRepository.GetAll())
            {
                empleadoComboBox.Items.Add(funcion.Nombre);
            }
            foreach (var funcion in _profesionRepository.GetAll())
            {
                profesionComboBox.Items.Add(funcion.Nombre);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void EmpleadoProfesionForm_Load(object sender, EventArgs e)
        {
            actualizarData();
        }

        void actualizarData()
        {
            var EmpleadoProfesions = _EmpleadoProfesionController.BuscarTodos();

            var EmpleadoProfesionsSinCampo = EmpleadoProfesions.Select(b => new
            {
                Empleado = b.EmpleadoNavigation.Nombre,
                Profesion = b.ProfesionNavigation.Nombre,
            }).ToList();
            dataGridView1.DataSource = EmpleadoProfesionsSinCampo;
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
            return empleadoComboBox.SelectedItem != null && profesionComboBox.SelectedItem != null;
        }

        private void agregarButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (validateField())
                {
                    var message = _EmpleadoProfesionController.AddEmpleadoProfesion(
                        empleadoComboBox.Text,
                        profesionComboBox.Text);

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
            var EmpleadoProfesions = _EmpleadoProfesionController.BuscarTodos();

            var EmpleadoProfesionsSinCampo = EmpleadoProfesions.Where(b =>
                b.Empleado == _empleadoRepository.Get(u => u.Nombre.Equals(empleadoComboBox.Text)).Codigo
                && b.Profesion == _profesionRepository.Get(u => u.Nombre.Equals(profesionComboBox.Text)).Codigo)
                .Select(b => new
                {
                    Empleado = b.EmpleadoNavigation.Nombre,
                    Profesion = b.ProfesionNavigation.Nombre,
                }).ToList();
            dataGridView1.DataSource = EmpleadoProfesionsSinCampo;

            resetButton.Enabled = true;
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            actualizarData();
            resetButton.Enabled = false;
        }

        private void eliminarButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (validateField())
                {
                    var message = _EmpleadoProfesionController.DeleteEmpleadoProfesion(
                        empleadoComboBox.Text,
                        profesionComboBox.Text);

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
