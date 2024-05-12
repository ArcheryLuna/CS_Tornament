using CS_Tornament.types;
using CS_Tornament.UserLogic;
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
    public partial class CreateUser : Form
    {
        Tornaments Tornaments = new Tornaments();
        bool ShowPassword = false;

        public CreateUser()
        {
            InitializeComponent();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to exit?", "Exit", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                if (Properties.Settings.Default.UserPassword == null || Properties.Settings.Default.UserPassword == "" || Properties.Settings.Default.UserPassword == " ")
                {
                    Properties.Settings.Default.UserPassword = "";
                    Properties.Settings.Default.Save();
                }

                Application.Exit();
            }

        }

        private void LogoutButton_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to logout?", "Logout", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                Properties.Settings.Default.UserName = "";
                Properties.Settings.Default.UserPassword = "";
                Properties.Settings.Default.Save();

                Application.Restart();
            }
        }

        private void ReturnToSelectionButton_Click(object sender, EventArgs e)
        {
            Tornaments.Show();
            this.Hide();
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            string Username = UsernameInput.Text;
            string UserEmail = UserEmailInput.Text;
            string UserPassword = PasswordInput.Text;

            if (Username == String.Empty || UserEmail == String.Empty || UserPassword == String.Empty)
            {
                MessageBox.Show("Please fill in all fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            string UserPasswordHash = Password.Hash(UserPassword);

            ResponseWrapper<User> UserCreator = Database.CreateUser(Username, UserEmail, UserPasswordHash);

            if (!UserCreator.IsSuccess)
            {
                MessageBox.Show(UserCreator.ErrorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            MessageBox.Show($"User created successfully\nUserID = {UserCreator.Data.UserID}\nUserName = {UserCreator.Data.UserName}\nUserEmail = {UserCreator.Data.UserEmail}\nUserPassword = {UserCreator.Data.UserPassword}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void ShowPasswordButton_Click(object sender, EventArgs e)
        {
            

            if(ShowPassword)
            {
                PasswordInput.PasswordChar = '*';
                PasswordInput.UseSystemPasswordChar = true;
                ShowPassword = !ShowPassword;
            }
            else
            {
                PasswordInput.PasswordChar = '\0';
                PasswordInput.UseSystemPasswordChar = false;
                ShowPassword = !ShowPassword;
            }
        }
    }
}
