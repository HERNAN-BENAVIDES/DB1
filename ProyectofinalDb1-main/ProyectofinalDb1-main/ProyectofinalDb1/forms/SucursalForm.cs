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
    public partial class SucursalForm : Form
    {
        private readonly SucursalController _SucursalController;
        private readonly MunicipioRepository _municipioRepository;
        private readonly UsuarioRepository _usuarioRepository;
        private readonly NivelRepository _nivelRepository;

        public SucursalForm(SucursalController SucursalController, MunicipioRepository municipioRepository,
            UsuarioRepository usuarioRepository, NivelRepository nivelRepository)
        {
            InitializeComponent();
            _SucursalController = SucursalController;
            resetButton.Enabled = false;
            _municipioRepository = municipioRepository;
            _usuarioRepository = usuarioRepository;
            _nivelRepository = nivelRepository;
            crearItemsCombo();
        }

        private void crearItemsCombo()
        {
            foreach (var funcion in _municipioRepository.GetAll())
            {
                municipioComboBox.Items.Add(funcion.Nombre);
            }
            foreach (var funcion in _usuarioRepository.GetAll())
            {
                var nivel = _nivelRepository.Get(n => n.Codigo == funcion.Nivel);
                if(nivel.Nombre.Equals("Director"))
                {
                    directorComboBox.Items.Add(funcion.NomUsuario);
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void SucursalForm_Load(object sender, EventArgs e)
        {
            actualizarData();
        }

        void actualizarData()
        {
            var Sucursals = _SucursalController.BuscarTodos();

            var SucursalsSinCampo = Sucursals.Select(b => new
            {
                b.Codigo,
                b.Nombre,
                b.Presupuesto,
                Director = b.DirectorNavigation.NomUsuario,
                Municipio = b.MunicipioNavigation.Nombre
            }).ToList();
            dataGridView1.DataSource = SucursalsSinCampo;
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
            return (int)codigoNumeric.Value > 0 && nombreTextBox.Text != "" && (int)presupuestoNumeric.Value > 0
                && directorComboBox.SelectedItem != null && municipioComboBox.SelectedItem != null;
        }

        private void agregarButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (validateField())
                {
                    var message = _SucursalController.AddSucursal(
                        (int)codigoNumeric.Value,
                        nombreTextBox.Text,
                        (int)presupuestoNumeric.Value,
                        directorComboBox.Text,
                        municipioComboBox.Text);

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
            var Sucursals = _SucursalController.BuscarTodos();

            var SucursalsSinCampo = Sucursals.Where(b => b.Codigo == (int)codigoNumeric.Value &&
                b.Nombre == nombreTextBox.Text && b.Presupuesto == (int)presupuestoNumeric.Value
                && b.Director == _usuarioRepository.Get(u => u.NomUsuario.Equals(directorComboBox.Text)).Codigo
                && b.Municipio == _municipioRepository.Get(f => f.Nombre.Equals(municipioComboBox.Text)).Codigo)
                .Select(b => new
                {
                    b.Codigo,
                    b.Nombre,
                    b.Presupuesto,
                    Director = b.DirectorNavigation.NomUsuario,
                    Municipio = b.MunicipioNavigation.Nombre
                }).ToList();
            dataGridView1.DataSource = SucursalsSinCampo;

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
                    var message = _SucursalController.ActualizarSucursal(
                        (int)codigoNumeric.Value,
                        nombreTextBox.Text,
                        (int)presupuestoNumeric.Value,
                        directorComboBox.Text,
                        municipioComboBox.Text);

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
                    var message = _SucursalController.DeleteSucursal(
                        (int)codigoNumeric.Value,
                        nombreTextBox.Text,
                        (int)presupuestoNumeric.Value,
                        directorComboBox.Text,
                        municipioComboBox.Text);

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
