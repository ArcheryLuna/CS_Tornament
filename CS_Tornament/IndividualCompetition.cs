using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CS_Tornament.types;
using CS_Tornament.UserLogic;

namespace CS_Tornament
{
    public partial class IndividualsCompetition : Form
    {
        bool IsEnabled = false;
        bool IsResetting = false;
        CurrentEventType CurrentEvent = new CurrentEventType();
        string CurrentCompetition = "";
        List<TornEvents> TornamentEvents = new List<TornEvents>();

        List<Player> IndivividualPlayers = new List<Player>();

        public IndividualsCompetition()
        {
            InitializeComponent();
        }

        private void BackToSelectionButton_Click(object sender, EventArgs e)
        {
            Tornaments tornamentsForm = new Tornaments();
            tornamentsForm.Show();
            this.Hide();
        }

        private void ExitLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DialogResult ExitConfirmationDialog;
            ExitConfirmationDialog = MessageBox.Show("Are you sure you want to exit the application?", "Exit Application", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (ExitConfirmationDialog == DialogResult.Yes)
            {
                if (Properties.Settings.Default.UserPassword == string.Empty)
                {
                    Properties.Settings.Default.UserName = string.Empty;
                    Properties.Settings.Default.UserPassword = string.Empty;
                    Properties.Settings.Default.Save();
                }

                Application.Exit();
            }
        }

        private void LogoutLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DialogResult ConfirmationDialog;
            ConfirmationDialog = MessageBox.Show("Are you sure you want to log out?\n\nLogging out will remove your remember me information.", "Log out", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (ConfirmationDialog == DialogResult.Yes)
            {
                Properties.Settings.Default.UserName = "";
                Properties.Settings.Default.UserPassword = "";
                Properties.Settings.Default.Save();

                Application.Restart();
            }
        }

