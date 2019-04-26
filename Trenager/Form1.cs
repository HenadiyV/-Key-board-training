using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
using System.Threading;
using System.Data.Linq;
using System.Reflection;

namespace Trenager
{
    public partial class Form1 : Form
    {
        private static string str1 = path + @"\TrenDB.mdf";
        // static string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\res\Trenager_temp2\TrenDB.mdf;Integrated Security = True; Connect Timeout = 30";Z:\StudentsFiles\RPZ\RPZ2\SV3\Trenager_temp2\TrenDB.mdf
        static string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + str1 + ";Integrated Security=True;Connect Timeout=30";
        private static string path = Directory.GetCurrentDirectory();
        private static string name_file = path + @"\Tren.txt";
        string path_image = null;
        Button but = new Button();
        List<Button> ListBut = new List<Button>();
        List<string> myTrenager = new List<string>();
        Color bt_Press = ColorTranslator.FromHtml("#FFFFFF");
        public static int col_simvol = 0;
        public static int S_tim = 0;
        int sek = 0;
        int h = 0;
        int m = 0;
        public static double res = 0.0;
        int index = 0;
        public static int bt_error = -1;  
        bool bt = false;
        int slognost = 0;
        string s_lang = "";
        bool LEng = false;
        bool LRu = false;
        bool LUa = false;
        string temp_Tag = "";
        string tem_s = null;
        bool lesson = false;
        int b_ind = 0;
        int a = 1;
        bool start = false;
        bool flag_Click = false;
        bool pauza = false;
        bool pauz_open_panel = false;
        List<double> mas = new List<double>();
        double ritm=0;
        bool regim = false;     
        string[] bt_nameEnglish = {
            "`","1", "2", "3", "4","5","6","7","8","9","0","-","=","Backspace",
            "Tab","Q","W","E","R","T", "Y", "U", "I", "O", "P","[","]","\\",
            "CapsLk", "A", "S", "D", "F_","G","H","_J","K","L",";", "'","Enter",
            "Shrift","Z","X","C","V","B","N","M",",",".","/","Shrift",
            "Ctrl","Win","Alt"," ","Alt","","Cntrl"};
        string[] bt_nameRu = {
            "Ё","1", "2", "3", "4","5","6","7","8","9","0","-","=","Backspace",
            "Tab","Й","Ц","У","К","Е", "Н", "Г", "Ш", "Щ", "З","Х","Ъ","\\",
            "CapsLk", "Ф", "Ы", "В", "А_", "П","Р","_О","Л","Д","Ж", "Э","Enter",
            "Shrift","Я","Ч","С","М","И","Т","Ь","Б","Ю",".","Shrift",
            "Ctrl","Win","Alt"," ","Alt","","Cntrl"};
        string[] bt_nameUa = {
            "`","1", "2", "3", "4","5","6","7","8","9","0","-","=","Backspace",
            "Tab","Й","Ц","У","К","Е", "Н", "Г", "Ш", "Щ", "З","Х","Ї","\\",
            "CapsLk", "Ф", "І", "В", "А_","П","Р","_О","Л","Д","Ж", "Є","Enter",
            "Shrift","Я","Ч","С","М","И","Т","Ь","Б","Ю",".","Shrift",
            "Ctrl","Win","Alt"," ","Alt","","Cntrl"};//"Oem4",
        string[] bt_teg = {"Oemtilde","D1","D2","D3","D4","D5","D6","D7","D8","D9","D0","OemMinus","Oemplus","Back",
            "Tab","Q","W","E","R","T","Y","U","I","O","P","OemOpenBrackets","Oem6","Oem5",
            "Capital","A","S","D","F","G","H","J","K","L","Oem1","Oem7","Return",
            "ShiftKey","Z","X","C","V","B","N","M","Oemcomma","OemPeriod","OemQuestion","ShiftKey",
            "ControlKey","LWin","Menu","Space","Menu","Apps","ControlKey" };
        protected override bool ProcessDialogKey(Keys keyData)
        { 
            switch (keyData)
            {
                case Keys.Tab:
                    return true;
                default:
                    return base.ProcessDialogKey(keyData);
            }
        }  
        public Form1()
        {
            if (DB_.work_level == 0)
            {
                PriW fr = new PriW();
                fr.ShowDialog();
            }
            InitializeComponent();
            richTextBox1.Focus();
            richTextBox1.Select();
        }
        // button
        public void ButColor(List<Button> but)
        {
            System.Drawing.Color bt_clr = System.Drawing.ColorTranslator.FromHtml("#E1E1E1");
            System.Drawing.Color bt_clrM = System.Drawing.ColorTranslator.FromHtml("#ED1C24");//#FFC8F5
            System.Drawing.Color bt_clrMR = System.Drawing.ColorTranslator.FromHtml("#E9C177");//#FFC8F5

            System.Drawing.Color bt_clrB = System.Drawing.ColorTranslator.FromHtml("#FF7F27");//#23FFC4
            System.Drawing.Color bt_clrBR = System.Drawing.ColorTranslator.FromHtml("#FFA7CD");//#23FFC4

            System.Drawing.Color bt_clrSr = System.Drawing.ColorTranslator.FromHtml("#3AE2CE");//#FEFFA5
            System.Drawing.Color bt_clrSrR = System.Drawing.ColorTranslator.FromHtml("#FFDD00");

            System.Drawing.Color bt_clrUk = System.Drawing.ColorTranslator.FromHtml("#22B14C");//#D2FFFF
            System.Drawing.Color bt_clrUkR = System.Drawing.ColorTranslator.FromHtml("#A349A4");//#EDF903
            System.Drawing.Color bt_clrBig = System.Drawing.ColorTranslator.FromHtml("#00A2E8");//
            for (int i = 0; i < but.Count; i++)
            {
                if (i == 14  || i == 54|| i == 55 || i == 57|| i == 58) but[i].BackColor = bt_clr;// i == 54 ||

                if (i == 0 || i == 15 || i == 16 || i == 29 || i == 28 || i == 41 || i == 42 || i == 53 ) but[i].BackColor = bt_clrM;
                if (i == 12 || i == 13 || i > 24 && i <= 27 || i == 40 || i == 52 || i == 59 || i == 38 || i == 39 || i == 51) but[i].BackColor = bt_clrMR;
                //

                if (i == 1 || i == 2 || i == 16 || i == 30 || i == 42 || i == 45 ) but[i].BackColor = bt_clrB;//|| i == 55
                if (i == 10 || i == 11 || i == 23 || i == 24 || i == 37 || i == 50) but[i].BackColor = bt_clrBR;


                if (i == 3 || i == 4 || i == 17 || i == 31 || i == 43) but[i].BackColor = bt_clrSr;//|| i == 1
                if (i == 8 || i == 9 || i == 22 || i == 36 || i == 49) but[i].BackColor = bt_clrSrR;

                if (i == 5 || i == 6 || i == 18 || i == 19
                    || i == 32 || i == 33 || i == 44 || i == 45 || i == 46) but[i].BackColor = bt_clrUk;

                if (i == 7 || i == 20 || i == 21
                    || i == 34 || i == 35 || i == 47 || i == 48) but[i].BackColor = bt_clrUkR;

                if (i == 56 ) but[i].BackColor = bt_clrBig;//|| i == 57
            }

        }
        public void NameBut(List<Button> n_but, string[] name)
        {
            for (int i = 0; i < n_but.Count; i++)
            {
                n_but[i].Text = name[i];
            }

        }
        public void Klava1()
        {
            System.Drawing.Color bt_clr = System.Drawing.ColorTranslator.FromHtml("#E1E1E1");

            int r = 5;
            Point poz = new Point();
            Button t_bt = new Button();
            int pos = 0;
            poz.X = 5;
            poz.Y = 5;
            int btX = Convert.ToInt32(panel2.Width / (14));//45 54  
           int btY = Convert.ToInt32(panel2.Height / (5)+r);//45 70
            int btD = btX + Convert.ToInt32(btX * 0.45);//65 78
            int sum = 0;

            //первая
            for (int i = 0; i < 14; i++)
            {
                if (i == 13)
                {

                    t_bt = BtCreate(poz, btX, btD, "", bt_teg[i], bt_clr);//bt_name[i]
                    panel2.Controls.Add(t_bt);
                    ListBut.Add(t_bt);
                    poz.X = poz.X + btD + r;
                    //pos = i;
                }
                else
                {

                    t_bt = BtCreate(poz, btX, btX, "", bt_teg[i], bt_clr);//bt_name[i]
                    panel2.Controls.Add(t_bt);
                    ListBut.Add(t_bt);
                    poz.X = poz.X + btX + (r/2);

                }
                pos = i;
                sum += btX + (r / 2);
            } 
            //вторая
            poz.Y = btY;//-(r*2)
            poz.X = 5;
            int ii = pos + 1;
            for (int i = 0; i < 14; i++)
            {
                if (i == 0)
                {

                    t_bt = BtCreate(poz, btX, (btD-2), "", bt_teg[ii], bt_clr);//bt_name[ii]
                    panel2.Controls.Add(t_bt);
                    ListBut.Add(t_bt);
                    poz.X = poz.X + (btD - 2) + (r / 2);
                }
                else
                {
                    string ret = bt_teg[ii].ToString();
                    t_bt = BtCreate(poz, btX, btX, "", bt_teg[ii], bt_clr); //bt_name[ii]
                    panel2.Controls.Add(t_bt);
                    ListBut.Add(t_bt);
                    poz.X = poz.X + btX+ (r / 2);
                }
                ii++;
            }
            //третья
            poz.Y = btY*2;//-(r*5)
            poz.X = 5;
            int iii = ii;
            for (int i = 0; i < 13; i++)
            {
                if (i == 0 || i == 12 && iii < bt_teg.Length)
                {

                    t_bt = BtCreate(poz, btX, (btD+16), "", bt_teg[iii], bt_clr);//bt_name[iii]
                    panel2.Controls.Add(t_bt);
                    ListBut.Add(t_bt);
                    poz.X = poz.X + (btD + 16) + (r / 2);
                }
                else if (iii < bt_teg.Length)
                {


                    t_bt = BtCreate(poz, btX, btX, "", bt_teg[iii], bt_clr);//bt_name[iii]
                    panel2.Controls.Add(t_bt);
                    ListBut.Add(t_bt);
                    poz.X = poz.X + btX + (r / 2);
                }
                iii++;
            }
            //четвертая
            poz.Y = btY * 3 ;//- (r * 8)
            poz.X = 5;
            int iiii = iii;
            for (int i = 0; i < 12; i++)
            {
                if (i == 0 || i == 11 && iiii < bt_teg.Length)
                {

                    t_bt = BtCreate(poz, btX, (btD+btD/2+1), "", bt_teg[iiii], bt_clr);//bt_name[iiii]
                    panel2.Controls.Add(t_bt);
                    ListBut.Add(t_bt);
                    poz.X = poz.X + (btD + btD/2+1) + (r / 2);
                }
                else if (iiii < bt_teg.Length)
                {

                    t_bt = BtCreate(poz, btX, btX, "", bt_teg[iiii], bt_clr);//bt_name[iiii]
                    panel2.Controls.Add(t_bt);
                    ListBut.Add(t_bt);
                    poz.X = poz.X + btX + (r / 2);
                }
                iiii++;
            }
            //пятая
            poz.Y = btY * 4;//-(r*11)
            poz.X = btD/2;
            int iiiii = iiii;
            for (int i = 0; i <= 7; i++)
            {
                if (i == 3)
                {

                    t_bt = BtCreate(poz, btX, (btD*6- btD), "", bt_teg[iiiii], bt_clr);//bt_name[iiiii]
                    panel2.Controls.Add(t_bt);
                    ListBut.Add(t_bt);
                    poz.X = poz.X + (btD * 6 - btD) + (r / 2);
                }
                else if (iiiii < bt_teg.Length)
                {

                    t_bt = BtCreate(poz, btX, btX, "", bt_teg[iiiii], bt_clr);//bt_name[iiiii]
                    panel2.Controls.Add(t_bt);
                    ListBut.Add(t_bt);
                    poz.X = poz.X + btX + (r / 2);
                }
                iiiii++;
            }

        }
        public Button BtCreate(Point poz, int h, int w, string s, string s_tag, Color cl)//#E1E1E1
        {
            Button tb = new Button();
            tb.Location = poz;
            tb.Text = s;
            tb.Width = w;
            tb.Height = h;
            tb.Tag = s_tag;
            tb.BackColor = cl;
            tb.Font = new Font(tb.Font.Name, 12, tb.Font.Style| FontStyle.Bold);
            tb.Visible = true;
            return tb;
        }
 //key
        public bool IndexSimvol(int a, int rr)
        {
            if (a == 1)
            {
                if (rr == 0 || rr < 15 || rr == 25 || rr == 26 || rr == 27 || rr == 28 || rr == 38 || rr == 39 || rr == 40 || rr == 41 || rr == 49 || rr == 50
                  || rr == 51 || rr == 52 || rr == 53 || rr == 54 || rr == 55 || rr == 57 || rr == 58 || rr == 59 || rr == 60)
                    return false;
                else return true;
            }
            if (a == 2)
            {
                if (rr < 15 || rr == 27 || rr == 28 || rr == 40 || rr == 41
                   || rr == 51 || rr == 52 || rr == 53 || rr == 54 || rr == 55 || rr == 57 || rr == 58 || rr == 59 || rr == 60)
                    return false;
                else return true;
            }
            if (a == 3)
            {
                if (rr == 0 || rr < 15 || rr == 27 || rr == 28 || rr == 40 || rr == 41
                   || rr == 51 || rr == 52 || rr == 53 || rr == 54 || rr == 55 || rr == 57 || rr == 58 || rr == 59 || rr == 60)
                    return false;
                else return true;
            }
            if (a == 4)
            {
                if (rr == 60 || rr == 59 || rr == 58 || rr == 57 || rr == 55 || rr == 54 || rr == 53 || rr == 52 || rr == 13 || rr == 28 || rr == 40 || rr == 41 || rr == 14)
                    return false;
                else return true;
            }
            return false;
        }
        public string Tren(int a, int slogn)
        {
            string sim = "";
            int rr = 1;
            Random r = new Random();
            rr = r.Next(60);
            bool flag = true;
            /////первый
            if (a == 1 && slogn == 1)
            {
               
                while(flag)
                {
                    rr = r.Next(60);
                    if (IndexSimvol(1, rr))
                    {
                        index = rr;
                        sim = bt_nameEnglish[index];
                        but.Tag = bt_teg[index];
                        flag=false;
                    }
                }
            }
            if (a == 2 && slogn == 1)
            {
                while (flag)
                {
                    rr = r.Next(60);
                    if (IndexSimvol(2, rr))
                    {
                        index = rr;
                        sim = bt_nameRu[index];
                        but.Tag = bt_teg[index];
                        flag = false;
                    }
                }
            }
            if (a == 3 && slogn == 1)
            {
                while (flag)
                {
                    rr = r.Next(60);
                    if (IndexSimvol(3, rr))
                    {
                        index = rr;
                        sim = bt_nameUa[index];
                        but.Tag = bt_teg[index];
                        flag = false;
                    }
                }
            }
            ////////////////2 уровень
            if (a == 1 && slogn == 2)
            {
                while (flag)
                {
                    rr = r.Next(60);
                    if (IndexSimvol(4, rr))
                    {
                        index = rr;
                        sim = bt_nameEnglish[index];
                        but.Tag = bt_teg[index];
                        flag = false;
                    }
                }
            }
            if (a == 2 && slogn == 2)
            {
                while (flag)
                {
                    rr = r.Next(60);
                    if (IndexSimvol(4, rr))//5
                    {
                        index = rr;
                        sim = bt_nameRu[index];
                        but.Tag = bt_teg[index];
                        flag = false;
                    }
                }
            }
            ////////////////3 уровень
            if (a == 1 && slogn == 3)
            {
                while (flag)
                {
                    rr = r.Next(60);
                    if (IndexSimvol(4, rr))
                    {
                        index = rr;
                        sim = bt_nameEnglish[index];
                        but.Tag = bt_teg[index];
                        flag = false;
                    }
                }
            }
            if (a == 2 && slogn == 2)
            {
                while (flag)
                {
                    rr = r.Next(60);
                    if (IndexSimvol(4, rr))//5
                    {
                        index = rr;
                        sim = bt_nameRu[index];
                        but.Tag = bt_teg[index];
                        flag = false;
                    }
                }
            }
            if (a == 3 && slogn == 3)
            {

                while (flag)
                {
                    rr = r.Next(60);
                    if (IndexSimvol(4, rr))//
                    {
                        index = rr;
                        sim = bt_nameUa[index];
                        but.Tag = bt_teg[index];
                        flag = false;
                    }
                }
            }
            for (int i = 0; i < ListBut.Count; i++)
            {
                if (i == index)
                    label10.BackColor = ListBut[i].BackColor;
            }
            return sim;
        }
//form
        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = DB_.Trenager_Name;
            path_image = new DirectoryInfo("Image").FullName;
           pictureBox5.ImageLocation = path_image + "\\" + DB_.Image_get_U();
            radioButton1.Checked = true;
            btnPauza.Text = "Start";
            slognost = 1;
            s_lang = "English";
            label1.Text = s_lang;
            panel1.BackColor = System.Drawing.ColorTranslator.FromHtml("#FEFFA5");
            panel1.Width = 5;
            panel1.Height = Height;
            panel3.BackColor = System.Drawing.ColorTranslator.FromHtml("#AFEEEE");//#FEFFA5
            panel3.Width = panel2.Width;
            panel3.Height = 5;
            btnPauza.Visible = false;
            lbPanelOpen.Visible = false;
        }
//moi func        
        public void MyFun()
        {
            if (LEng == true)
            {
                label6.Text = Tren(1, slognost);
                label6.ForeColor = (label10.BackColor);
            }

            if (LRu == true)
            {
                label6.Text = Tren(2, slognost);
                label6.ForeColor = (label10.BackColor);
            }

            if (LUa == true)
            {
                label6.Text = Tren(3, slognost);
                label6.ForeColor = (label10.BackColor);
            }

        }
        public bool MynotBukv(string s)
        {
            string[] notBukv = { "`", "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", "-", "=", "[", "]", "\\", ":", "'", ",", ".", "/", " " };
            for (int i = 0; i < notBukv.Length; i++)
            {
                if (notBukv[i].Contains(s) == true)
                    return false;
            }
            return true;
        }
        public void Language(string s)
        {
            int ru = 0;
            int ua = 0;
            int en = 0;
            for (int i = 0; i < s.Length; i++)
            {
                var resUa = bt_nameUa.Where(a => a.Contains(s[i]) == true);
                if (resUa.Count() > 0) ++ua;
                var resRu = bt_nameRu.Where(a => a.Contains(s[i]) == true);
                if (resRu.Count() > 0) ++ru;
                var resEn = bt_nameEnglish.Where(a => a.Contains(s[i]) == true);
                if (resEn.Count() > 0) ++en;
                if (s[i].CompareTo('Ы') == 0|| s[i].CompareTo('Ё') == 0 || s[i].CompareTo('Ъ') == 0) ++ru;
                if (s[i].CompareTo('ы') == 0 || s[i].CompareTo('ё') == 0 || s[i].CompareTo('ъ') == 0) ++ru;
                if (s[i].CompareTo('І') == 0 || s[i].CompareTo('Ї') == 0) ++ua;
                if (s[i].CompareTo('і') == 0 || s[i].CompareTo('ї') == 0) ++ua;
            }
            if (en > ua && en > ru)
            {
                LEng = true;
                NameBut(ListBut, bt_nameEnglish);
                LRu = false;
                LUa = false;
            }
            else if(ua>en&&ua>ru)
            {
                LEng = false;
                LRu = false;
                LUa = true;
                NameBut(ListBut, bt_nameUa);
            }
            else
            {
                LEng =false ;
                LRu = true;
                LUa = false;
                NameBut(ListBut, bt_nameRu);
            }
        }
        public void Start(bool les)
        {
            lbGo.Visible = false;
            pictureBox1.Visible = false;
            pictureBox2.Visible = false;
            pictureBox3.Visible = true;
            pictureBox4.Visible = true;

            if (rbtTime.Checked == true)
            {
                timer3.Interval = 1000;
                timer3.Start(); S_tim = 0;
            }
            if (rbtStatistic.Checked == true)
            {
                timer3.Interval = 1000;
                timer3.Start(); S_tim = 0;
            }
            if (LEng == true)
            {
                Klava1();
                NameBut(ListBut, bt_nameEnglish);
                ButColor(ListBut);
                label6.Text = Tren(1, slognost);
            }
            if (LRu == true)
            {
                Klava1();
                NameBut(ListBut, bt_nameRu);
                ButColor(ListBut);
                label6.Text = Tren(2, slognost);
            }
            if (LUa == true)
            {
                Klava1();
                NameBut(ListBut, bt_nameUa);
                ButColor(ListBut);
                label6.Text = Tren(3, slognost);
            }
            panel3.Size = new Size(panel2.Width, panel5.Height * 3);
            panel8.Visible = false;
            if(les==true)
            {
                textBox1.Select();
            }
            else
            {
                richTextBox1.Select();
            }
        }
//rihcTextBox
        private void richTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            string temp = "";
            if (start == true)
            {
                foreach (Button b in ListBut)
                {
                    if (b.Tag.ToString() == e.KeyCode.ToString())
                    {
                        b.BackColor = bt_Press;
                       temp=b.Text;
                    }
                }

                if (but.Tag.ToString() == e.KeyCode.ToString())
                {
                    bt = true;
                    col_simvol++;
                    mas.Add(ritm);
                    label3.Text = col_simvol.ToString();
                    ritm = 0;
                }
                else bt = false;
                
            }
            else
            {
                MyFun();
            }
            start = true;
            label2.Text =temp;
        }
        private void richTextBox1_KeyUp(object sender, KeyEventArgs e)
        {

            if (bt == false)
            {
                bt_error++;
            }
            else
            {
                ButColor(ListBut);
            
                if (LEng == true)
            {
                label6.Text = Tren(1, slognost);             
                label6.ForeColor = (label10.BackColor);
            }

                if (LRu == true )
                {
                    label6.Text = Tren(2, slognost);      
                    label6.ForeColor = (label10.BackColor);
                }

                if (LUa == true )
                {
                    label6.Text = Tren(3, slognost);
                    label6.ForeColor = (label10.BackColor);
                }   
           }
            label7.Text = bt_error.ToString();
            ButColor(ListBut);
        }
        private void richTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            label3.Text = col_simvol.ToString();
        }
