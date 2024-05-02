using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using dotenv.net;

namespace CS_Tornament.UserLogic
{
    internal class Database
    {
        private static string DatabaseServer = "node1.colmena.co.uk";
        private static string DatabaseUser = "u3_zGY7jF6RGM";
        private static string DatabasePassword = "Zu.Z^BX2USyYObL.b+7db8^i";
        private static string DatabaseName = "s3_unit-4-learning-aim-b-c";
            
        private static string ConnectionString = $"server={DatabaseServer};user={DatabaseUser};password={DatabasePassword};database={DatabaseName};";
        private static MySqlConnection Connection = new MySqlConnection(ConnectionString);
        
        private static void Connect() {
            try {
                // DotEnv.Load(options: new DotEnvOptions(probeForEnv: true, probeLevelsToSearch: 2));
                // var EnvironmentVariables = DotEnv.Read();

                Connection.Open();
            }
            catch ( MySqlException e ) {
                Console.WriteLine("Error SQL: " + e.Message);
            }
        }

        private static void Disconnect()
        {
            Connection.Close();
        }

        public static string[] GetUser(string username)
        {
            try
            {
                Connect();

                string query = $"SELECT * FROM Users WHERE userName = '{username}' OR userEmail = '{username}'";
                MySqlCommand command = new MySqlCommand(query, Connection);
                MySqlDataReader reader = command.ExecuteReader();

                if (!reader.HasRows)
                {
                    return new string[] { "User not found" };
                }

                while (reader.Read())
                {
                    string userId = reader.GetString(0);
                    string userName = reader.GetString(1);
                    string userEmail = reader.GetString(2);
                    string userPassword = reader.GetString(3);

                    return new string[] { userId, userName, userEmail, userPassword };
                }

                // If execution reaches here, it means no records were found
                return new string[] { "User not found" };
            }
            catch (MySqlException e)
            {
                Console.WriteLine("Error SQL: " + e.Message);
                return new string[] { "Error" };
            }
            finally
            {
                Disconnect();
            }
        }

    }
}
