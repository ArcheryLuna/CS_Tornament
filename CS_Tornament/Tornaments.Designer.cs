namespace CS_Tornament
{
    partial class Tornaments
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
            IndividualsButton = new Button();
            TeamsButton = new Button();
            SelectComptitionLabel = new Label();
            LogoutLink = new LinkLabel();
            UserNameLabel = new Label();
            pictureBox1 = new PictureBox();
            ExitLink = new LinkLabel();
            CreateUserButton = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // IndividualsButton
            // 
            IndividualsButton.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            IndividualsButton.Location = new Point(89, 162);
            IndividualsButton.Name = "IndividualsButton";
            IndividualsButton.Size = new Size(300, 100);
            IndividualsButton.TabIndex = 0;
            IndividualsButton.Text = "Individuals";
            IndividualsButton.UseVisualStyleBackColor = true;
            IndividualsButton.Click += IndividualsButton_Click;
            // 
            // TeamsButton
            // 
            TeamsButton.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            TeamsButton.Location = new Point(395, 162);
            TeamsButton.Name = "TeamsButton";
            TeamsButton.Size = new Size(300, 100);
            TeamsButton.TabIndex = 1;
            TeamsButton.Text = "Teams";
            TeamsButton.UseVisualStyleBackColor = true;
            TeamsButton.Click += TeamsButton_Click;
            // 
            // SelectComptitionLabel
            // 
            SelectComptitionLabel.AutoSize = true;
            SelectComptitionLabel.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            SelectComptitionLabel.Location = new Point(89, 40);
            SelectComptitionLabel.Name = "SelectComptitionLabel";
            SelectComptitionLabel.Size = new Size(356, 45);
            SelectComptitionLabel.TabIndex = 2;
            SelectComptitionLabel.Text = "Select the competition";
            // 
            // LogoutLink
            // 
            LogoutLink.AutoSize = true;
            LogoutLink.LinkColor = Color.IndianRed;
            LogoutLink.Location = new Point(743, 426);
            LogoutLink.Name = "LogoutLink";
            LogoutLink.Size = new Size(45, 15);
            LogoutLink.TabIndex = 3;
            LogoutLink.TabStop = true;
            LogoutLink.Text = "Logout";
            LogoutLink.VisitedLinkColor = Color.FromArgb(192, 192, 255);
            LogoutLink.LinkClicked += LogoutLink_LinkClicked;
            // 
            // UserNameLabel
            // 
            UserNameLabel.AutoSize = true;
            UserNameLabel.Location = new Point(46, 426);
            UserNameLabel.Name = "UserNameLabel";
            UserNameLabel.Size = new Size(30, 15);
            UserNameLabel.TabIndex = 4;
            UserNameLabel.Text = "User";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.user_solid;
            pictureBox1.Location = new Point(12, 414);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(28, 27);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
            // 
            // ExitLink
            // 
            ExitLink.AutoSize = true;
            ExitLink.LinkColor = Color.Brown;
            ExitLink.Location = new Point(711, 426);
            ExitLink.Name = "ExitLink";
            ExitLink.Size = new Size(26, 15);
            ExitLink.TabIndex = 6;
            ExitLink.TabStop = true;
            ExitLink.Text = "Exit";
            ExitLink.VisitedLinkColor = Color.FromArgb(192, 192, 255);
            ExitLink.LinkClicked += ExitLink_LinkClicked;
            // 
            // CreateUserButton
            // 
            CreateUserButton.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            CreateUserButton.Location = new Point(89, 268);
            CreateUserButton.Name = "CreateUserButton";
            CreateUserButton.Size = new Size(606, 41);
            CreateUserButton.TabIndex = 8;
            CreateUserButton.Text = "Add A User";
            CreateUserButton.UseVisualStyleBackColor = true;
            CreateUserButton.Click += CreateUserButton_Click;
            // 
            // Tornaments
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(CreateUserButton);
            Controls.Add(ExitLink);
            Controls.Add(pictureBox1);
            Controls.Add(UserNameLabel);
            Controls.Add(LogoutLink);
            Controls.Add(SelectComptitionLabel);
            Controls.Add(TeamsButton);
            Controls.Add(IndividualsButton);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "Tornaments";
            Text = "Select Tornament";
            Load += Tornaments_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button IndividualsButton;
        private Button TeamsButton;
        private Label SelectComptitionLabel;
        private LinkLabel LogoutLink;
        private Label UserNameLabel;
        private PictureBox pictureBox1;
        private LinkLabel ExitLink;
        private Button CreateUserButton;
    }
}