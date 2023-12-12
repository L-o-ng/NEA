//The client will operate over port 7178

namespace Client
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new frm_mazeClient());
        }
    }
}