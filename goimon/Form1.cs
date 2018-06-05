using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace goimon
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            View.Add frm = new View.Add();
            frm.ShowDialog();
            load_form();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var id = (int)dataGridView1.SelectedRows[0].Cells[8].Value;
            View.Edit frm = new View.Edit(id);
            frm.ShowDialog();
            load_form();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                var id = (int)dataGridView1.SelectedRows[0].Cells[8].Value;
                var db = new quanlygoimonEntities();
                var menu = db.Menu.Find(id);
                db.Menu.Remove(menu);
                db.SaveChanges();
                load_form();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            load_form();
        }
        public void load_form()
        {
            quanlygoimonEntities db = new quanlygoimonEntities();
            var ra = db.Menu;
            var rb = db.Table;
            dataGridView1.DataSource = (from a in ra join b in rb on a.ID_Table equals b.ID select new { b.TableName, a.Food, a.QuantityofFood, a.PriceofFood, a.Drink, a.QuantityofDrink, a.PriceofDrink, a.Total, a.ID }).ToList();
            //dataGridView1.Columns[0].Visible=  false;
            //dataGridView1.Columns[9].Visible = false;
            dataGridView1.Columns[8].Visible = false;

            dataGridView1.Columns[0].HeaderText = "Bàn";
            dataGridView1.Columns[1].HeaderText = "Món ăn";
            dataGridView1.Columns[2].HeaderText = "Số lượng";
            dataGridView1.Columns[3].HeaderText = "Giá";
            dataGridView1.Columns[4].HeaderText = "Đồ uống";
            dataGridView1.Columns[5].HeaderText = "Số lượng";
            dataGridView1.Columns[6].HeaderText = "Giá";
            dataGridView1.Columns[7].HeaderText = "Tổng cộng";
        }
    }
}
