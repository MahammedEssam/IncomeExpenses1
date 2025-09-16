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
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
            Con = new Functions();
        }
        Functions Con;
        private void SumInc()
        {
            string Query = "select Sum(Cost) from IncomeTbl";
            SumInclbl.Text = "RS   " + Con.GetData(Query).Rows[0][0].ToString();
            IncomeYearLbl.Text = "RS   " + Con.GetData(Query).Rows[0][0].ToString();
        }

        private void SumIncToday()
        {
            int TheDay = System.DateTime.Today.Day;
            string Query = "select Sum(Cost) from IncomeTbl where Day(DateInc) = {0}";
            Query = string.Format(Query, TheDay);
            TodayLbl.Text = "RS   " + Con.GetData(Query).Rows[0][0].ToString();
        }

        private void SumExpToday()
        {
            int TheDay = System.DateTime.Today.Day;
            string Query = "select Sum(Cost) from ExpenseTbl where Day(DateExp) = {0}";
            Query = string.Format(Query, TheDay);
            TodayLblExp.Text = "RS   " + Con.GetData(Query).Rows[0][0].ToString();
        }

        private void SumExpYear()
        {
            int TheDay = System.DateTime.Today.Year;
            string Query = "select Sum(Cost) from ExpenseTbl where YEAR(DateExp) = {0}";
            Query = string.Format(Query, TheDay);
            ExpYearLbl.Text = "RS   " + Con.GetData(Query).Rows[0][0].ToString();
        }
        private void SumIncYear()
        {
            int TheDay = System.DateTime.Today.Year;
            string Query = "select Sum(Cost) from IncomeTbl where YEAR(DateInc) = {0}";
            Query = string.Format(Query, TheDay);
            IncomeYearLbl.Text = "RS   " + Con.GetData(Query).Rows[0][0].ToString();
        }
        private void SumIExp()
        {
            string Query = "select Sum(Cost) from ExpenseTbl";
            SumExpLpl.Text = "RS   " + Con.GetData(Query).Rows[0][0].ToString();
            ExpYearLbl.Text = "RS   " + Con.GetData(Query).Rows[0][0].ToString();
        }
        private void Dashboard_Load(object sender, EventArgs e)
        {
            SumInc();
            SumIExp();
            SumIncToday();
            SumExpToday();
            SumExpYear();
            SumIncYear();
        }

        private void IncBtn_Click(object sender, EventArgs e)
        {
            Incomes Obj = new Incomes();
            Obj.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Expenses Obj = new Expenses();
            Obj.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Categories Obj = new Categories();
            Obj.Show();
            this.Hide();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void panel2_MouseClick(object sender, MouseEventArgs e)
        {
            Login Obj = new Login();
            Obj.Show();
            this.Hide();
        }
    }
}
