using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assessment2
{
    public partial class FormLogin : Form
    {
        public FormMain fmMain = new FormMain();
        string str_user_name;
        string str_password;

        public FormLogin()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btLogin_Click(object sender, EventArgs e)
        {
            str_user_name = tbUserName.Text;
            str_password = tbPassword.Text;
            if(str_user_name == "joh" && str_password == "minsoo")
            {
                fmMain.Owner = this;
                fmMain.Show();
                this.Hide();
            }
            
        }

        private void btNewUser_Click(object sender, EventArgs e)
        {

        }

        private void btExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
