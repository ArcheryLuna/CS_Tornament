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

namespace CS_Tornament
{
    public partial class UserSettings : Form
    {
        string Username = "";
        string Password = "";
        string EmailString = "";

        public UserSettings()
        {
            InitializeComponent();
        }

        public void UserSettings_Load(object sender, EventArgs e)
        {
            UsernameTextBox.PlaceholderText = Properties.Settings.Default.UserName;
            ActiveUser.Text = Properties.Settings.Default.UserName;

            try
            {
                string[] Userdata = Database.GetUser(username: Properties.Settings.Default.UserName);

                Username = Userdata[0];
                EmailString = Userdata[1];
                Password = Userdata[2];

                UserEmailTextbox.PlaceholderText = EmailString;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void BackToSelection_Click(object sender, EventArgs e)
        {
            DialogResult ConfirmationDialog;

            ConfirmationDialog = MessageBox.Show("Are you sure you want to go back to the selection screen?", "Back to selection", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (ConfirmationDialog == DialogResult.Yes)
            {
                // Close the current form without closing the other form that is open
                new Tornaments().CloseUserSetting();
            }
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            string NewUsername = UsernameTextBox.Text;
            string NewEmail = UserEmailTextbox.Text;
            string NewPassword = PasswordTextBox.Text;

            DialogResult ConfirmationDialog;

            if (NewUsername == "" && NewEmail == "" && NewPassword == "")
            {
                MessageBox.Show("Please fill in at least one field to update", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ConfirmationDialog = MessageBox.Show("Are you sure you want to update your information?", "Update Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (ConfirmationDialog == DialogResult.No)
            {
                return;
            }

            

            if (NewUsername != "")
            {
                try
                {
                    bool UsernameChangeStatus = Database.ChangeUsername(Properties.Settings.Default.UserName, NewUsername);

                    if (UsernameChangeStatus)
                    {
                        MessageBox.Show("Username changed successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                } catch ( Exception ex )
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            if (NewEmail != "")
            {
                try
                {
                    bool EmailChangeStatus = Database.ChangeEmail(Properties.Settings.Default.UserName, NewEmail);

                    if (EmailChangeStatus)
                    {
                        MessageBox.Show("Email changed successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            if (NewPassword != "")
            {
                try
                {
                    bool PasswordChangeStatus = Database.ChangePassword(Properties.Settings.Default.UserName, NewPassword);

                    if (PasswordChangeStatus)
                    {
                        MessageBox.Show("Password changed successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
