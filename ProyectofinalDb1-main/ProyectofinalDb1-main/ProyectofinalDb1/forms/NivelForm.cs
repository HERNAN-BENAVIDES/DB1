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
    public partial class NivelForm : Form
    {
        private readonly NivelController _nivelController;

        public NivelForm(NivelController nivelController)
        {
            InitializeComponent();
            _nivelController = nivelController;
            resetButton.Enabled = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void NivelForm_Load(object sender, EventArgs e)
        {
            actualizarData();
        }

        void actualizarData()
        {
            var Nivels = _nivelController.BuscarTodos();

            var NivelsSinCampo = Nivels.Select(b => new
            {
                b.Codigo,
                b.Nombre
            }).ToList();
            dataGridView1.DataSource = NivelsSinCampo;
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
            return (int)codigoNumeric.Value > 0 && nombreTextBox.Text != "";
        }

        private void agregarButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (validateField())
                {
                    var message = _nivelController.AddNivel(
                        (int)codigoNumeric.Value,
                        nombreTextBox.Text);

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
            var Nivels = _nivelController.BuscarTodos();

            var NivelsSinCampo = Nivels.Where(b => b.Codigo == (int)codigoNumeric.Value &&
                b.Nombre == nombreTextBox.Text)
                .Select(b => new
                {
                    b.Codigo,
                    b.Nombre
                }).ToList();
            dataGridView1.DataSource = NivelsSinCampo;

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
                    var message = _nivelController.ActualizarNivel(
                        (int)codigoNumeric.Value,
                        nombreTextBox.Text);

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
                    var message = _nivelController.DeleteNivel(
                        (int)codigoNumeric.Value,
                        nombreTextBox.Text);

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

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
