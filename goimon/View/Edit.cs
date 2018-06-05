using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using goimon.Model;
using System.Data.Entity;

namespace goimon.View
{
    public partial class Edit : Form
    {
        private int id = 0;
        private bool flag = false;
        goimonEntities db = new goimonEntities();
        public Edit(int ID)
        {
            this.id = ID;
            InitializeComponent();
        }

        private void btnOk_Click_1(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                string ban = "";
                if (comboBox1.Text == "Bàn số 1")
                {
                    ban = "TB1";
                }
                else if (comboBox1.Text == "Bàn số 2")
                {
                    ban = "TB2";
                }
                else if (comboBox1.Text == "Bàn số 3")
                {
                    ban = "TB3";
                }
                else if (comboBox1.Text == "Bàn số 4")
                {
                    ban = "TB4";
                }
                else if (comboBox1.Text == "Bàn số 5")
                {
                    ban = "TB5";
                }
                else if (comboBox1.Text == "Bàn số 6")
                {
                    ban = "TB6";
                }
                var rs = db.Menu.Find(id);
                rs.Food = comboBox2.Text;
                rs.QuantityofFood = int.Parse(textBox1.Text);
                rs.PriceofFood = int.Parse(textBox3.Text);
                rs.Drink = comboBox3.Text;
                rs.QuantityofDrink = int.Parse(textBox2.Text);
                rs.PriceofDrink = int.Parse(textBox4.Text);
                rs.Total = int.Parse(textBox5.Text);
                rs.ID_Table = ban;
                db.Entry(rs).State = EntityState.Modified;
                db.SaveChanges();
                this.Close();
            }
            else
            {
                MessageBox.Show("Chưa nhập số lượng");
            }
        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            if (textBox3.Text != "" && textBox1.Text != "")
            {
                textBox3.Text = (int.Parse(textBox1.Text) * int.Parse(textBox3.Text)).ToString();
            }

            if (textBox3.Text != "" && textBox4.Text != "")
            {
                textBox5.Text = (int.Parse(textBox3.Text) + int.Parse(textBox4.Text)).ToString();
            }

            if (textBox1.Text == "")
            {
                var rs = db.Food.FirstOrDefault(s => s.Name == comboBox2.Text).Price;
                textBox3.Text = rs.ToString();
            }
        }

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {
            if (textBox4.Text != "" && textBox2.Text != "")
            {
                textBox4.Text = (int.Parse(textBox2.Text) * int.Parse(textBox4.Text)).ToString();
            }

            if (textBox3.Text != "" && textBox4.Text != "")
            {
                textBox5.Text = (int.Parse(textBox3.Text) + int.Parse(textBox4.Text)).ToString();
            }
            if (textBox2.Text == "")
            {
                var rs = db.Drink.FirstOrDefault(s => s.Name == comboBox3.Text).Price;
                textBox4.Text = rs.ToString();
            }
        }

        private void comboBox3_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (flag == true)
            {
                var rs = db.Drink.FirstOrDefault(s => s.Name == comboBox3.Text).Price;
                textBox4.Text = rs.ToString();

                if (comboBox3.Text == "Trà sữa")
                {
                    pictureBox2.ImageLocation = Application.StartupPath + "\\Images\\trasua.jpg";
                }
                else if (comboBox3.Text == "Olong")
                {
                    pictureBox2.ImageLocation = Application.StartupPath + "\\Images\\olong.jpg";
                }
                else if (comboBox3.Text == "Aquafina")
                {
                    pictureBox2.ImageLocation = Application.StartupPath + "\\Images\\aquafina.jpeg";
                }
                else if (comboBox3.Text == "Sting")
                {
                    pictureBox2.ImageLocation = Application.StartupPath + "\\Images\\sting.jpeg";
                }
                flag = true;
            }
        }

        private void comboBox2_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (flag == true)
            {
                var rs = db.Food.FirstOrDefault(s => s.Name == comboBox2.Text).Price;
                textBox3.Text = rs.ToString();

                if (comboBox2.Text == "Gà cay")
                {
                    pictureBox1.ImageLocation = Application.StartupPath + "\\Images\\gacay.jpg";
                }
                else if (comboBox2.Text == "Pizza")
                {
                    pictureBox1.ImageLocation = Application.StartupPath + "\\Images\\pizza.jpg";
                }
                else if (comboBox2.Text == "Bánh tráng")
                {
                    pictureBox1.ImageLocation = Application.StartupPath + "\\Images\\banhtrang.jpg";
                }
                else if (comboBox2.Text == "Spagetti")
                {
                    pictureBox1.ImageLocation = Application.StartupPath + "\\Images\\spagetti.jpg";
                }
                flag = true;
            }

        }

        private void Edit_Load(object sender, EventArgs e)
        {
            flag = false;
            var result = db.Table.ToList();
            foreach (var item in result)
            {
                comboBox1.Items.Add(new { Text = item.TableName });
            }

            comboBox1.DisplayMember = "Text";
            comboBox1.ValueMember = "Text";

            var rs = db.Food.ToList();
            foreach (var item in rs)
            {
                comboBox2.Items.Add(new { Text = item.Name });
            }

            comboBox2.DisplayMember = "Text";
            comboBox2.ValueMember = "Text";

            var rs1 = db.Drink.ToList();
            foreach (var item in rs1)
            {
                comboBox3.Items.Add(new { Text = item.Name });
            }

            comboBox3.DisplayMember = "Text";
            comboBox3.ValueMember = "Text";

            var menu = db.Menu.Find(this.id);
            textBox1.Text = menu.QuantityofFood.ToString();
            textBox3.Text = menu.PriceofFood.ToString();
            textBox2.Text = menu.QuantityofDrink.ToString();
            textBox4.Text = menu.PriceofDrink.ToString();
            comboBox2.Text = menu.Food;
            comboBox3.Text = menu.Drink;
            comboBox1.Text = menu.Table.TableName;
            textBox5.Text = menu.Total.ToString();

            if (comboBox3.Text == "Trà sữa")
            {
                pictureBox2.ImageLocation = Application.StartupPath + "\\Images\\trasua.jpg";
            }
            else if (comboBox3.Text == "Olong")
            {
                pictureBox2.ImageLocation = Application.StartupPath + "\\Images\\olong.jpg";
            }
            else if (comboBox3.Text == "Aquafina")
            {
                pictureBox2.ImageLocation = Application.StartupPath + "\\Images\\aquafina.jpeg";
            }
            else if (comboBox3.Text == "Sting")
            {
                pictureBox2.ImageLocation = Application.StartupPath + "\\Images\\sting.jpeg";
            }

            if (comboBox2.Text == "Gà cay")
            {
                pictureBox1.ImageLocation = Application.StartupPath + "\\Images\\gacay.jpg";
            }
            else if (comboBox2.Text == "Pizza")
            {
                pictureBox1.ImageLocation = Application.StartupPath + "\\Images\\pizza.jpg";
            }
            else if (comboBox2.Text == "Bánh tráng")
            {
                pictureBox1.ImageLocation = Application.StartupPath + "\\Images\\banhtrang.jpg";
            }
            else if (comboBox2.Text == "Spagetti")
            {
                pictureBox1.ImageLocation = Application.StartupPath + "\\Images\\spagetti.jpg";
            }
            flag = true;
        }
    }
}