//radioButton slognost
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            slognost = 2;
        }
        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            slognost = 3;
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            slognost = 1;
        }
//timer        
        private void timer2_Tick(object sender, EventArgs e)
        {

            if (panel1.Width == 265)
            {
                timer2.Enabled = false;
                lbPanelOpen.Text = "<<";
            }
            else
            {
                panel1.Width += 20;
            }
            richTextBox1.Focus(); 
            richTextBox1.Select();

        }
        private void timer1_Tick_1(object sender, EventArgs e)
        {
            if (panel1.Width == 5)
            {
                timer1.Enabled = false;
                lbPanelOpen.Text = ">>";
            }
            else
            { panel1.Width -= 20; }
            richTextBox1.Focus(); 
            richTextBox1.Select(); 
        }
        private void timer3_Tick(object sender, EventArgs e)
        {
            sek++;
            S_tim++;
            if (sek == 60)
            {
                m++;
                sek = 0;

            }
            if (m == 60)
            {
                h++;
                m = 0;
            }

             label4.Text = h.ToString() + " " + m.ToString() + " " + sek.ToString();
             double CS = col_simvol;
             CS = CS*60 / S_tim;
             label5.Text = CS.ToString();
           // MyColSimvol(statistika,t,col_simvol);

           if (regim) END_Level( );
        }
        private void timer4_Tick(object sender, EventArgs e)
        {
            ritm = ritm + 0.01;
            if (mas.Count()>0) label14.Text ="Інтервал="+Math.Round( mas.Last(),4).ToString();

            // END_Level();
        }
