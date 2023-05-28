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
    public partial class FormAbout : Form
    {
        CLogin cLog;
        public FormAbout()
        {
            InitializeComponent();
        }

        private void btnOkay_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormAbout_Load(object sender, EventArgs e)
        {
            cLog = CLogin.GetInstance();
            string name = ("User: " + cLog.currentUser.FirstName +" " + cLog.currentUser.LastName);
            label1.Text = name;
            label2.Text = "Version 1.0.0";
            label3.Text = "Developer: Minsoo Joh";

        }
    }
}
