using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CS_Tornament.UserLogic;
using CS_Tornament.types;
using Org.BouncyCastle.Utilities.Encoders;

namespace CS_Tornament
{
    public partial class TeamsForm : Form
    {
        bool IsResetting = false;
        bool IsEnabled = false;

        CurrentEventType CurrentEvent = new CurrentEventType();

        string ZeroPercentColor = "#fca5a5";
        string TwentyFivePercentColor = "#fdba74";
        string FiftyPercentColor = "#fcd34d";
        string SeventyFivePercentColor = "#fde047";
        string NightyPercentColor = "#bef264";
        string OneHundredPercentColor = "#86efac";

        List<Player> TeamOnePlayers = new List<Player>();
        List<Player> TeamTwoPlayers = new List<Player>();
        List<Player> TeamThreePlayers = new List<Player>();
        List<Player> TeamFourPlayers = new List<Player>();
        List<Teams> Teams = new List<Teams>();

        List<TornEvents> CompetitionEvents = new List<TornEvents>();

        int TotalPoints = 0;

        public TeamsForm()
        {
            InitializeComponent();
        }

        private void TeamsForm_Load(object sender, EventArgs e)
        {
            UsernameLabel.Text = Properties.Settings.Default.UserName;

            ResponseWrapper<List<Teams>> AllTeams = Database.GetAllTeams(Properties.Settings.Default.UserName);

            if (AllTeams.IsSuccess == false)
            {
                MessageBox.Show("Error: " + AllTeams.ErrorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                Application.Exit();

                return;
            }

            Teams = AllTeams.Data;

            TeamOnePlayers.Add(Teams[0].PlayerOne);
            TeamOnePlayers.Add(Teams[0].PlayerTwo);
            TeamOnePlayers.Add(Teams[0].PlayerThree);
            TeamOnePlayers.Add(Teams[0].PlayerFour);
            TeamOnePlayers.Add(Teams[0].PlayerFive);

            TeamTwoPlayers.Add(Teams[1].PlayerOne);
            TeamTwoPlayers.Add(Teams[1].PlayerTwo);
            TeamTwoPlayers.Add(Teams[1].PlayerThree);
            TeamTwoPlayers.Add(Teams[1].PlayerFour);
            TeamTwoPlayers.Add(Teams[1].PlayerFive);

            TeamThreePlayers.Add(Teams[2].PlayerOne);
            TeamThreePlayers.Add(Teams[2].PlayerTwo);
            TeamThreePlayers.Add(Teams[2].PlayerThree);
            TeamThreePlayers.Add(Teams[2].PlayerFour);
            TeamThreePlayers.Add(Teams[2].PlayerFive);

            TeamFourPlayers.Add(Teams[3].PlayerOne);
            TeamFourPlayers.Add(Teams[3].PlayerTwo);
            TeamFourPlayers.Add(Teams[3].PlayerThree);
            TeamFourPlayers.Add(Teams[3].PlayerFour);
            TeamFourPlayers.Add(Teams[3].PlayerFive);

            TeamOneNameLabel.Text = Teams[0].TeamName;
            TeamTwoNameLabel.Text = Teams[1].TeamName;
            TeamThreeNameLabel.Text = Teams[2].TeamName;
            TeamFourNameLabel.Text = Teams[3].TeamName;

            TeamOnePlayerOneCheckBox.Text = $"{TeamOnePlayers[0].PlayerFirstName} {TeamOnePlayers[0].PlayerLastName}";
            TeamOnePlayerTwoCheckBox.Text = $"{TeamOnePlayers[1].PlayerFirstName} {TeamOnePlayers[1].PlayerLastName}";
            TeamOnePlayerThreeCheckBox.Text = $"{TeamOnePlayers[2].PlayerFirstName} {TeamOnePlayers[2].PlayerLastName}";
            TeamOnePlayerFourCheckBox.Text = $"{TeamOnePlayers[3].PlayerFirstName} {TeamOnePlayers[3].PlayerLastName}";
            TeamOnePlayerFiveCheckBox.Text = $"{TeamOnePlayers[4].PlayerFirstName} {TeamOnePlayers[4].PlayerLastName}";

            TeamTwoPlayerOneCheckBox.Text = $"{TeamTwoPlayers[0].PlayerFirstName} {TeamTwoPlayers[0].PlayerLastName}";
            TeamTwoPlayerTwoCheckBox.Text = $"{TeamTwoPlayers[1].PlayerFirstName} {TeamTwoPlayers[1].PlayerLastName}";
            TeamTwoPlayerThreeCheckBox.Text = $"{TeamTwoPlayers[2].PlayerFirstName} {TeamTwoPlayers[2].PlayerLastName}";
            TeamTwoPlayerFourCheckBox.Text = $"{TeamTwoPlayers[3].PlayerFirstName} {TeamTwoPlayers[3].PlayerLastName}";
            TeamTwoPlayerFiveCheckBox.Text = $"{TeamTwoPlayers[4].PlayerFirstName} {TeamTwoPlayers[4].PlayerLastName}";

            TeamThreePlayerOneCheckBox.Text = $"{TeamThreePlayers[0].PlayerFirstName} {TeamThreePlayers[0].PlayerLastName}";
            TeamThreePlayerTwoCheckBox.Text = $"{TeamThreePlayers[1].PlayerFirstName} {TeamThreePlayers[1].PlayerLastName}";
            TeamThreePlayerThreeCheckBox.Text = $"{TeamThreePlayers[2].PlayerFirstName} {TeamThreePlayers[2].PlayerLastName}";
            TeamThreePlayerFourCheckBox.Text = $"{TeamThreePlayers[3].PlayerFirstName} {TeamThreePlayers[3].PlayerLastName}";
            TeamThreePlayerFiveCheckBox.Text = $"{TeamThreePlayers[4].PlayerFirstName} {TeamThreePlayers[4].PlayerLastName}";

            TeamFourPlayerOneCheckBox.Text = $"{TeamFourPlayers[0].PlayerFirstName} {TeamFourPlayers[0].PlayerLastName}";
            TeamFourPlayerTwoCheckBox.Text = $"{TeamFourPlayers[1].PlayerFirstName} {TeamFourPlayers[1].PlayerLastName}";
            TeamFourPlayerThreeCheckBox.Text = $"{TeamFourPlayers[2].PlayerFirstName} {TeamFourPlayers[2].PlayerLastName}";
            TeamFourPlayerFourCheckBox.Text = $"{TeamFourPlayers[3].PlayerFirstName} {TeamFourPlayers[3].PlayerLastName}";
            TeamFourPlayerFiveCheckBox.Text = $"{TeamFourPlayers[4].PlayerFirstName} {TeamFourPlayers[4].PlayerLastName}";

            ResponseWrapper<List<TornEvents>> AllEvents = Database.GetEvents(Properties.Settings.Default.UserName);
            if (AllEvents.IsSuccess == false)
            {
                MessageBox.Show("Error: " + AllEvents.ErrorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                Application.Exit();

                return;
            }

            CompetitionEvents = AllEvents.Data;

            EventOneCheckBox.Text = CompetitionEvents[0].EventName;
            EventTwoCheckBox.Text = CompetitionEvents[1].EventName;
            EventThreeCheckBox.Text = CompetitionEvents[2].EventName;
            EventFourCheckBox.Text = CompetitionEvents[3].EventName;
            EventFiveCheckBox.Text = CompetitionEvents[4].EventName;

            EventOnePointsValueLabel.Text = CompetitionEvents[0].PointAmount.ToString();
            EventTwoPointsValueLabel.Text = CompetitionEvents[1].PointAmount.ToString();
            EventThreePointsValueLabel.Text = CompetitionEvents[2].PointAmount.ToString();
            EventFourPointsValueLabel.Text = CompetitionEvents[3].PointAmount.ToString();
            EventFivePointsValueLabel.Text = CompetitionEvents[4].PointAmount.ToString();

            TeamOnePointsLabel.Text = "0";
            TeamTwoPointsLabel.Text = "0";
            TeamThreePointsLabel.Text = "0";
            TeamFourPointsLabel.Text = "0";

            TeamOnePointsPanel.BackColor = ColorTranslator.FromHtml(ZeroPercentColor);
            TeamTwoPointsPanel.BackColor = ColorTranslator.FromHtml(ZeroPercentColor);
            TeamThreePointsPanel.BackColor = ColorTranslator.FromHtml(ZeroPercentColor);
            TeamFourPointsPanel.BackColor = ColorTranslator.FromHtml(ZeroPercentColor);

            OverallPointsValueLabel.Text = "0";
            TotalPointsValueLabel.Text = $"{CompetitionEvents[0].PointAmount + CompetitionEvents[1].PointAmount + CompetitionEvents[2].PointAmount + CompetitionEvents[3].PointAmount + CompetitionEvents[4].PointAmount}";
            TotalPoints = CompetitionEvents[0].PointAmount + CompetitionEvents[1].PointAmount + CompetitionEvents[2].PointAmount + CompetitionEvents[3].PointAmount + CompetitionEvents[4].PointAmount;

            CurrentEvent.Index = 0;
            CurrentEvent.IsActive = false;
        }

        private void ExitLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DialogResult ConfirmExit;

            ConfirmExit = MessageBox.Show("Are you sure you want to exit?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (ConfirmExit == DialogResult.Yes)
            {
                if (Properties.Settings.Default.UserPassword == null || Properties.Settings.Default.UserPassword == "")
                {
                    Properties.Settings.Default.UserName = "";
                    Properties.Settings.Default.UserPassword = "";

                    Properties.Settings.Default.Save();

                    Application.Exit();
                }
                else
                {
                    Application.Exit();
                }
            }
        }

        private void LogoutLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DialogResult ConfirmLogout;

            ConfirmLogout = MessageBox.Show("Are you sure you want to logout?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (ConfirmLogout == DialogResult.Yes)
            {
                Properties.Settings.Default.UserName = "";
                Properties.Settings.Default.UserPassword = "";

                Properties.Settings.Default.Save();

                Application.Restart();
            }
        }

        private void EventOneCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            IsEnabled = !IsEnabled;

            if (IsResetting == true)
            {
                return;
            }
            switch (IsEnabled)
            {
                case true:
                    CurrentEvent.Index = 0;

                    TeamOnePlayerOneCheckBox.Enabled = true;
                    TeamOnePlayerOneCheckBox.Checked = false;
                    TeamOnePlayerTwoCheckBox.Enabled = true;
                    TeamOnePlayerTwoCheckBox.Checked = false;
                    TeamOnePlayerThreeCheckBox.Enabled = true;
                    TeamOnePlayerThreeCheckBox.Checked = false;
                    TeamOnePlayerFourCheckBox.Enabled = true;
                    TeamOnePlayerFourCheckBox.Checked = false;
                    TeamOnePlayerFiveCheckBox.Enabled = true;
                    TeamOnePlayerFiveCheckBox.Checked = false;

                    TeamTwoPlayerOneCheckBox.Enabled = true;
                    TeamTwoPlayerOneCheckBox.Checked = false;
                    TeamTwoPlayerTwoCheckBox.Enabled = true;
                    TeamTwoPlayerTwoCheckBox.Checked = false;
                    TeamTwoPlayerThreeCheckBox.Enabled = true;
                    TeamTwoPlayerThreeCheckBox.Checked = false;
                    TeamTwoPlayerFourCheckBox.Enabled = true;
                    TeamTwoPlayerFourCheckBox.Checked = false;
                    TeamTwoPlayerFiveCheckBox.Enabled = true;

                    TeamThreePlayerOneCheckBox.Enabled = true;
                    TeamThreePlayerOneCheckBox.Checked = false;
                    TeamThreePlayerTwoCheckBox.Enabled = true;
                    TeamThreePlayerTwoCheckBox.Checked = false;
                    TeamThreePlayerThreeCheckBox.Enabled = true;
                    TeamThreePlayerThreeCheckBox.Checked = false;
                    TeamThreePlayerFourCheckBox.Enabled = true;
                    TeamThreePlayerFourCheckBox.Checked = false;
                    TeamThreePlayerFiveCheckBox.Enabled = true;
                    TeamThreePlayerFiveCheckBox.Checked = false;

                    TeamFourPlayerOneCheckBox.Enabled = true;
                    TeamFourPlayerOneCheckBox.Checked = false;
                    TeamFourPlayerTwoCheckBox.Enabled = true;
                    TeamFourPlayerTwoCheckBox.Checked = false;
                    TeamFourPlayerThreeCheckBox.Enabled = true;
                    TeamFourPlayerThreeCheckBox.Checked = false;
                    TeamFourPlayerFourCheckBox.Enabled = true;
                    TeamFourPlayerFourCheckBox.Checked = false;
                    TeamFourPlayerFiveCheckBox.Enabled = true;
                    TeamFourPlayerFiveCheckBox.Checked = false;

                    EventTwoCheckBox.Enabled = false;
                    EventThreeCheckBox.Enabled = false;
                    EventFourCheckBox.Enabled = false;
                    EventFiveCheckBox.Enabled = false;
                    CurrentEvent.IsActive = true;
                    break;
                default:

                    CurrentEvent.IsActive = false;

                    TeamOnePlayerOneCheckBox.Enabled = false;
                    TeamOnePlayerOneCheckBox.Checked = false;
                    TeamOnePlayerTwoCheckBox.Enabled = false;
                    TeamOnePlayerTwoCheckBox.Checked = false;
                    TeamOnePlayerThreeCheckBox.Enabled = false;
                    TeamOnePlayerThreeCheckBox.Checked = false;
                    TeamOnePlayerFourCheckBox.Enabled = false;
                    TeamOnePlayerFourCheckBox.Checked = false;
                    TeamOnePlayerFiveCheckBox.Enabled = false;
                    TeamOnePlayerFiveCheckBox.Checked = false;

                    TeamTwoPlayerOneCheckBox.Enabled = false;
                    TeamTwoPlayerOneCheckBox.Checked = false;
                    TeamTwoPlayerTwoCheckBox.Enabled = false;
                    TeamTwoPlayerTwoCheckBox.Checked = false;
                    TeamTwoPlayerThreeCheckBox.Enabled = false;
                    TeamTwoPlayerThreeCheckBox.Checked = false;
                    TeamTwoPlayerFourCheckBox.Enabled = false;
                    TeamTwoPlayerFourCheckBox.Checked = false;
                    TeamTwoPlayerFiveCheckBox.Enabled = false;
                    TeamTwoPlayerFiveCheckBox.Checked = false;

                    TeamThreePlayerOneCheckBox.Enabled = false;
                    TeamThreePlayerOneCheckBox.Checked = false;
                    TeamThreePlayerTwoCheckBox.Enabled = false;
                    TeamThreePlayerTwoCheckBox.Checked = false;
                    TeamThreePlayerThreeCheckBox.Enabled = false;
                    TeamThreePlayerThreeCheckBox.Checked = false;
                    TeamThreePlayerFourCheckBox.Enabled = false;
                    TeamThreePlayerFourCheckBox.Checked = false;
                    TeamThreePlayerFiveCheckBox.Enabled = false;
                    TeamThreePlayerFiveCheckBox.Checked = false;

                    TeamFourPlayerOneCheckBox.Enabled = false;
                    TeamFourPlayerOneCheckBox.Checked = false;
                    TeamFourPlayerTwoCheckBox.Enabled = false;
                    TeamFourPlayerTwoCheckBox.Checked = false;
                    TeamFourPlayerThreeCheckBox.Enabled = false;
                    TeamFourPlayerThreeCheckBox.Checked = false;
                    TeamFourPlayerFourCheckBox.Enabled = false;
                    TeamFourPlayerFourCheckBox.Checked = false;
                    TeamFourPlayerFiveCheckBox.Enabled = false;
                    TeamFourPlayerFiveCheckBox.Checked = false;

                    EventTwoCheckBox.Enabled = true;
                    EventThreeCheckBox.Enabled = true;
                    EventFourCheckBox.Enabled = true;
                    EventFiveCheckBox.Enabled = true;
                    break;
            }

        }

        private void EventTwoCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            IsEnabled = !IsEnabled;

            if (IsResetting == true)
            {
                return;
            }
            switch (IsEnabled)
            {
                case true:
                    CurrentEvent.Index = 1;

                    TeamOnePlayerOneCheckBox.Enabled = true;
                    TeamOnePlayerOneCheckBox.Checked = false;
                    TeamOnePlayerTwoCheckBox.Enabled = true;
                    TeamOnePlayerTwoCheckBox.Checked = false;
                    TeamOnePlayerThreeCheckBox.Enabled = true;
                    TeamOnePlayerThreeCheckBox.Checked = false;
                    TeamOnePlayerFourCheckBox.Enabled = true;
                    TeamOnePlayerFourCheckBox.Checked = false;
                    TeamOnePlayerFiveCheckBox.Enabled = true;
                    TeamOnePlayerFiveCheckBox.Checked = false;

                    TeamTwoPlayerOneCheckBox.Enabled = true;
                    TeamTwoPlayerOneCheckBox.Checked = false;
                    TeamTwoPlayerTwoCheckBox.Enabled = true;
                    TeamTwoPlayerTwoCheckBox.Checked = false;
                    TeamTwoPlayerThreeCheckBox.Enabled = true;
                    TeamTwoPlayerThreeCheckBox.Checked = false;
                    TeamTwoPlayerFourCheckBox.Enabled = true;
                    TeamTwoPlayerFourCheckBox.Checked = false;
                    TeamTwoPlayerFiveCheckBox.Enabled = true;

                    TeamThreePlayerOneCheckBox.Enabled = true;
                    TeamThreePlayerOneCheckBox.Checked = false;
                    TeamThreePlayerTwoCheckBox.Enabled = true;
                    TeamThreePlayerTwoCheckBox.Checked = false;
                    TeamThreePlayerThreeCheckBox.Enabled = true;
                    TeamThreePlayerThreeCheckBox.Checked = false;
                    TeamThreePlayerFourCheckBox.Enabled = true;
                    TeamThreePlayerFourCheckBox.Checked = false;
                    TeamThreePlayerFiveCheckBox.Enabled = true;
                    TeamThreePlayerFiveCheckBox.Checked = false;

                    TeamFourPlayerOneCheckBox.Enabled = true;
                    TeamFourPlayerOneCheckBox.Checked = false;
                    TeamFourPlayerTwoCheckBox.Enabled = true;
                    TeamFourPlayerTwoCheckBox.Checked = false;
                    TeamFourPlayerThreeCheckBox.Enabled = true;
                    TeamFourPlayerThreeCheckBox.Checked = false;
                    TeamFourPlayerFourCheckBox.Enabled = true;
                    TeamFourPlayerFourCheckBox.Checked = false;
                    TeamFourPlayerFiveCheckBox.Enabled = true;
                    TeamFourPlayerFiveCheckBox.Checked = false;

                    EventOneCheckBox.Enabled = false;
                    EventThreeCheckBox.Enabled = false;
                    EventFourCheckBox.Enabled = false;
                    EventFiveCheckBox.Enabled = false;
                    CurrentEvent.IsActive = true;
                    break;
                default:
                    CurrentEvent.IsActive = false;

                    TeamOnePlayerOneCheckBox.Enabled = false;
                    TeamOnePlayerOneCheckBox.Checked = false;
                    TeamOnePlayerTwoCheckBox.Enabled = false;
                    TeamOnePlayerTwoCheckBox.Checked = false;
                    TeamOnePlayerThreeCheckBox.Enabled = false;
                    TeamOnePlayerThreeCheckBox.Checked = false;
                    TeamOnePlayerFourCheckBox.Enabled = false;
                    TeamOnePlayerFourCheckBox.Checked = false;
                    TeamOnePlayerFiveCheckBox.Enabled = false;
                    TeamOnePlayerFiveCheckBox.Checked = false;

                    TeamTwoPlayerOneCheckBox.Enabled = false;
                    TeamTwoPlayerOneCheckBox.Checked = false;
                    TeamTwoPlayerTwoCheckBox.Enabled = false;
                    TeamTwoPlayerTwoCheckBox.Checked = false;
                    TeamTwoPlayerThreeCheckBox.Enabled = false;
                    TeamTwoPlayerThreeCheckBox.Checked = false;
                    TeamTwoPlayerFourCheckBox.Enabled = false;
                    TeamTwoPlayerFourCheckBox.Checked = false;
                    TeamTwoPlayerFiveCheckBox.Enabled = false;
                    TeamTwoPlayerFiveCheckBox.Checked = false;

                    TeamThreePlayerOneCheckBox.Enabled = false;
                    TeamThreePlayerOneCheckBox.Checked = false;
                    TeamThreePlayerTwoCheckBox.Enabled = false;
                    TeamThreePlayerTwoCheckBox.Checked = false;
                    TeamThreePlayerThreeCheckBox.Enabled = false;
                    TeamThreePlayerThreeCheckBox.Checked = false;
                    TeamThreePlayerFourCheckBox.Enabled = false;
                    TeamThreePlayerFourCheckBox.Checked = false;
                    TeamThreePlayerFiveCheckBox.Enabled = false;
                    TeamThreePlayerFiveCheckBox.Checked = false;

                    TeamFourPlayerOneCheckBox.Enabled = false;
                    TeamFourPlayerOneCheckBox.Checked = false;
                    TeamFourPlayerTwoCheckBox.Enabled = false;
                    TeamFourPlayerTwoCheckBox.Checked = false;
                    TeamFourPlayerThreeCheckBox.Enabled = false;
                    TeamFourPlayerThreeCheckBox.Checked = false;
                    TeamFourPlayerFourCheckBox.Enabled = false;
                    TeamFourPlayerFourCheckBox.Checked = false;
                    TeamFourPlayerFiveCheckBox.Enabled = false;
                    TeamFourPlayerFiveCheckBox.Checked = false;

                    EventOneCheckBox.Enabled = true;
                    EventThreeCheckBox.Enabled = true;
                    EventFourCheckBox.Enabled = true;
                    EventFiveCheckBox.Enabled = true;

                    break;
            }

        }

