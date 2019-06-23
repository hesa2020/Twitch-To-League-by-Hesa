using System;
using System.Windows.Forms;

namespace TwitchToLeagueChat
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        /*public static string BerearCode()
        {
            string lastLine = System.IO.File.ReadLines(System.IO.Path.Combine(Settings.Default.LeaguePath, "System.yaml")).Last();
            return lastLine.Replace("token:", "").Trim();
        }*/
    }
}
