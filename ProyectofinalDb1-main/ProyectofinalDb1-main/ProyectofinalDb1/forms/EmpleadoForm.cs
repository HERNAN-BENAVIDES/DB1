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
    public partial class EmpleadoForm : Form
    {
        private readonly EmpleadoController _EmpleadoController;
        private readonly UsuarioRepository _usuarioRepository;

        public EmpleadoForm(EmpleadoController EmpleadoController, UsuarioRepository usuarioRepository)
        {
            InitializeComponent();
            _EmpleadoController = EmpleadoController;
            resetButton.Enabled = false;
            _usuarioRepository = usuarioRepository;
            crearItemsCombo();
        }

        private void crearItemsCombo()
        {
            foreach (var funcion in _usuarioRepository.GetAll())
            {
                usuarioComboBox.Items.Add(funcion.NomUsuario);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void EmpleadoForm_Load(object sender, EventArgs e)
        {
            actualizarData();
        }

        void actualizarData()
        {
            var Empleados = _EmpleadoController.BuscarTodos();

            var EmpleadosSinCampo = Empleados.Select(b => new
            {
                b.Codigo,
                b.Cedula,
                b.Nombre,
                b.DireccionResidencia,
                b.Telefono,
                NivelNombre = b.UsuarioNavigation.NomUsuario,
            }).ToList();
            dataGridView1.DataSource = EmpleadosSinCampo;
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
            return (int)codigoNumeric.Value > 0 && nombreTextBox.Text != "" && cedulaTextBox.Text != ""
                && usuarioComboBox.SelectedItem != null && direccionTextBox.Text != "" && telefonoTextBox.Text != "";
        }

        private void agregarButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (validateField())
                {
                    var message = _EmpleadoController.AddEmpleado(
                        (int)codigoNumeric.Value,
                        cedulaTextBox.Text,
                        nombreTextBox.Text,
                        direccionTextBox.Text,
                        telefonoTextBox.Text,
                        usuarioComboBox.Text);

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
            var Empleados = _EmpleadoController.BuscarTodos();

            var EmpleadosSinCampo = Empleados.Where(b => b.Codigo == (int)codigoNumeric.Value &&
                b.Nombre == nombreTextBox.Text && b.Cedula == cedulaTextBox.Text
                && b.DireccionResidencia == direccionTextBox.Text && b.Telefono == telefonoTextBox.Text
                && b.Usuario == _usuarioRepository.Get(f => f.NomUsuario.Equals(usuarioComboBox.Text)).Codigo)
                .Select(b => new
                {
                    b.Codigo,
                    b.Cedula,
                    b.Nombre,
                    b.DireccionResidencia,
                    b.Telefono,
                    NivelNombre = b.UsuarioNavigation.NomUsuario,
                }).ToList();
            dataGridView1.DataSource = EmpleadosSinCampo;

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
                    var message = _EmpleadoController.ActualizarEmpleado(
                        (int)codigoNumeric.Value,
                        cedulaTextBox.Text,
                        nombreTextBox.Text,
                        direccionTextBox.Text,
                        telefonoTextBox.Text,
                        usuarioComboBox.Text);

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
                    var message = _EmpleadoController.DeleteEmpleado(
                        (int)codigoNumeric.Value,
                        cedulaTextBox.Text,
                        nombreTextBox.Text,
                        direccionTextBox.Text,
                        telefonoTextBox.Text,
                        usuarioComboBox.Text);

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
