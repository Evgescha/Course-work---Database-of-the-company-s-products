using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Course_work.GTEK.Database_of_the_company_s_products
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent(); 
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            loadData();
            dataGridView2.Sort(dataGridView2.Columns[0],ListSortDirection.Ascending);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }
        private void loadData()
        {
            this.продукцияTableAdapter.Fill(this.databaseDataSet.Продукция);
            this.сортTableAdapter.Fill(this.databaseDataSet.Сорт);
        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Все изменения в системе будут сохранены в базе данных.\r\n" +
                "Продолжить сохранение?",
               "Подтвердите сохранение",
               MessageBoxButtons.YesNo) == DialogResult.Yes)
                try
                {
                    сортTableAdapter.Update(databaseDataSet.Сорт);
                    MessageBox.Show("Изменения сохранены");
                    loadData();
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
       

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Все изменения в системе будут сохранены в базе данных.\r\n" +
                "Продолжить сохранение?",
               "Подтвердите сохранение",
               MessageBoxButtons.YesNo) == DialogResult.Yes)
                try
                {
                    продукцияTableAdapter.Update(databaseDataSet.Продукция);
                    MessageBox.Show("Изменения сохранены");
                    loadData();
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void dataGridView2_DataError(object sender, DataGridViewDataErrorEventArgs e){}

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            if (open.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = new Bitmap(open.FileName);
            }
        }
        // find
        private void button2_Click(object sender, EventArgs e)
        {
            продукцияBindingSource.Filter = "[Название] LIKE'%" + textBox1.Text + "%'";
        }
        // reset
        private void button3_Click(object sender, EventArgs e)
        {
            продукцияBindingSource.Filter = "";
        }
    }
}