//label
        private void lbGo_Click(object sender, EventArgs e)
        {
           
            LEng = true;
            panel3.Visible = false;
            panel7.Visible = true;
            lbGo.Visible = false;
            Progress.Visible = false;
            btnPauza.Text = "Пауза";
            btnPauza.Visible = true; 
            pictureBox1.Visible = false;
            pictureBox2.Visible = false;
            pictureBox3.Visible = true;
            pictureBox4.Visible = true;
            label21.Visible = false;

            if (rbtTime.Checked == true)
            {
                timer3.Interval = 1000;
                timer3.Start();
                timer4.Interval = 10;
                timer4.Start();
            }
            
            
               timer3.Interval = 1000;
               timer3.Start();
               timer4.Interval = 10;
               timer4.Start();
            
            if (LEng == true)
            {
                Klava1();
                NameBut(ListBut, bt_nameEnglish);
                ButColor(ListBut);
                label6.Text = Tren(1, slognost);
            }
            if (LRu == true)
            {
                Klava1();
                NameBut(ListBut, bt_nameRu);
                ButColor(ListBut);
                label6.Text = Tren(2, slognost);
            }
            if (LUa == true)
            {
                Klava1();
                NameBut(ListBut, bt_nameUa);
                ButColor(ListBut);
                label6.Text = Tren(3, slognost);
            }
             richTextBox1.Focus();
             richTextBox1.Select();
             panel3.Size = new Size(panel2.Width, panel5.Height * 3);

             MyFun();
        }
        private void lbPanelOpen_Click(object sender, EventArgs e)
        {
            switch (panel1.Width)
            {
                case 5:
                    timer2.Enabled = true;

                    break;
                case 265:
                    timer1.Enabled = true;

                    break;
            }
        }
        private void Progress_Click(object sender, EventArgs e)
        {
            bt_error = 0;
            pauz_open_panel = true;
            lbPanelOpen.Visible = false;
            label21.Visible = false;
            panel3.Visible = false;
            lbGo.Visible = false;
            Progress.Visible = false;
            btnPauza.Text = "Пауза";
            btnPauza.Visible = true;
            panel8.Visible = false;
            panel4.Visible = false;

            pictureBox1.Visible = false;
            pictureBox2.Visible = false;
            pictureBox3.Visible = true;
            pictureBox4.Visible = true;


            timer3.Interval = 1000;
            timer3.Start();
            timer4.Interval = 10;
            timer4.Start();
            ritm = 0;


            label7.Text = bt_error.ToString();
            label3.Text = col_simvol.ToString();

            panel3.Size = new Size(panel2.Width, panel5.Height * 3);

            string fileText = DB_.Load_Level();
            textBox1.Multiline = true;
            textBox1.Text = fileText.ToUpper();
            string d = fileText.Substring(1);
            Language(fileText);
            textBox1.ReadOnly = true;
            textBox1.SelectionStart = 0;
            textBox1.Select(0, 1);
            textBox1.Focus();
            richTextBox1.Visible = false;
            richTextBox1.Enabled = false;
            label6.Text = "";
            label10.BackColor = bt_Press;

            int temX = 0;
            int temY = 0;
            temX = panel5.Bottom;
            temY = ClientSize.Height - panel2.Height - panel5.Height;

            panel3.Location = new Point(panel5.Location.X, panel5.Bottom);//temY - temX 

            panel3.Size = new Size(panel2.Width, panel5.Height + 30);
            panel2.Location = new Point(panel2.Location.X, panel3.Bottom);
            panel3.BackColor = Color.PaleTurquoise;
            panel3.Visible = true;

            lesson = true;
            Language(fileText);
            MyFun();

            richTextBox1.Focus();
            richTextBox1.Select();
            Start(true);
        }
