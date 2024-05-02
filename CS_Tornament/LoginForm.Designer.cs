namespace CS_Tornament
{
    partial class LoginForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            LoginFormTitle = new Label();
            UsernameInput = new TextBox();
            PasswordInput = new TextBox();
            UsernameLabel = new Label();
            PasswordLabel = new Label();
            LoginSubmit = new Button();
            ResetSubmit = new Label();
            ExitSubmit = new Label();
            RememberPasswordCheckBox = new CheckBox();
            SuspendLayout();
            // 
            // LoginFormTitle
            // 
            LoginFormTitle.AutoSize = true;
            LoginFormTitle.Font = new Font("Roboto", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LoginFormTitle.Location = new Point(165, 9);
            LoginFormTitle.Name = "LoginFormTitle";
            LoginFormTitle.Size = new Size(147, 63);
            LoginFormTitle.TabIndex = 0;
            LoginFormTitle.Text = "Login";
            // 
            // UsernameInput
            // 
            UsernameInput.Location = new Point(165, 132);
            UsernameInput.Name = "UsernameInput";
            UsernameInput.PlaceholderText = "Username";
            UsernameInput.Size = new Size(250, 23);
            UsernameInput.TabIndex = 1;
            // 
            // PasswordInput
            // 
            PasswordInput.Location = new Point(165, 181);
            PasswordInput.Name = "PasswordInput";
            PasswordInput.PasswordChar = '*';
            PasswordInput.PlaceholderText = "Password";
            PasswordInput.Size = new Size(250, 23);
            PasswordInput.TabIndex = 2;
            PasswordInput.UseSystemPasswordChar = true;
            // 
            // UsernameLabel
            // 
            UsernameLabel.AutoSize = true;
            UsernameLabel.Location = new Point(165, 114);
            UsernameLabel.Margin = new Padding(0);
            UsernameLabel.Name = "UsernameLabel";
            UsernameLabel.Size = new Size(60, 15);
            UsernameLabel.TabIndex = 3;
            UsernameLabel.Text = "Username";
            // 
            // PasswordLabel
            // 
            PasswordLabel.AutoSize = true;
            PasswordLabel.Location = new Point(165, 163);
            PasswordLabel.Margin = new Padding(0);
            PasswordLabel.Name = "PasswordLabel";
            PasswordLabel.Size = new Size(57, 15);
            PasswordLabel.TabIndex = 4;
            PasswordLabel.Text = "Password";
            // 
            // LoginSubmit
            // 
            LoginSubmit.Location = new Point(166, 212);
            LoginSubmit.Name = "LoginSubmit";
            LoginSubmit.Size = new Size(250, 29);
            LoginSubmit.TabIndex = 5;
            LoginSubmit.Text = "Login";
            LoginSubmit.UseVisualStyleBackColor = true;
            LoginSubmit.Click += LoginSubmit_Click;
            // 
            // ResetSubmit
            // 
            ResetSubmit.AutoSize = true;
            ResetSubmit.Location = new Point(348, 243);
            ResetSubmit.Name = "ResetSubmit";
            ResetSubmit.Size = new Size(35, 15);
            ResetSubmit.TabIndex = 6;
            ResetSubmit.Text = "Reset";
            ResetSubmit.Click += ResetSubmit_Click;
            // 
            // ExitSubmit
            // 
            ExitSubmit.AutoSize = true;
            ExitSubmit.ForeColor = Color.IndianRed;
            ExitSubmit.Location = new Point(389, 243);
            ExitSubmit.Name = "ExitSubmit";
            ExitSubmit.Size = new Size(26, 15);
            ExitSubmit.TabIndex = 7;
            ExitSubmit.Text = "Exit";
            ExitSubmit.Click += ExitSubmit_Click;
            // 
            // RememberPasswordCheckBox
            // 
            RememberPasswordCheckBox.AutoSize = true;
            RememberPasswordCheckBox.Location = new Point(165, 242);
            RememberPasswordCheckBox.Name = "RememberPasswordCheckBox";
            RememberPasswordCheckBox.Size = new Size(104, 19);
            RememberPasswordCheckBox.TabIndex = 8;
            RememberPasswordCheckBox.Text = "Remember Me";
            RememberPasswordCheckBox.UseVisualStyleBackColor = true;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(576, 555);
            Controls.Add(RememberPasswordCheckBox);
            Controls.Add(ExitSubmit);
            Controls.Add(ResetSubmit);
            Controls.Add(LoginSubmit);
            Controls.Add(PasswordLabel);
            Controls.Add(UsernameLabel);
            Controls.Add(PasswordInput);
            Controls.Add(UsernameInput);
            Controls.Add(LoginFormTitle);
            Name = "LoginForm";
            Text = "Login";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label LoginFormTitle;
        private TextBox UsernameInput;
        private TextBox PasswordInput;
        private Label UsernameLabel;
        private Label PasswordLabel;
        private Button LoginSubmit;
        private Label ResetSubmit;
        private Label ExitSubmit;
        private CheckBox RememberPasswordCheckBox;
    }
}
