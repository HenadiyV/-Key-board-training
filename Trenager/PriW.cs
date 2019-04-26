using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Trenager
{
    public partial class PriW : Form
    {
        bool passw_user = false;
        bool cl = false;
        public PriW()
        {
            InitializeComponent();

            label3.Text = "v " + DB_.Version_Trenager.ToString();
            
        }
        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void Ok__Click(object sender, EventArgs e)
        {
             int temp = DB_.chekUser(textBox1.Text, textBox2.Text);
             if (temp>0 && temp<3)
             {
                 timer1.Start();
                 GoNext.Visible = true;
                // IconADD.Visible = true;
                 //this.Close();
             }

            else  if (temp == 3)
             {
             f_admin_Click(sender, e);

             }
             else
                 Help_Click(sender, e);

        }     

        private void Help_Click(object sender, EventArgs e)
        {
                if (passw_user == false)
            {
                
           
            var mbResult = MessageBox.Show("Ти тут вперше. Бажаєш зареєструватись? ", "", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

            if (mbResult == DialogResult.Yes)
            {
                    RegistrationForm r_f = new RegistrationForm();
                    r_f.ShowDialog();
                    this.Close();
            }
            else if (mbResult == DialogResult.No)
            {
                MessageBox.Show("Дозустрічі ;)");
                Application.Exit();
            }
            else if (mbResult == DialogResult.Cancel)
            {
               
            }
            }
            else
            {
                var mbResult = MessageBox.Show("Для відновлення паролю.Зверніться до адмірістратора або переєструватись ", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (mbResult == DialogResult.Yes)
                {
                    RegistrationForm r_f = new RegistrationForm();
                    r_f.ShowDialog();
                    this.Close();
                }
                else if (mbResult == DialogResult.No)
                {
                    MessageBox.Show("Дозустрічі ;)");
                    Application.Exit();
                }
                
            }
            // Help.ShowHelp(this, "Кнопкодав.chm");
            /*
                Process SysInfo = new Process();
                SysInfo.StartInfo.ErrorDialog = true;
               // SysInfo.StartInfo.FileName = @"D:\res\Trenager_temp2\help.chm";
                SysInfo.StartInfo.FileName = @"Z:\StudentsFiles\RPZ\RPZ2\SV3\Trenager_temp2\help.chm";              
                SysInfo.Start();
            */
        }
        private void f_admin_Click(object sender, EventArgs e)
        {
            AdmFor fr = new AdmFor();
            fr.ShowDialog();
        }
        private void IconADD_Click(object sender, EventArgs e)
        {
            textBox2.Visible = true;

        }
        private void GoNext_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            
            if (cl == false)
            { 
            GoNext.BackColor = Color.Coral;
                cl = !cl;
            }
            else
            {
                GoNext.BackColor = Color.Red;
                cl = !cl;
            }
        }
        private void btHello_Click(object sender, EventArgs e)
        {
            timer2.Stop();
            if (DB_.User_on_Baza(textBox1.Text))
            {
                label2.Text = "Привіт " + textBox1.Text + "  памятаєш секретний ключ ?";
                label2.Visible = true;
                textBox2.Visible = true;
                passw_user = true;
            }
            else Help_Click(sender, e);
        }
        
        private void textBox1_Enter(object sender, EventArgs e)
        {
            textBox1.Clear();
            timer2.Start();
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
           
            textBox2.Clear();
            textBox2.UseSystemPasswordChar = true;
            Ok_.Visible = true;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (cl == false)
            {
               btHello.BackColor = Color.GreenYellow;
                cl = !cl;
            }
            else
            {
                btHello.BackColor = Color.Gold;
                cl = !cl;
            }
        }

        private void PriW_Load(object sender, EventArgs e)
        {
            Exit.Select(); 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, "Справка.chm");
        }
    }
}