//button
        private void btnGo_Click(object sender, EventArgs e)
        {
            if (!flag_Click)
            {
                flag_Click = !flag_Click;
                timer3.Interval = 1000;
                timer3.Start();
                btnGo.Text = "Stop";
            }
            else
            {
                timer3.Stop();
                btnGo.Text = "Start";
            }
            richTextBox1.Select();
        }
//смена раскладки
        private void btnEngl_Click(object sender, EventArgs e)
        {
            LEng = true;
            LRu = false;
            LUa = false;
            start = false;
            NameBut(ListBut, bt_nameEnglish);
            s_lang = "English";
            label1.Text = s_lang;
            index = 0;
            col_simvol = 0;
            sek = 0;
            S_tim = 0;
            bt_error = 0;
            label3.Text = "";
            label7.Text = "";
            label10.BackColor = Color.White;
            richTextBox1.Select();
        }
        private void btnRu_Click(object sender, EventArgs e)
        {
            s_lang = "Русский";
            label1.Text = s_lang;
            LRu = true;
            LEng = false;
            LUa = false;
            start = false;
            NameBut(ListBut, bt_nameRu);
            richTextBox1.Select();
            index = 0;
            col_simvol = 0;
            bt_error = 0;
            label6.Text = "";
            label3.Text = "";
            label7.Text = "";
            label10.BackColor = Color.White;
            col_simvol = 0;
            sek = 0;
            S_tim = 0;
        }
        private void btnUA_Click(object sender, EventArgs e)
        {
            s_lang = "Українська";
            NameBut(ListBut, bt_nameUa);
            LRu = false;
            LEng = false;
            LUa = true;
            start = false;
            label1.Text = s_lang;
            index = 0;
            col_simvol = 0;
            bt_error = 0;
            label6.Text = "";
            label3.Text = "";
            label7.Text = "";
            label10.BackColor = Color.White;
            richTextBox1.Select();
            col_simvol = 0;
            sek = 0;
            S_tim = 0;
        }
