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
        Random rnd = new Random();

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

            MyPlayer.GetData();
            MyPlayer.GetInventory();
            Name_tbox.Text = MyPlayer.PName;
            LVL_tbox.Text = MyPlayer.Level.ToString();
            XP_lbl.Text = "XP: " + MyPlayer.XP.ToString() + "/" + MyPlayer.XPREQ.ToString();

            if (MyPlayer.XP >= MyPlayer.XPREQ)
            {
                MyPlayer.XP -= MyPlayer.XPREQ;
                MyPlayer.STATS = MyPlayer.Level;
                STATS_LBL.Text = "STATS: " + MyPlayer.STATS.ToString();
                MyPlayer.Level += 1;
                MyPlayer.PostData();
                LVL_tbox.Text = MyPlayer.Level.ToString();
                XP_lbl.Text = "XP: " + MyPlayer.XP.ToString() + "/" + MyPlayer.XPREQ.ToString();

                MessageBox.Show("Congrats You Leveled Up");
            }

            if (MyPlayer.STATS > 0) {
                HP_P_BTN.Visible = true;
                MP_P_BTN.Visible = true;
                ATK_P_BTN.Visible = true;
                SATK_P_BTN.Visible = true;
                DEF_P_BTN.Visible = true;
                SDEF_P_BTN.Visible = true;
                CHAR_P_BTN.Visible = true;
                DEX_P_BTN.Visible = true;
                STR_P_BTN.Visible = true;
                INT_P_BTN.Visible = true;
                PERC_P_BTN.Visible = true;

                HP_M_BTN.Visible = true;
                MP_M_BTN.Visible = true;
                ATK_M_BTN.Visible = true;
                SATK_M_BTN.Visible = true;
                DEF_M_BTN.Visible = true;
                SDEF_M_BTN.Visible = true;
                CHAR_M_BTN.Visible = true;
                DEX_M_BTN.Visible = true;
                STR_M_BTN.Visible = true;
                INT_M_BTN.Visible = true;
                PERC_M_BTN.Visible = true;
                Stats_Apply_BTN.Visible = true;

                UPDATE_btn.Visible = false;

                MyPlayer.NSTAT = MyPlayer.STATS;
                MyPlayer.NHPMax = MyPlayer.HPMax;
                MyPlayer.NMPMax = MyPlayer.MPMax;
                MyPlayer.NATK = MyPlayer.ATK;
                MyPlayer.NSATK = MyPlayer.SATK;
                MyPlayer.NDEF = MyPlayer.DEF;
                MyPlayer.NSDEF = MyPlayer.SDEF;
                MyPlayer.NCHARIS = MyPlayer.CHARIS;
                MyPlayer.NDEX = MyPlayer.DEX;
                MyPlayer.NSTR = MyPlayer.STR;
                MyPlayer.NINTEL = MyPlayer.INTEL;
                MyPlayer.NPERC = MyPlayer.PERC;

                Update_timer.Stop();
            } else {
                HP_P_BTN.Visible = false;
                MP_P_BTN.Visible = false;
                ATK_P_BTN.Visible = false;
                SATK_P_BTN.Visible = false;
                DEF_P_BTN.Visible = false;
                SDEF_P_BTN.Visible = false;
                CHAR_P_BTN.Visible = false;
                DEX_P_BTN.Visible = false;
                STR_P_BTN.Visible = false;
                INT_P_BTN.Visible = false;
                PERC_P_BTN.Visible = false;

                HP_M_BTN.Visible = false;
                MP_M_BTN.Visible = false;
                ATK_M_BTN.Visible = false;
                SATK_M_BTN.Visible = false;
                DEF_M_BTN.Visible = false;
                SDEF_M_BTN.Visible = false;
                CHAR_M_BTN.Visible = false;
                DEX_M_BTN.Visible = false;
                STR_M_BTN.Visible = false;
                INT_M_BTN.Visible = false;
                PERC_M_BTN.Visible = false;
                Stats_Apply_BTN.Visible = false;

                UPDATE_btn.Visible = true;
            }

            STATS_LBL.Text = "STATS: " + MyPlayer.STATS.ToString();
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
            if (MyPlayer.XPREQ >= MyPlayer.XP)
            {
                XP_pbar.Maximum = MyPlayer.XPREQ;
                XP_pbar.Value = MyPlayer.XP;
            } else
            {
                XP_pbar.Maximum = MyPlayer.XPREQ;
                XP_pbar.Value = MyPlayer.XPREQ;

            }


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
            
            //Display Gamemaster Content
            if (MyPlayer.GAMEMASTER == true)
            {

            }

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

        private void NPCS_lbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (NPCS_lbox.SelectedItem != null)
            {
                string IID = NPCS_lbox.Items[NPCS_lbox.SelectedIndex].ToString().Split('<', '>')[1];
                Player Pview = new Player(Convert.ToInt32(IID), conn);
                Pview.Show();
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
                    ", `Weapon`, `Consumable`, `Helm`, `Maille`, `Gloves`, `Pants`, `boot`, `Artifact`, `Healing`, `Satiety`, `Equipped`, `Turns`, `Quantity`, `Enhance`, `Durability`, `MaxDurability`, `Tier`, `Grade`, `EType`, `ELevel`, `Oracalcite`)" +
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
                    " '" + GRADE_editor_ud.Value + "'," +
                    " '" + EType_editor_tbox.Text + "'," +
                    " '" + ELevel_editor_ud.Value + "'," +
                    " '" + Convert.ToInt32(Oracalcite_editor_checkb.Checked) + "');";
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
                        " Satiety, Turns, Quantity, Enhance, Durability, MaxDurability, Tier, Grade, EType, ELevel, Oracalcite" +
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
                        EType_editor_tbox.Text = Convert.ToString(rdr[32]);
                        ELevel_editor_ud.Value = Convert.ToInt32(rdr[33]);
                        Oracalcite_editor_checkb.Checked = Convert.ToBoolean(rdr[34]);
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
                    " Grade = '" + GRADE_editor_ud.Value + "'," +
                    " EType = '" + EType_editor_tbox.Text.Replace("'", "\\'") + "'," +
                    " ELevel = '" + ELevel_editor_ud.Value + "'," +
                    " Oracalcite = '" + Convert.ToInt32(Oracalcite_editor_checkb.Checked) + "'" +
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

        private void EItem_editor_btn_Click(object sender, EventArgs e)
        {
            string SItem = Item_type_editor_cbox.SelectedItem.ToString();
            if (SItem != "Miscellaneous" && SItem != "Artifact" && SItem != "Consumable" && SItem != "ManaPotion" && SItem != "HealthPotion")
            {
                decimal TotalStatPoints = HP_editor_ud.Value + MP_editor_ud.Value + ATK_editor_ud.Value
                    + SATK_editor_ud.Value + DEF_editor_ud.Value + SDEF_editor_ud.Value + CHAR_editor_ud.Value
                    + DEX_editor_ud.Value + STR_editor_ud.Value + INT_editor_ud.Value + PERC_editor_ud.Value;

                decimal TargetStatPoints = ((Math.Ceiling((ENH_editor_ud.Value + 1) / 10)) / 10) * TotalStatPoints;
                ENH_editor_ud.Value += 1;
                while (TargetStatPoints > 0)
                {
                    switch (rnd.Next(0, 11))
                    {
                        case 0:
                            if (HP_editor_ud.Value > 0)
                            {
                                HP_editor_ud.Value += 1;
                                TargetStatPoints -= 1;
                            }
                            break;
                        case 1:
                            if (MP_editor_ud.Value > 0)
                            {
                                MP_editor_ud.Value += 1;
                                TargetStatPoints -= 1;
                            }
                            break;
                        case 2:
                            if (ATK_editor_ud.Value > 0)
                            {
                                ATK_editor_ud.Value += 1;
                                TargetStatPoints -= 1;
                            }
                            break;
                        case 3:
                            if (SATK_editor_ud.Value > 0)
                            {
                                SATK_editor_ud.Value += 1;
                                TargetStatPoints -= 1;
                            }
                            break;
                        case 4:
                            if (DEF_editor_ud.Value > 0)
                            {
                                DEF_editor_ud.Value += 1;
                                TargetStatPoints -= 1;
                            }
                            break;
                        case 5:
                            if (SDEF_editor_ud.Value > 0)
                            {
                                SDEF_editor_ud.Value += 1;
                                TargetStatPoints -= 1;
                            }
                            break;
                        case 6:
                            if (CHAR_editor_ud.Value > 0)
                            {
                                CHAR_editor_ud.Value += 1;
                                TargetStatPoints -= 1;
                            }
                            break;
                        case 7:
                            if (DEX_editor_ud.Value > 0)
                            {
                                DEX_editor_ud.Value += 1;
                                TargetStatPoints -= 1;
                            }
                            break;
                        case 8:
                            if (STR_editor_ud.Value > 0)
                            {
                                STR_editor_ud.Value += 1;
                                TargetStatPoints -= 1;
                            }
                            break;
                        case 9:
                            if (INT_editor_ud.Value > 0)
                            {
                                INT_editor_ud.Value += 1;
                                TargetStatPoints -= 1;
                            }
                            break;
                        case 10:
                            if (PERC_editor_ud.Value > 0)
                            {
                                PERC_editor_ud.Value += 1;
                                TargetStatPoints -= 1;
                            }
                            break;
                    }
                }
                MessageBox.Show("Enhanced");
            } else
            {
                MessageBox.Show("Not Enhancable ");
            }
        }

        private void UItem_editor_btn_Click(object sender, EventArgs e)
        {
            Update_Item_Pool();
        }

        //STATS 
        private void HP_P_BTN_Click(object sender, EventArgs e)
        {
            if (MyPlayer.NSTAT > 0)
            {
                MyPlayer.NSTAT -= 1;
                MyPlayer.NHPMax += 1;
                STATS_LBL.Text = "STATS: " + MyPlayer.NSTAT.ToString();

                HP_pbar.Maximum = MyPlayer.NHPMax;
                HP_pbar.Value = MyPlayer.HP;

                HP_lbl.Text = "HP: " + MyPlayer.HP.ToString() + "/" + MyPlayer.NHPMax.ToString();
            }
        }

        private void HP_M_BTN_Click(object sender, EventArgs e)
        {
            if (MyPlayer.NHPMax > MyPlayer.HPMax)
            {
                MyPlayer.NSTAT += 1;
                MyPlayer.NHPMax -= 1;
                STATS_LBL.Text = "STATS: " + MyPlayer.NSTAT.ToString();

                HP_pbar.Maximum = MyPlayer.NHPMax;
                HP_pbar.Value = MyPlayer.HP;

                HP_lbl.Text = "HP: " + MyPlayer.HP.ToString() + "/" + MyPlayer.NHPMax.ToString();
            }
        }

        private void MP_P_BTN_Click(object sender, EventArgs e)
        {
            if (MyPlayer.NSTAT > 0)
            {
                MyPlayer.NSTAT -= 1;
                MyPlayer.NMPMax += 1;
                STATS_LBL.Text = "STATS: " + MyPlayer.NSTAT.ToString();

                MP_pbar.Maximum = MyPlayer.NMPMax;
                MP_pbar.Value = MyPlayer.MP;

                MP_lbl.Text = "MP: " + MyPlayer.MP.ToString() + "/" + MyPlayer.NMPMax.ToString();
            }
        }

        private void MP_M_BTN_Click(object sender, EventArgs e)
        {
            if (MyPlayer.NMPMax > MyPlayer.MPMax)
            {
                MyPlayer.NSTAT += 1;
                MyPlayer.NMPMax -= 1;
                STATS_LBL.Text = "STATS: " + MyPlayer.NSTAT.ToString();

                MP_pbar.Maximum = MyPlayer.NMPMax;
                MP_pbar.Value = MyPlayer.MP;

                MP_lbl.Text = "MP: " + MyPlayer.MP.ToString() + "/" + MyPlayer.NMPMax.ToString();
            }
        }

        private void ATK_P_BTN_Click(object sender, EventArgs e)
        {
            if (MyPlayer.NSTAT > 0)
            {
                MyPlayer.NSTAT -= 1;
                MyPlayer.NATK += 1;
                STATS_LBL.Text = "STATS: " + MyPlayer.NSTAT.ToString();

                ATK_tbox.Text = MyPlayer.NATK.ToString();
            }
        }

        private void ATK_M_BTN_Click(object sender, EventArgs e)
        {
            if (MyPlayer.NATK > MyPlayer.ATK)
            {
                MyPlayer.NSTAT += 1;
                MyPlayer.NATK -= 1;
                STATS_LBL.Text = "STATS: " + MyPlayer.NSTAT.ToString();

                ATK_tbox.Text = MyPlayer.NATK.ToString();
            }
        }

        private void SATK_P_BTN_Click(object sender, EventArgs e)
        {
            if (MyPlayer.NSTAT > 0)
            {
                MyPlayer.NSTAT -= 1;
                MyPlayer.NSATK += 1;
                STATS_LBL.Text = "STATS: " + MyPlayer.NSTAT.ToString();

                SATK_tbox.Text = MyPlayer.NSATK.ToString();
            }
        }

        private void SATK_M_BTN_Click(object sender, EventArgs e)
        {
            if (MyPlayer.NSATK > MyPlayer.SATK)
            {
                MyPlayer.NSTAT += 1;
                MyPlayer.NSATK -= 1;
                STATS_LBL.Text = "STATS: " + MyPlayer.NSTAT.ToString();

                SATK_tbox.Text = MyPlayer.NSATK.ToString();
            }
        }

        private void DEF_P_BTN_Click(object sender, EventArgs e)
        {
            if (MyPlayer.NSTAT > 0)
            {
                MyPlayer.NSTAT -= 1;
                MyPlayer.NDEF += 1;
                STATS_LBL.Text = "STATS: " + MyPlayer.NSTAT.ToString();

                DEF_tbox.Text = MyPlayer.NDEF.ToString();
            }
        }

        private void DEF_M_BTN_Click(object sender, EventArgs e)
        {
            if (MyPlayer.NDEF > MyPlayer.DEF)
            {
                MyPlayer.NSTAT += 1;
                MyPlayer.NDEF -= 1;
                STATS_LBL.Text = "STATS: " + MyPlayer.NSTAT.ToString();

                DEF_tbox.Text = MyPlayer.NDEF.ToString();
            }
        }

        private void SDEF_P_BTN_Click(object sender, EventArgs e)
        {
            if (MyPlayer.NSTAT > 0)
            {
                MyPlayer.NSTAT -= 1;
                MyPlayer.NSDEF += 1;
                STATS_LBL.Text = "STATS: " + MyPlayer.NSTAT.ToString();

                SDEF_tbox.Text = MyPlayer.NSDEF.ToString();
            }
        }

        private void SDEF_M_BTN_Click(object sender, EventArgs e)
        {
            if (MyPlayer.NSDEF > MyPlayer.SDEF)
            {
                MyPlayer.NSTAT += 1;
                MyPlayer.NSDEF -= 1;
                STATS_LBL.Text = "STATS: " + MyPlayer.NSTAT.ToString();

                SDEF_tbox.Text = MyPlayer.NSDEF.ToString();
            }
        }

        private void CHAR_P_BTN_Click(object sender, EventArgs e)
        {
            if (MyPlayer.NSTAT > 0)
            {
                MyPlayer.NSTAT -= 1;
                MyPlayer.NCHARIS += 1;
                STATS_LBL.Text = "STATS: " + MyPlayer.NSTAT.ToString();

                CHAR_tbox.Text = MyPlayer.NCHARIS.ToString();
            }
        }

        private void CHAR_M_BTN_Click(object sender, EventArgs e)
        {
            if (MyPlayer.NCHARIS > MyPlayer.CHARIS)
            {
                MyPlayer.NSTAT += 1;
                MyPlayer.NCHARIS -= 1;
                STATS_LBL.Text = "STATS: " + MyPlayer.NSTAT.ToString();

                CHAR_tbox.Text = MyPlayer.NCHARIS.ToString();
            }
        }

        private void DEX_P_BTN_Click(object sender, EventArgs e)
        {
            if (MyPlayer.NSTAT > 0)
            {
                MyPlayer.NSTAT -= 1;
                MyPlayer.NDEX += 1;
                STATS_LBL.Text = "STATS: " + MyPlayer.NSTAT.ToString();

                DEX_tbox.Text = MyPlayer.NDEX.ToString();
            }
        }

        private void DEX_M_BTN_Click(object sender, EventArgs e)
        {
            if (MyPlayer.NDEX > MyPlayer.DEX)
            {
                MyPlayer.NSTAT += 1;
                MyPlayer.NDEX -= 1;
                STATS_LBL.Text = "STATS: " + MyPlayer.NSTAT.ToString();

                DEX_tbox.Text = MyPlayer.NDEX.ToString();
            }
        }

        private void STR_P_BTN_Click(object sender, EventArgs e)
        {
            if (MyPlayer.NSTAT > 0)
            {
                MyPlayer.NSTAT -= 1;
                MyPlayer.NSTR += 1;
                STATS_LBL.Text = "STATS: " + MyPlayer.NSTAT.ToString();

                STR_tbox.Text = MyPlayer.NSTR.ToString();
            }
        }

        private void STR_M_BTN_Click(object sender, EventArgs e)
        {
            if (MyPlayer.NSTR > MyPlayer.STR)
            {
                MyPlayer.NSTAT += 1;
                MyPlayer.NSTR -= 1;
                STATS_LBL.Text = "STATS: " + MyPlayer.NSTAT.ToString();

                STR_tbox.Text = MyPlayer.NSTR.ToString();
            }
        }

        private void INT_P_BTN_Click(object sender, EventArgs e)
        {
            if (MyPlayer.NSTAT > 0)
            {
                MyPlayer.NSTAT -= 1;
                MyPlayer.NINTEL += 1;
                STATS_LBL.Text = "STATS: " + MyPlayer.NSTAT.ToString();

                INT_tbox.Text = MyPlayer.NINTEL.ToString();
            }
        }

        private void INT_M_BTN_Click(object sender, EventArgs e)
        {
            if (MyPlayer.NINTEL > MyPlayer.INTEL)
            {
                MyPlayer.NSTAT += 1;
                MyPlayer.NINTEL -= 1;
                STATS_LBL.Text = "STATS: " + MyPlayer.NSTAT.ToString();

                INT_tbox.Text = MyPlayer.NINTEL.ToString();
            }
        }

        private void PERC_P_BTN_Click(object sender, EventArgs e)
        {
            if (MyPlayer.NSTAT > 0)
            {
                MyPlayer.NSTAT -= 1;
                MyPlayer.NPERC += 1;
                STATS_LBL.Text = "STATS: " + MyPlayer.NSTAT.ToString();

                PERC_tbox.Text = MyPlayer.NPERC.ToString();
            }
        }

        private void PERC_M_BTN_Click(object sender, EventArgs e)
        {
            if (MyPlayer.NPERC > MyPlayer.PERC)
            {
                MyPlayer.NSTAT += 1;
                MyPlayer.NPERC -= 1;
                STATS_LBL.Text = "STATS: " + MyPlayer.NSTAT.ToString();

                PERC_tbox.Text = MyPlayer.NPERC.ToString();
            }
        }

        private void Stats_Apply_BTN_Click(object sender, EventArgs e)
        {
            if (MyPlayer.NSTAT == 0)
            {
                MyPlayer.HPMax = MyPlayer.NHPMax;
                MyPlayer.MPMax = MyPlayer.NMPMax;
                MyPlayer.ATK = MyPlayer.NATK;
                MyPlayer.SATK = MyPlayer.NSATK;
                MyPlayer.DEF = MyPlayer.NDEF;
                MyPlayer.SDEF = MyPlayer.NSDEF;
                MyPlayer.CHARIS = MyPlayer.NCHARIS;
                MyPlayer.DEX = MyPlayer.NDEX;
                MyPlayer.STR = MyPlayer.NSTR;
                MyPlayer.INTEL = MyPlayer.NINTEL;
                MyPlayer.PERC = MyPlayer.NPERC;
                MyPlayer.STATS = MyPlayer.NSTAT;
                MyPlayer.PostData();

                UPDATE_btn.Visible = true;
                Update_timer.Start();
                MessageBox.Show("Stats Applied");
            }
            else
            {
                MessageBox.Show("Please Modify Stats");
            }
        }

        private void CM_UPDATE_BTN_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "SELECT PName, idPlayer FROM player";
                switch (Filter_Relation.SelectedItem)
                {
                    case "Player":
                        sql = "SELECT PName, idPlayer FROM player WHERE PLAYER='1'";
                        break;
                    case "Enemy":
                        sql = "SELECT PName, idPlayer FROM player WHERE ENEMY='1'";
                        break;
                    case "NPC":
                        sql = "SELECT PName, idPlayer FROM player WHERE NPC='1'";
                        break;
                    case "ALL":
                        break;
                }
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                NPCS_lbox.Items.Clear();
                while (rdr.Read())
                {
                    NPCS_lbox.Items.Add(Convert.ToString(rdr[0]) + " (ID: <" + Convert.ToString(rdr[1]) + ">)");
                }
                rdr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

    }
}
