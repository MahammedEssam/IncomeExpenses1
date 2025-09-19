using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IncomeExpenses
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            UNameTb.Text = "Admin123";
            PasswordTb.Text = "Admin";
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            if (UNameTb.Text == "" || PasswordTb.Text == "")
            {
                MessageBox.Show("Missing Data!!!");
            } 
            else if (UNameTb.Text == "Admin123" && PasswordTb.Text == "Admin")
            {
                Dashboard Obj = new Dashboard();
                Obj.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Wrong Credentials!!!");
            }
        }
    }
}
