using System.Collections.Generic;
using System.Reflection;
using CS_Tornament.UserLogic;

namespace CS_Tornament
{
    public partial class LoginForm : Form
    {
        bool ShowPassword = false;
        bool RememberMe = false;

        Tornaments TornamentForm = new Tornaments();
        public LoginForm()
        {
            InitializeComponent();


            this.StartPosition = FormStartPosition.CenterScreen;

            
        }

        private void ResetSubmit_Click(object sender, EventArgs e)
        {
            DialogResult ResetFormsDialog;

            ResetFormsDialog = MessageBox.Show("Do you want to reset the form?", "Reset Form", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (ResetFormsDialog == DialogResult.Yes)
            {
                UsernameInput.Clear();
                PasswordInput.Clear();
            }
        }

        private void ExitSubmit_Click(object sender, EventArgs e)
        {
            DialogResult ExitDialog;

            ExitDialog = MessageBox.Show("Do you want to exit the application?", "Exit Application", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (ExitDialog == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void LoginSubmit_Click(object sender, EventArgs e)
        {
            DialogResult LoginDialog;

            string Username = UsernameInput.Text;
            string UnhashedPassword = PasswordInput.Text;

            if (Username == "" || UnhashedPassword == "")
            {
                LoginDialog = MessageBox.Show("Please enter a username and password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {

                string[] User = Database.GetUser(username: Username);

                bool PasswordVerification = Password.Verify(UnhashedPassword, User[2].ToString());

                if (!PasswordVerification)
                {
                    LoginDialog = MessageBox.Show("Login Failed", "Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                LoginDialog = MessageBox.Show("Login Successful", "Login", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (RememberMe)
                {
                    Properties.Settings.Default.UserName = User[0];
                    Properties.Settings.Default.UserPassword = User[2]; 
                    Properties.Settings.Default.Save();   
                    TornamentForm.Show();
                    this.Hide();
                } else
                {
                    Properties.Settings.Default.UserName = User[0];
                    Properties.Settings.Default.UserPassword = "";
                    Properties.Settings.Default.Save();
                    TornamentForm.Show();
                    this.Hide();
                }
                
                

                
            }
            catch (Exception ex)
            {
                LoginDialog = MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void UsernameInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                PasswordInput.Select();
            }
        }

        private void PasswordInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LoginSubmit_Click(sender, e);
            }
        }

        private void ShowPasswordButton_Click(object sender, EventArgs e)
        {
            if (ShowPassword)
            {
                PasswordInput.PasswordChar = '*';
                PasswordInput.UseSystemPasswordChar = true;
                ShowPassword = false;
            }
            else
            {
                PasswordInput.PasswordChar = '\0';
                PasswordInput.UseSystemPasswordChar = false;
                ShowPassword = true;
            }
        }

        private void RememberMeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            RememberMe = !RememberMe;
        }
    }
}
