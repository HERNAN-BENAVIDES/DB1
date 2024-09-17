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
    public partial class FuncionForm : Form
    {
        private readonly FuncionController _funcionController;

        public FuncionForm(FuncionController funcionController)
        {
            InitializeComponent();
            _funcionController = funcionController;
            resetButton.Enabled = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void FuncionForm_Load(object sender, EventArgs e)
        {
            actualizarData();
        }

        void actualizarData()
        {
            var funcions = _funcionController.BuscarTodos();

            var funcionsSinCampo = funcions.Select(b => new
            {
                b.Codigo,
                b.Nombre,
                b.Descripcion
            }).ToList();
            dataGridView1.DataSource = funcionsSinCampo;
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
                    var message = _funcionController.AddFuncion(
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
            var Funcions = _funcionController.BuscarTodos();

            var FuncionsSinCampo = Funcions.Where(b => b.Codigo == (int)codigoNumeric.Value &&
                b.Nombre == nombreTextBox.Text && b.Descripcion == descripcionTextBox.Text)
                .Select(b => new
                {
                    b.Codigo,
                    b.Nombre,
                    b.Descripcion
                }).ToList();
            dataGridView1.DataSource = FuncionsSinCampo;

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
                    var message = _funcionController.ActualizarFuncion(
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
                    var message = _funcionController.DeleteFuncion(
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