        private void IndividualsCompetitions_Load(object sender, EventArgs e)
        {
            UsernameLabel.Text = Properties.Settings.Default.UserName;

            ResponseWrapper<List<Player>> GetPlayers = Database.GetIndividualPlayers();

            if (!GetPlayers.IsSuccess)
            {
                MessageBox.Show(GetPlayers.ErrorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            GetPlayers.Data.ForEach(player =>
            {
                IndivividualPlayers.Add(player);
            });

            PlayerOneName.Text = $"{IndivividualPlayers[0].PlayerFirstName} {IndivividualPlayers[0].PlayerLastName}";
            PlayerTwoName.Text = $"{IndivividualPlayers[1].PlayerFirstName} {IndivividualPlayers[1].PlayerLastName}";
            PlayerThreeName.Text = $"{IndivividualPlayers[2].PlayerFirstName} {IndivividualPlayers[2].PlayerLastName}";
            PlayerFourName.Text = $"{IndivividualPlayers[3].PlayerFirstName} {IndivividualPlayers[3].PlayerLastName}";
            PlayerFiveName.Text = $"{IndivividualPlayers[4].PlayerFirstName} {IndivividualPlayers[4].PlayerLastName}";
            PlayerSixName.Text = $"{IndivividualPlayers[5].PlayerFirstName} {IndivividualPlayers[5].PlayerLastName}";
            PlayerSevenName.Text = $"{IndivividualPlayers[6].PlayerFirstName} {IndivividualPlayers[6].PlayerLastName}";
            PlayerEightName.Text = $"{IndivividualPlayers[7].PlayerFirstName} {IndivividualPlayers[7].PlayerLastName}";
            PlayerNineName.Text = $"{IndivividualPlayers[8].PlayerFirstName} {IndivividualPlayers[8].PlayerLastName}";
            PlayerTenName.Text = $"{IndivividualPlayers[9].PlayerFirstName} {IndivividualPlayers[9].PlayerLastName}";

            PlayerElevenName.Text = $"{IndivividualPlayers[10].PlayerFirstName} {IndivividualPlayers[10].PlayerLastName}";
            PlayerTwelveName.Text = $"{IndivividualPlayers[11].PlayerFirstName} {IndivividualPlayers[11].PlayerLastName}";
            PlayerThirteenName.Text = $"{IndivividualPlayers[12].PlayerFirstName} {IndivividualPlayers[12].PlayerLastName}";
            PlayerFourteenName.Text = $"{IndivividualPlayers[13].PlayerFirstName} {IndivividualPlayers[13].PlayerLastName}";
            PlayerFifteenName.Text = $"{IndivividualPlayers[14].PlayerFirstName} {IndivividualPlayers[14].PlayerLastName}";
            PlayerSixteenName.Text = $"{IndivividualPlayers[15].PlayerFirstName} {IndivividualPlayers[15].PlayerLastName}";
            PlayerSeventeenName.Text = $"{IndivividualPlayers[16].PlayerFirstName} {IndivividualPlayers[16].PlayerLastName}";
            PlayerEighteenName.Text = $"{IndivividualPlayers[17].PlayerFirstName} {IndivividualPlayers[17].PlayerLastName}";
            PlayerNineteenName.Text = $"{IndivividualPlayers[18].PlayerFirstName} {IndivividualPlayers[18].PlayerLastName}";
            PlayerTwentyName.Text = $"{IndivividualPlayers[19].PlayerFirstName} {IndivividualPlayers[19].PlayerLastName}";

            ResponseWrapper<List<TornEvents>> GetEvents = Database.GetEvents(Properties.Settings.Default.UserName);

            if (!GetEvents.IsSuccess)
            {
                MessageBox.Show(GetEvents.ErrorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            GetEvents.Data.ForEach(tornEvent =>
            {
                TornamentEvents.Add(tornEvent);
            });

            EventOneCheckBox.Text = TornamentEvents[0].EventName;
            EventTwoCheckBox.Text = TornamentEvents[1].EventName;
            EventThreeCheckBox.Text = TornamentEvents[2].EventName;
            EventFourCheckBox.Text = TornamentEvents[3].EventName;
            EventFiveCheckBox.Text = TornamentEvents[4].EventName;

            EventOneValue.Text = TornamentEvents[0].PointAmount.ToString();
            EventTwoValue.Text = TornamentEvents[1].PointAmount.ToString();
            EventThreeValue.Text = TornamentEvents[2].PointAmount.ToString();
            EventFourValue.Text = TornamentEvents[3].PointAmount.ToString();
            EventFiveValue.Text = TornamentEvents[4].PointAmount.ToString();

            TotalPointsValue.Text = $"{TornamentEvents[0].PointAmount + TornamentEvents[1].PointAmount + TornamentEvents[2].PointAmount + TornamentEvents[3].PointAmount + TornamentEvents[4].PointAmount}";
        }

        private void OverallPointsButton_Click(object sender, EventArgs e)
        {
            OverallPointValue.Text = $"{int.Parse(PlayerOnePointsLabel.Text) + int.Parse(PlayerTwoPointsLabel.Text) + int.Parse(PlayerThreePointsLabel.Text) + int.Parse(PlayerFourPointsLabel.Text) + int.Parse(PlayerFivePointsLabel.Text) + int.Parse(PlayerSixPointsLabel.Text) + int.Parse(PlayerSevenPointsLabel.Text) + int.Parse(PlayerEightPointsLabel.Text) + int.Parse(PlayerNinePointsLabel.Text) + int.Parse(PlayerTenPointsLabel.Text) + int.Parse(PlayerElevenPointsLabel.Text) + int.Parse(PlayerTwelvePointsLabel.Text) + int.Parse(PlayerThirteenPointsLabel.Text) + int.Parse(PlayerFourteenPointsLabel.Text) + int.Parse(PlayerFifteenPointsLabel.Text) + int.Parse(PlayerSixteenPointsLabel.Text) + int.Parse(PlayerSeventeenPointsLabel.Text) + int.Parse(PlayerEighteenPointsLabel.Text) + int.Parse(PlayerNineteenPointsLabel.Text) + int.Parse(PlayerTwentyPointsLabel.Text)}";
        }

        private void EventOneCheckBox_CheckedChanged(object sender, EventArgs e) {
            if (IsResetting) return;

            IsEnabled = !IsEnabled;

            switch ( IsEnabled ) {
                case true:
                    CurrentEvent.Index = 0;

                    PlayerOneName.Enabled = true;
                    PlayerOneName.Checked = false;
                    PlayerTwoName.Enabled = true;
                    PlayerTwoName.Checked = false;
                    PlayerThreeName.Enabled = true;
                    PlayerThreeName.Checked = false;
                    PlayerFourName.Enabled = true;
                    PlayerFourName.Checked = false;
                    PlayerFiveName.Enabled = true;
                    PlayerFiveName.Checked = false;
                    PlayerSixName.Enabled = true;
                    PlayerSixName.Checked = false;
                    PlayerSevenName.Enabled = true;
                    PlayerSevenName.Checked = false;
                    PlayerEightName.Enabled = true;
                    PlayerEightName.Checked = false;
                    PlayerNineName.Enabled = true;
                    PlayerNineName.Checked = false;
                    PlayerTenName.Enabled = true;
                    PlayerTenName.Checked = false;
                    PlayerElevenName.Enabled = true;
                    PlayerElevenName.Checked = false;
                    PlayerTwelveName.Enabled = true;
                    PlayerTwelveName.Checked = false;
                    PlayerThirteenName.Enabled = true;
                    PlayerThirteenName.Checked = false;
                    PlayerFourteenName.Enabled = true;
                    PlayerFourteenName.Checked = false;
                    PlayerFifteenName.Enabled = true;
                    PlayerFifteenName.Checked = false;
                    PlayerSixteenName.Enabled = true;
                    PlayerSixteenName.Checked = false;
                    PlayerSeventeenName.Enabled = true;
                    PlayerSeventeenName.Checked = false;
                    PlayerEighteenName.Enabled = true;
                    PlayerEighteenName.Checked = false;
                    PlayerNineteenName.Enabled = true;
                    PlayerNineteenName.Checked = false;
                    PlayerTwentyName.Enabled = true;

                    EventTwoCheckBox.Enabled = false;
                    EventTwoCheckBox.Checked = false;
                    EventThreeCheckBox.Enabled = false;
                    EventThreeCheckBox.Checked = false;
                    EventFourCheckBox.Enabled = false;
                    EventFourCheckBox.Checked = false;
                    EventFiveCheckBox.Enabled = false;
                    EventFiveCheckBox.Checked = false;

                    break;
                default:
                    PlayerOneName.Enabled = false;
                    PlayerOneName.Checked = false;
                    PlayerTwoName.Enabled = false;
                    PlayerTwoName.Checked = false;
                    PlayerThreeName.Enabled = false;
                    PlayerThreeName.Checked = false;
                    PlayerFourName.Enabled = false;
                    PlayerFourName.Checked = false;
                    PlayerFiveName.Enabled = false;
                    PlayerFiveName.Checked = false;
                    PlayerSixName.Enabled = false;
                    PlayerSixName.Checked = false;
                    PlayerSevenName.Enabled = false;
                    PlayerSevenName.Checked = false;
                    PlayerEightName.Enabled = false;
                    PlayerEightName.Checked = false;
                    PlayerNineName.Enabled = false;
                    PlayerNineName.Checked = false;
                    PlayerTenName.Enabled = false;
                    PlayerTenName.Checked = false;
                    PlayerElevenName.Enabled = false;
                    PlayerElevenName.Checked = false;
                    PlayerTwelveName.Enabled = false;
                    PlayerTwelveName.Checked = false;
                    PlayerThirteenName.Enabled = false;
                    PlayerThirteenName.Checked = false;
                    PlayerFourteenName.Enabled = false;
                    PlayerFourteenName.Checked = false;
                    PlayerFifteenName.Enabled = false;
                    PlayerFifteenName.Checked = false;
                    PlayerSixteenName.Enabled = false;
                    PlayerSixteenName.Checked = false;
                    PlayerSeventeenName.Enabled = false;
                    PlayerSeventeenName.Checked = false;
                    PlayerEighteenName.Enabled = false;
                    PlayerEighteenName.Checked = false;
                    PlayerNineteenName.Enabled = false;
                    PlayerNineteenName.Checked = false;
                    PlayerTwentyName.Enabled = false;

                    EventTwoCheckBox.Enabled = true;
                    EventTwoCheckBox.Checked = false;
                    EventThreeCheckBox.Enabled = true;
                    EventThreeCheckBox.Checked = false;
                    EventFourCheckBox.Enabled = true;
                    EventFourCheckBox.Checked = false;
                    EventFiveCheckBox.Enabled = true;
                    EventFiveCheckBox.Checked = false;

                    break;
            }
        }

        private void EventTwoCheckBox_CheckedChanged(object sender, EventArgs e) {
            if (IsResetting) return;

            IsEnabled = !IsEnabled;

            switch ( IsEnabled ) {
                case true:
                    CurrentEvent.Index = 1;

                    PlayerOneName.Enabled = true;
                    PlayerOneName.Checked = false;
                    PlayerTwoName.Enabled = true;
                    PlayerTwoName.Checked = false;
                    PlayerThreeName.Enabled = true;
                    PlayerThreeName.Checked = false;
                    PlayerFourName.Enabled = true;
                    PlayerFourName.Checked = false;
                    PlayerFiveName.Enabled = true;
                    PlayerFiveName.Checked = false;
                    PlayerSixName.Enabled = true;
                    PlayerSixName.Checked = false;
                    PlayerSevenName.Enabled = true;
                    PlayerSevenName.Checked = false;
                    PlayerEightName.Enabled = true;
                    PlayerEightName.Checked = false;
                    PlayerNineName.Enabled = true;
                    PlayerNineName.Checked = false;
                    PlayerTenName.Enabled = true;
                    PlayerTenName.Checked = false;
                    PlayerElevenName.Enabled = true;
                    PlayerElevenName.Checked = false;
                    PlayerTwelveName.Enabled = true;
                    PlayerTwelveName.Checked = false;
                    PlayerThirteenName.Enabled = true;
                    PlayerThirteenName.Checked = false;
                    PlayerFourteenName.Enabled = true;
                    PlayerFourteenName.Checked = false;
                    PlayerFifteenName.Enabled = true;
                    PlayerFifteenName.Checked = false;
                    PlayerSixteenName.Enabled = true;
                    PlayerSixteenName.Checked = false;
                    PlayerSeventeenName.Enabled = true;
                    PlayerSeventeenName.Checked = false;
                    PlayerEighteenName.Enabled = true;
                    PlayerEighteenName.Checked = false;
                    PlayerNineteenName.Enabled = true;
                    PlayerNineteenName.Checked = false;
                    PlayerTwentyName.Enabled = true;

                    EventOneCheckBox.Enabled = false;
                    EventOneCheckBox.Checked = false;
                    EventThreeCheckBox.Enabled = false;
                    EventThreeCheckBox.Checked = false;
                    EventFourCheckBox.Enabled = false;
                    EventFourCheckBox.Checked = false;
                    EventFiveCheckBox.Enabled = false;
                    EventFiveCheckBox.Checked = false;

                    break;
                default:
                    PlayerOneName.Enabled = false;
                    PlayerOneName.Checked = false;
                    PlayerTwoName.Enabled = false;
                    PlayerTwoName.Checked = false;
                    PlayerThreeName.Enabled = false;
                    PlayerThreeName.Checked = false;
                    PlayerFourName.Enabled = false;
                    PlayerFourName.Checked = false;
                    PlayerFiveName.Enabled = false;
                    PlayerFiveName.Checked = false;
                    PlayerSixName.Enabled = false;
                    PlayerSixName.Checked = false;
                    PlayerSevenName.Enabled = false;
                    PlayerSevenName.Checked = false;
                    PlayerEightName.Enabled = false;
                    PlayerEightName.Checked = false;
                    PlayerNineName.Enabled = false;
                    PlayerNineName.Checked = false;
                    PlayerTenName.Enabled = false;
                    PlayerTenName.Checked = false;
                    PlayerElevenName.Enabled = false;
                    PlayerElevenName.Checked = false;
                    PlayerTwelveName.Enabled = false;
                    PlayerTwelveName.Checked = false;
                    PlayerThirteenName.Enabled = false;
                    PlayerThirteenName.Checked = false;
                    PlayerFourteenName.Enabled = false;
                    PlayerFourteenName.Checked = false;
                    PlayerFifteenName.Enabled = false;
                    PlayerFifteenName.Checked = false;
                    PlayerSixteenName.Enabled = false;
                    PlayerSixteenName.Checked = false;
                    PlayerSeventeenName.Enabled = false;
                    PlayerSeventeenName.Checked = false;
                    PlayerEighteenName.Enabled = false;
                    PlayerEighteenName.Checked = false;
                    PlayerNineteenName.Enabled = false;
                    PlayerNineteenName.Checked = false;
                    PlayerTwentyName.Enabled = false;

                    EventOneCheckBox.Enabled = true;
                    EventOneCheckBox.Checked = false;
                    EventThreeCheckBox.Enabled = true;
                    EventThreeCheckBox.Checked = false;
                    EventFourCheckBox.Enabled = true;
                    EventFourCheckBox.Checked = false;
                    EventFiveCheckBox.Enabled = true;
                    EventFiveCheckBox.Checked = false;

                    break;
            }
        }

        private void EventThreeCheckBox_CheckedChanged(object sender, EventArgs e) {
            if (IsResetting) return;

            IsEnabled = !IsEnabled;

            switch ( IsEnabled ) {
                case true:
                    CurrentEvent.Index = 2;

                    PlayerOneName.Enabled = true;
                    PlayerOneName.Checked = false;
                    PlayerTwoName.Enabled = true;
                    PlayerTwoName.Checked = false;
                    PlayerThreeName.Enabled = true;
                    PlayerThreeName.Checked = false;
                    PlayerFourName.Enabled = true;
                    PlayerFourName.Checked = false;
                    PlayerFiveName.Enabled = true;
                    PlayerFiveName.Checked = false;
                    PlayerSixName.Enabled = true;
                    PlayerSixName.Checked = false;
                    PlayerSevenName.Enabled = true;
                    PlayerSevenName.Checked = false;
                    PlayerEightName.Enabled = true;
                    PlayerEightName.Checked = false;
                    PlayerNineName.Enabled = true;
                    PlayerNineName.Checked = false;
                    PlayerTenName.Enabled = true;
                    PlayerTenName.Checked = false;
                    PlayerElevenName.Enabled = true;
                    PlayerElevenName.Checked = false;
                    PlayerTwelveName.Enabled = true;
                    PlayerTwelveName.Checked = false;
                    PlayerThirteenName.Enabled = true;
                    PlayerThirteenName.Checked = false;
                    PlayerFourteenName.Enabled = true;
                    PlayerFourteenName.Checked = false;
                    PlayerFifteenName.Enabled = true;
                    PlayerFifteenName.Checked = false;
                    PlayerSixteenName.Enabled = true;
                    PlayerSixteenName.Checked = false;
                    PlayerSeventeenName.Enabled = true;
                    PlayerSeventeenName.Checked = false;
                    PlayerEighteenName.Enabled = true;
                    PlayerEighteenName.Checked = false;
                    PlayerNineteenName.Enabled = true;
                    PlayerNineteenName.Checked = false;
                    PlayerTwentyName.Enabled = true;

                    EventTwoCheckBox.Enabled = false;
                    EventTwoCheckBox.Checked = false;
                    EventOneCheckBox.Enabled = false;
                    EventOneCheckBox.Checked = false;
                    EventFourCheckBox.Enabled = false;
                    EventFourCheckBox.Checked = false;
                    EventFiveCheckBox.Enabled = false;
                    EventFiveCheckBox.Checked = false;

                    break;
                default:
                    PlayerOneName.Enabled = false;
                    PlayerOneName.Checked = false;
                    PlayerTwoName.Enabled = false;
                    PlayerTwoName.Checked = false;
                    PlayerThreeName.Enabled = false;
                    PlayerThreeName.Checked = false;
                    PlayerFourName.Enabled = false;
                    PlayerFourName.Checked = false;
                    PlayerFiveName.Enabled = false;
                    PlayerFiveName.Checked = false;
                    PlayerSixName.Enabled = false;
                    PlayerSixName.Checked = false;
                    PlayerSevenName.Enabled = false;
                    PlayerSevenName.Checked = false;
                    PlayerEightName.Enabled = false;
                    PlayerEightName.Checked = false;
                    PlayerNineName.Enabled = false;
                    PlayerNineName.Checked = false;
                    PlayerTenName.Enabled = false;
                    PlayerTenName.Checked = false;
                    PlayerElevenName.Enabled = false;
                    PlayerElevenName.Checked = false;
                    PlayerTwelveName.Enabled = false;
                    PlayerTwelveName.Checked = false;
                    PlayerThirteenName.Enabled = false;
                    PlayerThirteenName.Checked = false;
                    PlayerFourteenName.Enabled = false;
                    PlayerFourteenName.Checked = false;
                    PlayerFifteenName.Enabled = false;
                    PlayerFifteenName.Checked = false;
                    PlayerSixteenName.Enabled = false;
                    PlayerSixteenName.Checked = false;
                    PlayerSeventeenName.Enabled = false;
                    PlayerSeventeenName.Checked = false;
                    PlayerEighteenName.Enabled = false;
                    PlayerEighteenName.Checked = false;
                    PlayerNineteenName.Enabled = false;
                    PlayerNineteenName.Checked = false;
                    PlayerTwentyName.Enabled = false;

                    EventTwoCheckBox.Enabled = true;
                    EventTwoCheckBox.Checked = false;
                    EventOneCheckBox.Enabled = true;
                    EventOneCheckBox.Checked = false;
                    EventFourCheckBox.Enabled = true;
                    EventFourCheckBox.Checked = false;
                    EventFiveCheckBox.Enabled = true;
                    EventFiveCheckBox.Checked = false;

                    break;
            }
        }

        private void EventFourCheckBox_CheckedChanged(object sender, EventArgs e) {
            if (IsResetting) return;

            IsEnabled = !IsEnabled;

            switch ( IsEnabled ) {
                case true:
                    CurrentEvent.Index = 3;

                    PlayerOneName.Enabled = true;
                    PlayerOneName.Checked = false;
                    PlayerTwoName.Enabled = true;
                    PlayerTwoName.Checked = false;
                    PlayerThreeName.Enabled = true;
                    PlayerThreeName.Checked = false;
                    PlayerFourName.Enabled = true;
                    PlayerFourName.Checked = false;
                    PlayerFiveName.Enabled = true;
                    PlayerFiveName.Checked = false;
                    PlayerSixName.Enabled = true;
                    PlayerSixName.Checked = false;
                    PlayerSevenName.Enabled = true;
                    PlayerSevenName.Checked = false;
                    PlayerEightName.Enabled = true;
                    PlayerEightName.Checked = false;
                    PlayerNineName.Enabled = true;
                    PlayerNineName.Checked = false;
                    PlayerTenName.Enabled = true;
                    PlayerTenName.Checked = false;
                    PlayerElevenName.Enabled = true;
                    PlayerElevenName.Checked = false;
                    PlayerTwelveName.Enabled = true;
                    PlayerTwelveName.Checked = false;
                    PlayerThirteenName.Enabled = true;
                    PlayerThirteenName.Checked = false;
                    PlayerFourteenName.Enabled = true;
                    PlayerFourteenName.Checked = false;
                    PlayerFifteenName.Enabled = true;
                    PlayerFifteenName.Checked = false;
                    PlayerSixteenName.Enabled = true;
                    PlayerSixteenName.Checked = false;
                    PlayerSeventeenName.Enabled = true;
                    PlayerSeventeenName.Checked = false;
                    PlayerEighteenName.Enabled = true;
                    PlayerEighteenName.Checked = false;
                    PlayerNineteenName.Enabled = true;
                    PlayerNineteenName.Checked = false;
                    PlayerTwentyName.Enabled = true;

                    EventTwoCheckBox.Enabled = false;
                    EventTwoCheckBox.Checked = false;
                    EventThreeCheckBox.Enabled = false;
                    EventThreeCheckBox.Checked = false;
                    EventOneCheckBox.Enabled = false;
                    EventOneCheckBox.Checked = false;
                    EventFiveCheckBox.Enabled = false;
                    EventFiveCheckBox.Checked = false;

                    break;
                default:
                    PlayerOneName.Enabled = false;
                    PlayerOneName.Checked = false;
                    PlayerTwoName.Enabled = false;
                    PlayerTwoName.Checked = false;
                    PlayerThreeName.Enabled = false;
                    PlayerThreeName.Checked = false;
                    PlayerFourName.Enabled = false;
                    PlayerFourName.Checked = false;
                    PlayerFiveName.Enabled = false;
                    PlayerFiveName.Checked = false;
                    PlayerSixName.Enabled = false;
                    PlayerSixName.Checked = false;
                    PlayerSevenName.Enabled = false;
                    PlayerSevenName.Checked = false;
                    PlayerEightName.Enabled = false;
                    PlayerEightName.Checked = false;
                    PlayerNineName.Enabled = false;
                    PlayerNineName.Checked = false;
                    PlayerTenName.Enabled = false;
                    PlayerTenName.Checked = false;
                    PlayerElevenName.Enabled = false;
                    PlayerElevenName.Checked = false;
                    PlayerTwelveName.Enabled = false;
                    PlayerTwelveName.Checked = false;
                    PlayerThirteenName.Enabled = false;
                    PlayerThirteenName.Checked = false;
                    PlayerFourteenName.Enabled = false;
                    PlayerFourteenName.Checked = false;
                    PlayerFifteenName.Enabled = false;
                    PlayerFifteenName.Checked = false;
                    PlayerSixteenName.Enabled = false;
                    PlayerSixteenName.Checked = false;
                    PlayerSeventeenName.Enabled = false;
                    PlayerSeventeenName.Checked = false;
                    PlayerEighteenName.Enabled = false;
                    PlayerEighteenName.Checked = false;
                    PlayerNineteenName.Enabled = false;
                    PlayerNineteenName.Checked = false;
                    PlayerTwentyName.Enabled = false;

                    EventTwoCheckBox.Enabled = true;
                    EventTwoCheckBox.Checked = false;
                    EventThreeCheckBox.Enabled = true;
                    EventThreeCheckBox.Checked = false;
                    EventOneCheckBox.Enabled = true;
                    EventOneCheckBox.Checked = false;
                    EventFiveCheckBox.Enabled = true;
                    EventFiveCheckBox.Checked = false;

                    break;
            }
        }

        private void EventFiveCheckBox_CheckedChanged(object sender, EventArgs e) {
            if (IsResetting) return;

            IsEnabled = !IsEnabled;

            switch ( IsEnabled ) {
                case true:
                    CurrentEvent.Index = 4;

                    PlayerOneName.Enabled = true;
                    PlayerOneName.Checked = false;
                    PlayerTwoName.Enabled = true;
                    PlayerTwoName.Checked = false;
                    PlayerThreeName.Enabled = true;
                    PlayerThreeName.Checked = false;
                    PlayerFourName.Enabled = true;
                    PlayerFourName.Checked = false;
                    PlayerFiveName.Enabled = true;
                    PlayerFiveName.Checked = false;
                    PlayerSixName.Enabled = true;
                    PlayerSixName.Checked = false;
                    PlayerSevenName.Enabled = true;
                    PlayerSevenName.Checked = false;
                    PlayerEightName.Enabled = true;
                    PlayerEightName.Checked = false;
                    PlayerNineName.Enabled = true;
                    PlayerNineName.Checked = false;
                    PlayerTenName.Enabled = true;
                    PlayerTenName.Checked = false;
                    PlayerElevenName.Enabled = true;
                    PlayerElevenName.Checked = false;
                    PlayerTwelveName.Enabled = true;
                    PlayerTwelveName.Checked = false;
                    PlayerThirteenName.Enabled = true;
                    PlayerThirteenName.Checked = false;
                    PlayerFourteenName.Enabled = true;
                    PlayerFourteenName.Checked = false;
                    PlayerFifteenName.Enabled = true;
                    PlayerFifteenName.Checked = false;
                    PlayerSixteenName.Enabled = true;
                    PlayerSixteenName.Checked = false;
                    PlayerSeventeenName.Enabled = true;
                    PlayerSeventeenName.Checked = false;
                    PlayerEighteenName.Enabled = true;
                    PlayerEighteenName.Checked = false;
                    PlayerNineteenName.Enabled = true;
                    PlayerNineteenName.Checked = false;
                    PlayerTwentyName.Enabled = true;

                    EventTwoCheckBox.Enabled = false;
                    EventTwoCheckBox.Checked = false;
                    EventThreeCheckBox.Enabled = false;
                    EventThreeCheckBox.Checked = false;
                    EventFourCheckBox.Enabled = false;
                    EventFourCheckBox.Checked = false;
                    EventOneCheckBox.Enabled = false;
                    EventOneCheckBox.Checked = false;

                    break;
                default:
                    PlayerOneName.Enabled = false;
                    PlayerOneName.Checked = false;
                    PlayerTwoName.Enabled = false;
                    PlayerTwoName.Checked = false;
                    PlayerThreeName.Enabled = false;
                    PlayerThreeName.Checked = false;
                    PlayerFourName.Enabled = false;
                    PlayerFourName.Checked = false;
                    PlayerFiveName.Enabled = false;
                    PlayerFiveName.Checked = false;
                    PlayerSixName.Enabled = false;
                    PlayerSixName.Checked = false;
                    PlayerSevenName.Enabled = false;
                    PlayerSevenName.Checked = false;
                    PlayerEightName.Enabled = false;
                    PlayerEightName.Checked = false;
                    PlayerNineName.Enabled = false;
                    PlayerNineName.Checked = false;
                    PlayerTenName.Enabled = false;
                    PlayerTenName.Checked = false;
                    PlayerElevenName.Enabled = false;
                    PlayerElevenName.Checked = false;
                    PlayerTwelveName.Enabled = false;
                    PlayerTwelveName.Checked = false;
                    PlayerThirteenName.Enabled = false;
                    PlayerThirteenName.Checked = false;
                    PlayerFourteenName.Enabled = false;
                    PlayerFourteenName.Checked = false;
                    PlayerFifteenName.Enabled = false;
                    PlayerFifteenName.Checked = false;
                    PlayerSixteenName.Enabled = false;
                    PlayerSixteenName.Checked = false;
                    PlayerSeventeenName.Enabled = false;
                    PlayerSeventeenName.Checked = false;
                    PlayerEighteenName.Enabled = false;
                    PlayerEighteenName.Checked = false;
                    PlayerNineteenName.Enabled = false;
                    PlayerNineteenName.Checked = false;
                    PlayerTwentyName.Enabled = false;

                    EventTwoCheckBox.Enabled = true;
                    EventTwoCheckBox.Checked = false;
                    EventThreeCheckBox.Enabled = true;
                    EventThreeCheckBox.Checked = false;
                    EventFourCheckBox.Enabled = true;
                    EventFourCheckBox.Checked = false;
                    EventOneCheckBox.Enabled = true;
                    EventOneCheckBox.Checked = false;

                    break;
            }
        }

        private void PlayerOneName_OnCheckChanged(object sender, EventArgs e) {
            if (IsResetting) return;

            if (IsEnabled) {
                switch (PlayerOneName.Checked) {
                    case true:
                        PlayerOnePointsLabel.Text = $"{int.Parse(PlayerOnePointsLabel.Text) + TornamentEvents[CurrentEvent.Index].PointAmount}";
                        break; 
                    default:
                        PlayerOnePointsLabel.Text = $"{int.Parse(PlayerOnePointsLabel.Text) - TornamentEvents[CurrentEvent.Index].PointAmount}";
                        break;
                }
            }
        }

        private void PlayerTwoName_OnCheckChanged(object sender, EventArgs e) {
            if (IsResetting) return;

            if (IsEnabled) {
                switch (PlayerTwoName.Checked) {
                    case true:
                        PlayerTwoPointsLabel.Text = $"{int.Parse(PlayerTwoPointsLabel.Text) + TornamentEvents[CurrentEvent.Index].PointAmount}";
                        break; 
                    default:
                        PlayerTwoPointsLabel.Text = $"{int.Parse(PlayerTwoPointsLabel.Text) - TornamentEvents[CurrentEvent.Index].PointAmount}";
                        break;
                }
            }
        }

        private void PlayerThreeName_OnCheckChanged(object sender, EventArgs e) {
            if (IsResetting) return;

            if (IsEnabled) {
                switch (PlayerThreeName.Checked) {
                    case true:
                        PlayerThreePointsLabel.Text = $"{int.Parse(PlayerThreePointsLabel.Text) + TornamentEvents[CurrentEvent.Index].PointAmount}";
                        break; 
                    default:
                        PlayerThreePointsLabel.Text = $"{int.Parse(PlayerThreePointsLabel.Text) - TornamentEvents[CurrentEvent.Index].PointAmount}";
                        break;
                }
            }
        }

        private void PlayerFourName_OnCheckChanged(object sender, EventArgs e) {
            if (IsResetting) return;

            if (IsEnabled) {
                switch (PlayerFourName.Checked) {
                    case true:
                        PlayerFourPointsLabel.Text = $"{int.Parse(PlayerFourPointsLabel.Text) + TornamentEvents[CurrentEvent.Index].PointAmount}";
                        break; 
                    default:
                        PlayerFourPointsLabel.Text = $"{int.Parse(PlayerFourPointsLabel.Text) - TornamentEvents[CurrentEvent.Index].PointAmount}";
                        break;
                }
            }
        }

        private void PlayerFiveName_OnCheckChanged(object sender, EventArgs e) {
            if (IsResetting) return;

            if (IsEnabled) {
                switch (PlayerFiveName.Checked) {
                    case true:
                        PlayerFivePointsLabel.Text = $"{int.Parse(PlayerFivePointsLabel.Text) + TornamentEvents[CurrentEvent.Index].PointAmount}";
                        break; 
                    default:
                        PlayerFivePointsLabel.Text = $"{int.Parse(PlayerFivePointsLabel.Text) - TornamentEvents[CurrentEvent.Index].PointAmount}";
                        break;
                }
            }
        }

        private void PlayerSixName_OnCheckChanged(object sender, EventArgs e) {
            if (IsResetting) return;

            if (IsEnabled) {
                switch (PlayerSixName.Checked) {
                    case true:
                        PlayerSixPointsLabel.Text = $"{int.Parse(PlayerSixPointsLabel.Text) + TornamentEvents[CurrentEvent.Index].PointAmount}";
                        break; 
                    default:
                        PlayerSixPointsLabel.Text = $"{int.Parse(PlayerSixPointsLabel.Text) - TornamentEvents[CurrentEvent.Index].PointAmount}";
                        break;
                }
            }
        }

        private void PlayerSevenName_OnCheckChanged(object sender, EventArgs e) {
            if (IsResetting) return;

            if (IsEnabled) {
                switch (PlayerSevenName.Checked) {
                    case true:
                        PlayerSevenPointsLabel.Text = $"{int.Parse(PlayerSevenPointsLabel.Text) + TornamentEvents[CurrentEvent.Index].PointAmount}";
                        break; 
                    default:
                        PlayerSevenPointsLabel.Text = $"{int.Parse(PlayerSevenPointsLabel.Text) - TornamentEvents[CurrentEvent.Index].PointAmount}";
                        break;
                }
            }
        }

        private void PlayerEightName_OnCheckChanged(object sender, EventArgs e) {
            if (IsResetting) return;

            if (IsEnabled) {
                switch (PlayerEightName.Checked) {
                    case true:
                        PlayerEightPointsLabel.Text = $"{int.Parse(PlayerEightPointsLabel.Text) + TornamentEvents[CurrentEvent.Index].PointAmount}";
                        break; 
                    default:
                        PlayerEightPointsLabel.Text = $"{int.Parse(PlayerEightPointsLabel.Text) - TornamentEvents[CurrentEvent.Index].PointAmount}";
                        break;
                }
            }
        }

        private void PlayerNineName_OnCheckChanged(object sender, EventArgs e) {
            if (IsResetting) return;

            if (IsEnabled) {
                switch (PlayerNineName.Checked) {
                    case true:
                        PlayerNinePointsLabel.Text = $"{int.Parse(PlayerNinePointsLabel.Text) + TornamentEvents[CurrentEvent.Index].PointAmount}";
                        break; 
                    default:
                        PlayerNinePointsLabel.Text = $"{int.Parse(PlayerNinePointsLabel.Text) - TornamentEvents[CurrentEvent.Index].PointAmount}";
                        break;
                }
            }
        }

        private void PlayerTenName_OnCheckChanged(object sender, EventArgs e) {
            if (IsResetting) return;

            if (IsEnabled) {
                switch (PlayerTenName.Checked) {
                    case true:
                        PlayerTenPointsLabel.Text = $"{int.Parse(PlayerTenPointsLabel.Text) + TornamentEvents[CurrentEvent.Index].PointAmount}";
                        break; 
                    default:
                        PlayerTenPointsLabel.Text = $"{int.Parse(PlayerTenPointsLabel.Text) - TornamentEvents[CurrentEvent.Index].PointAmount}";
                        break;
                }
            }
        }

        private void PlayerElevenName_OnCheckChanged(object sender, EventArgs e) {
            if (IsResetting) return;

            if (IsEnabled) {
                switch (PlayerElevenName.Checked) {
                    case true:
                        PlayerElevenPointsLabel.Text = $"{int.Parse(PlayerElevenPointsLabel.Text) + TornamentEvents[CurrentEvent.Index].PointAmount}";
                        break; 
                    default:
                        PlayerElevenPointsLabel.Text = $"{int.Parse(PlayerElevenPointsLabel.Text) - TornamentEvents[CurrentEvent.Index].PointAmount}";
                        break;
                }
            }
        }

        private void PlayerTwelveName_OnCheckChanged(object sender, EventArgs e) {
            if (IsResetting) return;

            if (IsEnabled) {
                switch (PlayerTwelveName.Checked) {
                    case true:
                        PlayerTwelvePointsLabel.Text = $"{int.Parse(PlayerTwelvePointsLabel.Text) + TornamentEvents[CurrentEvent.Index].PointAmount}";
                        break; 
                    default:
                        PlayerTwelvePointsLabel.Text = $"{int.Parse(PlayerTwelvePointsLabel.Text) - TornamentEvents[CurrentEvent.Index].PointAmount}";
                        break;
                }
            }
        }

        private void PlayerThirteenName_OnCheckChanged(object sender, EventArgs e) {
            if (IsResetting) return;

            if (IsEnabled) {
                switch (PlayerThirteenName.Checked) {
                    case true:
                        PlayerThirteenPointsLabel.Text = $"{int.Parse(PlayerThirteenPointsLabel.Text) + TornamentEvents[CurrentEvent.Index].PointAmount}";
                        break; 
                    default:
                        PlayerThirteenPointsLabel.Text = $"{int.Parse(PlayerThirteenPointsLabel.Text) - TornamentEvents[CurrentEvent.Index].PointAmount}";
                        break;
                }
            }
        }

        private void PlayerFourteenName_OnCheckChanged(object sender, EventArgs e) {
            if (IsResetting) return;

            if (IsEnabled) {
                switch (PlayerFourteenName.Checked) {
                    case true:
                        PlayerFourteenPointsLabel.Text = $"{int.Parse(PlayerFourteenPointsLabel.Text) + TornamentEvents[CurrentEvent.Index].PointAmount}";
                        break; 
                    default:
                        PlayerFourteenPointsLabel.Text = $"{int.Parse(PlayerFourteenPointsLabel.Text) - TornamentEvents[CurrentEvent.Index].PointAmount}";
                        break;
                }
            }
        }

        private void PlayerFifteenName_OnCheckChanged(object sender, EventArgs e) {
            if (IsResetting) return;

            if (IsEnabled) {
                switch (PlayerFifteenName.Checked) {
                    case true:
                        PlayerFifteenPointsLabel.Text = $"{int.Parse(PlayerFifteenPointsLabel.Text) + TornamentEvents[CurrentEvent.Index].PointAmount}";
                        break; 
                    default:
                        PlayerFifteenPointsLabel.Text = $"{int.Parse(PlayerFifteenPointsLabel.Text) - TornamentEvents[CurrentEvent.Index].PointAmount}";
                        break;
                }
            }
        }

        private void PlayerSixteenName_OnCheckChanged(object sender, EventArgs e) {
            if (IsResetting) return;

            if (IsEnabled) {
                switch (PlayerSixteenName.Checked) {
                    case true:
                        PlayerSixteenPointsLabel.Text = $"{int.Parse(PlayerSixteenPointsLabel.Text) + TornamentEvents[CurrentEvent.Index].PointAmount}";
                        break; 
                    default:
                        PlayerSixteenPointsLabel.Text = $"{int.Parse(PlayerSixteenPointsLabel.Text) - TornamentEvents[CurrentEvent.Index].PointAmount}";
                        break;
                }
            }
        }

        private void PlayerSeventeenName_OnCheckChanged(object sender, EventArgs e) {
            if (IsResetting) return;

            if (IsEnabled) {
                switch (PlayerSeventeenName.Checked) {
                    case true:
                        PlayerSeventeenPointsLabel.Text = $"{int.Parse(PlayerSeventeenPointsLabel.Text) + TornamentEvents[CurrentEvent.Index].PointAmount}";
                        break; 
                    default:
                        PlayerSeventeenPointsLabel.Text = $"{int.Parse(PlayerSeventeenPointsLabel.Text) - TornamentEvents[CurrentEvent.Index].PointAmount}";
                        break;
                }
            }
        }

        private void PlayerEighteenName_OnCheckChanged(object sender, EventArgs e) {
            if (IsResetting) return;

            if (IsEnabled) {
                switch (PlayerEighteenName.Checked) {
                    case true:
                        PlayerEighteenPointsLabel.Text = $"{int.Parse(PlayerEighteenPointsLabel.Text) + TornamentEvents[CurrentEvent.Index].PointAmount}";
                        break; 
                    default:
                        PlayerEighteenPointsLabel.Text = $"{int.Parse(PlayerEighteenPointsLabel.Text) - TornamentEvents[CurrentEvent.Index].PointAmount}";
                        break;
                }
            }
        }

        private void PlayerNineteenName_OnCheckChanged(object sender, EventArgs e) {
            if (IsResetting) return;

            if (IsEnabled) {
                switch (PlayerNineteenName.Checked) {
                    case true:
                        PlayerNineteenPointsLabel.Text = $"{int.Parse(PlayerNineteenPointsLabel.Text) + TornamentEvents[CurrentEvent.Index].PointAmount}";
                        break; 
                    default:
                        PlayerNineteenPointsLabel.Text = $"{int.Parse(PlayerNineteenPointsLabel.Text) - TornamentEvents[CurrentEvent.Index].PointAmount}";
                        break;
                }
            }
        }

        private void PlayerTwentyName_OnCheckChanged(object sender, EventArgs e) {
            if (IsResetting) return;

            if (IsEnabled) {
                switch (PlayerTwentyName.Checked) {
                    case true:
                        PlayerTwentyPointsLabel.Text = $"{int.Parse(PlayerTwentyPointsLabel.Text) + TornamentEvents[CurrentEvent.Index].PointAmount}";
                        break; 
                    default:
                        PlayerTwentyPointsLabel.Text = $"{int.Parse(PlayerTwentyPointsLabel.Text) - TornamentEvents[CurrentEvent.Index].PointAmount}";
                        break;
                }
            }
        }

        private void ResetButton_Click (object sender, EventArgs e) {
            IsResetting = true;

            PlayerOnePointsLabel.Text = "0";
            PlayerTwoPointsLabel.Text = "0";
            PlayerThreePointsLabel.Text = "0";
            PlayerFourPointsLabel.Text = "0";
            PlayerFivePointsLabel.Text = "0";
            PlayerSixPointsLabel.Text = "0";
            PlayerSevenPointsLabel.Text = "0";
            PlayerEightPointsLabel.Text = "0";
            PlayerNinePointsLabel.Text = "0";
            PlayerTenPointsLabel.Text = "0";
            PlayerElevenPointsLabel.Text = "0";
            PlayerTwelvePointsLabel.Text = "0";
            PlayerThirteenPointsLabel.Text = "0";
            PlayerFourteenPointsLabel.Text = "0";
            PlayerFifteenPointsLabel.Text = "0";
            PlayerSixteenPointsLabel.Text = "0";
            PlayerSeventeenPointsLabel.Text = "0";
            PlayerEighteenPointsLabel.Text = "0";
            PlayerNineteenPointsLabel.Text = "0";
            PlayerTwentyPointsLabel.Text = "0";

            IsEnabled = false;

            PlayerOneName.Checked = false;
            PlayerTwoName.Checked = false;
            PlayerThreeName.Checked = false;
            PlayerFourName.Checked = false;
            PlayerFiveName.Checked = false;
            PlayerSixName.Checked = false;
            PlayerSevenName.Checked = false;
            PlayerEightName.Checked = false;
            PlayerNineName.Checked = false;
            PlayerTenName.Checked = false;

            PlayerElevenName.Checked = false;
            PlayerTwelveName.Checked = false;
            PlayerThirteenName.Checked = false;
            PlayerFourteenName.Checked = false;
            PlayerFifteenName.Checked = false;
            PlayerSixteenName.Checked = false;
            PlayerSeventeenName.Checked = false;
            PlayerEighteenName.Checked = false;
            PlayerNineteenName.Checked = false;
            PlayerTwentyName.Checked = false;

            EventOneCheckBox.Checked = false;
            EventTwoCheckBox.Checked = false;
            EventThreeCheckBox.Checked = false;
            EventFourCheckBox.Checked = false;
            EventFiveCheckBox.Checked = false;

            PlayerOneName.Enabled = false;
            PlayerTwoName.Enabled = false;
            PlayerThreeName.Enabled = false;
            PlayerFourName.Enabled = false;
            PlayerFiveName.Enabled = false;
            PlayerSixName.Enabled = false;
            PlayerSevenName.Enabled = false;
            PlayerEightName.Enabled = false;
            PlayerNineName.Enabled = false;
            PlayerTenName.Enabled = false;

            PlayerElevenName.Enabled = false;
            PlayerTwelveName.Enabled = false;
            PlayerThirteenName.Enabled = false;
            PlayerFourteenName.Enabled = false;
            PlayerFifteenName.Enabled = false;
            PlayerSixteenName.Enabled = false;
            PlayerSeventeenName.Enabled = false;
            PlayerEighteenName.Enabled = false;
            PlayerNineteenName.Enabled = false;
            PlayerTwentyName.Enabled = false;

            EventOneCheckBox.Enabled = true;
            EventTwoCheckBox.Enabled = true;
            EventThreeCheckBox.Enabled = true;
            EventFourCheckBox.Enabled = true;
            EventFiveCheckBox.Enabled = true;

            TotalPointsValue.Text = "0";
            OverallPointValue.Text = "0";

            IsResetting = false;
        }
    }
}
