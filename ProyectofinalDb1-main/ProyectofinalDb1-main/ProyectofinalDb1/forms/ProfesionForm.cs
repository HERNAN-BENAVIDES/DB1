using ProyectofinalDb1.controller;
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
    public partial class ProfesionForm : Form
    {
        private readonly ProfesionController _profesionController;

        public ProfesionForm(ProfesionController ProfesionController)
        {
            InitializeComponent();
            _profesionController = ProfesionController;
            resetButton.Enabled = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void ProfesionForm_Load(object sender, EventArgs e)
        {
            actualizarData();
        }

        void actualizarData()
        {
            var Profesions = _profesionController.BuscarTodos();

            var ProfesionsSinCampo = Profesions.Select(b => new
            {
                b.Codigo,
                b.Nombre,
                b.Descripcion
            }).ToList();
            dataGridView1.DataSource = ProfesionsSinCampo;
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
            return (int)codigoNumeric.Value > 0 && nombreTextBox.Text != ""
                && descripcionTextBox.Text != "";
        }

        private void agregarButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (validateField())
                {
                    var message = _profesionController.AddProfesion(
                        (int)codigoNumeric.Value,
                        nombreTextBox.Text,
                        descripcionTextBox.Text);

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
            var Profesions = _profesionController.BuscarTodos();

            var ProfesionsSinCampo = Profesions.Where(b => b.Codigo == (int)codigoNumeric.Value &&
                b.Nombre == nombreTextBox.Text && b.Descripcion == descripcionTextBox.Text)
                .Select(b => new
                {
                    b.Codigo,
                    b.Nombre,
                    b.Descripcion
                }).ToList();
            dataGridView1.DataSource = ProfesionsSinCampo;

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
                    var message = _profesionController.ActualizarProfesion(
                        (int)codigoNumeric.Value,
                        nombreTextBox.Text,
                        descripcionTextBox.Text);

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
                    var message = _profesionController.DeleteProfesion(
                        (int)codigoNumeric.Value,
                        nombreTextBox.Text,
                        descripcionTextBox.Text);

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
    }
}
