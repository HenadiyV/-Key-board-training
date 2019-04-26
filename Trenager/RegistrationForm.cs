using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Trenager
{
    public partial class RegistrationForm : Form
    {
        string path_image = null;
        string nam_file = null;
       static public bool Result { set; get; }
        private static string path = Directory.GetCurrentDirectory();
        private static string str1 = path + @"\TrenDB.mdf";
        static string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + str1 + ";Integrated Security=True;Connect Timeout=30";
        public RegistrationForm()
        {
            InitializeComponent();
        }
        class Registration
        {
          
            public bool Nam { set; get; }
            public bool Login { set; get; }
            public bool Passw { set; get; }
            public bool Email { set; get; }
           
            public Registration( bool nm, bool log, bool ps, bool em)
            {
               
                Nam = nm;
                Login = log;
                Passw = ps;
                Email = em;
                
            }
        }
        abstract class RegistrationHandler
        {
            public RegistrationHandler Res { set; get; }
            public abstract void Handler(Registration registration);
        }
        
        class Nam_reg : RegistrationHandler
        {
            public override void Handler(Registration registration)
            {
                if (registration.Nam == true)
                {
                    Res.Handler(registration);
                }
                else
                {
                    Res = null;
                    MessageBox.Show(" Ошибка в поле имя");
                }
            }
        }
        class Login_reg : RegistrationHandler
        {
            public override void Handler(Registration registration)
            {
                if (registration.Login == true)
                {
                    Res.Handler(registration);
                }
                else
                {
                    Res = null;
                    MessageBox.Show(" Ошибка  в поле Login");
                }
            }
        }
        class Passw_reg : RegistrationHandler
        {
            public override void Handler(Registration registration)
            {
                if (registration.Passw == true)
                {
                    Res.Handler(registration);
                }
                else
                {
                    Res = null;
                    MessageBox.Show(" Ошибка в поле  пароль");
                }
            }
        }
        class Email_reg : RegistrationHandler
        {
            public override void Handler(Registration registration)
            {
                if (registration.Email == true)
                {
                    Result = true;
                }
                else
                {
                    MessageBox.Show(" Ошибка в поле  email пример(test@test.ua)");
                }
            }
        }
        

        private bool proverkaText(string s)
        {

            if (!String.IsNullOrEmpty(s) )
                return true;
            else return false;
        }
        public bool CorectEmaill(string s)
        {
            char ch = '@';
            char ch1 = '.';
            int i_ch = -1;
            int i_ch1 = -1;
            int ch_schet = 0;

            int ch1_schet = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i].CompareTo(ch) == 0)
                {
                    i_ch = i;
                    ch_schet++;
                }
                if (s[i].CompareTo(ch1) == 0)
                {
                    i_ch1 = i;
                    ch1_schet++;
                }
            }
            if (ch_schet == 1 && ch1_schet == 1 && i_ch > 1 && i_ch1 > i_ch && i_ch1 < s.Length - 1)
                return true;
            return false;
        }
        private void btUserAvatar_Click(object sender, EventArgs e)
        {
            try
            {
                string temp = null;
                string temp1 = null;
                string _path_image = null;
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.InitialDirectory = path_image;
                dlg.Filter = "GIF Files (GIF Files (*.gif)|*.gif*|.jpg|*.jpg";
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
                    nam_file = Path.GetFileName(_path_image);
                   
                }

            }
            catch (Exception ex)
            { MessageBox.Show(ex.ToString()); }
        }

        private void btUserReg_Click(object sender, EventArgs e)
        {
            Registration reg = new Registration(false, false, false, false);

           
            RegistrationHandler nam_reg = new Nam_reg();
            RegistrationHandler login_reg = new Login_reg();
            RegistrationHandler passw_reg = new Passw_reg();
            RegistrationHandler email_reg = new Email_reg();
           
            reg.Nam = proverkaText(textBox1.Text);
            nam_reg.Res = login_reg;

            reg.Login = proverkaText(textBox2.Text); ;
            login_reg.Res = passw_reg;

            reg.Passw = proverkaText(textBox3.Text); ;
            passw_reg.Res = email_reg;
            
            reg.Email = CorectEmaill(textBox4.Text);
            
            nam_reg.Handler(reg);
            if (Result )
            {
                DB_.NewUserAdd(textBox1.Text, textBox2.Text,textBox3.Text,textBox4.Text, nam_file);
                this.Close();
                MessageBox.Show("Реєстрация прошла успішно. Тепер можеш зайти під своїм ніком.");
                //PriW pr = new PriW();
                // pr.ShowDialog();
                //this.Close();
                Application.Restart();
            }
            else
            {
                MessageBox.Show("Спробуй ввести коректні дані для реєстраціі");
                // PriW pr = new PriW();
                // pr.ShowDialog();
            }
        }

        private void RegistrationForm_Load(object sender, EventArgs e)
        {
            path_image = new DirectoryInfo("Image").FullName;
        }

        private void btUserClose_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Вийти ? ", "Реестрація не завершена", MessageBoxButtons.YesNo) == DialogResult.No)

            {
            }

            else
                this.Close();
                //Application.Exit();
           
        }

        private void RegistrationForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)

            {

                if (MessageBox.Show("Завершити ? ", "Додаток припинить роботу ", MessageBoxButtons.YesNo) == DialogResult.No)

                {

                    e.Cancel = true;

                }

                else

                    Application.Exit();

            }


        }
    }
}
