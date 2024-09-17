namespace ProyectofinalDb1.forms
{
    partial class BitacoraForm
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            dataGridView1 = new DataGridView();
            label1 = new Label();
            consultarButton = new Button();
            panel1 = new Panel();
            label3 = new Label();
            fechaIngresoTimePicker = new DateTimePicker();
            label2 = new Label();
            label4 = new Label();
            fechaSalidaTimePicker = new DateTimePicker();
            label5 = new Label();
            horaSalidaTimePicker = new DateTimePicker();
            label6 = new Label();
            horaIngresoTimePicker = new DateTimePicker();
            codigoNumeric = new NumericUpDown();
            resetButton = new Button();
            usuarioComboBox = new ComboBox();
            label7 = new Label();
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
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(60, 142, 165);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = SystemColors.Window;
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(58, 115, 131);
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.GridColor = SystemColors.MenuText;
            dataGridView1.Location = new Point(191, 354);
            dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle2.BackColor = Color.White;
            dataGridViewCellStyle2.ForeColor = Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(29, 197, 202);
            dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle2;
            dataGridView1.Size = new Size(727, 309);
            dataGridView1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(299, 143);
            label1.Name = "label1";
            label1.Size = new Size(63, 21);
            label1.TabIndex = 1;
            label1.Text = "Codigo:";
            label1.Click += label1_Click;
            // 
            // consultarButton
            // 
            consultarButton.BackColor = Color.FromArgb(60, 142, 165);
            consultarButton.FlatAppearance.BorderSize = 0;
            consultarButton.FlatStyle = FlatStyle.Flat;
            consultarButton.ForeColor = SystemColors.ControlLightLight;
            consultarButton.Location = new Point(1050, 371);
            consultarButton.Name = "consultarButton";
            consultarButton.Size = new Size(200, 35);
            consultarButton.TabIndex = 6;
            consultarButton.Text = "Consultar";
            consultarButton.UseVisualStyleBackColor = false;
            consultarButton.Click += consultarButton_Click;
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
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 17F, FontStyle.Bold);
            label3.ForeColor = SystemColors.ControlLightLight;
            label3.Location = new Point(628, 9);
            label3.Name = "label3";
            label3.Size = new Size(245, 31);
            label3.TabIndex = 0;
            label3.Text = "Consulta de Bitacoras";
            // 
            // fechaIngresoTimePicker
            // 
            fechaIngresoTimePicker.CalendarMonthBackground = Color.FromArgb(226, 231, 228);
            fechaIngresoTimePicker.Format = DateTimePickerFormat.Custom;
            fechaIngresoTimePicker.Location = new Point(475, 220);
            fechaIngresoTimePicker.Name = "fechaIngresoTimePicker";
            fechaIngresoTimePicker.Size = new Size(87, 23);
            fechaIngresoTimePicker.TabIndex = 10;
            fechaIngresoTimePicker.ValueChanged += fechaIngresoTimePicker_ValueChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(360, 220);
            label2.Name = "label2";
            label2.Size = new Size(109, 21);
            label2.TabIndex = 11;
            label2.Text = "Fecha Ingreso:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F);
            label4.Location = new Point(646, 220);
            label4.Name = "label4";
            label4.Size = new Size(99, 21);
            label4.TabIndex = 13;
            label4.Text = "Fecha Salida:";
            // 
            // fechaSalidaTimePicker
            // 
            fechaSalidaTimePicker.CalendarMonthBackground = Color.FromArgb(226, 231, 228);
            fechaSalidaTimePicker.Format = DateTimePickerFormat.Custom;
            fechaSalidaTimePicker.Location = new Point(751, 220);
            fechaSalidaTimePicker.Name = "fechaSalidaTimePicker";
            fechaSalidaTimePicker.Size = new Size(87, 23);
            fechaSalidaTimePicker.TabIndex = 12;
            fechaSalidaTimePicker.ValueChanged += dateTimePicker1_ValueChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F);
            label5.Location = new Point(902, 147);
            label5.Name = "label5";
            label5.Size = new Size(93, 21);
            label5.TabIndex = 17;
            label5.Text = "Hora Salida:";
            // 
            // horaSalidaTimePicker
            // 
            horaSalidaTimePicker.CalendarMonthBackground = Color.FromArgb(226, 231, 228);
            horaSalidaTimePicker.Format = DateTimePickerFormat.Time;
            horaSalidaTimePicker.Location = new Point(1001, 147);
            horaSalidaTimePicker.Name = "horaSalidaTimePicker";
            horaSalidaTimePicker.Size = new Size(87, 23);
            horaSalidaTimePicker.TabIndex = 16;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F);
            label6.Location = new Point(616, 147);
            label6.Name = "label6";
            label6.Size = new Size(103, 21);
            label6.TabIndex = 15;
            label6.Text = "Hora Ingreso:";
            // 
            // horaIngresoTimePicker
            // 
            horaIngresoTimePicker.CalendarMonthBackground = Color.FromArgb(226, 231, 228);
            horaIngresoTimePicker.Format = DateTimePickerFormat.Time;
            horaIngresoTimePicker.Location = new Point(731, 147);
            horaIngresoTimePicker.Name = "horaIngresoTimePicker";
            horaIngresoTimePicker.Size = new Size(87, 23);
            horaIngresoTimePicker.TabIndex = 14;
            // 
            // codigoNumeric
            // 
            codigoNumeric.Location = new Point(368, 146);
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
            resetButton.Location = new Point(1050, 454);
            resetButton.Name = "resetButton";
            resetButton.Size = new Size(200, 35);
            resetButton.TabIndex = 19;
            resetButton.Text = "Resetear Tabla";
            resetButton.UseVisualStyleBackColor = false;
            resetButton.Click += resetButton_Click;
            // 
            // usuarioComboBox
            // 
            usuarioComboBox.FormattingEnabled = true;
            usuarioComboBox.Location = new Point(960, 222);
            usuarioComboBox.Name = "usuarioComboBox";
            usuarioComboBox.Size = new Size(121, 23);
            usuarioComboBox.TabIndex = 30;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 12F);
            label7.Location = new Point(887, 222);
            label7.Name = "label7";
            label7.Size = new Size(67, 21);
            label7.TabIndex = 29;
            label7.Text = "Usuario:";
            // 
            // BitacoraForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1435, 717);
            Controls.Add(usuarioComboBox);
            Controls.Add(label7);
            Controls.Add(resetButton);
            Controls.Add(codigoNumeric);
            Controls.Add(label5);
            Controls.Add(horaSalidaTimePicker);
            Controls.Add(label6);
            Controls.Add(horaIngresoTimePicker);
            Controls.Add(label4);
            Controls.Add(fechaSalidaTimePicker);
            Controls.Add(label2);
            Controls.Add(fechaIngresoTimePicker);
            Controls.Add(panel1);
            Controls.Add(consultarButton);
            Controls.Add(label1);
            Controls.Add(dataGridView1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "BitacoraForm";
            Text = "BitacoraForm";
            Load += BitacoraForm_Load;
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
        private Button consultarButton;
        private Panel panel1;
        private Label label3;
        private DateTimePicker fechaIngresoTimePicker;
        private Label label2;
        private Label label4;
        private DateTimePicker fechaSalidaTimePicker;
        private Label label5;
        private DateTimePicker horaSalidaTimePicker;
        private Label label6;
        private DateTimePicker horaIngresoTimePicker;
        private NumericUpDown codigoNumeric;
        private Button resetButton;
        private ComboBox usuarioComboBox;
        private Label label7;
    }
}