using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TcpServerChatCSharp
{
    public partial class PINForm : Form
    {
        public string PIN { get; private set; }
        public PINForm()
        {
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            PIN = txtPIN.Text.Trim();
            if (string.IsNullOrEmpty(PIN))
            {
                MessageBox.Show("Por favor, introduce un PIN válido.", "PIN requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }
    }
}
