using DashBuddy.API;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SimpleTumblr.NET
{
    public partial class Form1 : Form
    {
        private string PhotoFile { get; set; }
        private KeyValuePair<string, string> LoginDetails { get; set; }

        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (key.Text.Length == 0 || secret.Text.Length == 0)
            {
                MessageBox.Show("Enter app details");
                return;
            }

            OAuth.ConsumerKey = key.Text;
            OAuth.ConsumerSecret = secret.Text;
            loginSettings.Enabled = true;
        }

        private void login_Click(object sender, EventArgs e)
        {
            if (email.Text.Length == 0 || pwd.Text.Length == 0)
            {
                MessageBox.Show("Enter login details");
                return;
            }

            try
            {
                LoginDetails = OAuth.XAuthAccess(email.Text, pwd.Text);
                photoSettings.Enabled = true;
                token.Text = LoginDetails.Key;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void Submit_Click_1(object sender, EventArgs e)
        {
            if (PhotoFile.Length == 0)
            {
                MessageBox.Show("Select Photo");
                return;
            }

            try
            {
            var prms = new Dictionary<string, object>();

            prms.Add("type", "photo");
            prms.Add("caption", caption.Text);
            prms.Add("data[0]", System.IO.File.ReadAllBytes(PhotoFile));

            var postUrl = string.Format("http://api.tumblr.com/v2/blog/{0}.tumblr.com/post",blogName.Text);
            photoResult.Text = OAuth.OAuthData(postUrl, "POST", LoginDetails.Key, LoginDetails.Value, prms);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            using (var openFile = new OpenFileDialog())
            {
                if (openFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    photoName.Text = System.IO.Path.GetFileName(openFile.FileName);
                    PhotoFile = openFile.FileName;
                }
            }
        }
    }
}
