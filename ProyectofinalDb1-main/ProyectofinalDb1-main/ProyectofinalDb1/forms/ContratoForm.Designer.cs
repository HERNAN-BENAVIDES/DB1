namespace ProyectofinalDb1.forms
{
    partial class ContratoForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            dataGridView1 = new DataGridView();
            label1 = new Label();
            agregarButton = new Button();
            consultarButton = new Button();
            actualizarButton = new Button();
            eliminarButton = new Button();
            panel1 = new Panel();
            label3 = new Label();
            label5 = new Label();
            label6 = new Label();
            codigoNumeric = new NumericUpDown();
            resetButton = new Button();
            label7 = new Label();
            cargoComboBox = new ComboBox();
            sucursalComboBox = new ComboBox();
            empleadoComboBox = new ComboBox();
            label2 = new Label();
            fechaInicioTimePicker = new DateTimePicker();
            label4 = new Label();
            fechaFinTimePicker = new DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)codigoNumeric).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.BackgroundColor = SystemColors.ControlLightLight;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(60, 142, 165);
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = SystemColors.Window;
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(58, 115, 131);
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.GridColor = SystemColors.MenuText;
            dataGridView1.Location = new Point(177, 323);
            dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle4.BackColor = Color.White;
            dataGridViewCellStyle4.ForeColor = Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(29, 197, 202);
            dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle4;
            dataGridView1.Size = new Size(727, 309);
            dataGridView1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(301, 147);
            label1.Name = "label1";
            label1.Size = new Size(63, 21);
            label1.TabIndex = 1;
            label1.Text = "Codigo:";
            label1.Click += label1_Click;
            // 
            // agregarButton
            // 
            agregarButton.BackColor = Color.FromArgb(60, 142, 165);
            agregarButton.FlatAppearance.BorderSize = 0;
            agregarButton.FlatStyle = FlatStyle.Flat;
            agregarButton.ForeColor = SystemColors.ControlLightLight;
            agregarButton.Location = new Point(1050, 336);
            agregarButton.Name = "agregarButton";
            agregarButton.Size = new Size(200, 35);
            agregarButton.TabIndex = 5;
            agregarButton.Text = "Agregar";
            agregarButton.UseVisualStyleBackColor = false;
            agregarButton.Click += agregarButton_Click;
            // 
            // consultarButton
            // 
            consultarButton.BackColor = Color.FromArgb(60, 142, 165);
            consultarButton.FlatAppearance.BorderSize = 0;
            consultarButton.FlatStyle = FlatStyle.Flat;
            consultarButton.ForeColor = SystemColors.ControlLightLight;
            consultarButton.Location = new Point(1050, 409);
            consultarButton.Name = "consultarButton";
            consultarButton.Size = new Size(200, 35);
            consultarButton.TabIndex = 6;
            consultarButton.Text = "Consultar";
            consultarButton.UseVisualStyleBackColor = false;
            consultarButton.Click += consultarButton_Click;
            // 
            // actualizarButton
            // 
            actualizarButton.BackColor = Color.FromArgb(60, 142, 165);
            actualizarButton.FlatAppearance.BorderSize = 0;
            actualizarButton.FlatStyle = FlatStyle.Flat;
            actualizarButton.ForeColor = SystemColors.ControlLightLight;
            actualizarButton.Location = new Point(1050, 484);
            actualizarButton.Name = "actualizarButton";
            actualizarButton.Size = new Size(200, 35);
            actualizarButton.TabIndex = 7;
            actualizarButton.Text = "Actualizar";
            actualizarButton.UseVisualStyleBackColor = false;
            actualizarButton.Click += actualizarButton_Click;
            // 
            // eliminarButton
            // 
            eliminarButton.BackColor = Color.FromArgb(60, 142, 165);
            eliminarButton.FlatAppearance.BorderSize = 0;
            eliminarButton.FlatStyle = FlatStyle.Flat;
            eliminarButton.ForeColor = SystemColors.ControlLightLight;
            eliminarButton.Location = new Point(1050, 561);
            eliminarButton.Name = "eliminarButton";
            eliminarButton.Size = new Size(200, 35);
            eliminarButton.TabIndex = 8;
            eliminarButton.Text = "Eliminar";
            eliminarButton.UseVisualStyleBackColor = false;
            eliminarButton.Click += eliminarButton_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(60, 142, 165);
            panel1.Controls.Add(label3);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1435, 51);
            panel1.TabIndex = 9;
            panel1.Paint += panel1_Paint;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 17F, FontStyle.Bold);
            label3.ForeColor = SystemColors.ControlLightLight;
            label3.Location = new Point(628, 9);
            label3.Name = "label3";
            label3.Size = new Size(251, 31);
            label3.TabIndex = 0;
            label3.Text = "Consulta de Contratos";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F);
            label5.Location = new Point(904, 154);
            label5.Name = "label5";
            label5.Size = new Size(55, 21);
            label5.TabIndex = 17;
            label5.Text = "Cargo:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F);
            label6.Location = new Point(613, 150);
            label6.Name = "label6";
            label6.Size = new Size(82, 21);
            label6.TabIndex = 15;
            label6.Text = "Empleado:";
            // 
            // codigoNumeric
            // 
            codigoNumeric.Location = new Point(370, 150);
            codigoNumeric.Name = "codigoNumeric";
            codigoNumeric.Size = new Size(120, 23);
            codigoNumeric.TabIndex = 18;
            codigoNumeric.ValueChanged += numericUpDown1_ValueChanged;
            // 
            // resetButton
            // 
            resetButton.BackColor = Color.FromArgb(60, 142, 165);
            resetButton.FlatAppearance.BorderSize = 0;
            resetButton.FlatStyle = FlatStyle.Flat;
            resetButton.ForeColor = SystemColors.ControlLightLight;
            resetButton.Location = new Point(1050, 628);
            resetButton.Name = "resetButton";
            resetButton.Size = new Size(200, 35);
            resetButton.TabIndex = 19;
            resetButton.Text = "Resetear Tabla";
            resetButton.UseVisualStyleBackColor = false;
            resetButton.Click += resetButton_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 12F);
            label7.Location = new Point(295, 236);
            label7.Name = "label7";
            label7.Size = new Size(72, 21);
            label7.TabIndex = 27;
            label7.Text = "Sucursal:";
            // 
            // cargoComboBox
            // 
            cargoComboBox.FormattingEnabled = true;
            cargoComboBox.Location = new Point(965, 156);
            cargoComboBox.Name = "cargoComboBox";
            cargoComboBox.Size = new Size(121, 23);
            cargoComboBox.TabIndex = 28;
            // 
            // sucursalComboBox
            // 
            sucursalComboBox.FormattingEnabled = true;
            sucursalComboBox.Location = new Point(370, 236);
            sucursalComboBox.Name = "sucursalComboBox";
            sucursalComboBox.Size = new Size(121, 23);
            sucursalComboBox.TabIndex = 30;
            // 
            // empleadoComboBox
            // 
            empleadoComboBox.FormattingEnabled = true;
            empleadoComboBox.Location = new Point(694, 149);
            empleadoComboBox.Name = "empleadoComboBox";
            empleadoComboBox.Size = new Size(121, 23);
            empleadoComboBox.TabIndex = 31;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(613, 238);
            label2.Name = "label2";
            label2.Size = new Size(94, 21);
            label2.TabIndex = 33;
            label2.Text = "Fecha Inicio:";
            // 
            // fechaInicioTimePicker
            // 
            fechaInicioTimePicker.CalendarMonthBackground = Color.FromArgb(226, 231, 228);
            fechaInicioTimePicker.Format = DateTimePickerFormat.Custom;
            fechaInicioTimePicker.Location = new Point(713, 238);
            fechaInicioTimePicker.Name = "fechaInicioTimePicker";
            fechaInicioTimePicker.Size = new Size(87, 23);
            fechaInicioTimePicker.TabIndex = 32;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F);
            label4.Location = new Point(904, 239);
            label4.Name = "label4";
            label4.Size = new Size(78, 21);
            label4.TabIndex = 35;
            label4.Text = "Fecha Fin:";
            // 
            // fechaFinTimePicker
            // 
            fechaFinTimePicker.CalendarMonthBackground = Color.FromArgb(226, 231, 228);
            fechaFinTimePicker.Format = DateTimePickerFormat.Custom;
            fechaFinTimePicker.Location = new Point(988, 239);
            fechaFinTimePicker.Name = "fechaFinTimePicker";
            fechaFinTimePicker.Size = new Size(87, 23);
            fechaFinTimePicker.TabIndex = 34;
            // 
            // ContratoForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1435, 717);
            Controls.Add(label4);
            Controls.Add(fechaFinTimePicker);
            Controls.Add(label2);
            Controls.Add(fechaInicioTimePicker);
            Controls.Add(empleadoComboBox);
            Controls.Add(sucursalComboBox);
            Controls.Add(cargoComboBox);
            Controls.Add(label7);
            Controls.Add(resetButton);
            Controls.Add(codigoNumeric);
            Controls.Add(label5);
            Controls.Add(label6);
            Controls.Add(panel1);
            Controls.Add(eliminarButton);
            Controls.Add(actualizarButton);
            Controls.Add(consultarButton);
            Controls.Add(agregarButton);
            Controls.Add(label1);
            Controls.Add(dataGridView1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ContratoForm";
            Text = "ContratoForm";
            Load += ContratoForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)codigoNumeric).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Label label1;
        private Button agregarButton;
        private Button consultarButton;
        private Button actualizarButton;
        private Button eliminarButton;
        private Panel panel1;
        private Label label3;
        private Label label5;
        private Label label6;
        private NumericUpDown codigoNumeric;
        private Button resetButton;
        private Label label7;
        private ComboBox cargoComboBox;
        private ComboBox sucursalComboBox;
        private ComboBox empleadoComboBox;
        private Label label2;
        private DateTimePicker fechaInicioTimePicker;
        private Label label4;
        private DateTimePicker fechaFinTimePicker;
    }
}