using Org.BouncyCastle.Crypto.Generators;
using SimpleTcp;
using System;
using System.Media;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;


namespace TcpServerChatCSharp
{
    public partial class ServerForm : Form
    {
        private SoundPlayer sonido;
        public string key;
        public string serverHash;
        public ServerForm()
        {
            InitializeComponent();
            string rutaSonido = Path.Combine(Application.StartupPath, "ui", "server.wav");
            sonido = new SoundPlayer(rutaSonido);
            timer = new System.Windows.Forms.Timer();
            timer.Interval = 1000; // 1000 milisegundos = 1 segundo
            timer.Tick += Timer_Tick;
        }

        SimpleTcpServer server;
        private System.Windows.Forms.Timer timer;

        public string PINServer { get; private set; }
        public string serverHashCrypt { get; private set; }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            // Llamada al metodo Start() del server
            server.Start();
            txtInfo.Text += $"Iniciando...{Environment.NewLine}";
            txtInfo.Text += $"Su PIN es: {PINServer}{Environment.NewLine}";
            btnIniciar.Enabled = false;
            btnEnviar.Enabled = true;
            timer.Start();
            sonido.Play();
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

        public void ServerForm_Load(object sender, EventArgs e)
        {
            string pinServer = SolicitarPIN();
            PINServer = pinServer;
            btnEnviar.Enabled = false;
            string serverHash = CalcularHash("palabraultrasecreta", PINServer);
            serverHashCrypt = serverHash;
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
                string mensajePIN = Encoding.UTF8.GetString(e.Data);
                // Verificar si el mensaje es un intento de conexión con PIN
                if (mensajePIN.StartsWith("PIN:"))
                {
                    string clientHash = mensajePIN.Substring(4);
                    string serverHash = CalcularHash("palabraultrasecreta", PINServer);
                    MessageBox.Show($"Hash del cliente: {clientHash}\nHash del servidor: {serverHash}");

                    if (clientHash == serverHash)
                    {
                        // Si los hashes coinciden, permitir que el cliente se conecte
                        server.Send(e.IpPort, "Conexión permitida");
                    }
                    else
                    {
                        // Si los hashes no coinciden, denegar la conexión
                        server.Send(e.IpPort, "PIN incorrecto. Conexión denegada");
                        // Además, podrías agregar aquí código para desconectar al cliente si lo deseas
                        server.DisconnectClient(e.IpPort);
                    }
                }
                else
                {
                    // Este es un mensaje normal, haz lo que necesites con él
                    string mensajeDescifrado = DescifrarMensaje(e.Data);
                    txtInfo.Text += $"{mensajeDescifrado}{Environment.NewLine}";

                    // Reenviar mensaje a todos los clientes excepto al cliente que lo envió originalmente
                    foreach (string clienteIpPort in lstUsuarios.Items)
                    {
                        if (clienteIpPort != e.IpPort)
                        {
                            server.Send(clienteIpPort, e.Data);
                        }
                    }
                }

            });
            
        }

        private string CalcularHash(string input, string pin)
        {
            // Lógica para calcular el hash utilizando el PIN
            // Se esta utilizando SHA256
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(input + pin);
                byte[] hashBytes = sha256.ComputeHash(bytes);
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    builder.Append(hashBytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
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

        // Método para cifrar un mensaje antes de enviarlo
        private byte[] CifrarMensaje(string mensaje)
        {
            byte[] serverHashTruncada = AESUtil.ConvertTo128Bits(serverHashCrypt);
            return AESUtil.Encrypt(mensaje, serverHashTruncada);
        }

        // Método para descifrar un mensaje recibido
        private string DescifrarMensaje(byte[] mensajeCifrado)
        {
            byte[] serverHashTruncada = AESUtil.ConvertTo128Bits(serverHashCrypt);
            return AESUtil.Decrypt(mensajeCifrado, serverHashTruncada);
        }
    }
}