//очистить
        private void btnClear_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            //S_tim = 0;
            richTextBox1.Select();
            rbtStatistic.Checked = false;
            rbtTime.Checked = false;
            panel4.Visible = true;
            label3.Text = "";
            label5.Text = "";
            label7.Text = "";
            label4.Text = "";
        }
//pauza
        private void btnPauza_Click(object sender, EventArgs e)
        {
            if (pauza)
            {
                pauza = !pauza;
                if (pauz_open_panel == false)
                {
                    if (panel1.Width == 265) lbPanelOpen_Click(sender, e);
                lbPanelOpen.Visible = false;
                }
 
                //if (rbtTime.Checked == true || rbtStatistic.Checked == true)
                {
                    timer3.Interval = 1000;
                    timer3.Start();
                    timer4.Interval = 10;
                    timer4.Start();

                }
                pictureBox1.Visible = false;
                pictureBox2.Visible = false;
                
                btnPauza.Text = "Пауза";
            }
            else
            {
               // if (rbtTime.Checked == true || rbtStatistic.Checked == true)
                timer3.Stop();
                timer4.Stop();
                panel4.Visible = true;
                pictureBox1.Visible = true;
                pictureBox2.Visible = true;
                btnPauza.Text = "Продовжити";
                pauza = !pauza;
                if (pauz_open_panel == false)
                    lbPanelOpen.Visible = true;
            }
            richTextBox1.Focus();
            richTextBox1.Select();
             if (lesson) textBox1.Focus();
        }
