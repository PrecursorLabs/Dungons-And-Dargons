using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Dungons_And_Dargons
{
    public partial class User : Form
    {
        MySqlConnection conn;
        public static string connStr;
        public int PlayerID;
        public string UserName = "User";
        public string PName = "Guy";
        public string Description = "About Guy";
        public Boolean GAMEMASTER = false;
        public int Level = 0;
        public int XP = 0;
        public int xpReq = 0;
        public int Age = 0;
        public int Gold = 0;
        public int HP = 0;
        public int MP = 0;
        public int HPMax = 0;
        public int MPMax = 0;
        public int ATK = 0;
        public int SATK = 0;
        public int DEF = 0;
        public int SDEF = 0;
        public int CHARIS = 0;
        public int DEX = 0;
        public int STR = 0;
        public int INTEL = 0;
        public int PERC = 0;
        public int SATIE = 0;
        public string PlayerOwner;
        private string DBip;
        private string DBpassword;

        public User(string username, string ip, string password)
        {
            UserName = username;
            DBip = ip;
            DBpassword = password;
            connStr = "server=" + DBip + ";user=DBUser;database=dungonsdargons;port=3306;password=" + DBpassword;
            conn = new MySqlConnection(connStr);
            InitializeComponent();
        }

        private void User_Load(object sender, EventArgs e)
        {
            this.FormClosing += new FormClosingEventHandler(User_Closing);
            this.Text = UserName;
            conn.Open();
            GetData();
            if (!GAMEMASTER)
            {
                Main_tabs.TabPages.Remove(GameMaster_tab);
            }

        }




        public void GetData()
        {
            try
            {
                Log_lbox.Items.Add("Grabbing Info");

                string sql = "SELECT idPlayer, GAMEMASTER, PLevel, XP, Age, PName, PDescription, HPMax, HPCur, MPMax, MPCur, ATK, SATK, DEF, SDEF, CHARIS, DEX, STR, INTEL, PERC, Satiety, POwner FROM player WHERE USERNAME='" + UserName + "'";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                int count = 0;
                while (rdr.Read())
                {
                    count++;
                    PlayerID = Convert.ToInt32(rdr[0]);
                    GAMEMASTER = Convert.ToBoolean(rdr[1]);
                    Level = Convert.ToInt32(rdr[2]);
                    XP = Convert.ToInt32(rdr[3]);
                    Age = Convert.ToInt32(rdr[4]);
                    PName = Convert.ToString(rdr[5]);
                    Description = Convert.ToString(rdr[6]);
                    HPMax = Convert.ToInt32(rdr[7]);
                    HP = Convert.ToInt32(rdr[8]);
                    MPMax = Convert.ToInt32(rdr[9]);
                    MP = Convert.ToInt32(rdr[10]);
                    ATK = Convert.ToInt32(rdr[11]);
                    SATK = Convert.ToInt32(rdr[12]);
                    DEF = Convert.ToInt32(rdr[13]);
                    SDEF = Convert.ToInt32(rdr[14]);
                    CHARIS = Convert.ToInt32(rdr[15]);
                    DEX = Convert.ToInt32(rdr[16]);
                    STR = Convert.ToInt32(rdr[17]);
                    INTEL = Convert.ToInt32(rdr[18]);
                    PERC = Convert.ToInt32(rdr[19]);
                    SATIE = Convert.ToInt32(rdr[20]);
                    PlayerOwner = Convert.ToString(rdr[21]);

                }

                Log_lbox.Items.Add("Grabbed Info");
                rdr.Close();
                UpdateInventory();
                UpdateStats();
            }
            catch (Exception ex)
            {
                Log_lbox.Items.Add((ex.ToString()));
            }
        }


        public void UpdateInventory()
        {
            try
            {
                Inventory_lbox.Items.Clear();
                Log_lbox.Items.Add("Grabbing Inventory");
                string sql = "SELECT Items_idWeapons FROM player_has_items WHERE Player_idPlayer=" + PlayerID.ToString();
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                int count = 0;
                List<int> al = new List<int>();
                while (rdr.Read())
                {
                    count++;
                    al.Add(Convert.ToInt32(rdr[0]));
                }
                rdr.Close();
                foreach (int ItemID in al)
                {
                    string sql2 = "SELECT Name FROM items WHERE idWeapons=" + ItemID.ToString();
                    MySqlCommand cmd2 = new MySqlCommand(sql2, conn);
                    MySqlDataReader rdr2 = cmd2.ExecuteReader();
                    while (rdr2.Read())
                    {
                        Inventory_lbox.Items.Add(Convert.ToString(rdr2[0]) + " (ID: <" + ItemID.ToString() +">)");
                    }
                    rdr2.Close();
                }
                Log_lbox.Items.Add("Grabbed Inventory");
            }
            catch (Exception ex)
            {
                Log_lbox.Items.Add((ex.ToString()));
            }
        }


        public void UpdateStats()
        {
            Name_tbox.Text = PName;
            LVL_tbox.Text = Level.ToString();
            XP_tbox.Text = XP.ToString();
            MHP_tbox.Text = HPMax.ToString();
            HP_tbox.Text = HP.ToString();
            MMP_tbox.Text = MPMax.ToString();
            MP_tbox.Text = MP.ToString();
            ATK_tbox.Text = ATK.ToString();
            SATK_tbox.Text = SATK.ToString();
            DEF_tbox.Text = DEF.ToString();
            SDEF_tbox.Text = SDEF.ToString();
            CHAR_tbox.Text = CHARIS.ToString();
            DEX_tbox.Text = DEX.ToString();
            STR_tbox.Text = STR.ToString();
            INT_tbox.Text = INTEL.ToString();
            PERC_tbox.Text = PERC.ToString();
            Satiety_tbox.Text = SATIE.ToString();
        }

        private void UPDATE_btn_Click(object sender, EventArgs e)
        {
            GetData();
        }

        private void Log_lbox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void User_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.FormClosing -= new FormClosingEventHandler(User_Closing);
            conn.Close();
        }

        private void Inventory_lbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Inventory_lbox.SelectedItem != null)
            {
                try
                {
                    string IID = Inventory_lbox.Items[Inventory_lbox.SelectedIndex].ToString().Split('<', '>')[1];
                    Item Iview = new Item(Convert.ToInt32(IID), conn, PName);
                    Iview.Show();
                } catch(Exception ex)
                {

                }
            }
        }

        private void Update_timer_Tick(object sender, EventArgs e)
        {
            UPDATE_btn.PerformClick();
        }

        private void Log_desc_tbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void ten_timer_Tick(object sender, EventArgs e)
        {
            Log_lbox.Items.Clear();
        }
    }
}
