using ProyectofinalDb1.controller;
using ProyectofinalDb1.repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectofinalDb1.forms
{
    public partial class BitacoraForm : Form
    {
        private readonly BitacoraController _bitacoraController;
        private readonly UsuarioRepository _usuarioRepository;

        public BitacoraForm(BitacoraController bitacoraController, UsuarioRepository usuarioRepository)
        {
            InitializeComponent();
            _bitacoraController = bitacoraController;
            _usuarioRepository = usuarioRepository;
            horaSalidaTimePicker.ShowUpDown = true;
            resetButton.Enabled = false;
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

        private void BitacoraForm_Load(object sender, EventArgs e)
        {
            actualizarData();
        }

        void actualizarData()
        {
            var bitacoras = _bitacoraController.BuscarTodos();

            var bitacorasSinCampo = bitacoras.Select(b => new
            {
                b.Codigo,
                b.FechaIngreso,
                b.FechaSalida,
                b.HoraIngreso,
                b.HoraSalida,
                Usuario = b.UsuarioNavigation.NomUsuario,
            }).ToList();
            dataGridView1.DataSource = bitacorasSinCampo;
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
            return (int)codigoNumeric.Value > 0 && usuarioComboBox.Text != "";
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
            var bitacoras = _bitacoraController.BuscarTodos();

            TimeSpan horaIngreso = horaIngresoTimePicker.Value.TimeOfDay;
            TimeSpan horaSalida = horaSalidaTimePicker.Value.TimeOfDay;

            var bitacorasSinCampo = bitacoras.Where(b => b.Codigo == (int)codigoNumeric.Value &&
                b.FechaIngreso.Value.Date == fechaIngresoTimePicker.Value.Date.Date &&
                b.FechaSalida.Value.Date == fechaSalidaTimePicker.Value.Date.Date &&
                b.HoraIngreso == new TimeSpan(horaIngreso.Hours, horaIngreso.Minutes, horaIngreso.Seconds) &&
                b.HoraSalida == new TimeSpan(horaSalida.Hours, horaSalida.Minutes, horaSalida.Seconds)
                && b.UsuarioNavigation.NomUsuario.Equals(usuarioComboBox.Text))
                .Select(b => new
                {
                    b.Codigo,
                    b.FechaIngreso,
                    b.FechaSalida,
                    b.HoraIngreso,
                    b.HoraSalida,
                    Usuario = b.UsuarioNavigation.NomUsuario,
                }).ToList();
            dataGridView1.DataSource = bitacorasSinCampo;

            resetButton.Enabled = true;
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            actualizarData();
            resetButton.Enabled = false;
        }
    }
}
