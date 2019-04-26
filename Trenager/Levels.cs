using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Trenager
{
    public partial class Levels : Form
    {
        int id_user = 2;
        int uroven=1;
        string path_image = null;
        DataContext db = new DataContext(connectionString);
        public Levels()
        {
            InitializeComponent();
        }
        public Levels(int id)
        {
            InitializeComponent();
            id_user =DB_.user_Id;

        }
        public int Uroven { set; get; }
        private static string path = Directory.GetCurrentDirectory();

        private static string str1 = path + @"\TrenDB.mdf";
        // static string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\res\Trenager_temp2\TrenDB.mdf;Integrated Security = True; Connect Timeout = 30";Z:\StudentsFiles\RPZ\RPZ2\SV3\Trenager_temp2\TrenDB.mdf
        static string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + str1 + ";Integrated Security=True;Connect Timeout=30";
 
        private void My(int a)
        {
            try
            {
                DataContext db = new DataContext(connectionString);
                var res = db.GetTable<PopytT>().Where(r => r.Lev_id == a && r.User_id == DB_.user_Id);
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = res;
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[1].Visible = false;
                dataGridView1.Columns[2].Visible = false;
            }
            catch (Exception ex)
            { ex.ToString(); }
        }
      
        private void Levels_Load(object sender, EventArgs e)
        {
            path_image = new DirectoryInfo("Image").FullName;
            DataContext db1 = new DataContext(connectionString);
            var put = db1.GetTable<UserT>().Where(s => s.Id == DB_.user_Id).FirstOrDefault();
            pictureBox1.ImageLocation = path_image+"\\"+ put.Avatar;
            lbLogin.Text = put.Login;
            lbName.Text = put.Name;
            lbEmail.Text = put.Email;
            Point poz = new Point {  X = 0, Y = 15 };
            DataContext db = new DataContext(connectionString);
            comboBox1.DataSource = DB_.SetLevesTab();
            comboBox1.ValueMember = "Id";
            comboBox1.DisplayMember = "Id";           
        }

        private void btLoadLevel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Levels_FormClosed(object sender, FormClosedEventArgs e)
        {
            Uroven = uroven;
        }

        private void btCloseStatistik_Click(object sender, EventArgs e)
        {
            //DataContext db = new DataContext(connectionString);
            //var m_level = db.GetTable<UserT>().Max(s => s.Progres);
            int I = 1;
            if (comboBox1.SelectedItem != null)
                try
                { 
                    string s = comboBox1.Text;
                    I = Int32.Parse(s);
                }
                catch (Exception ex) { ex.ToString(); }
            uroven = I;
            Close();
        }

        private void btAddAvatar_Click(object sender, EventArgs e)
        {
            try { 
            string temp = null;
            string temp1 = null;
            string _path_image = null;
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.InitialDirectory = path_image;
                dlg.Filter = " GIF Files(*.gif) | *.gif|JPG Files (*.jpg) | *.jpg";
            dlg.Title = "Виберіть зображення";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    _path_image = dlg.FileName.ToString();
                    pictureBox1.ImageLocation = _path_image;
                    temp = path_image + "\\" + Path.GetFileName(_path_image);
                    temp1 = Path.GetFullPath(_path_image);
                    if ((temp1.ToUpper()).CompareTo(temp.ToUpper()) != 0)
                    {
                        FileInfo f = new FileInfo(_path_image);
                        f.CopyTo(temp, true);
                    }
                    DataContext db = new DataContext(connectionString);
                    var us = db.GetTable<UserT>().Where(s => s.Id == DB_.user_Id).FirstOrDefault();
                    us.Avatar = Path.GetFileName(_path_image); //_path_image.ToString();
                    db.SubmitChanges();
                }
                
            }
            catch (Exception ex)
            { MessageBox.Show(ex.ToString()); }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            int I=1;
            if (comboBox1.SelectedItem != null)
                try
                { //MessageBox.Show(comboBox1.SelectedValue.ToString());
                    string s = comboBox1.Text;
                    I = Int32.Parse(s); }
                catch (Exception ex) { ex.ToString(); }
            else return;
            My(I);
            uroven = I;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, "Справка.chm");
        }
    }
    }
