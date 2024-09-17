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
    public partial class CargoForm : Form
    {
        private readonly CargoController _CargoController;
        private readonly FuncionRepository _funcionRepository;

        public CargoForm(CargoController CargoController, FuncionRepository funcionRepository)
        {
            InitializeComponent();
            _CargoController = CargoController;
            resetButton.Enabled = false;
            _funcionRepository = funcionRepository;
            crearItemsCombo();
        }

        private void crearItemsCombo()
        {
            foreach (var funcion in _funcionRepository.GetAll())
            {
                funcionComboBox.Items.Add(funcion.Nombre);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void CargoForm_Load(object sender, EventArgs e)
        {
            actualizarData();
        }

        void actualizarData()
        {
            var Cargos = _CargoController.BuscarTodos();

            var CargosSinCampo = Cargos.Select(b => new
            {
                b.Codigo,
                b.Nombre,
                b.Salario,
                FuncionNombre = b.FuncionNavigation.Nombre
            }).ToList();
            dataGridView1.DataSource = CargosSinCampo;
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
                && (int)salarioNumeric.Value > 0 && funcionComboBox.SelectedItem != null;
        }

        private void agregarButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (validateField())
                {
                    var message = _CargoController.AddCargo(
                        (int)codigoNumeric.Value,
                        nombreTextBox.Text,
                        (int)salarioNumeric.Value,
                        funcionComboBox.Text);

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
            var Cargos = _CargoController.BuscarTodos();

            var CargosSinCampo = Cargos.Where(b => b.Codigo == (int)codigoNumeric.Value &&
                b.Nombre == nombreTextBox.Text && b.Salario == (int)salarioNumeric.Value
                && b.Funcion == _funcionRepository.Get(f => f.Nombre.Equals(funcionComboBox.Text)).Codigo)
                .Select(b => new
                {
                    b.Codigo,
                    b.Nombre,
                    b.Salario,
                    FuncionNombre = b.FuncionNavigation.Nombre
                }).ToList();
            dataGridView1.DataSource = CargosSinCampo;

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
                    var message = _CargoController.ActualizarCargo(
                        (int)codigoNumeric.Value,
                        nombreTextBox.Text,
                        (int)salarioNumeric.Value,
                        funcionComboBox.Text);

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
                    var message = _CargoController.DeleteCargo(
                        (int)codigoNumeric.Value,
                        nombreTextBox.Text,
                        (int)salarioNumeric.Value, 
                        funcionComboBox.Text);

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
