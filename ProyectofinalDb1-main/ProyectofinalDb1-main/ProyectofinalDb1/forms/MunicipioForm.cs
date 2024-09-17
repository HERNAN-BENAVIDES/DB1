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
    public partial class MunicipioForm : Form
    {
        private readonly MunicipioController _MunicipioController;
        private readonly PrioridadRepository _prioridadRepository;
        private readonly DepartamentoRepository _departamentoRepository;

        public MunicipioForm(MunicipioController MunicipioController, DepartamentoRepository departamentoRepository,
            PrioridadRepository prioridadRepository)
        {
            InitializeComponent();
            _MunicipioController = MunicipioController;
            resetButton.Enabled = false;
            _departamentoRepository = departamentoRepository;
            _prioridadRepository = prioridadRepository;
            crearItemsCombo();
        }

        private void crearItemsCombo()
        {
            foreach (var funcion in _prioridadRepository.GetAll())
            {
                prioridadComboBox.Items.Add(funcion.Nombre);
            }
            foreach (var funcion in _departamentoRepository.GetAll())
            {
                departamentoComboBox.Items.Add(funcion.Nombre);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void MunicipioForm_Load(object sender, EventArgs e)
        {
            actualizarData();
        }

        void actualizarData()
        {
            var Municipios = _MunicipioController.BuscarTodos();

            var MunicipiosSinCampo = Municipios.Select(b => new
            {
                b.Codigo,
                b.Nombre,
                b.Poblacion,
                Priodad = b.PrioridadNavigation.Nombre,
                Departamento = b.DepartamentoNavigation.Nombre
            }).ToList();
            dataGridView1.DataSource = MunicipiosSinCampo;
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
            return (int)codigoNumeric.Value > 0 && nombreTextBox.Text != "" && (int)poblacionNumeric.Value > 0
                && prioridadComboBox.SelectedItem != null && departamentoComboBox.SelectedItem != null;
        }

        private void agregarButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (validateField())
                {
                    var message = _MunicipioController.AddMunicipio(
                        (int)codigoNumeric.Value,
                        nombreTextBox.Text,
                        (int)poblacionNumeric.Value,
                        prioridadComboBox.Text,
                        departamentoComboBox.Text);

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
            var Municipios = _MunicipioController.BuscarTodos();

            var MunicipiosSinCampo = Municipios.Where(b => b.Codigo == (int)codigoNumeric.Value &&
                b.Nombre == nombreTextBox.Text && b.Poblacion == (int)poblacionNumeric.Value
                && b.Prioridad == _prioridadRepository.Get(f => f.Nombre.Equals(prioridadComboBox.Text)).Codigo
                && b.Departamento == 
                _departamentoRepository.Get(f => f.Nombre.Equals(departamentoComboBox.Text)).Codigo)
                .Select(b => new
                {
                    b.Codigo,
                    b.Nombre,
                    b.Poblacion,
                    Priodad = b.PrioridadNavigation.Nombre,
                    Departamento = b.DepartamentoNavigation.Nombre
                }).ToList();
            dataGridView1.DataSource = MunicipiosSinCampo;

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
                    var message = _MunicipioController.ActualizarMunicipio(
                        (int)codigoNumeric.Value,
                        nombreTextBox.Text,
                        (int)poblacionNumeric.Value,
                        prioridadComboBox.Text,
                        departamentoComboBox.Text);

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
                    var message = _MunicipioController.DeleteMunicipio(
                        (int)codigoNumeric.Value,
                        nombreTextBox.Text,
                        (int)poblacionNumeric.Value,
                        prioridadComboBox.Text,
                        departamentoComboBox.Text);

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
