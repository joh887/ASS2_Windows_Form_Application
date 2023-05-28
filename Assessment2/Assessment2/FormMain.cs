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
    public partial class FormMain : Form
    {
        string strUserName;
        string strPassword;
        CLogin cLogin;

        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e) //Load Users from txt file to program
        {
            cLogin = CLogin.GetInstance();
            cLogin.LoadUsers();
        }

        private void btLogin_Click(object sender, EventArgs e)
        {
            FormEdit fmEdit = new FormEdit();
            strUserName = tbUserName.Text;
            strPassword = tbPassword.Text;
            int userType = cLogin.GetUserType(strUserName, strPassword);
            if (userType == 1 || userType == 2)
            {
                fmEdit.Owner = this;
                fmEdit.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Incorrect Username or Password");
            }        
        }

        private void btNewUser_Click(object sender, EventArgs e)
        {
            FormReigister formReigister = new FormReigister();
            formReigister.Owner = this;
            formReigister.Show();
            this.Hide();
        }

        private void btExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FormMain_VisibleChanged(object sender, EventArgs e)
        {
            tbUserName.Text = null;
            tbPassword.Text = null; 
        }
    }
}