        private void EventThreeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            IsEnabled = !IsEnabled;

            if (IsResetting == true)
            {
                return;
            }

            switch (IsEnabled)
            {
                case true:
                    CurrentEvent.Index = 2;

                    TeamOnePlayerOneCheckBox.Enabled = true;
                    TeamOnePlayerOneCheckBox.Checked = false;
                    TeamOnePlayerTwoCheckBox.Enabled = true;
                    TeamOnePlayerTwoCheckBox.Checked = false;
                    TeamOnePlayerThreeCheckBox.Enabled = true;
                    TeamOnePlayerThreeCheckBox.Checked = false;
                    TeamOnePlayerFourCheckBox.Enabled = true;
                    TeamOnePlayerFourCheckBox.Checked = false;
                    TeamOnePlayerFiveCheckBox.Enabled = true;
                    TeamOnePlayerFiveCheckBox.Checked = false;

                    TeamTwoPlayerOneCheckBox.Enabled = true;
                    TeamTwoPlayerOneCheckBox.Checked = false;
                    TeamTwoPlayerTwoCheckBox.Enabled = true;
                    TeamTwoPlayerTwoCheckBox.Checked = false;
                    TeamTwoPlayerThreeCheckBox.Enabled = true;
                    TeamTwoPlayerThreeCheckBox.Checked = false;
                    TeamTwoPlayerFourCheckBox.Enabled = true;
                    TeamTwoPlayerFourCheckBox.Checked = false;
                    TeamTwoPlayerFiveCheckBox.Enabled = true;

                    TeamThreePlayerOneCheckBox.Enabled = true;
                    TeamThreePlayerOneCheckBox.Checked = false;
                    TeamThreePlayerTwoCheckBox.Enabled = true;
                    TeamThreePlayerTwoCheckBox.Checked = false;
                    TeamThreePlayerThreeCheckBox.Enabled = true;
                    TeamThreePlayerThreeCheckBox.Checked = false;
                    TeamThreePlayerFourCheckBox.Enabled = true;
                    TeamThreePlayerFourCheckBox.Checked = false;
                    TeamThreePlayerFiveCheckBox.Enabled = true;
                    TeamThreePlayerFiveCheckBox.Checked = false;

                    TeamFourPlayerOneCheckBox.Enabled = true;
                    TeamFourPlayerOneCheckBox.Checked = false;
                    TeamFourPlayerTwoCheckBox.Enabled = true;
                    TeamFourPlayerTwoCheckBox.Checked = false;
                    TeamFourPlayerThreeCheckBox.Enabled = true;
                    TeamFourPlayerThreeCheckBox.Checked = false;
                    TeamFourPlayerFourCheckBox.Enabled = true;
                    TeamFourPlayerFourCheckBox.Checked = false;
                    TeamFourPlayerFiveCheckBox.Enabled = true;
                    TeamFourPlayerFiveCheckBox.Checked = false;

                    EventTwoCheckBox.Enabled = false;
                    EventOneCheckBox.Enabled = false;
                    EventFourCheckBox.Enabled = false;
                    EventFiveCheckBox.Enabled = false;
                    CurrentEvent.IsActive = true;
                    break;
                default:
                    CurrentEvent.IsActive = false;

                    TeamOnePlayerOneCheckBox.Enabled = false;
                    TeamOnePlayerOneCheckBox.Checked = false;
                    TeamOnePlayerTwoCheckBox.Enabled = false;
                    TeamOnePlayerTwoCheckBox.Checked = false;
                    TeamOnePlayerThreeCheckBox.Enabled = false;
                    TeamOnePlayerThreeCheckBox.Checked = false;
                    TeamOnePlayerFourCheckBox.Enabled = false;
                    TeamOnePlayerFourCheckBox.Checked = false;
                    TeamOnePlayerFiveCheckBox.Enabled = false;
                    TeamOnePlayerFiveCheckBox.Checked = false;

                    TeamTwoPlayerOneCheckBox.Enabled = false;
                    TeamTwoPlayerOneCheckBox.Checked = false;
                    TeamTwoPlayerTwoCheckBox.Enabled = false;
                    TeamTwoPlayerTwoCheckBox.Checked = false;
                    TeamTwoPlayerThreeCheckBox.Enabled = false;
                    TeamTwoPlayerThreeCheckBox.Checked = false;
                    TeamTwoPlayerFourCheckBox.Enabled = false;
                    TeamTwoPlayerFourCheckBox.Checked = false;
                    TeamTwoPlayerFiveCheckBox.Enabled = false;
                    TeamTwoPlayerFiveCheckBox.Checked = false;

                    TeamThreePlayerOneCheckBox.Enabled = false;
                    TeamThreePlayerOneCheckBox.Checked = false;
                    TeamThreePlayerTwoCheckBox.Enabled = false;
                    TeamThreePlayerTwoCheckBox.Checked = false;
                    TeamThreePlayerThreeCheckBox.Enabled = false;
                    TeamThreePlayerThreeCheckBox.Checked = false;
                    TeamThreePlayerFourCheckBox.Enabled = false;
                    TeamThreePlayerFourCheckBox.Checked = false;
                    TeamThreePlayerFiveCheckBox.Enabled = false;
                    TeamThreePlayerFiveCheckBox.Checked = false;

                    TeamFourPlayerOneCheckBox.Enabled = false;
                    TeamFourPlayerOneCheckBox.Checked = false;
                    TeamFourPlayerTwoCheckBox.Enabled = false;
                    TeamFourPlayerTwoCheckBox.Checked = false;
                    TeamFourPlayerThreeCheckBox.Enabled = false;
                    TeamFourPlayerThreeCheckBox.Checked = false;
                    TeamFourPlayerFourCheckBox.Enabled = false;
                    TeamFourPlayerFourCheckBox.Checked = false;
                    TeamFourPlayerFiveCheckBox.Enabled = false;
                    TeamFourPlayerFiveCheckBox.Checked = false;

                    EventTwoCheckBox.Enabled = true;
                    EventOneCheckBox.Enabled = true;
                    EventFourCheckBox.Enabled = true;
                    EventFiveCheckBox.Enabled = true;

                    break;
            }

        }

