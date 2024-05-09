namespace CS_Tornament
{
    partial class UserSettings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            UserSettingLabel = new Label();
            UserNameLabel = new Label();
            UsernameTextBox = new TextBox();
            Email = new Label();
            UserEmailTextbox = new TextBox();
            PasswordLabel = new Label();
            PasswordTextBox = new TextBox();
            ShowPasswordButton = new Button();
            SubmitButton = new Button();
            BackToSelection = new Button();
            pictureBox1 = new PictureBox();
            LogoutButton = new Button();
            ExitButton = new Button();
            ActiveUser = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // UserSettingLabel
            // 
            UserSettingLabel.AutoSize = true;
            UserSettingLabel.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            UserSettingLabel.Location = new Point(12, 9);
            UserSettingLabel.Name = "UserSettingLabel";
            UserSettingLabel.Size = new Size(217, 45);
            UserSettingLabel.TabIndex = 0;
            UserSettingLabel.Text = "User Settings";
            // 
            // UserNameLabel
            // 
            UserNameLabel.AutoSize = true;
            UserNameLabel.Location = new Point(12, 72);
            UserNameLabel.Name = "UserNameLabel";
            UserNameLabel.Size = new Size(60, 15);
            UserNameLabel.TabIndex = 1;
            UserNameLabel.Text = "Username";
            // 
            // UsernameTextBox
            // 
            UsernameTextBox.Location = new Point(12, 90);
            UsernameTextBox.Name = "UsernameTextBox";
            UsernameTextBox.PlaceholderText = "username";
            UsernameTextBox.Size = new Size(217, 23);
            UsernameTextBox.TabIndex = 2;
            // 
            // Email
            // 
            Email.AutoSize = true;
            Email.Location = new Point(12, 127);
            Email.Name = "Email";
            Email.Size = new Size(36, 15);
            Email.TabIndex = 3;
            Email.Text = "Email";
            // 
            // UserEmailTextbox
            // 
            UserEmailTextbox.Location = new Point(12, 145);
            UserEmailTextbox.Name = "UserEmailTextbox";
            UserEmailTextbox.PlaceholderText = "email";
            UserEmailTextbox.Size = new Size(217, 23);
            UserEmailTextbox.TabIndex = 4;
            // 
            // PasswordLabel
            // 
            PasswordLabel.AutoSize = true;
            PasswordLabel.Location = new Point(12, 186);
            PasswordLabel.Name = "PasswordLabel";
            PasswordLabel.Size = new Size(57, 15);
            PasswordLabel.TabIndex = 5;
            PasswordLabel.Text = "Password";
            // 
            // PasswordTextBox
            // 
            PasswordTextBox.Location = new Point(12, 204);
            PasswordTextBox.Name = "PasswordTextBox";
            PasswordTextBox.PasswordChar = '*';
            PasswordTextBox.PlaceholderText = "Password";
            PasswordTextBox.Size = new Size(189, 23);
            PasswordTextBox.TabIndex = 6;
            PasswordTextBox.UseSystemPasswordChar = true;
            // 
            // ShowPasswordButton
            // 
            ShowPasswordButton.Location = new Point(207, 204);
            ShowPasswordButton.Name = "ShowPasswordButton";
            ShowPasswordButton.Size = new Size(22, 23);
            ShowPasswordButton.TabIndex = 7;
            ShowPasswordButton.Text = "👁️";
            ShowPasswordButton.UseVisualStyleBackColor = true;
            // 
            // SubmitButton
            // 
            SubmitButton.Location = new Point(12, 233);
            SubmitButton.Name = "SubmitButton";
            SubmitButton.Size = new Size(217, 43);
            SubmitButton.TabIndex = 8;
            SubmitButton.Text = "Submit Changes";
            SubmitButton.UseVisualStyleBackColor = true;
            SubmitButton.Click += SubmitButton_Click;
            // 
            // BackToSelection
            // 
            BackToSelection.Location = new Point(12, 282);
            BackToSelection.Name = "BackToSelection";
            BackToSelection.Size = new Size(217, 28);
            BackToSelection.TabIndex = 9;
            BackToSelection.Text = "Back To Selection";
            BackToSelection.UseVisualStyleBackColor = true;
            BackToSelection.Click += BackToSelection_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            pictureBox1.Image = Properties.Resources.user_solid;
            pictureBox1.Location = new Point(244, 9);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(134, 129);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 10;
            pictureBox1.TabStop = false;
            // 
            // LogoutButton
            // 
            LogoutButton.ForeColor = Color.IndianRed;
            LogoutButton.Location = new Point(244, 174);
            LogoutButton.Name = "LogoutButton";
            LogoutButton.Size = new Size(134, 23);
            LogoutButton.TabIndex = 11;
            LogoutButton.Text = "Logout";
            LogoutButton.UseVisualStyleBackColor = true;
            // 
            // ExitButton
            // 
            ExitButton.ForeColor = Color.IndianRed;
            ExitButton.Location = new Point(244, 203);
            ExitButton.Name = "ExitButton";
            ExitButton.Size = new Size(134, 23);
            ExitButton.TabIndex = 12;
            ExitButton.Text = "Exit";
            ExitButton.UseVisualStyleBackColor = true;
            // 
            // ActiveUser
            // 
            ActiveUser.AutoSize = true;
            ActiveUser.Location = new Point(244, 148);
            ActiveUser.Name = "ActiveUser";
            ActiveUser.Size = new Size(29, 15);
            ActiveUser.TabIndex = 13;
            ActiveUser.Text = "user";
            // 
            // UserSettings
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(395, 335);
            Controls.Add(ActiveUser);
            Controls.Add(ExitButton);
            Controls.Add(LogoutButton);
            Controls.Add(pictureBox1);
            Controls.Add(BackToSelection);
            Controls.Add(SubmitButton);
            Controls.Add(ShowPasswordButton);
            Controls.Add(PasswordTextBox);
            Controls.Add(PasswordLabel);
            Controls.Add(UserEmailTextbox);
            Controls.Add(Email);
            Controls.Add(UsernameTextBox);
            Controls.Add(UserNameLabel);
            Controls.Add(UserSettingLabel);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "UserSettings";
            Text = "User Settings";
            Load += UserSettings_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label UserSettingLabel;
        private Label UserNameLabel;
        private TextBox UsernameTextBox;
        private Label Email;
        private TextBox UserEmailTextbox;
        private Label PasswordLabel;
        private TextBox PasswordTextBox;
        private Button ShowPasswordButton;
        private Button SubmitButton;
        private Button BackToSelection;
        private PictureBox pictureBox1;
        private Button LogoutButton;
        private Button ExitButton;
        private Label ActiveUser;
    }
}