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
        public UsuarioForm()
        {
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            // Obtener el nombre de usuario ingresado por el usuario
            NombreUsuario = txtUsuario.Text.Trim();
            DialogResult = DialogResult.OK;
            Close();
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
