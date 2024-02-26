﻿namespace TcpServerChatCSharp
{
    partial class ServerForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            btnIniciar = new Button();
            txtInfo = new TextBox();
            txtMensaje = new TextBox();
            btnEnviar = new Button();
            txtTextoMensaje = new Label();
            lstUsuarios = new ListBox();
            label2 = new Label();
            txtIP = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Location = new Point(12, 12);
            label1.Name = "label1";
            label1.Size = new Size(81, 20);
            label1.TabIndex = 0;
            label1.Text = "IP del Server:";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            label1.Click += label1_Click;
            // 
            // btnIniciar
            // 
            btnIniciar.Location = new Point(383, 293);
            btnIniciar.Name = "btnIniciar";
            btnIniciar.Size = new Size(75, 23);
            btnIniciar.TabIndex = 1;
            btnIniciar.Text = "Iniciar";
            btnIniciar.UseVisualStyleBackColor = true;
            btnIniciar.Click += btnIniciar_Click;
            // 
            // txtInfo
            // 
            txtInfo.Location = new Point(90, 41);
            txtInfo.Multiline = true;
            txtInfo.Name = "txtInfo";
            txtInfo.ScrollBars = ScrollBars.Both;
            txtInfo.Size = new Size(368, 217);
            txtInfo.TabIndex = 3;
            txtInfo.TextChanged += textBox2_TextChanged;
            // 
            // txtMensaje
            // 
            txtMensaje.Location = new Point(90, 264);
            txtMensaje.Name = "txtMensaje";
            txtMensaje.Size = new Size(368, 23);
            txtMensaje.TabIndex = 4;
            // 
            // btnEnviar
            // 
            btnEnviar.Location = new Point(302, 293);
            btnEnviar.Name = "btnEnviar";
            btnEnviar.Size = new Size(75, 23);
            btnEnviar.TabIndex = 5;
            btnEnviar.Text = "Enviar";
            btnEnviar.UseVisualStyleBackColor = true;
            btnEnviar.Click += btnEnviar_Click;
            // 
            // txtTextoMensaje
            // 
            txtTextoMensaje.Location = new Point(30, 266);
            txtTextoMensaje.Name = "txtTextoMensaje";
            txtTextoMensaje.Size = new Size(54, 16);
            txtTextoMensaje.TabIndex = 6;
            txtTextoMensaje.Text = "Mensaje:";
            txtTextoMensaje.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lstUsuarios
            // 
            lstUsuarios.FormattingEnabled = true;
            lstUsuarios.ItemHeight = 15;
            lstUsuarios.Location = new Point(472, 41);
            lstUsuarios.Name = "lstUsuarios";
            lstUsuarios.Size = new Size(154, 124);
            lstUsuarios.TabIndex = 7;
            // 
            // label2
            // 
            label2.Location = new Point(472, 12);
            label2.Name = "label2";
            label2.Size = new Size(154, 20);
            label2.TabIndex = 8;
            label2.Text = "Usuarios conectados:";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtIP
            // 
            txtIP.Location = new Point(90, 12);
            txtIP.Name = "txtIP";
            txtIP.Size = new Size(368, 23);
            txtIP.TabIndex = 2;
            txtIP.Text = "127.0.0.1:9000";
            // 
            // ServerForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(638, 346);
            Controls.Add(label2);
            Controls.Add(lstUsuarios);
            Controls.Add(txtTextoMensaje);
            Controls.Add(btnEnviar);
            Controls.Add(txtMensaje);
            Controls.Add(txtInfo);
            Controls.Add(txtIP);
            Controls.Add(btnIniciar);
            Controls.Add(label1);
            MaximizeBox = false;
            Name = "ServerForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Servidor TCP/IP";
            Load += ServerForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button btnIniciar;
        private TextBox txtInfo;
        private TextBox txtMensaje;
        private Button btnEnviar;
        private Label txtTextoMensaje;
        private ListBox lstUsuarios;
        private Label label2;
        private TextBox txtIP;
    }
}