//режим редактора
        private void button1_Click(object sender, EventArgs e)
        {
            int temX = 0;
            int temY = 0;
            temX = panel5.Bottom;
            temY = ClientSize.Height-panel2.Height;
            panel2.Location = new Point (panel2.Location.X,temY ) ;
            panel3.Location = new Point(panel3.Location.X, temX);
            panel3.Size = new Size(panel2.Width, temY-temX  );
            panel3.BackColor = Color.Coral;
        }
//открыть файл 
        private void button2_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "txt files (*.txt)|*.txt";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            string filename = openFileDialog1.FileName;
            // читаем файл в строку
            string fileText = System.IO.File.ReadAllText(filename);
            textBox1.Multiline = true;
            textBox1.Text= fileText.ToUpper();
            string d = fileText.Substring(1);
            Language(fileText.ToUpper());
            textBox1.ReadOnly = true;
            textBox1.SelectionStart = 0;
            textBox1.Select(0, 1);
            textBox1.Focus();
            richTextBox1.Visible = false;
            richTextBox1.Enabled = false;
            label6.Text = "";
            label10.BackColor = bt_Press;
            int temX = 0;
            int temY = 0;
            temX = panel5.Bottom;
            temY = ClientSize.Height - panel2.Height-panel5.Height;
             panel3.Location = new Point(panel5.Location.X, panel5.Bottom);
            panel3.Size = new Size(panel2.Width, panel5.Height+30);
           panel2.Location = new Point(panel2.Location.X, panel3.Bottom);
            panel3.BackColor = Color.PaleTurquoise;
            panel3.Visible = true;
            lesson = true;
            b_ind = 0;
        }
