using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Assessment2
{
    public partial class FormReigister : Form
    {
        public FormReigister()
        {
            InitializeComponent();
        }
        private void btSubmit_Click(object sender, EventArgs e)
        {
            CLogin login = CLogin.GetInstance();
            if(tb_password.Text != tb_confirm.Text)
            {
                MessageBox.Show("Password does not match!", "UTS");
                return;
            }
            int user_type = 0;
            if (cbUserType.SelectedItem.ToString() == "View Member") user_type = 1;
            else user_type = 2;
            login.AddUser(tb_username.Text, tb_password.Text, user_type, tb_firstname.Text, tb_lastname.Text, birthdayPicker.Value);
            login.saveOneUser();
            this.Hide();
            this.Owner.Show();
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Owner.Show();
        }


        private void FormReigister_VisibleChanged(object sender, EventArgs e)
        {
            tb_username.Text = null;
            tb_password.Text = null;
            tb_confirm.Text = null;
            tb_firstname.Text = null;
            tb_lastname.Text = null;
            birthdayPicker.Value = DateTime.Now;
            tb_confirm.Text = null;
        }
    }
}
