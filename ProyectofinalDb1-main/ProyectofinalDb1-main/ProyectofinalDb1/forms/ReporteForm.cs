using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Generators;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Security;
using ProyectofinalDb1.controller;
using ProyectofinalDb1.data;
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
    public partial class ReporteForm : Form
    {
        private readonly UsuarioController usuarioController;
        private readonly BitacoraController bitacoraController;
        private readonly EmpleadoController empleadoController;
        private readonly FuncionController funcionController;
        private readonly MunicipioController municipioController;
        private readonly DepartamentoController departamentoController;
        private string nivel;

        public ReporteForm(UsuarioController usuario, BitacoraController bitacora, EmpleadoController empleado, FuncionController funcion, MunicipioController municipio, DepartamentoController departamento)
        {
            InitializeComponent();
            usuarioController = usuario;
            empleadoController = empleado;
            bitacoraController = bitacora;
            funcionController = funcion;
            municipioController = municipio;
            departamentoController = departamento;
            nivel = empleadoController.obtenerNivel();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void ReporteForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            List<Usuario> list = usuarioController.ObtenerUsuariosConNivel2();
            if(this.nivel == "1")
            {
                GenerarPdfUsuariosConNivel2(list);

            }
            else
            {
                MessageBox.Show("Usted no cuenta con los permisos para acceder a este reporte");
            }

       
           


        }

        public void GenerarPdfUsuariosConNivel2(List<Usuario> usuarios)
        {
            // Crear el PDF
            using (PdfWriter writer = new PdfWriter("reporteUsuariosNivel2.pdf"))
            {
                using (PdfDocument pdf = new PdfDocument(writer))
                {
                    Document document = new Document(pdf);

                    // Agregar título
                    document.Add(new Paragraph("Usuarios con Nivel 2")
                        .SetTextAlignment(TextAlignment.CENTER)
                        .SetFontSize(20));

                    // Crear una tabla con 3 columnas
                    Table table = new Table(3);
                    table.SetWidth(UnitValue.CreatePercentValue(100));

                    // Agregar encabezados de la tabla
                    table.AddHeaderCell("Codigo");
                    table.AddHeaderCell("Nombre de Usuario");
                    table.AddHeaderCell("Fecha de Creación");

                    // Agregar filas a la tabla
                    foreach (var usuario in usuarios)
                    {
                        table.AddCell(usuario.Codigo.ToString());
                        table.AddCell(usuario.NomUsuario);
                        table.AddCell(usuario.FechaCreacion.ToString());
                    }

                    document.Add(table);
                }
            }
            MessageBox.Show("Reporte generado exitosamente");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<Bitacora> bitacoras = bitacoraController.obtenerTodas();
      
            if (this.nivel == "1")
            {
                GenerarPdfBitacoras(bitacoras);
            }
            else
            {
                MessageBox.Show("Usted no cuenta con los permisos para acceder a este reporte");
            }
            


        }

        public void GenerarPdfBitacoras(List<Bitacora> item)
        {
            // Crear el PDF
            using (PdfWriter writer = new PdfWriter("generarBitacoras.pdf"))
            {
                using (PdfDocument pdf = new PdfDocument(writer))
                {
                    Document document = new Document(pdf);

                    // Agregar título
                    document.Add(new Paragraph("Reporte de bitacoras")
                        .SetTextAlignment(TextAlignment.CENTER)
                        .SetFontSize(20));

                    // Crear una tabla con 3 columnas
                    Table table = new Table(6);
                    table.SetWidth(UnitValue.CreatePercentValue(100));

                    // Agregar encabezados de la tabla
                    table.AddHeaderCell("Codigo");
                    table.AddHeaderCell("Nombre de Usuario");
                    table.AddHeaderCell("Fecha de Ingreso");
                    table.AddHeaderCell("Fecha de Salida");
                    table.AddHeaderCell("Fecha de Ingreso");
                    table.AddHeaderCell("Fecha de Salida");

                    // Agregar filas a la tabla
                    foreach (var aux in item)
                    {
                        table.AddCell(aux.Codigo.ToString());
                        table.AddCell(aux.Usuario.ToString());
                        table.AddCell(aux.FechaIngreso.ToString());
                        table.AddCell(aux.FechaSalida.ToString());
                        table.AddCell(aux.HoraIngreso.ToString());
                        table.AddCell(aux.HoraSalida.ToString());
                    }

                    document.Add(table);
                }
            }
            MessageBox.Show("Reporte generado exitosamente");
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            List<Empleado> empleados = empleadoController.obtenerTodos();
           
            if (this.nivel == "2")
            {
                GenerarPdfEmpleados(empleados);
            }
            else
            {
                MessageBox.Show("Usted no cuenta con los permisos para acceder a este reporte");
            }
           
        }

        public void GenerarPdfEmpleados(List<Empleado> item)
        {
            // Crear el PDF
            using (PdfWriter writer = new PdfWriter("generarEmpleados.pdf"))
            {
                using (PdfDocument pdf = new PdfDocument(writer))
                {
                    Document document = new Document(pdf);

                    // Agregar título
                    document.Add(new Paragraph("Reporte empleados y sus respectivos contratos")
                        .SetTextAlignment(TextAlignment.CENTER)
                        .SetFontSize(20));

                    // Crear una tabla con 3 columnas
                    Table table1 = new Table(5);
                    table1.SetWidth(UnitValue.CreatePercentValue(100));

                    // Agregar encabezados de la tabla
                    table1.AddHeaderCell("Codigo");
                    table1.AddHeaderCell("Nombre");
                    table1.AddHeaderCell("Usuario");
                    table1.AddHeaderCell("Cedula");
                    table1.AddHeaderCell("Telefono");

                    // Agregar filas a la tabla
                    foreach (var aux in item)
                    {
                        table1.AddCell(aux.Codigo.ToString());
                        table1.AddCell(aux.Nombre.ToString());
                        table1.AddCell(aux.Usuario.ToString());
                        table1.AddCell(aux.Cedula.ToString());
                        table1.AddCell(aux.Telefono);

                    }

                    document.Add(table1);

                    Table table2 = new Table(5);
                    table2.SetWidth(UnitValue.CreatePercentValue(100));
                    table2.AddHeaderCell("Codigo");
                    table2.AddHeaderCell("Cargo");
                    table2.AddHeaderCell("Empleado");
                    table2.AddHeaderCell("FechaInicio");
                    table2.AddHeaderCell("Sucursal");

                    /*


                    foreach (var aux in item)
                    {
                        List<Contrato> contratos = aux.Contratos.ToList();

                        foreach(var aux2 in contratos)
                        {
                            table1.AddCell(aux2.Codigo.ToString());
                            table1.AddCell(aux2.Cargo.ToString());
                            table1.AddCell(aux2.Empleado.ToString());
                            table1.AddCell(aux2.FechaInicio.ToString());
                            table1.AddCell(aux2.Sucursal.ToString());

                        }
                    }

                    document.Add(table2);
                    */



                }
            }
            MessageBox.Show("Reporte generado exitosamente");
        }


        private void button4_Click_1(object sender, EventArgs e)
        {
            List<Funcion> funciones = funcionController.obtenerTodos();
         
            if (this.nivel == "2")
            {
                GenerarPdfFunciones(funciones);
            }
            else
            {
                MessageBox.Show("Usted no cuenta con los permisos para acceder a este reporte");
            }
           

        }

        public void GenerarPdfFunciones(List<Funcion> item)
        {
            // Crear el PDF
            using (PdfWriter writer = new PdfWriter("generarFunciones.pdf"))
            {
                using (PdfDocument pdf = new PdfDocument(writer))
                {
                    Document document = new Document(pdf);

                    // Agregar título
                    document.Add(new Paragraph("Reporte de Funcioes")
                        .SetTextAlignment(TextAlignment.CENTER)
                        .SetFontSize(20));

                    // Crear una tabla con 3 columnas
                    Table table = new Table(3);
                    table.SetWidth(UnitValue.CreatePercentValue(100));

                    // Agregar encabezados de la tabla
                    table.AddHeaderCell("Codigo");
                    table.AddHeaderCell("Descripcion");
                    table.AddHeaderCell("Nombre");

                    // Agregar filas a la tabla
                    foreach (var aux in item)
                    {
                        table.AddCell(aux.Codigo.ToString());
                        table.AddCell(aux.Descripcion.ToString());
                        table.AddCell(aux.Nombre.ToString());

                    }

                    document.Add(table);
                }
            }
            MessageBox.Show("Reporte generado exitosamente");
        }


        private void button5_Click_1(object sender, EventArgs e)
        {
            List<Municipio> municipios = municipioController.obtenerTodos();
           
            if (this.nivel == "3")
            {
                GenerarPdfMunicipios(municipios);
            }
            else
            {
                MessageBox.Show("Usted no cuenta con los permisos para acceder a este reporte");
            }
            
        }

        public void GenerarPdfMunicipios(List<Municipio> item)
        {
            // Crear el PDF
            using (PdfWriter writer = new PdfWriter("generarMunicipios.pdf"))
            {
                using (PdfDocument pdf = new PdfDocument(writer))
                {
                    Document document = new Document(pdf);

                    // Agregar título
                    document.Add(new Paragraph("Reporte de Municipios")
                        .SetTextAlignment(TextAlignment.CENTER)
                        .SetFontSize(20));

                    // Crear una tabla con 3 columnas
                    Table table = new Table(4);
                    table.SetWidth(UnitValue.CreatePercentValue(100));

                    // Agregar encabezados de la tabla
                    table.AddHeaderCell("Codigo");
                    table.AddHeaderCell("Nombre");
                    table.AddHeaderCell("Poblacion");
                    table.AddHeaderCell("Prioridad");
             

                    // Agregar filas a la tabla
                    foreach (var aux in item)
                    {
                        table.AddCell(aux.Codigo.ToString());
                        table.AddCell(aux.Nombre.ToString());
                        table.AddCell(aux.Poblacion.ToString());
                        table.AddCell(aux.Prioridad.ToString());
                      

                    }

                    document.Add(table);
                
                }
            }
            MessageBox.Show("Reporte generado exitosamente");
        }

     
        private void button6_Click_1(object sender, EventArgs e)
        {
            List<Departamento> departamentos = departamentoController.obtenerTodos();
          
            if (this.nivel == "3")
            {
                GenerarPdfDepartamentos(departamentos);

            }
            else
            {
                MessageBox.Show("Usted no cuenta con los permisos para acceder a este reporte");
            }
            
        }

        public void GenerarPdfDepartamentos(List<Departamento> item)
        {
            // Crear el PDF
            using (PdfWriter writer = new PdfWriter("generarDepartamentos.pdf"))
            {
                using (PdfDocument pdf = new PdfDocument(writer))
                {
                    Document document = new Document(pdf);

                    // Agregar título
                    document.Add(new Paragraph("Reporte de Departamentos")
                        .SetTextAlignment(TextAlignment.CENTER)
                        .SetFontSize(20));

                    // Crear una tabla con 3 columnas
                    Table table = new Table(3);
                    table.SetWidth(UnitValue.CreatePercentValue(100));

                    // Agregar encabezados de la tabla
                    table.AddHeaderCell("Codigo");
                    table.AddHeaderCell("Nombre");
                    table.AddHeaderCell("Poblacion");
                    
                  

                    // Agregar filas a la tabla
                    foreach (var aux in item)
                    {
                        table.AddCell(aux.Codigo.ToString());
                        table.AddCell(aux.Nombre.ToString());
                        table.AddCell(aux.Poblacion.ToString());
                       

                    }

                    document.Add(table);
                }
            }
            MessageBox.Show("Reporte generado exitosamente");
        }

      
    }
}