// Прохождение уроков
        public string goNo(string s)
        {
            string tem = null;
            string t_s = null;
            for (int i = 0; i < bt_teg.Length; ++i)
                {
                if (ListBut[i].Text == "F_" || ListBut[i].Text == "А_") t_s = ListBut[i].Text.Substring(0,1);
                else
                    if (ListBut[i].Text == "_J" || ListBut[i].Text == "_О") t_s = ListBut[i].Text.Substring(1);
                else
                    t_s = ListBut[i].Text;
                if (t_s==s)
                    {
                  tem = ListBut[i].Tag.ToString();
                    temp_Tag= ListBut[i].Tag.ToString();
                    return tem;
                }
                 }
                return null;
        }
        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            ButColor(ListBut);

            if (e.KeyCode == Keys.Enter && tem_s == "\n" || tem_s == "\n\r" || tem_s == "\r")
            {
                e.Handled = true;
                textBox1.Text += Environment.NewLine;
                b_ind += 2;
                a++;
                label6.Text = "";
                textBox1.SelectionStart = textBox1.Text.Length - 1;
                textBox1.ScrollToCaret();
                textBox1.Select(b_ind, a);
            }
            else
            {
                a = 1;
                textBox1.Select(b_ind, a);
            }
            tem_s = textBox1.SelectedText;
            
            label20.Text = textBox1.SelectedText;
           if (goNo(tem_s)!= null )
            {           
                foreach (Button teb in ListBut)
                {
                    if (teb.Tag.ToString() == temp_Tag)
                        label10.BackColor = teb.BackColor;
                }
                label6.Text = textBox1.SelectedText;
                label6.ForeColor = (label10.BackColor);
            }
            temp_Tag = null;
                tem_s = null;
            ButColor(ListBut);
        }
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            ButColor(ListBut);
            textBox1.Select(b_ind, a);
            tem_s = textBox1.SelectedText;
            if (e.KeyCode == Keys.Enter && tem_s == "\n" || tem_s == "\n\r" || tem_s == "\r")
            {
                e.Handled = true;
                textBox1.Text += Environment.NewLine;
                b_ind += 2;
                a++;
                label6.Text = "";
                textBox1.SelectionStart = textBox1.Text.Length - 1;
                textBox1.ScrollToCaret();
                textBox1.Select(b_ind, a);
            }
            else
            {
                a = 1;
                textBox1.Select(b_ind, a);
            }
            tem_s = textBox1.SelectedText;
            if (tem_s!=null&&tem_s.Length > 1)
            { tem_s = tem_s.Substring(1); }
         
            if (goNo(tem_s ) ==e .KeyCode.ToString())
            {
                
                b_ind++;
                foreach (Button teb in ListBut)
                {
                    if (teb.Tag.ToString() == temp_Tag)
                        label10.BackColor = teb.BackColor;
                }
                label6.Text = textBox1.SelectedText;
                label6.ForeColor = (label10.BackColor);
                bt = true;
                col_simvol++;
                mas.Add(ritm);
                label3.Text = col_simvol.ToString();
                ritm = 0;
            }
            else
            { bt = false; bt_error++; label7.Text = bt_error.ToString(); }
       
            foreach (Button b in ListBut)
            {
                if (b.Tag.ToString() == e.KeyData.ToString())
                {
                    b.BackColor = bt_Press;
                }
            }
            if (col_simvol>2) END_Level();
        }       
        private void END_Level()
        {
                if (S_tim == 0) S_tim = 1;
                int sspeed = (col_simvol * 60 / S_tim);              
                double rrrrr =0;
                if (col_simvol>3) rrrrr = ebanui_ritm();
                if (rrrrr >= 0) rrrrr = (1 - rrrrr) * 100;
                if (rrrrr < 0) { rrrrr = 0; } else rrrrr = Math.Round(rrrrr);
                if (bt_error >= DB_.mistake_L)
                {             
                MessageBox.Show("Uroven ne proyden!!!  Швидкість=" + sspeed.ToString() + "симв/мин  ритм= " + rrrrr.ToString()+ "%", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DB_.Wrong_End_Level(sspeed, rrrrr, bt_error);
                var mbResult = MessageBox.Show(" Швидкість = " + sspeed.ToString() + "симв / мин  ритм = " + rrrrr.ToString()+ " % ", "Рівень не завершений.Бажаєте повторити? ", MessageBoxButtons.YesNo, MessageBoxIcon.Error);

                if (mbResult == DialogResult.Yes)
                {
                    textBox1.Clear();
                    S_tim = 0; sek = 0; mas.Clear();
                    label7.Text = "";
                    bt_error = 0;
                    col_simvol = 0;
                    b_ind = 0;
                    string fileText = DB_.Load_Level();
                    Language(fileText);
                    textBox1.Multiline = true;
                    textBox1.Text = fileText.ToUpper();
                }
                else if (mbResult == DialogResult.No)
                {

                    Levels lv = new Levels();
                    lv.ShowDialog();
                    Application.Restart();
                }
                }
                if (col_simvol>= DB_.long_level)
                {
                 MessageBox.Show("GOOD!!!  Скорость=" + sspeed.ToString() + "симв/мин  ритм= " + rrrrr.ToString() + "%");
                    DB_.Good_End_Level(sspeed, rrrrr, bt_error);
                var mbResult = MessageBox.Show("Швидкість=" + sspeed.ToString() + "симв/хв.  ритм= " + rrrrr.ToString() + "%", "Рівень завершенно.Бажаєте продовжити? ",  MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (mbResult == DialogResult.Yes)
                {
                    textBox1.Clear();
                    label7.Text = "";
                    S_tim = 0; sek = 0; mas.Clear();
                    col_simvol = 0;
                    b_ind = 0;
                    bt_error = 0;
                    string fileText = DB_.Load_Level();
                    textBox1.Multiline = true;
                    Language(fileText);
                    textBox1.Text = fileText.ToUpper();
                  
                }

                else if (mbResult == DialogResult.No)

                { 
                    Levels lv = new Levels();
                    lv.ShowDialog();
                    Application.Restart();
                }
                }
        }
 //перегрузка приложения       
        private void button3_Click(object sender, EventArgs e)
        {
            Application.Restart();

        }
/// ///////////
//подсчет ритма
        public double ebanui_ritm()
        {
            if (col_simvol == 0) col_simvol = 1;
            int time = S_tim;
            if (time == 0) { time = 1; mas.Add(0); }
            if (col_simvol == 0) { col_simvol++; mas.Add(0); }
            double rritm = time / col_simvol;
            double rrrrr = 0;
            foreach (double II in mas)
            {
                rrrrr = rrrrr + (Math.Abs(II - rritm) );
            }
            rrrrr = rrrrr / mas.Count / rritm;
            if (rrrrr < 0.0001) rrrrr = 0.0001;
            if (rrrrr > 60) rrrrr = 60;
           // label14.Text = rrrrr.ToString();
            return rrrrr;
        }
//загрузка статистики
        private void label21_Click(object sender, EventArgs e)
        {
            if (DB_.user_Id > 0)
            {
                Levels fr = new Levels(DB_.user_Id);
                fr.ShowDialog();
                DB_.Set_Work_Level(fr.Uroven);
            }
            label21.Text = "Уровень : " + DB_.work_level.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            btnEngl_Click(sender,e);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            btnRu_Click(sender, e);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            btnUA_Click(sender, e);
        }

        /////////////
    }
}





