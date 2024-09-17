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
    public partial class UsuarioForm : Form
    {
        private readonly UsuarioController _UsuarioController;
        private readonly NivelRepository _nivelRepository;

        public UsuarioForm(UsuarioController UsuarioController, NivelRepository nivelRepository)
        {
            InitializeComponent();
            _UsuarioController = UsuarioController;
            resetButton.Enabled = false;
            _nivelRepository = nivelRepository;
            crearItemsCombo();
        }

        private void crearItemsCombo()
        {
            foreach (var funcion in _nivelRepository.GetAll())
            {
                nivelComboBox.Items.Add(funcion.Nombre);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void UsuarioForm_Load(object sender, EventArgs e)
        {
            actualizarData();
        }

        void actualizarData()
        {
            var Usuarios = _UsuarioController.BuscarTodos();

            var UsuariosSinCampo = Usuarios.Select(b => new
            {
                b.Codigo,
                b.NomUsuario,
                b.Clave,
                b.FechaCreacion,
                NivelNombre = b.NivelNavigation.Nombre
            }).ToList();
            dataGridView1.DataSource = UsuariosSinCampo;
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
            return (int)codigoNumeric.Value > 0 && nombreTextBox.Text != "" && claveTextBox.Text != ""
                && nivelComboBox.SelectedItem != null;
        }

        private void agregarButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (validateField())
                {
                    var message = _UsuarioController.AddUsuario(
                        (int)codigoNumeric.Value,
                        nombreTextBox.Text,
                        claveTextBox.Text,
                        fechaCreacionTimePicker.Value.Date,
                        nivelComboBox.Text);

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
            var Usuarios = _UsuarioController.BuscarTodos();

            var UsuariosSinCampo = Usuarios.Where(b => b.Codigo == (int)codigoNumeric.Value &&
                b.NomUsuario == nombreTextBox.Text && b.Clave == claveTextBox.Text
                && b.FechaCreacion.Value.Date == fechaCreacionTimePicker.Value.Date
                && b.Nivel == _nivelRepository.Get(f => f.Nombre.Equals(nivelComboBox.Text)).Codigo)
                .Select(b => new
                {
                    b.Codigo,
                    b.NomUsuario,
                    b.Clave,
                    b.FechaCreacion,
                    NivelNombre = b.NivelNavigation.Nombre
                }).ToList();
            dataGridView1.DataSource = UsuariosSinCampo;

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
                    var message = _UsuarioController.ActualizarUsuario(
                        (int)codigoNumeric.Value,
                        nombreTextBox.Text,
                        claveTextBox.Text,
                        fechaCreacionTimePicker.Value.Date,
                        nivelComboBox.Text);

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
                    var message = _UsuarioController.DeleteUsuario(
                        (int)codigoNumeric.Value,
                        nombreTextBox.Text,
                        claveTextBox.Text,
                        fechaCreacionTimePicker.Value.Date,
                        nivelComboBox.Text);

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
