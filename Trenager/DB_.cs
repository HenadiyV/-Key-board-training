using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq.Mapping;
using System.Data.Linq;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace Trenager
{
    [Table(Name = "LevelSpT")]
    public class LevelSpT
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int Id { get; set; }
        [Column]
        public string Exercise { get; set; }
        [Column]
        public int Mistake { get; set; }
    }

    [Table(Name = "PopytT")]
    public class PopytT
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int Id { get; set; }
        [Column]
        public int Lev_id { get; set; }
        [Column]
        public int User_id { get; set; }
        [Column]
        public int Kol_popyt { get; set; }
        [Column]
        public int Speed { get; set; }
        [Column]
        public int Mistake { get; set; }
        [Column]
        public double Ritm { get; set; }
        [Column]
        public DateTime Datta { get; set; }
    }

    [Table(Name = "UserT")]
    public class UserT
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int Id { get; set; }
        [Column]
        public string Login { get; set; }
        [Column]
        public int Dostup { get; set; }
        [Column]
        public string Password { get; set; }
        [Column]
        public int Progres { get; set; }
        [Column]
        public string Avatar { get; set; }
        [Column]
        public string Name { get; set; }
        [Column]
        public string Email { get; set; }
        
    }

    public static class DB_
    {
        public static string Trenager_Name{ get; set; }
        public static string Hello_ { get; set; }
        public static string Version_Trenager { get; set; }
        private static string path = System.IO.Directory.GetCurrentDirectory();
        private static string str1=path+ @"\TrenDB.mdf";
       // static string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\res\Trenager_temp2\TrenDB.mdf;Integrated Security = True; Connect Timeout = 30";
       // static string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=Z:\StudentsFiles\RPZ\RPZ2\SV3\Trenager_temp2\TrenDB.mdf;Integrated Security=True;Connect Timeout=30";
        static string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename="+str1+";Integrated Security=True;Connect Timeout=30";
        public static int dostup_L { get; private set; }
        public static int user_Id { get; private set; }
        public static int mistake_L { get; private set; }
        public static int long_level { get; private set; }
        public static int work_level { get; set; }


        static DB_ ()
        {
           // DB_.Trenager_Name = "KnopkodaW";
            //DB_.Hello_ = "Здесь могла быть ваша реклама";
            DB_.Version_Trenager = "1.0";
            DB_.work_level = 0;
        }
//добавил 
        public static bool User_on_Baza(string log)
        {
            bool res = false;
            DataContext db = new DataContext(connectionString);
            Table<UserT> users = db.GetTable<UserT>();

            var selectedUsers = from user in users
                                where (user.Login == log )
                                select user;

            UserT Temp = selectedUsers.FirstOrDefault();
            if (selectedUsers.Count() > 0)
            {
                res = true;
            }
            else
            {
                res = false;
            }
            return res;
        }

        public static int chekUser(string log, string pas)
        {
            int res = 0;
            DataContext db = new DataContext(connectionString);
            Table<UserT> users = db.GetTable<UserT>();

            var selectedUsers = from user in users
                                where (user.Login == log && user.Password == pas)
                                select user;

            UserT Temp = selectedUsers.FirstOrDefault();
            if (selectedUsers.Count() > 0)
            {res = Temp.Dostup;
                DB_.dostup_L = res;
                DB_.user_Id = Temp.Id; }
            
            else MessageBox.Show("У доступі відмовленно.");

            //if (res > 0) { DB_.dostup_L = res; DB_.user_Id=Temp.Id; }
            return res;
        }

        public static void NewUserAdd(string nam,string log, string pas, string email_name, string image_file_name)
        {
//Dopil
            DataContext db = new DataContext(connectionString);
            Table<UserT> TU = db.GetTable<UserT>();
            var SelUz = TU.Where(u => u.Login==log );
            if (SelUz.Count()>0) { MessageBox.Show("Користувач "+ log + " вже зареєстрований в системі!"); return; }
            UserT NU = new UserT { Login=log, Password=pas, Dostup=1, Progres=1, Avatar= image_file_name , Email= email_name , Name=nam}; 

            try
            {
                db.GetTable<UserT>().InsertOnSubmit(NU);
                db.SubmitChanges();
                Table<PopytT> PTs = db.GetTable<PopytT>();
                Table<UserT> TU2 = db.GetTable<UserT>();
                UserT NU2 = TU2.Where(u => u.Login==log).First();
                PopytT NP = new PopytT { Lev_id=1, Kol_popyt=1, User_id=NU2.Id, Mistake = 0, Ritm = 0, Speed = 0, Datta = DateTime.Now };
                db.GetTable<PopytT>().InsertOnSubmit(NP);
                db.SubmitChanges();
                //  MessageBox.Show(" Теперь выберите продолжить и зайдите под выбранным именем ");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        public static void N_LevelAdd(string txt, int mis)
        {
            //Dopil
            try
            {
                DataContext db = new DataContext(connectionString);
                Table<LevelSpT> TU = db.GetTable<LevelSpT>();
                int maxId = TU.Max(u => u.Id);
                maxId++;
                LevelSpT NU = new LevelSpT { Exercise=txt, Mistake=mis }; 
                db.GetTable<LevelSpT>().InsertOnSubmit(NU);
                db.SubmitChanges();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        public static List<LevelSpT> SetLevesTab ()
        {
            DataContext db = new DataContext(connectionString);
            int max_lev = db.GetTable<UserT>().Where(u => u.Id == DB_.user_Id).Select(t => t.Progres).Single();
            List<LevelSpT> AD_ = db.GetTable<LevelSpT>().Where( u=> u.Id <= max_lev).ToList();
            return AD_;
        }

        public static List<LevelSpT> SetLevesAdm()
        {
            DataContext db = new DataContext(connectionString);
            //int max_lev = db.GetTable<UserT>().Where(u => u.Id == DB_.user_Id).Select(t => t.Progres).Single();
            List<LevelSpT> AD_ = db.GetTable<LevelSpT>().ToList();
            return AD_;
        }

        public static void DelLev(int i)
        {
            DataContext db = new DataContext(connectionString);
            var lev = db.GetTable<LevelSpT>().OrderByDescending(u => u.Id == i).FirstOrDefault();
            if (lev != null)
            {
                db.GetTable<LevelSpT>().DeleteOnSubmit(lev);
                db.SubmitChanges();
            }
        }

        public static string Load_Level()
        {
            string temp="";
            DataContext db = new DataContext(connectionString);
            Table<LevelSpT> LU = db.GetTable<LevelSpT>();
            Table<UserT> TU2 = db.GetTable<UserT>();
            UserT NU2 = TU2.Where(u => u.Id == DB_.user_Id).First();
            int findlevel=NU2.Progres;
            if (DB_.work_level != 0) findlevel = DB_.work_level;
            else { DB_.work_level = 1; }
            LevelSpT TL = LU.Where(u => u.Id == findlevel).First();
            temp = TL.Exercise;
            DB_.long_level = temp.Length;
            DB_.mistake_L = TL.Mistake;
            Table<PopytT> PT = db.GetTable<PopytT>();
            var last = PT.Where(u => u.Lev_id == findlevel && u.User_id == DB_.user_Id);
            if (last.Count() == 0)
            {
                PopytT t_p = new PopytT { Lev_id = findlevel, User_id = DB_.user_Id, Kol_popyt=1, Mistake = 0, Ritm = 0, Speed = 0, Datta = DateTime.Now };
                db.GetTable<PopytT>().InsertOnSubmit(t_p);
                db.SubmitChanges();
            }
            else
            {
                int kp = last.Max(u => u.Kol_popyt); kp++;
                PopytT t_p = new PopytT { Lev_id = findlevel, User_id = DB_.user_Id, Kol_popyt=kp, Mistake = 0, Ritm = 0, Speed = 0, Datta = DateTime.Now };
                db.GetTable<PopytT>().InsertOnSubmit(t_p);
                db.SubmitChanges();
            }
            return temp;
        }

        public static void Wrong_End_Level(int speed, double ritm, int mistake)
        {
            try
            {
                DataContext db = new DataContext(connectionString);
                Table<PopytT> PT = db.GetTable<PopytT>();
                Table<UserT> TU2 = db.GetTable<UserT>();               
                var last = PT.Where(u => u.Lev_id == work_level && u.User_id == DB_.user_Id);
                int kp = last.Max(u => u.Kol_popyt);
                PopytT temp = last.Where(u => u.Kol_popyt == kp).FirstOrDefault();
                temp.Ritm = ritm; temp.Speed = speed; temp.Mistake = mistake; 
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public static void Good_End_Level(int speed, double ritm, int mistake)
        {
            try
            {
                DataContext db = new DataContext(connectionString);
                Table<PopytT> PT = db.GetTable<PopytT>();
                Table<UserT> TU2 = db.GetTable<UserT>();
                var last = PT.Where(u => u.Lev_id == work_level && u.User_id == DB_.user_Id);
                int kp = last.Max(u => u.Kol_popyt);
                PopytT temp = last.Where(u => u.Kol_popyt == kp).FirstOrDefault();
                temp.Ritm = (double)ritm;
                temp.Speed = speed;
                temp.Mistake = mistake;
                db.SubmitChanges();
                int i = DB_.work_level + 1;
                 //Set_Work_Level(i); //Stabilnost!!!
                //{
                DB_.work_level = i;
                Table<LevelSpT> LU = db.GetTable<LevelSpT>();
                int LUmax = LU.Max(u => u.Id);
                if (LUmax < i) { MessageBox.Show("ALL LEVELS ARE COMPLETE!!! CONGRATULATIONS!!! Do you want train again?"); DB_.work_level = 1; return; }
                var LJ = LU.Where(u => u.Id >= i);
                foreach (LevelSpT II in LJ)
                    if (II.Id >= i) { DB_.work_level = II.Id; break; }
                
               // }
                UserT NU3 = TU2.Where(u => u.Id == DB_.user_Id).First();
                if (NU3.Progres < DB_.work_level)
                {
                    NU3.Progres = DB_.work_level;
                    db.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        public static void Set_Work_Level(int i)
        {
            DataContext db = new DataContext(connectionString);
            DB_.work_level = i;
            Table<LevelSpT> LU = db.GetTable<LevelSpT>();
            int LUmax = LU.Max(u => u.Id);
            if (LUmax<i) { MessageBox.Show("ALL LEVELS ARE COMPLETE!!! CONGRATULATIONS!!!"); return; }
            var LJ = LU.Where(u => u.Id >=i);
            foreach (LevelSpT II in LJ)
                if (II.Id >= i) { DB_.work_level = II.Id; return; } // break;
        }

        public static string Image_get_U()
        {
           // DELETE?!
            try
            {
                DataContext db = new DataContext(connectionString);
                Table<UserT> TU = db.GetTable<UserT>();
                UserT NU = TU.Where(t => t.Id == DB_.user_Id).First();
                if (NU.Avatar != null)
                {
                    return NU.Avatar;               
                }
                
            }
            catch(Exception ex)
            { 
                return null; 
            }
            return null;
        }

        public static LevelSpT Edit_Level_p1(int i)
        {
            DataContext db = new DataContext(connectionString);
            LevelSpT temp = db.GetTable<LevelSpT>().Where(u => u.Id == i).FirstOrDefault();
            MessageBox.Show(temp.Mistake.ToString());
            return temp;
        }

        public static void Ed_Lev_p2(LevelSpT CL)
        {
            try
            {
                DataContext db = new DataContext(connectionString);
                LevelSpT temp = db.GetTable<LevelSpT>().Where(u => u.Id == CL.Id).FirstOrDefault();
                temp.Exercise = CL.Exercise; temp.Mistake = CL.Mistake;
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

    }
}
