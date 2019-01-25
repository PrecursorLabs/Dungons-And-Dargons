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
        private string DBip;
        private string DBpassword;

        NPC MyPlayer;

        public User(string username, string ip, string password)
        {
            DBip = ip;
            DBpassword = password;
            connStr = "server=" + DBip + ";user=DBUser;database=dungonsdargons;port=3306;password=" + DBpassword;
            conn = new MySqlConnection(connStr);
            InitializeComponent();
            conn.Open();
            MyPlayer = new NPC(conn);
            MyPlayer.UserName = username;
            MyPlayer.GetData();
            MyPlayer.GetInventory();
        }

        private void User_Load(object sender, EventArgs e)
        {
            this.FormClosing += new FormClosingEventHandler(User_Closing);
            this.Text = MyPlayer.UserName;
            UpdateDisplay();
            if (!MyPlayer.GAMEMASTER) Main_tabs.TabPages.Remove(GameMaster_tab);
        }


        public void UpdateDisplay()
        {
            Name_tbox.Text = MyPlayer.PName;
            LVL_tbox.Text = MyPlayer.Level.ToString();
            XP_lbl.Text = "XP: " + MyPlayer.XP.ToString() + "/" + MyPlayer.XPREQ.ToString();
            HP_lbl.Text = "HP: " + MyPlayer.HP.ToString() + "/" + MyPlayer.HPMax.ToString();
            MP_lbl.Text = "MP: " + MyPlayer.MP.ToString() + "/" + MyPlayer.MPMax.ToString();
            ATK_tbox.Text = MyPlayer.ATK.ToString();
            SATK_tbox.Text = MyPlayer.SATK.ToString();
            DEF_tbox.Text = MyPlayer.DEF.ToString();
            SDEF_tbox.Text = MyPlayer.SDEF.ToString();
            CHAR_tbox.Text = MyPlayer.CHARIS.ToString();
            DEX_tbox.Text = MyPlayer.DEX.ToString();
            STR_tbox.Text = MyPlayer.STR.ToString();
            INT_tbox.Text = MyPlayer.INTEL.ToString();
            PERC_tbox.Text = MyPlayer.PERC.ToString();
            Satiety_tbox.Text = MyPlayer.SATIE.ToString();
            Gold_tbox.Text = MyPlayer.Gold.ToString();

            HP_pbar.Maximum = MyPlayer.HPMax;
            HP_pbar.Value = MyPlayer.HP;

            MP_pbar.Maximum = MyPlayer.MPMax;
            MP_pbar.Value = MyPlayer.MP;
            XP_pbar.Maximum = MyPlayer.XPREQ;
            XP_pbar.Value = MyPlayer.XP;
            Inventory_lbox.Items.Clear();

            HP_pbar.ForeColor = Color.LawnGreen;

            if (MyPlayer.HP < MyPlayer.HPMax / 2)
            {
                HP_pbar.ForeColor = Color.Yellow;
            }

            if (MyPlayer.HP < MyPlayer.HPMax / 4)
            {
                HP_pbar.ForeColor = Color.Red;
            }

            foreach (string item in MyPlayer.Inventory)
            {
                Inventory_lbox.Items.Add(item);
            }
            Update_Item_Pool();

        }

        private void Update_Item_Pool()
        {
            try
            {
                string sql = "SELECT idItems FROM items";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                List<int> al = new List<int>();
                while (rdr.Read())
                {
                    al.Add(Convert.ToInt32(rdr[0]));
                }
                rdr.Close();
                EditorItems_lbox.Items.Clear();
                foreach (int ItemID in al)
                {
                    string sql2 = "SELECT Name FROM items WHERE idItems=" + ItemID.ToString();
                    MySqlCommand cmd2 = new MySqlCommand(sql2, conn);
                    MySqlDataReader rdr2 = cmd2.ExecuteReader();
                    while (rdr2.Read())
                    {
                        EditorItems_lbox.Items.Add(Convert.ToString(rdr2[0]) + " (ID: <" + ItemID.ToString() + ">)");
                    }
                    rdr2.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void UPDATE_btn_Click(object sender, EventArgs e)
        {
            MyPlayer.GetData();
            MyPlayer.GetInventory();
            UpdateDisplay();
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
                string IID = Inventory_lbox.Items[Inventory_lbox.SelectedIndex].ToString().Split('<', '>')[1];
                Item Iview = new Item(Convert.ToInt32(IID), conn, MyPlayer.PName);
                Iview.Show();
            }
        }

        private void Update_timer_Tick(object sender, EventArgs e)
        {
            UPDATE_btn.PerformClick();
        }

        private void NItem_editor_btn_Click(object sender, EventArgs e)
        {
            try
            {
                string NItem_Consumable = "0";
                string NItem_Healing = "0";
                string NItem_Artifact = "0";
                string NItem_Weapon = "0";
                string NItem_Helmet = "0";
                string NItem_Maille = "0";
                string NItem_Gloves = "0";
                string NItem_Pants = "0";
                string NItem_Boots = "0";
                switch (Item_type_editor_cbox.SelectedItem)
                {
                    case "HealthPotion":
                        NItem_Healing = "1";
                        NItem_Consumable = "1";
                        HP_editor_ud.Value = 1;
                        break;
                    case "ManaPotion":
                        NItem_Healing = "1";
                        NItem_Consumable = "1";
                        MP_editor_ud.Value = 1;
                        break;
                    case "Consumable":
                        NItem_Consumable = "1";
                        break;
                    case "Artifact":
                        NItem_Artifact = "1";
                        break;
                    case "Weapon":
                        NItem_Weapon = "1";
                        break;
                    case "Helmet":
                        NItem_Helmet = "1";
                        break;
                    case "Maille":
                        NItem_Maille = "1";
                        break;
                    case "Gloves":
                        NItem_Gloves = "1";
                        break;
                    case "Pants":
                        NItem_Pants = "1";
                        break;
                    case "Boots":
                        NItem_Boots = "1";
                        break;
                    case "Miscellaneous":
                        break;
                }

                string sql = "INSERT INTO `items`" +
                    " (`Name`, `Description`, `Dice`, `M_HP`, `M_MP`, `M_ATK`, `M_SATK`, `M_DEF`, `M_SDEF`, `M_CHAR`, `M_DEX`, `M_STR`, `M_INT`, `M_PERC`" +
                    ", `Weapon`, `Consumable`, `Helm`, `Maille`, `Gloves`, `Pants`, `boot`, `Artifact`, `Healing`, `Satiety`, `Equipped`, `Turns`, `Quantity`, `Enhance`, `Durability`, `MaxDurability`, `Tier`, `Grade`)" +
                    " VALUES" +
                    " ('" + Item_name_editor_tbox.Text + "'," +
                    " '" + item_desc_editor_tbox.Text + "'," +
                    " '" + DICE_editor_ud.Value + "'," +
                    " '" + HP_editor_ud.Value + "'," +
                    " '" + MP_editor_ud.Value + "'," +
                    " '" + ATK_editor_ud.Value + "'," +
                    " '" + SATK_editor_ud.Value + "'," +
                    " '" + DEF_editor_ud.Value + "'," +
                    " '" + SDEF_editor_ud.Value + "'," +
                    " '" + CHAR_editor_ud.Value + "'," +
                    " '" + DEX_editor_ud.Value + "'," +
                    " '" + STR_editor_ud.Value + "'," +
                    " '" + INT_editor_ud.Value + "'," +
                    " '" + PERC_editor_ud.Value + "'," +
                    " '" + NItem_Weapon + "'," +
                    " '" + NItem_Consumable + "'," +
                    " '" + NItem_Helmet + "'," +
                    " '" + NItem_Maille + "'," +
                    " '" + NItem_Gloves + "'," +
                    " '" + NItem_Pants + "'," +
                    " '" + NItem_Boots + "'," +
                    " '" + NItem_Artifact + "'," +
                    " '" + NItem_Healing + "'," +
                    " '" + SAT_editor_ud.Value + "'," +
                    " '0'," +
                    " '" + TURNS_editor_ud.Value + "'," +
                    " '" + QTY_editor_ud.Value + "'," +
                    " '" + ENH_editor_ud.Value + "'," +
                    " '" + DUR_editor_ud.Value + "'," +
                    " '" + MDUR_editor_ud.Value + "'," +
                    " '" + TIER_editor_ud.Value + "'," +
                    " '" + GRADE_editor_ud.Value + "');";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            Update_Item_Pool();
        }

        private void EditorItems_lbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string IID = "Dead";
            foreach (ListViewItem item in EditorItems_lbox.SelectedItems)
            {
                IID = item.Text.Split('<', '>')[1];
            }
            if (IID != "Dead")
            {
                try
                {
                    string sql = "SELECT idItems, Name, Description, Dice, M_HP, M_MP, M_ATK, M_SATK, M_DEF, M_SDEF, M_CHAR," +
                        " M_DEX, M_STR, M_INT, M_PERC, Weapon, Consumable, Helm, Maille, Gloves, Pants, boot, Artifact, Healing," +
                        " Satiety, Turns, Quantity, Enhance, Durability, MaxDurability, Tier, Grade" +
                        " FROM items WHERE idItems=" + IID;
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    MySqlDataReader rdr = cmd.ExecuteReader();
                    int count = 0;

                    int Weapon = 0;
                    int Consumable = 0;
                    int Helm = 0;
                    int Maille = 0;
                    int Gloves = 0;
                    int Pants = 0;
                    int Boot = 0;
                    int Artifact = 0;
                    int Healing = 0;

                    while (rdr.Read())
                    {
                        ID_editor_up.Value = Convert.ToInt32(rdr[0]);
                        Item_name_editor_tbox.Text = Convert.ToString(rdr[1]);
                        item_desc_editor_tbox.Text = Convert.ToString(rdr[2]);
                        DICE_editor_ud.Value = Convert.ToInt32(rdr[3]);
                        HP_editor_ud.Value = Convert.ToInt32(rdr[4]);
                        MP_editor_ud.Value = Convert.ToInt32(rdr[5]);
                        ATK_editor_ud.Value = Convert.ToInt32(rdr[6]);
                        SATK_editor_ud.Value = Convert.ToInt32(rdr[7]);
                        DEF_editor_ud.Value = Convert.ToInt32(rdr[8]);
                        SDEF_editor_ud.Value = Convert.ToInt32(rdr[9]);
                        CHAR_editor_ud.Value = Convert.ToInt32(rdr[10]);
                        DEX_editor_ud.Value = Convert.ToInt32(rdr[11]);
                        STR_editor_ud.Value = Convert.ToInt32(rdr[12]);
                        INT_editor_ud.Value = Convert.ToInt32(rdr[13]);
                        PERC_editor_ud.Value = Convert.ToInt32(rdr[14]);
                        Weapon = Convert.ToInt32(rdr[15]);
                        Consumable = Convert.ToInt32(rdr[16]);
                        Helm = Convert.ToInt32(rdr[17]);
                        Maille = Convert.ToInt32(rdr[18]);
                        Gloves = Convert.ToInt32(rdr[19]);
                        Pants = Convert.ToInt32(rdr[20]);
                        Boot = Convert.ToInt32(rdr[21]);
                        Artifact = Convert.ToInt32(rdr[22]);
                        Healing = Convert.ToInt32(rdr[23]);
                        SAT_editor_ud.Value = Convert.ToInt32(rdr[24]);
                        TURNS_editor_ud.Value = Convert.ToInt32(rdr[25]);
                        QTY_editor_ud.Value = Convert.ToInt32(rdr[26]);
                        ENH_editor_ud.Value = Convert.ToInt32(rdr[27]);
                        DUR_editor_ud.Value = Convert.ToInt32(rdr[28]);
                        MDUR_editor_ud.Value = Convert.ToInt32(rdr[29]);
                        TIER_editor_ud.Value = Convert.ToInt32(rdr[30]);
                        GRADE_editor_ud.Value = Convert.ToInt32(rdr[31]);
                        count++;
                    }

                    if (Weapon == 0 && Helm == 0 && Maille == 0 && Gloves == 0 && Pants == 0 && Boot == 0)
                    {
                        Item_type_editor_cbox.SelectedItem = "Miscellaneous";
                    }


                    if (Healing == 1 && Consumable == 1 && Convert.ToInt32(rdr[4]) == 1)
                    {
                        Item_type_editor_cbox.SelectedItem = "HealthPotion";
                    }

                    if (Healing == 1 && Consumable == 1 && Convert.ToInt32(rdr[5]) == 1)
                    {
                        Item_type_editor_cbox.SelectedItem = "ManaPotion";
                    }

                    if (Artifact == 1)
                    {
                        Item_type_editor_cbox.SelectedItem = "Artifact";
                    }

                    if (Weapon == 1)
                    {
                        Item_type_editor_cbox.SelectedItem = "Weapon";
                    }

                    if (Helm == 1)
                    {
                        Item_type_editor_cbox.SelectedItem = "Helmet";
                    }

                    if (Maille == 1)
                    {
                        Item_type_editor_cbox.SelectedItem = "Maille";
                    }

                    if (Gloves == 1)
                    {
                        Item_type_editor_cbox.SelectedItem = "Gloves";
                    }

                    if (Pants == 1)
                    {
                        Item_type_editor_cbox.SelectedItem = "Pants";
                    }

                    if (Boot == 1)
                    {
                        Item_type_editor_cbox.SelectedItem = "Boots";
                    }
                    rdr.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }

        }

        private void DItem_editor_btn_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "DELETE FROM `items` WHERE `idItems` = " + ID_editor_up.Value + "";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            Update_Item_Pool();
        }

        private void MItem_editor_btn_Click(object sender, EventArgs e)
        {

            try
            {
                string NItem_Consumable = "0";
                string NItem_Healing = "0";
                string NItem_Artifact = "0";
                string NItem_Weapon = "0";
                string NItem_Helmet = "0";
                string NItem_Maille = "0";
                string NItem_Gloves = "0";
                string NItem_Pants = "0";
                string NItem_Boots = "0";
                switch (Item_type_editor_cbox.SelectedItem)
                {
                    case "HealthPotion":
                        NItem_Healing = "1";
                        NItem_Consumable = "1";
                        HP_editor_ud.Value = 1;
                        break;
                    case "ManaPotion":
                        NItem_Healing = "1";
                        NItem_Consumable = "1";
                        MP_editor_ud.Value = 1;
                        break;
                    case "Consumable":
                        NItem_Consumable = "1";
                        break;
                    case "Artifact":
                        NItem_Artifact = "1";
                        break;
                    case "Weapon":
                        NItem_Weapon = "1";
                        break;
                    case "Helmet":
                        NItem_Helmet = "1";
                        break;
                    case "Maille":
                        NItem_Maille = "1";
                        break;
                    case "Gloves":
                        NItem_Gloves = "1";
                        break;
                    case "Pants":
                        NItem_Pants = "1";
                        break;
                    case "Boots":
                        NItem_Boots = "1";
                        break;
                    case "Miscellaneous":
                        break;

                }
                string sql = "UPDATE items SET" +
                    " Name = '" + Item_name_editor_tbox.Text.Replace("'", "\\'") + "'," +
                    " Description = '" + item_desc_editor_tbox.Text.Replace("'", "\\'") + "'," +
                    " Dice = '" + DICE_editor_ud.Value + "', " +
                    " M_HP = '" + HP_editor_ud.Value + "'," +
                    " M_MP = '" + MP_editor_ud.Value + "'," +
                    " M_ATK = '" + ATK_editor_ud.Value + "'," +
                    " M_SATK = '" + SATK_editor_ud.Value + "'," +
                    " M_DEF = '" + DEF_editor_ud.Value + "'," +
                    " M_SDEF = '" + SDEF_editor_ud.Value + "'," +
                    " M_CHAR = '" + CHAR_editor_ud.Value + "'," +
                    " M_DEX = '" + DEX_editor_ud.Value + "'," +
                    " M_STR = '" + STR_editor_ud.Value + "'," +
                    " M_INT = '" + INT_editor_ud.Value + "'," +
                    " M_PERC = '" + PERC_editor_ud.Value + "'," +
                    " Weapon = '" + NItem_Weapon + "'," +
                    " Consumable = '" + NItem_Consumable + "'," +
                    " HELM = '" + NItem_Helmet + "'," +
                    " Maille = '" + NItem_Maille + "'," +
                    " Gloves = '" + NItem_Gloves + "'," +
                    " Pants = '" + NItem_Pants + "'," +
                    " boot = '" + NItem_Boots + "'," +
                    " Artifact = '" + NItem_Artifact + "'," +
                    " Healing = '" + NItem_Healing + "'," +
                    " Satiety = '" + SAT_editor_ud.Value + "'," +
                    " Turns = '" + TURNS_editor_ud.Value + "'," +
                    " Quantity = '" + QTY_editor_ud.Value + "'," +
                    " Enhance = '" + ENH_editor_ud.Value + "'," +
                    " Durability = '" + DUR_editor_ud.Value + "'," +
                    " MaxDurability = '" + MDUR_editor_ud.Value + "'," +
                    " Tier = '" + TIER_editor_ud.Value + "'," +
                    " Grade = '" + GRADE_editor_ud.Value + "'" +
                    " WHERE idItems='" + ID_editor_up.Value + "'";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            Update_Item_Pool();
        }
    }

    public class NPC {
        MySqlConnection conn;
        public int PlayerID { get; set; }
        public string UserName { get; set; }
        public string PName { get; set; }
        public string Description { get; set; }

        public int Level { get; set; }
        public int XP { get; set; }
        public int XPREQ { get; set; }
        public int Age { get; set; }
        public int Gold { get; set; }
        public int HP { get; set; }
        public int MP { get; set; }
        public int HPMax { get; set; }
        public int MPMax { get; set; }
        public int ATK { get; set; }
        public int SATK { get; set; }
        public int DEF { get; set; }
        public int SDEF { get; set; }
        public int CHARIS { get; set; }
        public int DEX { get; set; }
        public int STR { get; set; }
        public int INTEL { get; set; }
        public int PERC { get; set; }
        public int SATIE { get; set; }

        public string PlayerOwner { get; set; }

        public Boolean GAMEMASTER { get; set; }
        public Boolean isPlayer { get; set; }
        public Boolean isEnemy { get; set; }
        public Boolean isNPC { get; set; }

        public List<string> Inventory { get; set; }

        public NPC(MySqlConnection inconn)
        {
            conn = inconn;
            Inventory = new List<String>();
        }

        public void GetData()
        {
            try
            {
                string sql = "SELECT idPlayer," +
                    " GAMEMASTER," +
                    " PLevel, " +
                    " XP," +
                    " Age," +
                    " Gold," +
                    " PName," +
                    " PDescription," +
                    " HPMax," +
                    " HPCur," +
                    " MPMax," +
                    " MPCur," +
                    " ATK," +
                    " SATK," +
                    " DEF," +
                    " SDEF," +
                    " CHARIS," +
                    " DEX," +
                    " STR," +
                    " INTEL," +
                    " PERC," +
                    " Satiety," +
                    " POwner," +
                    " PLAYER," +
                    " NPC," +
                    " ENEMY," +
                    " XPREQ" +
                    " FROM player WHERE USERNAME='" + UserName + "'";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    PlayerID = Convert.ToInt32(rdr[0]);
                    GAMEMASTER = Convert.ToBoolean(rdr[1]);
                    Level = Convert.ToInt32(rdr[2]);
                    XP = Convert.ToInt32(rdr[3]);
                    Age = Convert.ToInt32(rdr[4]);
                    Gold = Convert.ToInt32(rdr[5]);
                    PName = Convert.ToString(rdr[6]);
                    Description = Convert.ToString(rdr[7]);
                    HPMax = Convert.ToInt32(rdr[8]);
                    HP = Convert.ToInt32(rdr[9]);
                    MPMax = Convert.ToInt32(rdr[10]);
                    MP = Convert.ToInt32(rdr[11]);
                    ATK = Convert.ToInt32(rdr[12]);
                    SATK = Convert.ToInt32(rdr[13]);
                    DEF = Convert.ToInt32(rdr[14]);
                    SDEF = Convert.ToInt32(rdr[15]);
                    CHARIS = Convert.ToInt32(rdr[16]);
                    DEX = Convert.ToInt32(rdr[17]);
                    STR = Convert.ToInt32(rdr[18]);
                    INTEL = Convert.ToInt32(rdr[19]);
                    PERC = Convert.ToInt32(rdr[20]);
                    SATIE = Convert.ToInt32(rdr[21]);
                    PlayerOwner = Convert.ToString(rdr[22]);
                    isPlayer = Convert.ToBoolean(rdr[23]);
                    isNPC = Convert.ToBoolean(rdr[24]);
                    isEnemy = Convert.ToBoolean(rdr[25]);
                    XPREQ = Convert.ToInt32(rdr[26]);
                }
                
                rdr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }


        }

        public void PostData()
        {
            double LVL = Convert.ToDouble(Level);
            double XP = 0;
            for (int i = 1; i < (LVL + 1); i++)
            {
                XP += Math.Pow(i, 3);
            }

            try
            {
                string sql = "UPDATE player SET" +
                    " GAMEMASTER = '" + GAMEMASTER + "'," +
                    " PLevel = '" + Level + "'," +
                    " XP = '" + XP + "'," +
                    " Age = '" + Age + "'," +
                    " Gold = '" + Gold + "'," +
                    " PName = '" + PName + "'," +
                    " PDescription = '" + Description + "'," +
                    " HPMax = '" + HPMax + "'," +
                    " HPCur = '" + HP + "'," +
                    " MPMax = '" + MPMax + "'," +
                    " MPCur = '" + MP + "'," +
                    " ATK = '" + ATK + "'," +
                    " SATK = '" + SATK + "'," +
                    " DEF = '" + DEF + "'," +
                    " SDEF = '" + SDEF + "'," +
                    " CHARIS = '" + CHARIS + "'," +
                    " DEX = '" + DEX + "'," +
                    " STR = '" + STR + "'," +
                    " INTEL = '" + INTEL + "'," +
                    " PERC = '" + PERC + "'," +
                    " Satiety = '" + SATIE + "'," +
                    " PLAYER = '" + isPlayer + "'," +
                    " NPC = '" + isNPC + "'," +
                    " ENEMY = '" + isEnemy + "'," +
                    " XPREQ = '" + Convert.ToDecimal(XP) + "'" +
                    " WHERE idPlayer='" + PlayerID + "'";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void GetInventory()
        {
            try
            {
                Inventory.Clear();
                string sql = "SELECT Items_idItems FROM player_has_items WHERE Player_idPlayer=" + PlayerID.ToString();
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                List<int> al = new List<int>();
                while (rdr.Read())
                {
                    al.Add(Convert.ToInt32(rdr[0]));
                }
                rdr.Close();
                foreach (int ItemID in al)
                {
                    string sql2 = "SELECT Name FROM items WHERE idItems=" + ItemID.ToString();
                    MySqlCommand cmd2 = new MySqlCommand(sql2, conn);
                    MySqlDataReader rdr2 = cmd2.ExecuteReader();
                    while (rdr2.Read())
                    {
                        Inventory.Add(Convert.ToString(rdr2[0]) + " (ID: <" + ItemID.ToString() + ">)");
                    }
                    rdr2.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void SetInventory()
        {
            try
            {
                string sql = "DELETE FROM player_has_items WHERE Player_idPlayer = '" + PlayerID + "'";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            foreach (string item in Inventory) {

                string IID = item.Split('<', '>')[1];
                try
                {
                    string sql = "INSERT INTO player_has_items (Player_idPlayer, Items_idItems) " +
                        "VALUES (" + PlayerID + "," + IID + ")";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }

        }

    }
}
