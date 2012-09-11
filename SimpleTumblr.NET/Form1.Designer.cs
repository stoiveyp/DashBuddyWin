namespace SimpleTumblr.NET
{
    partial class Form1
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
            this.appSettings = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.secret = new System.Windows.Forms.TextBox();
            this.key = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.loginSettings = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.blogName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.token = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.pwd = new System.Windows.Forms.TextBox();
            this.email = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.login = new System.Windows.Forms.Button();
            this.photoSettings = new System.Windows.Forms.GroupBox();
            this.photoResult = new System.Windows.Forms.TextBox();
            this.Submit = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.photoName = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.caption = new System.Windows.Forms.TextBox();
            this.appSettings.SuspendLayout();
            this.loginSettings.SuspendLayout();
            this.photoSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // appSettings
            // 
            this.appSettings.Controls.Add(this.button2);
            this.appSettings.Controls.Add(this.secret);
            this.appSettings.Controls.Add(this.key);
            this.appSettings.Controls.Add(this.label2);
            this.appSettings.Controls.Add(this.label1);
            this.appSettings.Location = new System.Drawing.Point(12, 12);
            this.appSettings.Name = "appSettings";
            this.appSettings.Size = new System.Drawing.Size(556, 100);
            this.appSettings.TabIndex = 11;
            this.appSettings.TabStop = false;
            this.appSettings.Text = "App Settings";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(261, 27);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(143, 23);
            this.button2.TabIndex = 11;
            this.button2.Text = "Set Details";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // secret
            // 
            this.secret.Location = new System.Drawing.Point(71, 54);
            this.secret.Name = "secret";
            this.secret.Size = new System.Drawing.Size(169, 20);
            this.secret.TabIndex = 10;
            // 
            // key
            // 
            this.key.Location = new System.Drawing.Point(71, 27);
            this.key.Name = "key";
            this.key.Size = new System.Drawing.Size(169, 20);
            this.key.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "secret";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "key";
            // 
            // loginSettings
            // 
            this.loginSettings.Controls.Add(this.label9);
            this.loginSettings.Controls.Add(this.blogName);
            this.loginSettings.Controls.Add(this.label5);
            this.loginSettings.Controls.Add(this.token);
            this.loginSettings.Controls.Add(this.label7);
            this.loginSettings.Controls.Add(this.pwd);
            this.loginSettings.Controls.Add(this.email);
            this.loginSettings.Controls.Add(this.label3);
            this.loginSettings.Controls.Add(this.label6);
            this.loginSettings.Controls.Add(this.login);
            this.loginSettings.Enabled = false;
            this.loginSettings.Location = new System.Drawing.Point(13, 119);
            this.loginSettings.Name = "loginSettings";
            this.loginSettings.Size = new System.Drawing.Size(555, 110);
            this.loginSettings.TabIndex = 12;
            this.loginSettings.TabStop = false;
            this.loginSettings.Text = "Login Details";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(175, 82);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(61, 13);
            this.label9.TabIndex = 19;
            this.label9.Text = ".tumblr.com";
            // 
            // blogName
            // 
            this.blogName.Location = new System.Drawing.Point(68, 82);
            this.blogName.Name = "blogName";
            this.blogName.Size = new System.Drawing.Size(100, 20);
            this.blogName.TabIndex = 18;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 84);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "blog name";
            // 
            // token
            // 
            this.token.AutoSize = true;
            this.token.Location = new System.Drawing.Point(349, 57);
            this.token.Name = "token";
            this.token.Size = new System.Drawing.Size(10, 13);
            this.token.TabIndex = 16;
            this.token.Text = "-";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(260, 57);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Token";
            // 
            // pwd
            // 
            this.pwd.Location = new System.Drawing.Point(70, 55);
            this.pwd.Name = "pwd";
            this.pwd.PasswordChar = '*';
            this.pwd.Size = new System.Drawing.Size(169, 20);
            this.pwd.TabIndex = 14;
            // 
            // email
            // 
            this.email.Location = new System.Drawing.Point(70, 29);
            this.email.Name = "email";
            this.email.Size = new System.Drawing.Size(169, 20);
            this.email.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "pwd";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(28, 28);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "email";
            // 
            // login
            // 
            this.login.Location = new System.Drawing.Point(260, 29);
            this.login.Name = "login";
            this.login.Size = new System.Drawing.Size(143, 22);
            this.login.TabIndex = 0;
            this.login.Text = "Login";
            this.login.UseVisualStyleBackColor = true;
            this.login.Click += new System.EventHandler(this.login_Click);
            // 
            // photoSettings
            // 
            this.photoSettings.Controls.Add(this.photoResult);
            this.photoSettings.Controls.Add(this.Submit);
            this.photoSettings.Controls.Add(this.label4);
            this.photoSettings.Controls.Add(this.photoName);
            this.photoSettings.Controls.Add(this.button1);
            this.photoSettings.Controls.Add(this.caption);
            this.photoSettings.Enabled = false;
            this.photoSettings.Location = new System.Drawing.Point(13, 235);
            this.photoSettings.Name = "photoSettings";
            this.photoSettings.Size = new System.Drawing.Size(555, 152);
            this.photoSettings.TabIndex = 13;
            this.photoSettings.TabStop = false;
            this.photoSettings.Text = "Photo Post";
            // 
            // photoResult
            // 
            this.photoResult.Location = new System.Drawing.Point(260, 81);
            this.photoResult.Multiline = true;
            this.photoResult.Name = "photoResult";
            this.photoResult.Size = new System.Drawing.Size(289, 65);
            this.photoResult.TabIndex = 16;
            // 
            // Submit
            // 
            this.Submit.Location = new System.Drawing.Point(260, 24);
            this.Submit.Name = "Submit";
            this.Submit.Size = new System.Drawing.Size(143, 23);
            this.Submit.TabIndex = 15;
            this.Submit.Text = "Submit";
            this.Submit.UseVisualStyleBackColor = true;
            this.Submit.Click += new System.EventHandler(this.Submit_Click_1);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Caption";
            // 
            // photoName
            // 
            this.photoName.AutoSize = true;
            this.photoName.Location = new System.Drawing.Point(93, 57);
            this.photoName.Name = "photoName";
            this.photoName.Size = new System.Drawing.Size(10, 13);
            this.photoName.TabIndex = 13;
            this.photoName.Text = "-";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 52);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 12;
            this.button1.Text = "Photo";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // caption
            // 
            this.caption.Location = new System.Drawing.Point(70, 26);
            this.caption.Name = "caption";
            this.caption.Size = new System.Drawing.Size(169, 20);
            this.caption.TabIndex = 11;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(580, 399);
            this.Controls.Add(this.photoSettings);
            this.Controls.Add(this.loginSettings);
            this.Controls.Add(this.appSettings);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Form1";
            this.appSettings.ResumeLayout(false);
            this.appSettings.PerformLayout();
            this.loginSettings.ResumeLayout(false);
            this.loginSettings.PerformLayout();
            this.photoSettings.ResumeLayout(false);
            this.photoSettings.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox appSettings;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox secret;
        private System.Windows.Forms.TextBox key;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox loginSettings;
        private System.Windows.Forms.Button login;
        private System.Windows.Forms.GroupBox photoSettings;
        private System.Windows.Forms.Button Submit;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label photoName;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox caption;
        private System.Windows.Forms.TextBox pwd;
        private System.Windows.Forms.TextBox email;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label token;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox photoResult;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox blogName;
        private System.Windows.Forms.Label label5;
    }
}

