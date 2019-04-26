using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Trenager
{
    public partial class AdmFor : Form
    {

        public AdmFor()
        {
            InitializeComponent();
            dataGridView1.DataSource = DB_.SetLevesAdm();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog2.Filter = "txt files (*.txt)|*.txt";
            openFileDialog2.FilterIndex = 2;
            openFileDialog2.RestoreDirectory = true;
            if (openFileDialog2.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            string filename = openFileDialog2.FileName;
            // читаем файл в строку
            string fileText = System.IO.File.ReadAllText(filename);
            textBox1.Multiline = true;
            textBox1.Text = fileText.ToUpper();
            string d = fileText.Substring(1);
        }

        private void Add_Level_Click(object sender, EventArgs e)
        {
            string temp = textBox1.Text;
            int m=9;
            try
            {
               m = Int32.Parse(textBox2.Text);
            }
            catch { MessageBox.Show("Admin ne tupi!"); }
            DB_.N_LevelAdd(temp, m);
            dataGridView1.DataSource = DB_.SetLevesTab();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int i=0;
            bool result = Int32.TryParse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString(), out i);
            if (result)
            {
                i = Int32.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            }
            else { MessageBox.Show("Выбрать уровень!"); return; }
            DB_.DelLev(i);
            dataGridView1.DataSource = DB_.SetLevesTab();
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                int I = 0;
                I = Int32.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                Edit_lev_but.Visible = true;
                textBox3.Visible = true;
                textBox4.Visible = true;
                DB_.work_level=I;
                LevelSpT temp = DB_.Edit_Level_p1(I);
                textBox4.Text = temp.Exercise;
                textBox3.Text = temp.Mistake.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void Edit_lev_but_Click(object sender, EventArgs e)
        {
            try
            {
                Edit_lev_but.Visible = false;
                textBox3.Visible = false;
                textBox4.Visible = false;
                int I = Int32.Parse(textBox3.Text);
                LevelSpT temp = new LevelSpT { Id = DB_.work_level, Exercise = textBox4.Text, Mistake=I};
                DB_.Ed_Lev_p2(temp);
                DB_.work_level = 0;
            }
            catch (Exception ex)
            { MessageBox.Show(ex.ToString()); }
        }
    }
}
