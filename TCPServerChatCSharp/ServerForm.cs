using SimpleTcp;
using System;
using System.Text;
using System.Windows.Forms;


namespace TcpServerChatCSharp
{
    public partial class ServerForm : Form
    {
        public ServerForm()
        {
            InitializeComponent();
            timer = new System.Windows.Forms.Timer();
            timer.Interval = 1000; // 1000 milisegundos = 1 segundo
            timer.Tick += Timer_Tick;
        }

        SimpleTcpServer server;
        private System.Windows.Forms.Timer timer;

        public object PINServer { get; private set; }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            // Llamada al metodo Start() del server
            server.Start();
            txtInfo.Text += $"Iniciando...{Environment.NewLine}";
            txtInfo.Text += $"Su PIN es: {PINServer}{Environment.NewLine}";
            btnIniciar.Enabled = false;
            btnEnviar.Enabled = true;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            // Verificar si el servidor está escuchando (_isListening es verdadero)
            if (server.IsListening)
            {
                // Detener el temporizador
                timer.Stop();
                // Mostrar "Iniciado" en la caja de texto
                txtInfo.Text += "Iniciado" + Environment.NewLine;
            }
        }

        private void ServerForm_Load(object sender, EventArgs e)
        {
            string pinServer = SolicitarPIN();
            PINServer = pinServer;
            btnEnviar.Enabled = false;
            server = new SimpleTcpServer(txtIP.Text);
            server.Events.ClientConnected += Events_ClienteConectado;
            server.Events.ClientDisconnected += Events_ClienteDesconectado;
            server.Events.DataReceived += Events_DatosRecibidos;
        }

        private string SolicitarPIN()
        {
            using (PINForm pinForm = new PINForm())
            {
                if (pinForm.ShowDialog() == DialogResult.OK)
                {
                    return pinForm.PIN;
                }
                else
                {
                    return string.Empty;
                }
            }
        }

        private void Events_DatosRecibidos(object? sender, DataReceivedFromClientEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                txtInfo.Text += $"{Encoding.UTF8.GetString(e.Data)}{Environment.NewLine}";

                // Reenviar mensaje a todos los clientes excepto al cliente que lo envió originalmente
                foreach (string clienteIpPort in lstUsuarios.Items)
                {
                    if (clienteIpPort != e.IpPort)
                    {
                        server.Send(clienteIpPort, e.Data);
                    }
                }

            });
            
        }

        private void Events_ClienteDesconectado(object? sender, ClientDisconnectedEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                txtInfo.Text += $"{e.IpPort} se ha desconectado.{Environment.NewLine}";
                lstUsuarios.Items.Remove(e.IpPort);
            });
            
        }

        private void Events_ClienteConectado(object? sender, ClientConnectedEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                txtInfo.Text += $"{e.IpPort} se ha conectado.{Environment.NewLine}";
                lstUsuarios.Items.Add(e.IpPort);
            });
            
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            if(server.IsListening)
            {
                if(!string.IsNullOrEmpty(txtMensaje.Text)&&lstUsuarios.SelectedItem != null)
                    //Chequea de quien viene el mensaje y selecciona ip de cliente de la lista
                {
                    server.Send(lstUsuarios.SelectedItem.ToString(),txtMensaje.Text);
                    txtInfo.Text += $"Servidor: {txtMensaje.Text}{Environment.NewLine}";
                    txtMensaje.Text = string.Empty;
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
