namespace ProyectofinalDb1.forms
{
    partial class LoginForm
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
            usernameTextBox = new TextBox();
            label6 = new Label();
            passwordTextBox = new TextBox();
            label1 = new Label();
            loginButton = new Button();
            SuspendLayout();
            // 
            // usernameTextBox
            // 
            usernameTextBox.BackColor = Color.FromArgb(226, 231, 228);
            usernameTextBox.Location = new Point(146, 35);
            usernameTextBox.Name = "usernameTextBox";
            usernameTextBox.Size = new Size(118, 23);
            usernameTextBox.TabIndex = 23;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F);
            label6.Location = new Point(48, 37);
            label6.Name = "label6";
            label6.Size = new Size(84, 21);
            label6.TabIndex = 22;
            label6.Text = "Username:";
            // 
            // passwordTextBox
            // 
            passwordTextBox.BackColor = Color.FromArgb(226, 231, 228);
            passwordTextBox.Location = new Point(146, 114);
            passwordTextBox.Name = "passwordTextBox";
            passwordTextBox.Size = new Size(118, 23);
            passwordTextBox.TabIndex = 25;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(48, 112);
            label1.Name = "label1";
            label1.Size = new Size(92, 21);
            label1.TabIndex = 24;
            label1.Text = "Contraseña:";
            // 
            // loginButton
            // 
            loginButton.BackColor = Color.FromArgb(60, 142, 165);
            loginButton.FlatAppearance.BorderSize = 0;
            loginButton.FlatStyle = FlatStyle.Flat;
            loginButton.ForeColor = SystemColors.ControlLightLight;
            loginButton.Location = new Point(118, 185);
            loginButton.Name = "loginButton";
            loginButton.Size = new Size(200, 35);
            loginButton.TabIndex = 26;
            loginButton.Text = "Iniciar Sesion";
            loginButton.UseVisualStyleBackColor = false;
            loginButton.Click += loginButton_Click;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(341, 251);
            Controls.Add(loginButton);
            Controls.Add(passwordTextBox);
            Controls.Add(label1);
            Controls.Add(usernameTextBox);
            Controls.Add(label6);
            Name = "LoginForm";
            Text = "LoginForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox usernameTextBox;
        private Label label6;
        private TextBox passwordTextBox;
        private Label label1;
        private Button loginButton;
    }
}