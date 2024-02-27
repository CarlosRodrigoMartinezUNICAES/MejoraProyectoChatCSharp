namespace TcpServerChatCSharp
{
    partial class PINForm
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
            txtPIN = new TextBox();
            btnAceptar = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 5);
            label1.Name = "label1";
            label1.Size = new Size(141, 15);
            label1.TabIndex = 0;
            label1.Text = "Ingrese PIN para la sesion";
            // 
            // txtPIN
            // 
            txtPIN.Location = new Point(6, 23);
            txtPIN.Name = "txtPIN";
            txtPIN.Size = new Size(141, 23);
            txtPIN.TabIndex = 1;
            // 
            // btnAceptar
            // 
            btnAceptar.Location = new Point(43, 52);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(62, 23);
            btnAceptar.TabIndex = 2;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // PINForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(151, 84);
            ControlBox = false;
            Controls.Add(btnAceptar);
            Controls.Add(txtPIN);
            Controls.Add(label1);
            Name = "PINForm";
            SizeGripStyle = SizeGripStyle.Hide;
            Text = "PIN";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtPIN;
        private Button btnAceptar;
    }
}