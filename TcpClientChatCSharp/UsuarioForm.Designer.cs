﻿namespace TcpClientChatCSharp
{
    partial class UsuarioForm
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
            label1 = new Label();
            txtUsuario = new TextBox();
            btnAceptar = new Button();
            txtPIN = new TextBox();
            label2 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(24, 13);
            label1.Name = "label1";
            label1.Size = new Size(165, 15);
            label1.TabIndex = 0;
            label1.Text = "Ingresa un nombre de usuario";
            label1.Click += label1_Click;
            // 
            // txtUsuario
            // 
            txtUsuario.Location = new Point(24, 37);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(165, 23);
            txtUsuario.TabIndex = 1;
            // 
            // btnAceptar
            // 
            btnAceptar.Location = new Point(128, 132);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(75, 23);
            btnAceptar.TabIndex = 2;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // txtPIN
            // 
            txtPIN.Location = new Point(55, 98);
            txtPIN.Name = "txtPIN";
            txtPIN.Size = new Size(100, 23);
            txtPIN.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(24, 78);
            label2.Name = "label2";
            label2.Size = new Size(161, 15);
            label2.TabIndex = 4;
            label2.Text = "Contraseña (PIN) del servidor";
            label2.Click += label2_Click;
            // 
            // UsuarioForm
            // 
            AcceptButton = btnAceptar;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(213, 167);
            Controls.Add(label2);
            Controls.Add(txtPIN);
            Controls.Add(btnAceptar);
            Controls.Add(txtUsuario);
            Controls.Add(label1);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "UsuarioForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Bienvenido";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtUsuario;
        private Button btnAceptar;
        private TextBox txtPIN;
        private Label label2;
    }
}