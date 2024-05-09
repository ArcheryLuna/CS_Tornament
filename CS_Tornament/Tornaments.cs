using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CS_Tornament
{
    public partial class Tornaments : Form
    {

        CreateUser CreateUserForm = new CreateUser();
        UserSettings UserSettingForm = new UserSettings();

        public Tornaments()
        {
            InitializeComponent();
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

        private void Tornaments_Load(object sender, EventArgs e)
        {
            UserNameLabel.Text = Properties.Settings.Default.UserName;
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

        private void UserSettingsButton_Click(object sender, EventArgs e)
        {
            UserSettingForm.Show();
        }

        private void CreateUserButton_Click(object sender, EventArgs e)
        { 
            CreateUserForm.Show();

        }

        public void CloseUserSetting()
        {
            UserSettingForm.Close();
        }

        public void CloseUserCreation()
        {
            CreateUserForm.Close();
        }
    }
}
