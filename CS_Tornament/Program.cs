using CS_Tornament.UserLogic;
using dotenv.net;

namespace CS_Tornament
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

            if (Properties.Settings.Default.UserPassword != string.Empty)
            {
                string Username = Properties.Settings.Default.UserName;
                string Password = Properties.Settings.Default.UserPassword;

                bool UserExists = Database.UserExists(Username, Password);

                if (UserExists)
                {
                    Application.Run(new Tornaments());
                }
                else
                {
                    Properties.Settings.Default.UserName = string.Empty;
                    Properties.Settings.Default.UserPassword = string.Empty;

                    Properties.Settings.Default.Save();

                    Application.Run(new LoginForm());
                }
            }
            else
            {
                Application.Run(new LoginForm());
            }
        }
    }
}