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

namespace goimon.View
{
    public partial class Add : Form
    {
        goimonEntities db = new goimonEntities();
        public Add()
        {
            InitializeComponent();
        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }
        private void btnOk_Click(object sender, EventArgs e)
        {
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
                    var rs = new Model.Menu()
                    {
                        Food = comboBox2.Text,
                        QuantityofFood = int.Parse(textBox1.Text),
                        PriceofFood = int.Parse(textBox3.Text),
                        Drink = comboBox3.Text,
                        QuantityofDrink = int.Parse(textBox2.Text),
                        PriceofDrink = int.Parse(textBox4.Text),
                        Total = int.Parse(textBox5.Text),
                        ID_Table = ban,
                    };
                    db.Menu.Add(rs);
                    db.SaveChanges();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Chưa nhập số lượng");
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_Click(object sender, EventArgs e)
        {

        }

        private void Add_Load(object sender, EventArgs e)
        {
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

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
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

        private void comboBox2_SelectedIndexChanged_1(object sender, EventArgs e)
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
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
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
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
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
    }
}
