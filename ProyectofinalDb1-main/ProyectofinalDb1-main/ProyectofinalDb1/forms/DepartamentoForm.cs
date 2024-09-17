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
    public partial class DepartamentoForm : Form
    {
        private readonly DepartamentoController _DepartamentoController;

        public DepartamentoForm(DepartamentoController DepartamentoController)
        {
            InitializeComponent();
            _DepartamentoController = DepartamentoController;
            resetButton.Enabled = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void DepartamentoForm_Load(object sender, EventArgs e)
        {
            actualizarData();
        }

        void actualizarData()
        {
            var Departamentos = _DepartamentoController.BuscarTodos();

            var DepartamentosSinCampo = Departamentos.Select(b => new
            {
                b.Codigo,
                b.Nombre,
                b.Poblacion
            }).ToList();
            dataGridView1.DataSource = DepartamentosSinCampo;
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
                && (int)poblacionNumeric.Value > 0;
        }

        private void agregarButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (validateField())
                {
                    var message = _DepartamentoController.AddDepartamento(
                        (int)codigoNumeric.Value,
                        nombreTextBox.Text,
                        (int)poblacionNumeric.Value);

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
            var Departamentos = _DepartamentoController.BuscarTodos();

            var DepartamentosSinCampo = Departamentos.Where(b => b.Codigo == (int)codigoNumeric.Value &&
                b.Nombre == nombreTextBox.Text && b.Poblacion == (int)poblacionNumeric.Value)
                .Select(b => new
                {
                    b.Codigo,
                    b.Nombre,
                    b.Poblacion
                }).ToList();
            dataGridView1.DataSource = DepartamentosSinCampo;

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
                    var message = _DepartamentoController.ActualizarDepartamento(
                        (int)codigoNumeric.Value,
                        nombreTextBox.Text,
                        (int)poblacionNumeric.Value);

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
                    var message = _DepartamentoController.DeleteDepartamento(
                        (int)codigoNumeric.Value,
                        nombreTextBox.Text,
                        (int)poblacionNumeric.Value);

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