        private void EventFourCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            IsEnabled = !IsEnabled;

            if (IsResetting == true)
            {
                return;
            }

            switch (IsEnabled)
            {
                case true:
                    CurrentEvent.Index = 3;

                    TeamOnePlayerOneCheckBox.Enabled = true;
                    TeamOnePlayerOneCheckBox.Checked = false;
                    TeamOnePlayerTwoCheckBox.Enabled = true;
                    TeamOnePlayerTwoCheckBox.Checked = false;
                    TeamOnePlayerThreeCheckBox.Enabled = true;
                    TeamOnePlayerThreeCheckBox.Checked = false;
                    TeamOnePlayerFourCheckBox.Enabled = true;
                    TeamOnePlayerFourCheckBox.Checked = false;
                    TeamOnePlayerFiveCheckBox.Enabled = true;
                    TeamOnePlayerFiveCheckBox.Checked = false;

                    TeamTwoPlayerOneCheckBox.Enabled = true;
                    TeamTwoPlayerOneCheckBox.Checked = false;
                    TeamTwoPlayerTwoCheckBox.Enabled = true;
                    TeamTwoPlayerTwoCheckBox.Checked = false;
                    TeamTwoPlayerThreeCheckBox.Enabled = true;
                    TeamTwoPlayerThreeCheckBox.Checked = false;
                    TeamTwoPlayerFourCheckBox.Enabled = true;
                    TeamTwoPlayerFourCheckBox.Checked = false;
                    TeamTwoPlayerFiveCheckBox.Enabled = true;

                    TeamThreePlayerOneCheckBox.Enabled = true;
                    TeamThreePlayerOneCheckBox.Checked = false;
                    TeamThreePlayerTwoCheckBox.Enabled = true;
                    TeamThreePlayerTwoCheckBox.Checked = false;
                    TeamThreePlayerThreeCheckBox.Enabled = true;
                    TeamThreePlayerThreeCheckBox.Checked = false;
                    TeamThreePlayerFourCheckBox.Enabled = true;
                    TeamThreePlayerFourCheckBox.Checked = false;
                    TeamThreePlayerFiveCheckBox.Enabled = true;
                    TeamThreePlayerFiveCheckBox.Checked = false;

                    TeamFourPlayerOneCheckBox.Enabled = true;
                    TeamFourPlayerOneCheckBox.Checked = false;
                    TeamFourPlayerTwoCheckBox.Enabled = true;
                    TeamFourPlayerTwoCheckBox.Checked = false;
                    TeamFourPlayerThreeCheckBox.Enabled = true;
                    TeamFourPlayerThreeCheckBox.Checked = false;
                    TeamFourPlayerFourCheckBox.Enabled = true;
                    TeamFourPlayerFourCheckBox.Checked = false;
                    TeamFourPlayerFiveCheckBox.Enabled = true;
                    TeamFourPlayerFiveCheckBox.Checked = false;

                    EventTwoCheckBox.Enabled = false;
                    EventThreeCheckBox.Enabled = false;
                    EventOneCheckBox.Enabled = false;
                    EventFiveCheckBox.Enabled = false;
                    CurrentEvent.IsActive = true;
                    break;
                default:
                    CurrentEvent.IsActive = false;

                    TeamOnePlayerOneCheckBox.Enabled = false;
                    TeamOnePlayerOneCheckBox.Checked = false;
                    TeamOnePlayerTwoCheckBox.Enabled = false;
                    TeamOnePlayerTwoCheckBox.Checked = false;
                    TeamTwoPlayerTwoCheckBox.Checked = false;
                    TeamTwoPlayerThreeCheckBox.Enabled = false;
                    TeamTwoPlayerThreeCheckBox.Checked = false;
                    TeamTwoPlayerFourCheckBox.Enabled = false;
                    TeamTwoPlayerFourCheckBox.Checked = false;
                    TeamTwoPlayerFiveCheckBox.Enabled = false;
                    TeamTwoPlayerFiveCheckBox.Checked = false;

                    TeamThreePlayerOneCheckBox.Enabled = false;
                    TeamThreePlayerOneCheckBox.Checked = false;
                    TeamThreePlayerTwoCheckBox.Enabled = false;
                    TeamThreePlayerTwoCheckBox.Checked = false;
                    TeamThreePlayerThreeCheckBox.Enabled = false;
                    TeamThreePlayerThreeCheckBox.Checked = false;
                    TeamThreePlayerFourCheckBox.Enabled = false;
                    TeamThreePlayerFourCheckBox.Checked = false;
                    TeamThreePlayerFiveCheckBox.Enabled = false;
                    TeamThreePlayerFiveCheckBox.Checked = false;

                    TeamFourPlayerOneCheckBox.Enabled = false;
                    TeamFourPlayerOneCheckBox.Checked = false;
                    TeamFourPlayerTwoCheckBox.Enabled = false;
                    TeamFourPlayerTwoCheckBox.Checked = false;
                    TeamFourPlayerThreeCheckBox.Enabled = false;
                    TeamFourPlayerThreeCheckBox.Checked = false;
                    TeamFourPlayerFourCheckBox.Enabled = false;
                    TeamFourPlayerFourCheckBox.Checked = false;
                    TeamFourPlayerFiveCheckBox.Enabled = false;
                    TeamFourPlayerFiveCheckBox.Checked = false;

                    EventTwoCheckBox.Enabled = true;
                    EventThreeCheckBox.Enabled = true;
                    TeamOnePlayerThreeCheckBox.Enabled = false;
                    TeamOnePlayerThreeCheckBox.Checked = false;
                    TeamOnePlayerFourCheckBox.Enabled = false;
                    TeamOnePlayerFourCheckBox.Checked = false;
                    TeamOnePlayerFiveCheckBox.Enabled = false;
                    TeamOnePlayerFiveCheckBox.Checked = false;

                    TeamTwoPlayerOneCheckBox.Enabled = false;
                    TeamTwoPlayerOneCheckBox.Checked = false;
                    TeamTwoPlayerTwoCheckBox.Enabled = false;
                    EventOneCheckBox.Enabled = true;
                    EventFiveCheckBox.Enabled = true;

                    break;
            }

        }

        private void EventFiveCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            IsEnabled = !IsEnabled;

            if (IsResetting == true)
            {
                return;
            }

            switch (IsEnabled)
            {
                case true:
                    CurrentEvent.Index = 4;

                    TeamOnePlayerOneCheckBox.Enabled = true;
                    TeamOnePlayerOneCheckBox.Checked = false;
                    TeamOnePlayerTwoCheckBox.Enabled = true;
                    TeamOnePlayerTwoCheckBox.Checked = false;
                    TeamOnePlayerThreeCheckBox.Enabled = true;
                    TeamOnePlayerThreeCheckBox.Checked = false;
                    TeamOnePlayerFourCheckBox.Enabled = true;
                    TeamOnePlayerFourCheckBox.Checked = false;
                    TeamOnePlayerFiveCheckBox.Enabled = true;
                    TeamOnePlayerFiveCheckBox.Checked = false;

                    TeamTwoPlayerOneCheckBox.Enabled = true;
                    TeamTwoPlayerOneCheckBox.Checked = false;
                    TeamTwoPlayerTwoCheckBox.Enabled = true;
                    TeamTwoPlayerTwoCheckBox.Checked = false;
                    TeamTwoPlayerThreeCheckBox.Enabled = true;
                    TeamTwoPlayerThreeCheckBox.Checked = false;
                    TeamTwoPlayerFourCheckBox.Enabled = true;
                    TeamTwoPlayerFourCheckBox.Checked = false;
                    TeamTwoPlayerFiveCheckBox.Enabled = true;

                    TeamThreePlayerOneCheckBox.Enabled = true;
                    TeamThreePlayerOneCheckBox.Checked = false;
                    TeamThreePlayerTwoCheckBox.Enabled = true;
                    TeamThreePlayerTwoCheckBox.Checked = false;
                    TeamThreePlayerThreeCheckBox.Enabled = true;
                    TeamThreePlayerThreeCheckBox.Checked = false;
                    TeamThreePlayerFourCheckBox.Enabled = true;
                    TeamThreePlayerFourCheckBox.Checked = false;
                    TeamThreePlayerFiveCheckBox.Enabled = true;
                    TeamThreePlayerFiveCheckBox.Checked = false;

                    TeamFourPlayerOneCheckBox.Enabled = true;
                    TeamFourPlayerOneCheckBox.Checked = false;
                    TeamFourPlayerTwoCheckBox.Enabled = true;
                    TeamFourPlayerTwoCheckBox.Checked = false;
                    TeamFourPlayerThreeCheckBox.Enabled = true;
                    TeamFourPlayerThreeCheckBox.Checked = false;
                    TeamFourPlayerFourCheckBox.Enabled = true;
                    TeamFourPlayerFourCheckBox.Checked = false;
                    TeamFourPlayerFiveCheckBox.Enabled = true;
                    TeamFourPlayerFiveCheckBox.Checked = false;

                    EventTwoCheckBox.Enabled = false;
                    EventThreeCheckBox.Enabled = false;
                    EventFourCheckBox.Enabled = false;
                    EventOneCheckBox.Enabled = false;
                    CurrentEvent.IsActive = true;
                    break;
                default:
                    CurrentEvent.IsActive = false;

                    TeamOnePlayerOneCheckBox.Enabled = false;
                    TeamOnePlayerOneCheckBox.Checked = false;
                    TeamOnePlayerTwoCheckBox.Enabled = false;
                    TeamOnePlayerTwoCheckBox.Checked = false;
                    TeamOnePlayerThreeCheckBox.Enabled = false;
                    TeamOnePlayerThreeCheckBox.Checked = false;
                    TeamOnePlayerFourCheckBox.Enabled = false;
                    TeamOnePlayerFourCheckBox.Checked = false;
                    TeamOnePlayerFiveCheckBox.Enabled = false;
                    TeamOnePlayerFiveCheckBox.Checked = false;

                    TeamTwoPlayerOneCheckBox.Enabled = false;
                    TeamTwoPlayerOneCheckBox.Checked = false;
                    TeamTwoPlayerTwoCheckBox.Enabled = false;
                    TeamTwoPlayerTwoCheckBox.Checked = false;
                    TeamTwoPlayerThreeCheckBox.Enabled = false;
                    TeamTwoPlayerThreeCheckBox.Checked = false;
                    TeamTwoPlayerFourCheckBox.Enabled = false;
                    TeamTwoPlayerFourCheckBox.Checked = false;
                    TeamTwoPlayerFiveCheckBox.Enabled = false;
                    TeamTwoPlayerFiveCheckBox.Checked = false;

                    TeamThreePlayerOneCheckBox.Enabled = false;
                    TeamThreePlayerOneCheckBox.Checked = false;
                    TeamThreePlayerTwoCheckBox.Enabled = false;
                    TeamThreePlayerTwoCheckBox.Checked = false;
                    TeamThreePlayerThreeCheckBox.Enabled = false;
                    TeamThreePlayerThreeCheckBox.Checked = false;
                    TeamThreePlayerFourCheckBox.Enabled = false;
                    TeamThreePlayerFourCheckBox.Checked = false;
                    TeamThreePlayerFiveCheckBox.Enabled = false;
                    TeamThreePlayerFiveCheckBox.Checked = false;

                    TeamFourPlayerOneCheckBox.Enabled = false;
                    TeamFourPlayerOneCheckBox.Checked = false;
                    TeamFourPlayerTwoCheckBox.Enabled = false;
                    TeamFourPlayerTwoCheckBox.Checked = false;
                    TeamFourPlayerThreeCheckBox.Enabled = false;
                    TeamFourPlayerThreeCheckBox.Checked = false;
                    TeamFourPlayerFourCheckBox.Enabled = false;
                    TeamFourPlayerFourCheckBox.Checked = false;
                    TeamFourPlayerFiveCheckBox.Enabled = false;
                    TeamFourPlayerFiveCheckBox.Checked = false;

                    EventTwoCheckBox.Enabled = true;
                    EventThreeCheckBox.Enabled = true;
                    EventFourCheckBox.Enabled = true;
                    EventOneCheckBox.Enabled = true;

                    break;
            }

        }
        public void TeamOnePlayerOneCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (IsEnabled == true)
            {
                switch (TeamOnePlayerOneCheckBox.Checked && CurrentEvent.IsActive)
                {
                    case true:
                        TeamOnePointsLabel.Text = (int.Parse(TeamOnePointsLabel.Text) + CompetitionEvents[CurrentEvent.Index].PointAmount).ToString();
                        break;
                    case false:
                        TeamOnePointsLabel.Text = (int.Parse(TeamOnePointsLabel.Text) - CompetitionEvents[CurrentEvent.Index].PointAmount).ToString();
                        break;
                }
            }
        }

        public void TeamOnePlayerTwoCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (IsEnabled == true)
            {
                switch (TeamOnePlayerTwoCheckBox.Checked && CurrentEvent.IsActive)
                {
                    case true:
                        TeamOnePointsLabel.Text = (int.Parse(TeamOnePointsLabel.Text) + CompetitionEvents[CurrentEvent.Index].PointAmount).ToString();
                        break;
                    case false:
                        TeamOnePointsLabel.Text = (int.Parse(TeamOnePointsLabel.Text) - CompetitionEvents[CurrentEvent.Index].PointAmount).ToString();
                        break;
                }
            }
        }

        public void TeamOnePlayerThreeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (IsEnabled == true)
            {
                switch (TeamOnePlayerThreeCheckBox.Checked && CurrentEvent.IsActive)
                {
                    case true:
                        TeamOnePointsLabel.Text = (int.Parse(TeamOnePointsLabel.Text) + CompetitionEvents[CurrentEvent.Index].PointAmount).ToString();
                        break;
                    case false:
                        TeamOnePointsLabel.Text = (int.Parse(TeamOnePointsLabel.Text) - CompetitionEvents[CurrentEvent.Index].PointAmount).ToString();
                        break;
                }
            }
        }

        public void TeamOnePlayerFourCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (IsEnabled == true)
            {
                switch (TeamOnePlayerFourCheckBox.Checked && CurrentEvent.IsActive)
                {
                    case true:
                        TeamOnePointsLabel.Text = (int.Parse(TeamOnePointsLabel.Text) + CompetitionEvents[CurrentEvent.Index].PointAmount).ToString();
                        break;
                    case false:
                        TeamOnePointsLabel.Text = (int.Parse(TeamOnePointsLabel.Text) - CompetitionEvents[CurrentEvent.Index].PointAmount).ToString();
                        break;
                }
            }
        }

        public void TeamOnePlayerFiveCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (IsEnabled == true)
            {
                switch (TeamOnePlayerFiveCheckBox.Checked && CurrentEvent.IsActive)
                {
                    case true:
                        TeamOnePointsLabel.Text = (int.Parse(TeamOnePointsLabel.Text) + CompetitionEvents[CurrentEvent.Index].PointAmount).ToString();
                        break;
                    case false:
                        TeamOnePointsLabel.Text = (int.Parse(TeamOnePointsLabel.Text) - CompetitionEvents[CurrentEvent.Index].PointAmount).ToString();
                        break;
                }
            }
        }

        public void TeamTwoPlayerOneCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (IsEnabled == true)
            {
                switch (TeamTwoPlayerOneCheckBox.Checked && CurrentEvent.IsActive)
                {
                    case true:
                        TeamTwoPointsLabel.Text = (int.Parse(TeamTwoPointsLabel.Text) + CompetitionEvents[CurrentEvent.Index].PointAmount).ToString();
                        break;
                    case false:
                        TeamTwoPointsLabel.Text = (int.Parse(TeamTwoPointsLabel.Text) - CompetitionEvents[CurrentEvent.Index].PointAmount).ToString();
                        break;
                }
            }
        }

        public void TeamTwoPlayerTwoCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (IsEnabled == true)
            {
                switch (TeamTwoPlayerTwoCheckBox.Checked && CurrentEvent.IsActive)
                {
                    case true:
                        TeamTwoPointsLabel.Text = (int.Parse(TeamTwoPointsLabel.Text) + CompetitionEvents[CurrentEvent.Index].PointAmount).ToString();
                        break;
                    case false:
                        TeamTwoPointsLabel.Text = (int.Parse(TeamTwoPointsLabel.Text) - CompetitionEvents[CurrentEvent.Index].PointAmount).ToString();
                        break;
                }
            }
        }

        public void TeamTwoPlayerThreeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (IsEnabled == true)
            {
                switch (TeamTwoPlayerThreeCheckBox.Checked && CurrentEvent.IsActive)
                {
                    case true:
                        TeamTwoPointsLabel.Text = (int.Parse(TeamTwoPointsLabel.Text) + CompetitionEvents[CurrentEvent.Index].PointAmount).ToString();
                        break;
                    case false:
                        TeamTwoPointsLabel.Text = (int.Parse(TeamTwoPointsLabel.Text) - CompetitionEvents[CurrentEvent.Index].PointAmount).ToString();
                        break;
                }
            }
        }

        public void TeamTwoPlayerFourCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (IsEnabled == true)
            {
                switch (TeamTwoPlayerFourCheckBox.Checked && CurrentEvent.IsActive)
                {
                    case true:
                        TeamTwoPointsLabel.Text = (int.Parse(TeamTwoPointsLabel.Text) + CompetitionEvents[CurrentEvent.Index].PointAmount).ToString();
                        break;
                    case false:
                        TeamTwoPointsLabel.Text = (int.Parse(TeamTwoPointsLabel.Text) - CompetitionEvents[CurrentEvent.Index].PointAmount).ToString();
                        break;
                }
            }
        }

        public void TeamTwoPlayerFiveCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (IsEnabled == true)
            {
                switch (TeamTwoPlayerFiveCheckBox.Checked && CurrentEvent.IsActive)
                {
                    case true:
                        TeamTwoPointsLabel.Text = (int.Parse(TeamTwoPointsLabel.Text) + CompetitionEvents[CurrentEvent.Index].PointAmount).ToString();
                        break;
                    case false:
                        TeamTwoPointsLabel.Text = (int.Parse(TeamTwoPointsLabel.Text) - CompetitionEvents[CurrentEvent.Index].PointAmount).ToString();
                        break;
                }
            }
        }

        public void TeamThreePlayerOneCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (IsEnabled == true)
            {
                switch (TeamThreePlayerOneCheckBox.Checked && CurrentEvent.IsActive)
                {
                    case true:
                        TeamThreePointsLabel.Text = (int.Parse(TeamThreePointsLabel.Text) + CompetitionEvents[CurrentEvent.Index].PointAmount).ToString();
                        break;
                    case false:
                        TeamThreePointsLabel.Text = (int.Parse(TeamThreePointsLabel.Text) - CompetitionEvents[CurrentEvent.Index].PointAmount).ToString();
                        break;
                }
            }
        }

        public void TeamThreePlayerTwoCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (IsEnabled == true)
            {
                switch (TeamThreePlayerTwoCheckBox.Checked && CurrentEvent.IsActive)
                {
                    case true:
                        TeamThreePointsLabel.Text = (int.Parse(TeamThreePointsLabel.Text) + CompetitionEvents[CurrentEvent.Index].PointAmount).ToString();
                        break;
                    case false:
                        TeamThreePointsLabel.Text = (int.Parse(TeamThreePointsLabel.Text) - CompetitionEvents[CurrentEvent.Index].PointAmount).ToString();
                        break;
                }
            }
        }

        public void TeamThreePlayerThreeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (IsEnabled == true)
            {
                switch (TeamThreePlayerThreeCheckBox.Checked && CurrentEvent.IsActive)
                {
                    case true:
                        TeamThreePointsLabel.Text = (int.Parse(TeamThreePointsLabel.Text) + CompetitionEvents[CurrentEvent.Index].PointAmount).ToString();
                        break;
                    case false:
                        TeamThreePointsLabel.Text = (int.Parse(TeamThreePointsLabel.Text) - CompetitionEvents[CurrentEvent.Index].PointAmount).ToString();
                        break;
                }
            }
        }

        public void TeamThreePlayerFourCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (IsEnabled == true)
            {
                switch (TeamThreePlayerFourCheckBox.Checked && CurrentEvent.IsActive)
                {
                    case true:
                        TeamThreePointsLabel.Text = (int.Parse(TeamThreePointsLabel.Text) + CompetitionEvents[CurrentEvent.Index].PointAmount).ToString();
                        break;
                    case false:
                        TeamThreePointsLabel.Text = (int.Parse(TeamThreePointsLabel.Text) - CompetitionEvents[CurrentEvent.Index].PointAmount).ToString();
                        break;
                }
            }
        }

        public void TeamThreePlayerFiveCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (IsEnabled == true)
            {
                switch (TeamThreePlayerFiveCheckBox.Checked && CurrentEvent.IsActive)
                {
                    case true:
                        TeamThreePointsLabel.Text = (int.Parse(TeamThreePointsLabel.Text) + CompetitionEvents[CurrentEvent.Index].PointAmount).ToString();
                        break;
                    case false:
                        TeamThreePointsLabel.Text = (int.Parse(TeamThreePointsLabel.Text) - CompetitionEvents[CurrentEvent.Index].PointAmount).ToString();
                        break;
                }
            }
        }

        public void TeamFourPlayerOneCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (IsEnabled == true)
            {
                switch (TeamFourPlayerOneCheckBox.Checked && CurrentEvent.IsActive)
                {
                    case true:
                        TeamFourPointsLabel.Text = (int.Parse(TeamFourPointsLabel.Text) + CompetitionEvents[CurrentEvent.Index].PointAmount).ToString();
                        break;
                    case false:
                        TeamFourPointsLabel.Text = (int.Parse(TeamFourPointsLabel.Text) - CompetitionEvents[CurrentEvent.Index].PointAmount).ToString();
                        break;
                }
            }
        }

        public void TeamFourPlayerTwoCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (IsEnabled == true)
            {
                switch (TeamFourPlayerTwoCheckBox.Checked && CurrentEvent.IsActive)
                {
                    case true:
                        TeamFourPointsLabel.Text = (int.Parse(TeamFourPointsLabel.Text) + CompetitionEvents[CurrentEvent.Index].PointAmount).ToString();
                        break;
                    case false:
                        TeamFourPointsLabel.Text = (int.Parse(TeamFourPointsLabel.Text) - CompetitionEvents[CurrentEvent.Index].PointAmount).ToString();
                        break;
                }
            }
        }

        public void TeamFourPlayerThreeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (IsEnabled == true)
            {
                switch (TeamFourPlayerThreeCheckBox.Checked && CurrentEvent.IsActive)
                {
                    case true:
                        TeamFourPointsLabel.Text = (int.Parse(TeamFourPointsLabel.Text) + CompetitionEvents[CurrentEvent.Index].PointAmount).ToString();
                        break;
                    case false:
                        TeamFourPointsLabel.Text = (int.Parse(TeamFourPointsLabel.Text) - CompetitionEvents[CurrentEvent.Index].PointAmount).ToString();
                        break;
                }
            }
        }

        public void TeamFourPlayerFourCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (IsEnabled == true)
            {
                switch (TeamFourPlayerFourCheckBox.Checked && CurrentEvent.IsActive)
                {
                    case true:
                        TeamFourPointsLabel.Text = (int.Parse(TeamFourPointsLabel.Text) + CompetitionEvents[CurrentEvent.Index].PointAmount).ToString();
                        break;
                    case false:
                        TeamFourPointsLabel.Text = (int.Parse(TeamFourPointsLabel.Text) - CompetitionEvents[CurrentEvent.Index].PointAmount).ToString();
                        break;
                }
            }
        }

        public void TeamFourPlayerFiveCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (IsEnabled == true)
            {
                switch (TeamFourPlayerFiveCheckBox.Checked && CurrentEvent.IsActive)
                {
                    case true:
                        TeamFourPointsLabel.Text = (int.Parse(TeamFourPointsLabel.Text) + CompetitionEvents[CurrentEvent.Index].PointAmount).ToString();
                        break;
                    case false:
                        TeamFourPointsLabel.Text = (int.Parse(TeamFourPointsLabel.Text) - CompetitionEvents[CurrentEvent.Index].PointAmount).ToString();
                        break;
                }
            }
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            IsEnabled = false;
            IsResetting = true;

            TeamFourPointsLabel.Text = "0";
            TeamThreePointsLabel.Text = "0";
            TeamTwoPointsLabel.Text = "0";
            TeamOnePointsLabel.Text = "0";

            OverallPointsValueLabel.Text = "0";

            CurrentEvent.IsActive = false;

            TeamOnePlayerOneCheckBox.Enabled = false;
            TeamOnePlayerOneCheckBox.Checked = false;
            TeamOnePlayerTwoCheckBox.Enabled = false;
            TeamOnePlayerTwoCheckBox.Checked = false;
            TeamOnePlayerThreeCheckBox.Enabled = false;
            TeamOnePlayerThreeCheckBox.Checked = false;
            TeamOnePlayerFourCheckBox.Enabled = false;
            TeamOnePlayerFourCheckBox.Checked = false;
            TeamOnePlayerFiveCheckBox.Enabled = false;
            TeamOnePlayerFiveCheckBox.Checked = false;

            TeamTwoPlayerOneCheckBox.Enabled = false;
            TeamTwoPlayerOneCheckBox.Checked = false;
            TeamTwoPlayerTwoCheckBox.Enabled = false;
            TeamTwoPlayerTwoCheckBox.Checked = false;
            TeamTwoPlayerThreeCheckBox.Enabled = false;
            TeamTwoPlayerThreeCheckBox.Checked = false;
            TeamTwoPlayerFourCheckBox.Enabled = false;
            TeamTwoPlayerFourCheckBox.Checked = false;
            TeamTwoPlayerFiveCheckBox.Enabled = false;
            TeamTwoPlayerFiveCheckBox.Checked = false;

            TeamThreePlayerOneCheckBox.Enabled = false;
            TeamThreePlayerOneCheckBox.Checked = false;
            TeamThreePlayerTwoCheckBox.Enabled = false;
            TeamThreePlayerTwoCheckBox.Checked = false;
            TeamThreePlayerThreeCheckBox.Enabled = false;
            TeamThreePlayerThreeCheckBox.Checked = false;
            TeamThreePlayerFourCheckBox.Enabled = false;
            TeamThreePlayerFourCheckBox.Checked = false;
            TeamThreePlayerFiveCheckBox.Enabled = false;
            TeamThreePlayerFiveCheckBox.Checked = false;

            TeamFourPlayerOneCheckBox.Enabled = false;
            TeamFourPlayerOneCheckBox.Checked = false;
            TeamFourPlayerTwoCheckBox.Enabled = false;
            TeamFourPlayerTwoCheckBox.Checked = false;
            TeamFourPlayerThreeCheckBox.Enabled = false;
            TeamFourPlayerThreeCheckBox.Checked = false;
            TeamFourPlayerFourCheckBox.Enabled = false;
            TeamFourPlayerFourCheckBox.Checked = false;
            TeamFourPlayerFiveCheckBox.Enabled = false;
            TeamFourPlayerFiveCheckBox.Checked = false;

            EventOneCheckBox.Enabled = true;
            EventTwoCheckBox.Enabled = true;
            EventThreeCheckBox.Enabled = true;
            EventFourCheckBox.Enabled = true;
            EventOneCheckBox.Enabled = true;

            EventOneCheckBox.Checked = false;
            EventTwoCheckBox.Checked = false;
            EventThreeCheckBox.Checked = false;
            EventFourCheckBox.Checked = false;
            EventFiveCheckBox.Checked = false;

            IsResetting = false;
        }

        private void OverallPointsButton_Click(object sender, EventArgs e)
        {
            OverallPointsValueLabel.Text = $"{int.Parse(TeamOnePointsLabel.Text) + int.Parse(TeamTwoPointsLabel.Text) + int.Parse(TeamThreePointsLabel.Text) + int.Parse(TeamFourPointsLabel.Text)}";
        }

        private void TeamOnePointsLabel_TextChanged(object sender, EventArgs e)
        {
            if (int.Parse(TeamOnePointsLabel.Text) < TotalPoints / 25)
            {
                TeamOnePointsPanel.BackColor = ColorTranslator.FromHtml(ZeroPercentColor);
            }
            if (int.Parse(TeamTwoPointsLabel.Text) > TotalPoints / 25 && int.Parse(TeamOnePointsLabel.Text) < TotalPoints / 50)
            {
                TeamOnePointsPanel.BackColor = ColorTranslator.FromHtml(TwentyFivePercentColor);
            }
            if (int.Parse(TeamOnePointsLabel.Text) > TotalPoints / 50 && int.Parse(TeamOnePointsLabel.Text) < TotalPoints / 75)
            {
                TeamOnePointsPanel.BackColor = ColorTranslator.FromHtml(FiftyPercentColor);
            }
            if (int.Parse(TeamOnePointsLabel.Text) > TotalPoints / 75 && int.Parse(TeamOnePointsLabel.Text) < TotalPoints / 90)
            {
                TeamOnePointsPanel.BackColor = ColorTranslator.FromHtml(SeventyFivePercentColor);
            }
            if (int.Parse(TeamOnePointsLabel.Text) > TotalPoints / 90 && int.Parse(TeamOnePointsLabel.Text) < TotalPoints)
            {
                TeamOnePointsPanel.BackColor = ColorTranslator.FromHtml(NightyPercentColor);
            }
            if (int.Parse(TeamOnePointsLabel.Text) == TotalPoints || int.Parse(TeamOnePointsLabel.Text) > TotalPoints)
            {
                TeamOnePointsPanel.BackColor = ColorTranslator.FromHtml(OneHundredPercentColor);
            }
        }

        private void TeamTwoPointsLabel_TextChanged(object sender, EventArgs e)
        {
            if (int.Parse(TeamTwoPointsLabel.Text) < TotalPoints / 25)
            {
                TeamTwoPointsPanel.BackColor = ColorTranslator.FromHtml(ZeroPercentColor);
            }
            if (int.Parse(TeamTwoPointsLabel.Text) > TotalPoints / 25 && int.Parse(TeamTwoPointsLabel.Text) < TotalPoints / 50)
            {
                TeamTwoPointsPanel.BackColor = ColorTranslator.FromHtml(TwentyFivePercentColor);
            }
            if (int.Parse(TeamTwoPointsLabel.Text) > TotalPoints / 50 && int.Parse(TeamTwoPointsLabel.Text) < TotalPoints / 75)
            {
                TeamTwoPointsPanel.BackColor = ColorTranslator.FromHtml(FiftyPercentColor);
            }
            if (int.Parse(TeamTwoPointsLabel.Text) > TotalPoints / 75 && int.Parse(TeamTwoPointsLabel.Text) < TotalPoints / 90)
            {
                TeamTwoPointsPanel.BackColor = ColorTranslator.FromHtml(SeventyFivePercentColor);
            }
            if (int.Parse(TeamTwoPointsLabel.Text) > TotalPoints / 90 && int.Parse(TeamTwoPointsLabel.Text) < TotalPoints)
            {
                TeamTwoPointsPanel.BackColor = ColorTranslator.FromHtml(NightyPercentColor);
            }
            if (int.Parse(TeamTwoPointsLabel.Text) == TotalPoints || int.Parse(TeamTwoPointsLabel.Text) > TotalPoints)
            {
                TeamTwoPointsPanel.BackColor = ColorTranslator.FromHtml(OneHundredPercentColor);
            }
        }

        private void TeamThreePointsLabel_TextChanged(object sender, EventArgs e)
        {
            if (int.Parse(TeamThreePointsLabel.Text) < TotalPoints / 25)
            {
                TeamThreePointsPanel.BackColor = ColorTranslator.FromHtml(ZeroPercentColor);
            }
            if (int.Parse(TeamThreePointsLabel.Text) > TotalPoints / 25 && int.Parse(TeamThreePointsLabel.Text) < TotalPoints / 50)
            {
                TeamThreePointsPanel.BackColor = ColorTranslator.FromHtml(TwentyFivePercentColor);
            }
            if (int.Parse(TeamThreePointsLabel.Text) > TotalPoints / 50 && int.Parse(TeamThreePointsLabel.Text) < TotalPoints / 75)
            {
                TeamThreePointsPanel.BackColor = ColorTranslator.FromHtml(FiftyPercentColor);
            }
            if (int.Parse(TeamThreePointsLabel.Text) > TotalPoints / 75 && int.Parse(TeamThreePointsLabel.Text) < TotalPoints / 90)
            {
                TeamThreePointsPanel.BackColor = ColorTranslator.FromHtml(SeventyFivePercentColor);
            }
            if (int.Parse(TeamThreePointsLabel.Text) > TotalPoints / 90 && int.Parse(TeamThreePointsLabel.Text) < TotalPoints)
            {
                TeamThreePointsPanel.BackColor = ColorTranslator.FromHtml(NightyPercentColor);
            }
            if (int.Parse(TeamThreePointsLabel.Text) == TotalPoints || int.Parse(TeamThreePointsLabel.Text) > TotalPoints)
            {
                TeamThreePointsPanel.BackColor = ColorTranslator.FromHtml(OneHundredPercentColor);
            }
        }

        private void TeamFourPointsLabel_TextChanged(object sender, EventArgs e)
        {
            if (int.Parse(TeamFourPointsLabel.Text) < TotalPoints / 25)
            {
                TeamFourPointsPanel.BackColor = ColorTranslator.FromHtml(ZeroPercentColor);
            }
            if (int.Parse(TeamFourPointsLabel.Text) > TotalPoints / 25 && int.Parse(TeamFourPointsLabel.Text) < TotalPoints / 50)
            {
                TeamFourPointsPanel.BackColor = ColorTranslator.FromHtml(TwentyFivePercentColor);
            }
            if (int.Parse(TeamFourPointsLabel.Text) > TotalPoints / 50 && int.Parse(TeamFourPointsLabel.Text) < TotalPoints / 75)
            {
                TeamFourPointsPanel.BackColor = ColorTranslator.FromHtml(FiftyPercentColor);
            }
            if (int.Parse(TeamFourPointsLabel.Text) > TotalPoints / 75 && int.Parse(TeamFourPointsLabel.Text) < TotalPoints / 90)
            {
                TeamFourPointsPanel.BackColor = ColorTranslator.FromHtml(SeventyFivePercentColor);
            }
            if (int.Parse(TeamFourPointsLabel.Text) > TotalPoints / 90 && int.Parse(TeamFourPointsLabel.Text) < TotalPoints)
            {
                TeamFourPointsPanel.BackColor = ColorTranslator.FromHtml(NightyPercentColor);
            }
            if (int.Parse(TeamFourPointsLabel.Text) == TotalPoints || int.Parse(TeamFourPointsLabel.Text) > TotalPoints)
            {
                TeamFourPointsPanel.BackColor = ColorTranslator.FromHtml(OneHundredPercentColor);
            }
        }

        private void ReturnToSelectionButton_Click(object sender, EventArgs e)
        {
            Tornaments tornaments = new Tornaments();
            tornaments.Show();
            this.Hide();
        }
    }


}
