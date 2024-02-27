using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TcpClientChatCSharp
{
    public partial class UsuarioForm : Form
    {
        public string NombreUsuario { get; private set; }
        public string PINSala { get; private set; }

        public UsuarioForm()
        {
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            // Obtener el nombre de usuario ingresado por el usuario y el pin de la sala (para desencriptar los mensajes y encriptarlos)
            if (txtUsuario.Text.Length < 1)
            {
                NombreUsuario = "Anonimo";
            }
            else
            {
                NombreUsuario = txtUsuario.Text.Trim();
            }
            
            PINSala = txtPIN.Text.Trim();

            if (string.IsNullOrEmpty(PINSala)) // Verificar si el PIN está vacío o nulo
            {
                MessageBox.Show("Debes ingresar un PIN para conectarte al servidor.", "PIN requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Detener el flujo del método si no se proporcionó un PIN
            }

            DialogResult = DialogResult.OK;
            Close();
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
