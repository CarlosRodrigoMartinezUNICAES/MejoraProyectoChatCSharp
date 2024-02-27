namespace TcpClientChatCSharp
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            string nombreUsuario = SolicitarNombreUsuario();

            if (!string.IsNullOrEmpty(nombreUsuario))
            {
                Application.Run(new ClienteForm(nombreUsuario));
            }
        }

        private static string SolicitarNombreUsuario()
        {
            using (UsuarioForm usuarioForm = new UsuarioForm())
            {
                if (usuarioForm.ShowDialog() == DialogResult.OK)
                {
                    return usuarioForm.NombreUsuario;
                }
                else
                {
                    return "Anónimo";
                }
            }
        }
    }
}