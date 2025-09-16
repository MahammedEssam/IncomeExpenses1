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
    public partial class Incomes : Form
    {
        public Incomes()
        {
            InitializeComponent();
            Con = new Functions();
            ShowIncomes();
            GetCategories();
        }
        Functions Con;
        private void ShowIncomes()
        {
            string Query = "Select * from IncomeTbl";
            IncomesList.DataSource = Con.GetData(Query);
        }
        private void GetCategories()
        {
            string Query = "Select * from CategoryTbl";
            CatCb.ValueMember = Con.GetData(Query).Columns["Id"].ToString();
            CatCb.DisplayMember = Con.GetData(Query).Columns["Name"].ToString();
            CatCb.DataSource = Con.GetData(Query);
        }
        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (CatCb.SelectedIndex == -1 || DescTb.Text == "" || ItemTb.Text == "" || CostTb.Text == "")
            {
                MessageBox.Show("Missing Data!!!");
            }
            else
            {
                try
                {
                    string Query = "delete from IncomeTbl where Id = {0}";
                    Query = string.Format(Query, Key);
                    Con.SetData(Query);
                    MessageBox.Show("Income Deleted!!!");
                    ClearFields();
                    ShowIncomes();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }
        private void ClearFields()
        {
            CostTb.Text = string.Empty;
            DescTb.Text = string.Empty;
            ItemTb.Text = string.Empty;

        }
        private void AddBtn_Click(object sender, EventArgs e)
        {
            if (CatCb.SelectedIndex == -1 || DescTb.Text == "" || ItemTb.Text == "" || CostTb.Text == "")
            {
                MessageBox.Show("Missing Data!!!");
            }
            else
            {
                try
                {
                    string Item = ItemTb.Text;
                    string Desc = DescTb.Text;
                    int Amount = Convert.ToInt32(CostTb.Text);
                    int Category = Convert.ToInt32(CatCb.SelectedValue.ToString());
                    string IncDate = DateTb.Value.ToString("yyyy-MM-dd");
                    string Query = "insert into IncomeTbl values({0},'{1}', {2}, '{3}', '{4}')";
                    Query = string.Format(Query, Category, Item, Amount, Desc, IncDate);
                    Con.SetData(Query);
                    MessageBox.Show("Income Added!!!");
                    ClearFields();
                    ShowIncomes();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            if (CatCb.SelectedIndex == -1 || DescTb.Text == "" || ItemTb.Text == "" || CostTb.Text == "")
            {
                MessageBox.Show("Missing Data!!!");
            }
            else
            {
                try
                {
                    string Item = ItemTb.Text;
                    string Desc = DescTb.Text;
                    int Amount = Convert.ToInt32(CostTb.Text);
                    int Category = Convert.ToInt32(CatCb.SelectedValue.ToString());
                    string IncDate = DateTb.Value.ToString("yyyy-MM-dd");
                    string Query = "update IncomeTbl set Category = {0},Item = '{1}',Cost = {2},Description = '{3}',DateInc = '{4}' where Id = {5}";
                    Query = string.Format(Query, Category, Item, Amount, Desc, IncDate, Key);
                    Con.SetData(Query);
                    MessageBox.Show("Income Update!!!");
                    ClearFields();
                    ShowIncomes();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }
        int Key;
        private void IncomesList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            CatCb.Text = IncomesList.SelectedRows[0].Cells[1].Value.ToString();
            ItemTb.Text = IncomesList.SelectedRows[0].Cells[2].Value.ToString();
            CostTb.Text = IncomesList.SelectedRows[0].Cells[3].Value.ToString();
            DescTb.Text = IncomesList.SelectedRows[0].Cells[4].Value.ToString();

            if (ItemTb.Text == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(IncomesList.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Dashboard Obj = new Dashboard();
            Obj.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Categories Obj = new Categories();
            Obj.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Expenses Obj = new Expenses();
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
