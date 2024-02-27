using SimpleTcp;
using System.Text;

namespace TcpClientChatCSharp
{
    public partial class ClienteForm : Form
    {
        public ClienteForm(string nombreUsuario)
        {
            InitializeComponent();
            txtInfo.Text += $"Bienvenido, {nombreUsuario}!{Environment.NewLine}";
        }

        SimpleTcpClient client;

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            if (client.IsConnected)
            {
                if (!string.IsNullOrEmpty(txtMensaje.Text))
                {
                    client.Send(txtMensaje.Text);
                    txtInfo.Text += $"Yo: {txtMensaje.Text}{Environment.NewLine}";
                    txtMensaje.Text = string.Empty;
                }
            }
        }

        private void txtMensaje_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true; // Evita que se escriba el carácter de retorno de carro en el cuadro de texto
                btnEnviar.PerformClick(); // Simula un clic en el botón "Enviar"
            }
        }

        private void btnConectar_Click(object sender, EventArgs e)
        {
            try
            {
                client.Connect();
                btnEnviar.Enabled = true;
                btnConectar.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Excepcion de Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClienteForm_Load(object sender, EventArgs e)
        {
            client = new(txtIP.Text);
            client.Events.Connected += Events_Conectado;
            client.Events.Disconnected += Events_Desconectado;
            client.Events.DataReceived += Events_DatosRecibidos;
            btnEnviar.Enabled = false;
            txtMensaje.KeyPress += txtMensaje_KeyPress;
        }

        private void Events_Conectado(object? sender, EventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                txtInfo.Text += $"Conectado.{Environment.NewLine}";
            });
            
        }

        private void Events_DatosRecibidos(object? sender, DataReceivedFromServerEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                txtInfo.Text += $"Server: {Encoding.UTF8.GetString(e.Data)}{Environment.NewLine}";
            });
            
        }

        private void Events_Desconectado(object? sender, EventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                txtInfo.Text += $"Desconectado.{Environment.NewLine}";
            });
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtIP_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
