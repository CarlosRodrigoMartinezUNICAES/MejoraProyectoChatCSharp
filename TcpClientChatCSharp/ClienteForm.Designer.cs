namespace TcpClientChatCSharp
{
    partial class ClienteForm
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
            btnConectar = new Button();
            txtIP = new TextBox();
            txtInfo = new TextBox();
            txtMensaje = new TextBox();
            btnEnviar = new Button();
            txtTextoMensaje = new Label();
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
            // btnConectar
            // 
            btnConectar.Location = new Point(383, 293);
            btnConectar.Name = "btnConectar";
            btnConectar.Size = new Size(75, 23);
            btnConectar.TabIndex = 1;
            btnConectar.Text = "Conectar";
            btnConectar.UseVisualStyleBackColor = true;
            btnConectar.Click += btnConectar_Click;
            // 
            // txtIP
            // 
            txtIP.Location = new Point(90, 12);
            txtIP.Name = "txtIP";
            txtIP.Size = new Size(368, 23);
            txtIP.TabIndex = 2;
            txtIP.Text = "127.0.0.1:9000";
            txtIP.TextChanged += txtIP_TextChanged;
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
            // ClienteForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(470, 346);
            Controls.Add(txtTextoMensaje);
            Controls.Add(btnEnviar);
            Controls.Add(txtMensaje);
            Controls.Add(txtInfo);
            Controls.Add(txtIP);
            Controls.Add(btnConectar);
            Controls.Add(label1);
            MaximizeBox = false;
            Name = "ClienteForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Cliente TCP/IP";
            Load += ClienteForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button btnConectar;
        private TextBox txtIP;
        private TextBox txtInfo;
        private TextBox txtMensaje;
        private Button btnEnviar;
        private Label txtTextoMensaje;
    }
}
