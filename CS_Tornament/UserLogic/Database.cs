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
using CS_Tornament.types;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Data;

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
                if ( Connection.State != System.Data.ConnectionState.Open)
                {
                    Connection.Open();
                }
                
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

                Disconnect();

                return true;
            }
            catch (MySqlException e)
            {
                Console.WriteLine("Error SQL: " + e.Message);
                return false;
            }
        }

        public static ResponseWrapper<User> CreateUser(string username, string email, string password)
        {
            var response = new ResponseWrapper<User>();

            try
            {
                Connect();

                string query = $"INSERT INTO Users (userName, userEmail, userPassword) VALUES ('{username}', '{email}', '{password}')";
                MySqlCommand command = new MySqlCommand(query, Connection);
                command.ExecuteNonQuery();

                string findUserQuery = $"SELECT * FROM Users WHERE userName = '{username}' OR userEmail = '{email}'";
                MySqlCommand findUserCommand = new MySqlCommand(findUserQuery, Connection);
                MySqlDataReader reader = findUserCommand.ExecuteReader();

                if (!reader.HasRows)
                {
                    response.IsSuccess = false;
                    response.ErrorMessage = "User failed to create";
                    return response;
                }

                int UserID = 0;

                while (reader.Read())
                {
                    UserID = reader.GetInt32(0);
                }

                reader.Close();

                response.IsSuccess = true;

                response.Data = new User
                {
                    UserID = UserID,
                    UserName = username,
                    UserEmail = email,
                    UserPassword = password,
                };

                return response;
            }
            catch (MySqlException e)
            {
                Console.WriteLine("Error SQL: " + e.Message);
                response.IsSuccess = false;
                response.ErrorMessage = e.Message;
                return response;
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

                reader.Close();

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

        // Competitions

       public static ResponseWrapper<List<Player>> GetPlayers(int[] PlayerIDs ) {
            var response = new ResponseWrapper<List<Player>>();
            List<Player> PlayersList = new List<Player>();

            try {
                Connect();

                foreach (int PlayerID in PlayerIDs)
                {
                    string PlayerQuery = $"SELECT * FROM `Players` WHERE PlayerID = {PlayerID};";
                    MySqlCommand GetPlayers = new MySqlCommand(PlayerQuery, Connection);
                    MySqlDataReader PlayersReader = GetPlayers.ExecuteReader();

                    if (!PlayersReader.HasRows)
                    {
                        response.IsSuccess = false;
                        response.ErrorMessage = "No players found";
                        return response;
                    }

                    while (PlayersReader.Read())
                    {
                        Player Player = new Player
                        {
                            PlayerID = PlayersReader.GetInt32(0),
                            PlayerFirstName = PlayersReader.GetString(1),
                            PlayerLastName = PlayersReader.GetString(2),
                            PlayerIsIndividual = PlayersReader.GetBoolean(3),
                        };

                        PlayersList.Add(Player);
                    }

                    PlayersReader.Close();
                }

                response.IsSuccess = true;

                response.Data = PlayersList;

                return response;

            }
            catch (MySqlException Ex)
            {
                Console.WriteLine("Mysql error | Competitions : " + Ex.Message);
                response.IsSuccess = false;
                response.ErrorMessage = Ex.Message;
                return response;
            }
            finally
            {
                Disconnect();
            }

       }  

        public static ResponseWrapper<List<Teams>> GetAllTeams(string Username)
        {
            var response = new ResponseWrapper<List<Teams>>();
            List<Teams> TeamsList = new List<Teams>();
            
            try
            {
                Connect();

                string TeamQuery = "SELECT * FROM `Teams`;";
                MySqlCommand GetTeams = new MySqlCommand(TeamQuery, Connection);
                MySqlDataReader TeamsReader = GetTeams.ExecuteReader();
                if (!TeamsReader.HasRows)
                {
                    response.IsSuccess = false;
                    response.ErrorMessage = "No teams found";
                    return response;
                }

                List<RawTeams> RawTeamsList = new List<RawTeams>();

                while (TeamsReader.Read())
                {
                    RawTeams Team = new RawTeams
                    {
                        TeamID = TeamsReader.GetInt32(0),
                        PlayerOne = TeamsReader.GetInt32(1),
                        PlayerTwo = TeamsReader.GetInt32(2),
                        PlayerThree = TeamsReader.GetInt32(3),
                        PlayerFour = TeamsReader.GetInt32(4),
                        PlayerFive = TeamsReader.GetInt32(5),
                        TeamName = TeamsReader.GetString(6),
                    };

                    RawTeamsList.Add(Team);
                }

                TeamsReader.Close();

                foreach (RawTeams Team in RawTeamsList)
                {
                    List<Player> Players = new List<Player>();

                    int[] PlayerIDs = new int[] { Team.PlayerOne, Team.PlayerTwo, Team.PlayerThree, Team.PlayerFour, Team.PlayerFive };
                    var PlayersResponse = GetPlayers(PlayerIDs);

                    if (PlayersResponse.IsSuccess)
                    {
                        Players = PlayersResponse.Data;
                    }

                    Teams TeamObject = new Teams
                    {
                        TeamId = Team.TeamID,
                        PlayerOne = Players[0],
                        PlayerTwo = Players[1],
                        PlayerThree = Players[2],
                        PlayerFour = Players[3],
                        PlayerFive = Players[4],
                        TeamName = Team.TeamName,
                    };

                    TeamsList.Add(TeamObject);
                }

                response.IsSuccess = true;

                response.Data = TeamsList;

                return response;
            }
            catch (MySqlException Ex)
            {
                Console.WriteLine("Mysql error | Competitions : " + Ex.Message);
                response.IsSuccess = false;
                response.ErrorMessage = Ex.Message;
                return response;
            }
            finally
            {
                Disconnect();
            }
        }

        public static ResponseWrapper<List<TornEvents>> GetEvents(string Username)
        {
            var response = new ResponseWrapper<List<TornEvents>>();
            List<TornEvents> EventsList = new List<TornEvents>();

            try
            {
                Connect();

                string EventQuery = "SELECT * FROM `TournamentEvents`";
                MySqlCommand GetEvents = new MySqlCommand(EventQuery, Connection);
                MySqlDataReader EventsReader = GetEvents.ExecuteReader();

                if (!EventsReader.HasRows)
                {
                    response.IsSuccess = false;
                    response.ErrorMessage = "No events found";
                    return response;
                }

                while (EventsReader.Read())
                {
                    TornEvents Event = new TornEvents
                    {
                        EventID = EventsReader.GetInt32(0),
                        EventName = EventsReader.GetString(1),
                        PointAmount = EventsReader.GetInt32(2),
                    };

                    EventsList.Add(Event);
                }

                response.IsSuccess = true;

                response.Data = EventsList;

                return response;
            }
            catch (MySqlException Ex)
            {
                Console.WriteLine("Mysql error | Competitions : " + Ex.Message);
                response.IsSuccess = false;
                response.ErrorMessage = "Error connecting to the database";
                return response;
            }
            finally
            {
                Disconnect();
            }
        }

        public static ResponseWrapper<List<Player>> GetIndividualPlayers() {
            var response = new ResponseWrapper<List<Player>>();
            List<Player> ContestantsList = new List<Player>();

            try {
                Connect();

                string ContestantsQuery = "SELECT * FROM `Players` WHERE PlayerIsIndividual = 1;";
                MySqlCommand GetContestants = new MySqlCommand(ContestantsQuery, Connection);
                MySqlDataReader ContestantsReader = GetContestants.ExecuteReader();

                if (!ContestantsReader.HasRows)
                {
                    response.IsSuccess = false;
                    response.ErrorMessage = "No contestants found";
                    return response;
                }

                int i = 0;

                while (ContestantsReader.Read())
                {

                    if (i > 20) {
                        break;
                    }

                    Player Contestant = new Player
                    {
                        PlayerID = ContestantsReader.GetInt32(0),
                        PlayerFirstName = ContestantsReader.GetString(1),
                        PlayerLastName = ContestantsReader.GetString(2),
                        PlayerIsIndividual = ContestantsReader.GetBoolean(3),
                    };

                    ContestantsList.Add(Contestant);

                    i++;
                }

                ContestantsReader.Close();

                response.IsSuccess = true;

                response.Data = ContestantsList;

                return response;
            }
            catch (MySqlException Ex)
            {
                Console.WriteLine("Mysql error | Competitions : " + Ex.Message);
                response.IsSuccess = false;
                response.ErrorMessage = "Error connecting to the database";
                return response;
            }
            finally
            {
                Disconnect();
            }
        }
    }
}
