namespace CS_Tornament
{
    partial class CreateUser
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
            TitleLabel = new Label();
            UserNameLabel = new Label();
            UsernameInput = new TextBox();
            UserEmailInput = new TextBox();
            UserEmailLabel = new Label();
            PasswordInput = new TextBox();
            UserPasswordLabel = new Label();
            ShowPasswordButton = new Button();
            SubmitButton = new Button();
            UserImage = new PictureBox();
            LogoutButton = new Button();
            ExitButton = new Button();
            ReturnToSelectionButton = new Button();
            ((System.ComponentModel.ISupportInitialize)UserImage).BeginInit();
            SuspendLayout();
            // 
            // TitleLabel
            // 
            TitleLabel.AutoSize = true;
            TitleLabel.Font = new Font("Segoe UI", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            TitleLabel.Location = new Point(12, 9);
            TitleLabel.Name = "TitleLabel";
            TitleLabel.Size = new Size(204, 40);
            TitleLabel.TabIndex = 0;
            TitleLabel.Text = "Create A User";
            // 
            // UserNameLabel
            // 
            UserNameLabel.AutoSize = true;
            UserNameLabel.Location = new Point(12, 64);
            UserNameLabel.Name = "UserNameLabel";
            UserNameLabel.Size = new Size(60, 15);
            UserNameLabel.TabIndex = 1;
            UserNameLabel.Text = "Username";
            // 
            // UsernameInput
            // 
            UsernameInput.Location = new Point(12, 82);
            UsernameInput.Name = "UsernameInput";
            UsernameInput.PlaceholderText = "Username";
            UsernameInput.Size = new Size(204, 23);
            UsernameInput.TabIndex = 2;
            // 
            // UserEmailInput
            // 
            UserEmailInput.Location = new Point(12, 140);
            UserEmailInput.Name = "UserEmailInput";
            UserEmailInput.PlaceholderText = "Email";
            UserEmailInput.Size = new Size(204, 23);
            UserEmailInput.TabIndex = 4;
            // 
            // UserEmailLabel
            // 
            UserEmailLabel.AutoSize = true;
            UserEmailLabel.Location = new Point(12, 122);
            UserEmailLabel.Name = "UserEmailLabel";
            UserEmailLabel.Size = new Size(36, 15);
            UserEmailLabel.TabIndex = 3;
            UserEmailLabel.Text = "Email";
            // 
            // PasswordInput
            // 
            PasswordInput.Location = new Point(12, 204);
            PasswordInput.Name = "PasswordInput";
            PasswordInput.PasswordChar = '*';
            PasswordInput.PlaceholderText = "Password";
            PasswordInput.Size = new Size(176, 23);
            PasswordInput.TabIndex = 6;
            PasswordInput.UseSystemPasswordChar = true;
            // 
            // UserPasswordLabel
            // 
            UserPasswordLabel.AutoSize = true;
            UserPasswordLabel.Location = new Point(12, 186);
            UserPasswordLabel.Name = "UserPasswordLabel";
            UserPasswordLabel.Size = new Size(57, 15);
            UserPasswordLabel.TabIndex = 5;
            UserPasswordLabel.Text = "Password";
            // 
            // ShowPasswordButton
            // 
            ShowPasswordButton.Location = new Point(194, 204);
            ShowPasswordButton.Name = "ShowPasswordButton";
            ShowPasswordButton.Size = new Size(22, 23);
            ShowPasswordButton.TabIndex = 7;
            ShowPasswordButton.Text = "👁️";
            ShowPasswordButton.UseVisualStyleBackColor = true;
            ShowPasswordButton.Click += ShowPasswordButton_Click;
            // 
            // SubmitButton
            // 
            SubmitButton.Location = new Point(12, 235);
            SubmitButton.Name = "SubmitButton";
            SubmitButton.Size = new Size(204, 39);
            SubmitButton.TabIndex = 8;
            SubmitButton.Text = "Add User";
            SubmitButton.UseVisualStyleBackColor = true;
            SubmitButton.Click += SubmitButton_Click;
            // 
            // UserImage
            // 
            UserImage.BorderStyle = BorderStyle.FixedSingle;
            UserImage.Image = Properties.Resources.user_solid;
            UserImage.Location = new Point(237, 12);
            UserImage.Name = "UserImage";
            UserImage.Size = new Size(156, 151);
            UserImage.SizeMode = PictureBoxSizeMode.StretchImage;
            UserImage.TabIndex = 9;
            UserImage.TabStop = false;
            // 
            // LogoutButton
            // 
            LogoutButton.ForeColor = Color.IndianRed;
            LogoutButton.Location = new Point(237, 169);
            LogoutButton.Name = "LogoutButton";
            LogoutButton.Size = new Size(156, 27);
            LogoutButton.TabIndex = 10;
            LogoutButton.Text = "Logout";
            LogoutButton.UseVisualStyleBackColor = true;
            LogoutButton.Click += LogoutButton_Click;
            // 
            // ExitButton
            // 
            ExitButton.ForeColor = Color.IndianRed;
            ExitButton.Location = new Point(237, 204);
            ExitButton.Name = "ExitButton";
            ExitButton.Size = new Size(156, 27);
            ExitButton.TabIndex = 11;
            ExitButton.Text = "Exit";
            ExitButton.UseVisualStyleBackColor = true;
            ExitButton.Click += ExitButton_Click;
            // 
            // ReturnToSelectionButton
            // 
            ReturnToSelectionButton.Location = new Point(12, 280);
            ReturnToSelectionButton.Name = "ReturnToSelectionButton";
            ReturnToSelectionButton.Size = new Size(204, 28);
            ReturnToSelectionButton.TabIndex = 12;
            ReturnToSelectionButton.Text = "Return To Selections";
            ReturnToSelectionButton.UseVisualStyleBackColor = true;
            ReturnToSelectionButton.Click += ReturnToSelectionButton_Click;
            // 
            // CreateUser
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(424, 322);
            Controls.Add(ReturnToSelectionButton);
            Controls.Add(ExitButton);
            Controls.Add(LogoutButton);
            Controls.Add(UserImage);
            Controls.Add(SubmitButton);
            Controls.Add(ShowPasswordButton);
            Controls.Add(PasswordInput);
            Controls.Add(UserPasswordLabel);
            Controls.Add(UserEmailInput);
            Controls.Add(UserEmailLabel);
            Controls.Add(UsernameInput);
            Controls.Add(UserNameLabel);
            Controls.Add(TitleLabel);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "CreateUser";
            Text = "Create A User";
            ((System.ComponentModel.ISupportInitialize)UserImage).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label TitleLabel;
        private Label UserNameLabel;
        private TextBox UsernameInput;
        private TextBox UserEmailInput;
        private Label UserEmailLabel;
        private TextBox PasswordInput;
        private Label UserPasswordLabel;
        private Button ShowPasswordButton;
        private Button SubmitButton;
        private PictureBox UserImage;
        private Button LogoutButton;
        private Button ExitButton;
        private Button ReturnToSelectionButton;
    }
}