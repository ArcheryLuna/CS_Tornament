using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using dotenv.net;
using System.Windows.Forms.VisualStyles;
using System.Diagnostics;

using CS_Tornament.UserLogic;
using CS_Tornament.Properties;

namespace CS_Tornament.UserLogic
{
    internal class Database
    {
        private static string DatabaseServer = Properties.Settings.Default.SQL_Server;
        private static string DatabaseUser = Properties.Settings.Default.SQL_User;
        private static string DatabasePassword = Properties.Settings.Default.SQL_Password;
        private static string DatabaseName = Properties.Settings.Default.SQL_Name;

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

        public static bool UserExists(string username, string hashedPassword)
        {
            try
            {
                Connect();

                string query = $"SELECT * FROM Users WHERE userName = '{username}' OR userEmail = '{username}' AND userPassword = '{hashedPassword}'";
                MySqlCommand command = new MySqlCommand(query, Connection);
                MySqlDataReader reader = command.ExecuteReader();

                if (!reader.HasRows) {
                    return false;
                }

                return true;
            }
            catch (MySqlException e)
            {
                Console.WriteLine("Error SQL: " + e.Message);
                return false;
            }
            finally
            {
                Disconnect();
            }
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

                int userId = 0;
                string userName = "";
                string userEmail = "";
                string userPassword = "";

                while (reader.Read())
                {
                    userId = reader.GetInt32(0);
                    userName = reader.GetString(1);
                    userEmail = reader.GetString(2);
                    userPassword = reader.GetString(3);

                    
                }

                if ( userName =="" || userEmail =="" || userPassword =="")
                {
                    return new string[] { "User not found" };
                }

                return new string[] {userName, userEmail, userPassword };
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

        public static bool ChangeUsername(string username, string newUsername)
        {
            try
            {
                Connect();

                string findUserQuery = $"SELECT * FROM Users WHERE userName = '{username}' OR userEmail = '{username}'";
                MySqlCommand findUserCommand = new MySqlCommand(findUserQuery, Connection);
                MySqlDataReader reader = findUserCommand.ExecuteReader();

                if (!reader.HasRows)
                {
                    return false;
                }

                

                string query = $"UPDATE Users SET userName = '{newUsername}' WHERE userName = '{username}' OR userEmail = '{username}'";
                MySqlCommand command = new MySqlCommand(query, Connection);
                command.ExecuteNonQuery();
                
                if (Properties.Settings.Default.UserName != string.Empty)
                {
                    Properties.Settings.Default.UserName = newUsername;
                    Properties.Settings.Default.Save();
                }
                
                return true;
            }
            catch ( MySqlException Ex )
            {
                Console.WriteLine("Error SQL: " + Ex.Message);
                return false;
            }
            finally
            {
                Disconnect();
            }
        }

        public static bool ChangeEmail ( string username, string newEmail )
        {
            try
            {
                Connect();

                string findUserQuery = $"SELECT * FROM Users WHERE userName = '{username}' OR userEmail = '{username}'";
                MySqlCommand findUserCommand = new MySqlCommand(findUserQuery, Connection);
                MySqlDataReader reader = findUserCommand.ExecuteReader();

                if (!reader.HasRows)
                {
                    return false;
                }

                string query = $"UPDATE Users SET userEmail = '{newEmail}' WHERE userName = '{username}' OR userEmail = '{username}'";
                MySqlCommand command = new MySqlCommand(query, Connection);
                command.ExecuteNonQuery();

                return true;
            }
            catch (MySqlException Ex)
            {
                Console.WriteLine("Error SQL: " + Ex.Message);
                return false;
            }
            finally
            {
                Disconnect();
            }
        }

        public static bool ChangePassword( string username, string newPassword )
        {
            try
            {
                Connect();

                string findUserQuery = $"SELECT * FROM Users WHERE userName = '{username}' OR userEmail = '{username}'";
                MySqlCommand findUserCommand = new MySqlCommand(findUserQuery, Connection);
                MySqlDataReader reader = findUserCommand.ExecuteReader();

                if (!reader.HasRows)
                {
                    return false;
                }

                string PasswordHash = Password.Hash(newPassword);

                string query = $"UPDATE Users SET userPassword = '{PasswordHash}' WHERE userName = '{username}' OR userEmail = '{username}'";
                MySqlCommand command = new MySqlCommand(query, Connection);
                command.ExecuteNonQuery();

                if ( Properties.Settings.Default.UserPassword != string.Empty )
                {
                    Properties.Settings.Default.UserPassword = PasswordHash;
                    Properties.Settings.Default.Save();
                }
                
                return true;
            }
            catch (MySqlException Ex)
            {
                Console.WriteLine("Error SQL: " + Ex.Message);
                return false;
            }
            finally
            {
                Disconnect();
            }
        }
    }
}
