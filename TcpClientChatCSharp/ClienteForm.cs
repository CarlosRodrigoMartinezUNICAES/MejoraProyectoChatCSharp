using SimpleTcp;
using System.Media;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using System;
using System.IO;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.Crypto;

namespace TcpClientChatCSharp
{
    public partial class ClienteForm : Form
    {
        public string NombreUsuario { get; private set; }
        public string clientHash { get; private set; }

        public string pinSala;
        public string key;

        private SoundPlayer sonido;

        public ClienteForm(string nombreUsuario, string PINSala)
        {
            InitializeComponent();
            clientHash = CalcularHash("palabraultrasecreta", PINSala);
            string rutaSonido = Path.Combine(Application.StartupPath, "ui", "client.wav");
            sonido = new SoundPlayer(rutaSonido);
            txtInfo.Text += $"Bienvenido, {nombreUsuario} {PINSala} !{Environment.NewLine}";
            NombreUsuario = nombreUsuario;
            pinSala = PINSala;
        }

        SimpleTcpClient client;

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            if (client.IsConnected)
            {
                if (!string.IsNullOrEmpty(txtMensaje.Text))
                {
                    string mensajeCompleto = $"{NombreUsuario}: {txtMensaje.Text}";
                    byte[] mensajeCifrado = CifrarMensaje(mensajeCompleto);
                    client.Send(mensajeCifrado);
                    txtInfo.Text += $"{NombreUsuario} (Yo): {txtMensaje.Text}{Environment.NewLine}";
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
                sonido.Play();
                // Calcular el hash de la cadena "palabraultrasecreta" utilizando el PIN del cliente
                string hash = CalcularHash("palabraultrasecreta", pinSala);
                clientHash = hash;
                client.Send($"PIN:{hash}");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Excepcion de Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string CalcularHash(string input, string pin)
        {
            // Logica para calcular el hash utilizando el PIN
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
                string mensajeDescifrado = DescifrarMensaje(e.Data);
                txtInfo.Text += $"{mensajeDescifrado}{Environment.NewLine}";
            });

        }

        private void Events_Desconectado(object? sender, EventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                txtInfo.Text += $"Desconectado.{Environment.NewLine}";
                btnConectar.Enabled = true; // Reactivar el botón de conectar
                btnEnviar.Enabled = false; // Desactivar el botón de enviar
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

        // Método para cifrar un mensaje antes de enviarlo
        private byte[] CifrarMensaje(string mensaje)
        {
            byte[] clientHashTruncada = AESUtil.ConvertTo128Bits(clientHash);
            return AESUtil.Encrypt(mensaje, clientHashTruncada);
        }

        // Método para descifrar un mensaje recibido
        private string DescifrarMensaje(byte[] mensajeCifrado)
        {
            byte[] clientHashTruncada = AESUtil.ConvertTo128Bits(clientHash);
            return AESUtil.Decrypt(mensajeCifrado, clientHashTruncada);
        }


    }

    }
