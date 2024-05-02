using System.Collections.Generic;
using CS_Tornament.UserLogic;

namespace CS_Tornament
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
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

                MessageBox.Show(User[0].ToString());
                MessageBox.Show(User[1].ToString());
                MessageBox.Show(User[2].ToString());
                MessageBox.Show(User[3].ToString());

                bool PasswordVerification = Password.Verify(UnhashedPassword, User[3].ToString());

                if (PasswordVerification)
                {
                    LoginDialog = MessageBox.Show("Login Successful", "Login", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    LoginDialog = MessageBox.Show("Login Failed", "Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                LoginDialog = MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            
        }
    }
}
