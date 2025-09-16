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
    public partial class Categories : Form
    {
        public Categories()
        {
            InitializeComponent();
            Con = new Functions();
            ShowCategories();
        }
        Functions Con;
        private void ShowCategories()
        {
            string Query = "Select * from CategoryTbl";
            CategoriesList.DataSource = Con.GetData(Query);
        }
        private void ClearFields()
        {
            CatTb.Text = string.Empty;
            DescTb.Text = string.Empty;
        }
        private void AddBtn_Click(object sender, EventArgs e)
        {
            if (CatTb.Text == "" || DescTb.Text == "")
            {
                MessageBox.Show("Missing Data!!!");
            }
            else
            {
                try
                {
                    string CName = CatTb.Text;
                    string Desc = DescTb.Text;
                    string Query = "insert into CategoryTbl(Name, Description) values('{0}','{1}')";
                    Query = string.Format(Query, CName, Desc);
                    Con.SetData(Query);
                    MessageBox.Show("Category Added!!!");
                    ClearFields();
                    ShowCategories();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }
        int Key = 0;
        private void CategoriesList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            CatTb.Text = CategoriesList.SelectedRows[0].Cells[1].Value.ToString();
            DescTb.Text = CategoriesList.SelectedRows[0].Cells[2].Value.ToString();
            if (CatTb.Text == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(CategoriesList.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            if (CatTb.Text == "" || DescTb.Text == "")
            {
                MessageBox.Show("Missing Data!!!");
            }
            else
            {
                try
                {
                    string CName = CatTb.Text;
                    string Desc = DescTb.Text;
                    string Query = "update CategoryTbl set Name = '{0}', Description = '{1}' where ID = {2}";
                    Query = string.Format(Query, CName, Desc, Key);
                    Con.SetData(Query);
                    MessageBox.Show("Category Updated!!!");
                    ClearFields();
                    ShowCategories();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (CatTb.Text == "" || DescTb.Text == "")
            {
                MessageBox.Show("Missing Data!!!");
            }
            else
            {
                try
                {
                    string CName = CatTb.Text;
                    string Desc = DescTb.Text;
                    string Query = "Delete from CategoryTbl where ID = {0}";
                    Query = string.Format(Query, Key);
                    Con.SetData(Query);
                    MessageBox.Show("Category Deleted!!!");
                    ClearFields();
                    ShowCategories();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Dashboard Obj = new Dashboard();
            Obj.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Incomes Obj = new Incomes();
            Obj.Show();
            this.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
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

        private void label3_Click(object sender, EventArgs e)
        {
            Expenses Obj = new Expenses();
            Obj.Show();
            this.Hide();
        }
    }
}
