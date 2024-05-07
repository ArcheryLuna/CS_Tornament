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
                this.Close();
            }
        }
    }
}
