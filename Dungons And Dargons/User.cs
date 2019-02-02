using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
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
        private List<ITEM> OLD_INVENTORY;
        private List<SPELL> OLD_SPELLS;
        Random rnd = new Random();

        NPCS GM_NPC_LIST;
        ITEMS GM_ITEM_LIST;
        SPELLS GM_SPELLS_LIST;

        private double RandomNumberBetween(double minValue, double maxValue)
        {
            var next = rnd.NextDouble();
            return (Math.Floor((minValue + (next * (maxValue - minValue)))*10000000000))/10000000000;
        }

        public User(int PlayerID, string ip, string password)
        {
            String version = "1.1.6.0";
            string LatestVersion = "0.0.0.0";
            DBip = ip;
            DBpassword = password;
            connStr = "server=" + DBip + ";user=DBUser;database=dungonsdargons;port=3306;password=" + DBpassword;
            conn = new MySqlConnection(connStr);

            InitializeComponent();
            conn.Open();
            try
            {
                string sql = "SELECT `APP VERSION` FROM `global_info` WHERE `idGlobal_Info` = '0'";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    LatestVersion = Convert.ToString(rdr[0]);
                }
                rdr.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            if (version != LatestVersion)
            {
                MessageBox.Show("YOU MUST UPDATE!!");
                MessageBox.Show("BYE BYE!");
                System.Diagnostics.Process.Start("https://github.com/PrecursorLabs/Dungons-And-Dargons/releases/");
                conn.Close();
                Application.Exit();
                this.Close();
            }
            MyPlayer = new NPC(conn);

            GM_NPC_LIST = new NPCS(conn);
            GM_ITEM_LIST = new ITEMS(conn);
            GM_SPELLS_LIST = new SPELLS(conn);

            OLD_INVENTORY = new List<ITEM>();
            OLD_SPELLS = new List<SPELL>();

            MyPlayer.PlayerID = PlayerID;
            MyPlayer.GetData();
            MyPlayer.GetInventory();
        }

        private void User_Load(object sender, EventArgs e)
        {
            this.FormClosing += new FormClosingEventHandler(User_Closing);
            this.Text = MyPlayer.PName;
            if (!MyPlayer.GAMEMASTER) Main_tabs.TabPages.Remove(GameMaster_tab);
            UPDATE_btn.PerformClick();
            CCLEVELSEL_CBOX.SelectedIndex = 0;
        }

        private void UPDATE_btn_Click(object sender, EventArgs e)
        {
            update();
        }

        private void update()
        {
            MyPlayer.GetData();
            MyPlayer.GetInventory();
            MyPlayer.GetSpells();
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

            if (MyPlayer.STATS > 0)
            {
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
            }
            else
            {
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
            HP_lbl.Text = "HP: " + MyPlayer.HP.ToString() + "/" + (MyPlayer.HPMax + MyPlayer.M_HP).ToString();
            MP_lbl.Text = "MP: " + MyPlayer.MP.ToString() + "/" + (MyPlayer.MPMax + MyPlayer.M_MP).ToString();
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

            M_ATK_tbox.Text = MyPlayer.M_ATK.ToString();
            M_SATK_tbox.Text = MyPlayer.M_SATK.ToString();
            M_DEF_tbox.Text = MyPlayer.M_DEF.ToString();
            M_SDEF_tbox.Text = MyPlayer.M_SDEF.ToString();
            M_CHAR_tbox.Text = MyPlayer.M_CHAR.ToString();
            M_DEX_tbox.Text = MyPlayer.M_DEX.ToString();
            M_STR_tbox.Text = MyPlayer.M_STR.ToString();
            M_INT_tbox.Text = MyPlayer.M_INT.ToString();
            M_PERC_tbox.Text = MyPlayer.M_PERC.ToString();

            T_ATK_tbox.Text = MyPlayer.T_ATK.ToString();
            T_SATK_tbox.Text = MyPlayer.T_SATK.ToString();
            T_DEF_tbox.Text = MyPlayer.T_DEF.ToString();
            T_SDEF_tbox.Text = MyPlayer.T_SDEF.ToString();
            T_CHAR_tbox.Text = MyPlayer.T_CHAR.ToString();
            T_DEX_tbox.Text = MyPlayer.T_DEX.ToString();
            T_STR_tbox.Text = MyPlayer.T_STR.ToString();
            T_INT_tbox.Text = MyPlayer.T_INT.ToString();
            T_PERC_tbox.Text = MyPlayer.T_PERC.ToString();

            Power_Level_tbox.Text = Convert.ToString(MyPlayer.HP + MyPlayer.MP + MyPlayer.M_ATK + MyPlayer.ATK + MyPlayer.M_SATK + MyPlayer.SATK
                + MyPlayer.M_DEF + MyPlayer.DEF + MyPlayer.M_SDEF + MyPlayer.SDEF + MyPlayer.M_CHAR + MyPlayer.CHARIS + MyPlayer.M_DEX
                + MyPlayer.DEX + MyPlayer.M_STR + MyPlayer.STR + MyPlayer.M_INT + MyPlayer.INTEL + MyPlayer.M_PERC + MyPlayer.PERC)
                + "/" + Convert.ToString(MyPlayer.HPMax + MyPlayer.M_HP + MyPlayer.MPMax + MyPlayer.M_MP + MyPlayer.M_ATK + MyPlayer.ATK + MyPlayer.M_SATK + MyPlayer.SATK
                + MyPlayer.M_DEF + MyPlayer.DEF + MyPlayer.M_SDEF + MyPlayer.SDEF + MyPlayer.M_CHAR + MyPlayer.CHARIS + MyPlayer.M_DEX
                + MyPlayer.DEX + MyPlayer.M_STR + MyPlayer.STR + MyPlayer.M_INT + MyPlayer.INTEL + MyPlayer.M_PERC + MyPlayer.PERC); ;

            Knowledge_lbox.Items.Clear();
            if (MyPlayer.Earth > 0)
            {
                Knowledge_lbox.Items.Add("Earth Knowledge: " + MyPlayer.Earth);
            }
            if (MyPlayer.Fire > 0)
            {
                Knowledge_lbox.Items.Add("Fire Knowledge: " + MyPlayer.Fire);
            }
            if (MyPlayer.Lightning > 0)
            {
                Knowledge_lbox.Items.Add("Lightning Knowledge: " + MyPlayer.Lightning);
            }
            if (MyPlayer.Ice > 0)
            {
                Knowledge_lbox.Items.Add("Ice Knowledge: " + MyPlayer.Ice);
            }
            if (MyPlayer.Holy > 0)
            {
                Knowledge_lbox.Items.Add("Holy Knowledge: " + MyPlayer.Holy);
            }
            if (MyPlayer.Unholy > 0)
            {
                Knowledge_lbox.Items.Add("Unholy Knowledge: " + MyPlayer.Unholy);
            }

            if (MyPlayer.Helmet.Name != null)
            {
                Helmet_tbox.Text = MyPlayer.Helmet.ITEM_DATA();
            }
            else
            {
                Helmet_tbox.Text = "";
            }

            if (MyPlayer.Maille.Name != null)
            {
                Maille_tbox.Text = MyPlayer.Maille.ITEM_DATA();
            }
            else
            {
                Maille_tbox.Text = "";
            }

            if (MyPlayer.Pants.Name != null)
            {
                Pants__tbox.Text = MyPlayer.Pants.ITEM_DATA();
            }
            else
            {
                Pants__tbox.Text = "";
            }

            if (MyPlayer.Boots.Name != null)
            {
                Boots_tbox.Text = MyPlayer.Boots.ITEM_DATA();
            }
            else
            {
                Boots_tbox.Text = "";
            }

            if (MyPlayer.Gloves.Name != null)
            {
                Gloves_tbox.Text = MyPlayer.Gloves.ITEM_DATA();
            }
            else
            {
                Gloves_tbox.Text = "";
            }

            if (MyPlayer.WeaponLeft.Name != null)
            {
                WeaponLeft_tbox.Text = MyPlayer.WeaponLeft.ITEM_DATA();
            }
            else
            {
                WeaponLeft_tbox.Text = "";
            }

            if (MyPlayer.WeaponRight.Name != null)
            {
                WeaponRight_tbox.Text = MyPlayer.WeaponRight.ITEM_DATA();
            }
            else
            {
                WeaponRight_tbox.Text = "";
            }

            if (MyPlayer.Artifact.Name != null)
            {
                Artifact_tbox.Text = MyPlayer.Artifact.ITEM_DATA();
            }
            else
            {
                Artifact_tbox.Text = "";
            }


            HP_pbar.Maximum = MyPlayer.T_HP;
            if (MyPlayer.HP > MyPlayer.HPMax + MyPlayer.M_HP)
            {
                HP_pbar.Value = MyPlayer.HPMax + MyPlayer.M_HP;
            }
            else
            {
                HP_pbar.Value = MyPlayer.HP;
            }

            MP_pbar.Maximum = MyPlayer.T_MP;
            if (MyPlayer.MP > MyPlayer.MPMax + MyPlayer.M_MP)
            {
                MP_pbar.Value = MyPlayer.HPMax + MyPlayer.M_HP;
            }
            else
            {
                MP_pbar.Value = MyPlayer.MP;
            }

            if (MyPlayer.XPREQ >= MyPlayer.XP)
            {
                XP_pbar.Maximum = MyPlayer.XPREQ;
                XP_pbar.Value = MyPlayer.XP;
            }
            else
            {
                XP_pbar.Maximum = MyPlayer.XPREQ;
                XP_pbar.Value = MyPlayer.XPREQ;

            }

            HP_pbar.ForeColor = Color.LawnGreen;

            if (MyPlayer.HP < MyPlayer.HPMax / 2)
            {
                HP_pbar.ForeColor = Color.Yellow;
            }

            if (MyPlayer.HP < MyPlayer.HPMax / 4)
            {
                HP_pbar.ForeColor = Color.Red;
            }

            string NINVTOT = "";
            string OINVTOT = "";
            foreach (ITEM item in MyPlayer.Inventory) NINVTOT = string.Format("{0}{1}", NINVTOT, item.ItemID + Convert.ToInt32(item.Equipped));
            foreach (ITEM item in OLD_INVENTORY) OINVTOT = string.Format("{0}{1}", OINVTOT, item.ItemID + Convert.ToInt32(item.Equipped));

            if (NINVTOT != OINVTOT)
            {
                Inventory_lbox.Items.Clear();
                Equipable_lbox.Items.Clear();
                OLD_INVENTORY.Clear();
                foreach (ITEM item in MyPlayer.Inventory)
                {
                    item.GetData();
                    if (item.Equipable())
                    {
                        if (item.Equipped == false)
                        {
                            Equipable_lbox.Items.Add(item.Prop_To_Type() + ": " + item.ITEM_DATA());
                        }


                    }
                    Inventory_lbox.Items.Add(item.ITEM_DATA());
                    OLD_INVENTORY.Add(item);
                }
            }

            string NSPLTOT = "";
            string OSPLTOT = "";
            foreach (SPELL spell in MyPlayer.Spells) NSPLTOT = string.Format("{0}{1}", NSPLTOT, spell.SpellID);
            foreach (SPELL spell in OLD_SPELLS) OSPLTOT = string.Format("{0}{1}", OSPLTOT, spell.SpellID);

            if (NSPLTOT != OSPLTOT)
            {
                Spells_lbox.Items.Clear();
                OLD_SPELLS.Clear();
                foreach (SPELL spell in MyPlayer.Spells)
                {
                    Spells_lbox.Items.Add(spell.SPELL_DATA());
                    OLD_SPELLS.Add(spell);
                }
            }

            //Display Gamemaster Content
            if (MyPlayer.GAMEMASTER == true)
            {

            }
        }
        private void MAINUPDATE_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }

        private void User_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.FormClosing -= new FormClosingEventHandler(User_Closing);
            conn.Close();
        }

        private void Inventory_lbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string IID = "Dead";
            foreach (ListViewItem item in Inventory_lbox.SelectedItems)
            {
                IID = item.Text.Split('<', '>')[1];
            }
            if (IID != "Dead")
            {
                ItemView Iview = new ItemView(Convert.ToInt32(IID), conn, MyPlayer.PlayerID);
                //Iview.Show();
                itemInfo_CNTRL.Controls.Clear();
                Iview.TopLevel = false;
                Iview.TopMost = false;
                Iview.FormBorderStyle = FormBorderStyle.None;
                Iview.Dock = DockStyle.Fill;
                Iview.Visible = true;
                itemInfo_CNTRL.Controls.Add(Iview);
            }
        }

        private void Spells_lbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string IID = "Dead";
            foreach (ListViewItem item in Spells_lbox.SelectedItems)
            {
                IID = item.Text.Split('<', '>')[1];
            }
            if (IID != "Dead")
            {
                SpellView Sview = new SpellView(Convert.ToInt32(IID), conn);
                //Sview.Show();
                SpellInfo_CNTRL.Controls.Clear();
                Sview.TopLevel = false;
                Sview.TopMost = false;
                Sview.FormBorderStyle = FormBorderStyle.None;
                Sview.Dock = DockStyle.Fill;
                Sview.Visible = true;
                SpellInfo_CNTRL.Controls.Add(Sview);
            }

        }

        private void NPCS_lbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (NPCS_lbox.SelectedItem != null)
            {
                string IID = NPCS_lbox.Items[NPCS_lbox.SelectedIndex].ToString().Split('<', '>')[1];
                PlayerView Pview = new PlayerView(Convert.ToInt32(IID), conn);
                Pview.Show();
            }
        }

        private void Update_timer_Tick(object sender, EventArgs e)
        {
            UPDATE_btn.PerformClick();
        }

        private void NItem_editor_btn_Click(object sender, EventArgs e)
        {
            ITEM IEDITOR_ITEM = new ITEM(conn);
            IEDITOR_ITEM.Name = Item_name_editor_tbox.Text;
            IEDITOR_ITEM.Description = item_desc_editor_tbox.Text;
            IEDITOR_ITEM.Dice = (int)DICE_editor_ud.Value;
            IEDITOR_ITEM.M_HP = (int)HP_editor_ud.Value;
            IEDITOR_ITEM.M_MP = (int)MP_editor_ud.Value;
            IEDITOR_ITEM.M_ATK = (int)ATK_editor_ud.Value;
            IEDITOR_ITEM.M_SATK = (int)SATK_editor_ud.Value;
            IEDITOR_ITEM.M_DEF = (int)DEF_editor_ud.Value;
            IEDITOR_ITEM.M_SDEF = (int)SDEF_editor_ud.Value;
            IEDITOR_ITEM.M_CHAR = (int)CHAR_editor_ud.Value;
            IEDITOR_ITEM.M_DEX = (int)DEX_editor_ud.Value;
            IEDITOR_ITEM.M_STR = (int)STR_editor_ud.Value;
            IEDITOR_ITEM.M_INT = (int)INT_editor_ud.Value;
            IEDITOR_ITEM.M_PERC = (int)PERC_editor_ud.Value;
            IEDITOR_ITEM.Satiety = (int)SAT_editor_ud.Value;
            IEDITOR_ITEM.Equipped = false;
            IEDITOR_ITEM.Turns = (int)TURNS_editor_ud.Value;
            IEDITOR_ITEM.Quantity = (int)QTY_editor_ud.Value;
            IEDITOR_ITEM.Enhance = (int)ENH_editor_ud.Value;
            IEDITOR_ITEM.Durability = (int)DUR_editor_ud.Value;
            IEDITOR_ITEM.MaxDurability = (int)MDUR_editor_ud.Value;
            IEDITOR_ITEM.Tier = (int)TIER_editor_ud.Value;
            IEDITOR_ITEM.Grade = (int)GRADE_editor_ud.Value;
            IEDITOR_ITEM.EType = EType_editor_tbox.Text;
            IEDITOR_ITEM.ELevel = (int)ELevel_editor_ud.Value;
            IEDITOR_ITEM.Oracalcite = Oracalcite_editor_checkb.Checked;

            if (Item_Character_Cbox.SelectedItem != null)
            {
                string IID = Item_Character_Cbox.Items[Item_Character_Cbox.SelectedIndex].ToString().Split('<', '>')[1];
                IEDITOR_ITEM.OWNER_ID = Convert.ToInt32(IID);
            }

            IEDITOR_ITEM.Type_To_Prop(Item_type_editor_cbox.SelectedItem.ToString());

            IEDITOR_ITEM.CreateData();
            UItem_editor_btn.PerformClick();
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
                ITEM IEDITOR_ITEM = new ITEM(conn);
                IEDITOR_ITEM.ItemID = Convert.ToInt32(IID);
                IEDITOR_ITEM.GetData();

                ID_editor_up.Value = IEDITOR_ITEM.ItemID;
                Item_type_editor_cbox.SelectedItem = IEDITOR_ITEM.Prop_To_Type();

                Item_name_editor_tbox.Text = IEDITOR_ITEM.Name;
                item_desc_editor_tbox.Text = IEDITOR_ITEM.Description;
                DICE_editor_ud.Value = IEDITOR_ITEM.Dice;
                HP_editor_ud.Value = IEDITOR_ITEM.M_HP;
                MP_editor_ud.Value = IEDITOR_ITEM.M_MP;
                ATK_editor_ud.Value = IEDITOR_ITEM.M_ATK;
                SATK_editor_ud.Value = IEDITOR_ITEM.M_SATK;
                DEF_editor_ud.Value = IEDITOR_ITEM.M_DEF;
                SDEF_editor_ud.Value = IEDITOR_ITEM.M_SDEF;
                CHAR_editor_ud.Value = IEDITOR_ITEM.M_CHAR;
                DEX_editor_ud.Value = IEDITOR_ITEM.M_DEX;
                STR_editor_ud.Value = IEDITOR_ITEM.M_STR;
                INT_editor_ud.Value = IEDITOR_ITEM.M_INT;
                PERC_editor_ud.Value = IEDITOR_ITEM.M_PERC;
                SAT_editor_ud.Value = IEDITOR_ITEM.Satiety;
                TURNS_editor_ud.Value = IEDITOR_ITEM.Turns;
                QTY_editor_ud.Value = IEDITOR_ITEM.Quantity;
                ENH_editor_ud.Value = IEDITOR_ITEM.Enhance;
                DUR_editor_ud.Value = IEDITOR_ITEM.Durability;
                MDUR_editor_ud.Value = IEDITOR_ITEM.MaxDurability;
                TIER_editor_ud.Value = IEDITOR_ITEM.Tier;
                GRADE_editor_ud.Value = IEDITOR_ITEM.Grade;
                EType_editor_tbox.Text = IEDITOR_ITEM.EType;
                ELevel_editor_ud.Value = IEDITOR_ITEM.ELevel;
                Oracalcite_editor_checkb.Checked = IEDITOR_ITEM.Oracalcite;

                foreach (object option in Item_Character_Cbox.Items)
                {
                    string CID = option.ToString().Split('<', '>')[1];
                    if (Convert.ToInt32(CID) == IEDITOR_ITEM.OWNER_ID)
                    {
                        Item_Character_Cbox.SelectedItem = option.ToString();
                    }
                }
            }

        }

        private void DItem_editor_btn_Click(object sender, EventArgs e)
        {
            ITEM IEDITOR_ITEM = new ITEM(conn);
            IEDITOR_ITEM.ItemID = (int)ID_editor_up.Value;
            IEDITOR_ITEM.GetData();
            IEDITOR_ITEM.Delete();
            UItem_editor_btn.PerformClick();
        }

        private void MItem_editor_btn_Click(object sender, EventArgs e)
        {

            ITEM IEDITOR_ITEM = new ITEM(conn);
            IEDITOR_ITEM.ItemID = (int)ID_editor_up.Value;
            IEDITOR_ITEM.Name = Item_name_editor_tbox.Text;
            IEDITOR_ITEM.Description = item_desc_editor_tbox.Text;
            IEDITOR_ITEM.Dice = (int)DICE_editor_ud.Value;
            IEDITOR_ITEM.M_HP = (int)HP_editor_ud.Value;
            IEDITOR_ITEM.M_MP = (int)MP_editor_ud.Value;
            IEDITOR_ITEM.M_ATK = (int)ATK_editor_ud.Value;
            IEDITOR_ITEM.M_SATK = (int)SATK_editor_ud.Value;
            IEDITOR_ITEM.M_DEF = (int)DEF_editor_ud.Value;
            IEDITOR_ITEM.M_SDEF = (int)SDEF_editor_ud.Value;
            IEDITOR_ITEM.M_CHAR = (int)CHAR_editor_ud.Value;
            IEDITOR_ITEM.M_DEX = (int)DEX_editor_ud.Value;
            IEDITOR_ITEM.M_STR = (int)STR_editor_ud.Value;
            IEDITOR_ITEM.M_INT = (int)INT_editor_ud.Value;
            IEDITOR_ITEM.M_PERC = (int)PERC_editor_ud.Value;
            IEDITOR_ITEM.Satiety = (int)SAT_editor_ud.Value;
            IEDITOR_ITEM.Equipped = false;
            IEDITOR_ITEM.Turns = (int)TURNS_editor_ud.Value;
            IEDITOR_ITEM.Quantity = (int)QTY_editor_ud.Value;
            IEDITOR_ITEM.Enhance = (int)ENH_editor_ud.Value;
            IEDITOR_ITEM.Durability = (int)DUR_editor_ud.Value;
            IEDITOR_ITEM.MaxDurability = (int)MDUR_editor_ud.Value;
            IEDITOR_ITEM.Tier = (int)TIER_editor_ud.Value;
            IEDITOR_ITEM.Grade = (int)GRADE_editor_ud.Value;
            IEDITOR_ITEM.EType = EType_editor_tbox.Text;
            IEDITOR_ITEM.ELevel = (int)ELevel_editor_ud.Value;
            IEDITOR_ITEM.Oracalcite = Oracalcite_editor_checkb.Checked;

            if (Item_Character_Cbox.SelectedItem != null)
            {
                string IID = Item_Character_Cbox.Items[Item_Character_Cbox.SelectedIndex].ToString().Split('<', '>')[1];
                IEDITOR_ITEM.OWNER_ID = Convert.ToInt32(IID);
            }

            IEDITOR_ITEM.Type_To_Prop(Item_type_editor_cbox.SelectedItem.ToString());

            IEDITOR_ITEM.PostData();
            UItem_editor_btn.PerformClick();
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
                MessageBox.Show("Not Enhanceable ");
            }
        }

        private void UItem_editor_btn_Click(object sender, EventArgs e)
        {
            int CharID = 0;
            int FiltID = 0;
            List<NPC> GM_NPCS = GM_NPC_LIST.GetNPCS("ALL", "1");
            CharID = Item_Character_Cbox.SelectedIndex;
            FiltID = ItemFilter_sbox.SelectedIndex;
            Item_Character_Cbox.Items.Clear();
            ItemFilter_sbox.Items.Clear();
            ItemFilter_sbox.Items.Add("ALL");
            foreach (NPC GM_NPC in GM_NPCS)
            {
                Item_Character_Cbox.Items.Add(GM_NPC.PLAYER_DATA());
                ItemFilter_sbox.Items.Add(GM_NPC.PLAYER_DATA());
            }
            Item_Character_Cbox.SelectedIndex = CharID;
            ItemFilter_sbox.SelectedIndex = FiltID;

            if (ItemFilter_sbox.SelectedItem == null || ItemFilter_sbox.SelectedItem.ToString() == "ALL")
            {
                List<ITEM> GM_ITEMS = GM_ITEM_LIST.GetITEM("ALL", "1");
                EditorItems_lbox.Items.Clear();
                foreach (ITEM GM_ITEM in GM_ITEMS)
                {
                    EditorItems_lbox.Items.Add(GM_ITEM.ITEM_DATA());
                }
            }
            else
            {
                List<ITEM> GM_ITEMS = GM_ITEM_LIST.GetITEM("OWNER_ID", ItemFilter_sbox.SelectedItem.ToString().Split('<', '>')[1]);
                EditorItems_lbox.Items.Clear();
                foreach (ITEM GM_ITEM in GM_ITEMS)
                {
                    EditorItems_lbox.Items.Add(GM_ITEM.ITEM_DATA());
                }
            }
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
            string WHERE = "ALL";
            string Property = "1";
            switch (Filter_Relation.SelectedItem)
            {
                case "Player":
                    WHERE = "PLAYER";
                    Property = "1";
                    break;
                case "Enemy":
                    WHERE = "ENEMY";
                    Property = "1";
                    break;
                case "NPC":
                    WHERE = "NPC";
                    Property = "1";
                    break;
                case "All":
                    WHERE = "ALL";
                    Property = "1";
                    break;
            }
            List<NPC> GM_NPCS = GM_NPC_LIST.GetNPCS(WHERE, Property);
            NPCS_lbox.Items.Clear();
            foreach (NPC Player in GM_NPCS)
            {
                Player.GetData();
                NPCS_lbox.Items.Add(Player.PLAYER_DATA());
            }
        }

        private void Equipment_tab_Click(object sender, EventArgs e)
        {

        }

        private void Spells_tab_Click(object sender, EventArgs e)
        {

        }

        private void New_Spell_editor_BTN_Click(object sender, EventArgs e)
        {
            SPELL SEDITOR_SPELL = new SPELL(conn);
            SEDITOR_SPELL.Name = Spell_name_editor_tbox.Text;
            SEDITOR_SPELL.Description = spell_desc_editor_tbox.Text;
            SEDITOR_SPELL.Tier = (int)Tier_Spell_editor_ud.Value;
            SEDITOR_SPELL.Rank = (int)Rank_Spell_editor_ud.Value;
            SEDITOR_SPELL.MaxSlots = (int)MSlots_Spell_editor_ud.Value;
            SEDITOR_SPELL.Slots = (int)Slots_Spell_editor_ud.Value;
            SEDITOR_SPELL.C_MP = (int)C_MP_UD.Value;

            if (Spell_Character_Cbox.SelectedItem != null)
            {
                string IID = Spell_Character_Cbox.SelectedItem.ToString().Split('<', '>')[1];
                SEDITOR_SPELL.OWNER_ID = Convert.ToInt32(IID);
            }
            SEDITOR_SPELL.CreateData();
            Refresh_Spell_editor_BTN.PerformClick();
        }

        private void Refresh_Spell_editor_BTN_Click(object sender, EventArgs e)
        {
            int CharID = 0;
            int FiltID = 0;
            List<NPC> GM_NPCS = GM_NPC_LIST.GetNPCS("ALL", "1");
            CharID = Spell_Character_Cbox.SelectedIndex;
            FiltID = SpellFilter_sbox.SelectedIndex;
            Spell_Character_Cbox.Items.Clear();
            SpellFilter_sbox.Items.Clear();
            SpellFilter_sbox.Items.Add("ALL");
            foreach (NPC GM_NPC in GM_NPCS)
            {
                Spell_Character_Cbox.Items.Add(GM_NPC.PLAYER_DATA());
                SpellFilter_sbox.Items.Add(GM_NPC.PLAYER_DATA());
            }
            Spell_Character_Cbox.SelectedIndex = CharID;
            SpellFilter_sbox.SelectedIndex = FiltID;

            if (SpellFilter_sbox.SelectedItem == null || SpellFilter_sbox.SelectedItem.ToString() == "ALL")
            {
                List<SPELL> GM_SPELLS = GM_SPELLS_LIST.GetSPELLS("ALL", "1");
                Spells_Edititor_lbox.Items.Clear();
                foreach (SPELL GM_SPELL in GM_SPELLS)
                {
                    Spells_Edititor_lbox.Items.Add(GM_SPELL.SPELL_DATA());
                }
            }
            else
            {
                List<SPELL> GM_SPELLS = GM_SPELLS_LIST.GetSPELLS("OWNER_ID", SpellFilter_sbox.SelectedItem.ToString().Split('<', '>')[1]);
                Spells_Edititor_lbox.Items.Clear();
                foreach (SPELL GM_SPELL in GM_SPELLS)
                {
                    Spells_Edititor_lbox.Items.Add(GM_SPELL.SPELL_DATA());
                }
            }
        }

        private void Modify_Spell_editor_BTN_Click(object sender, EventArgs e)
        {
            SPELL SEDITOR_SPELL = new SPELL(conn);
            SEDITOR_SPELL.SpellID = (int)ID_spell_editor_up.Value;
            SEDITOR_SPELL.Name = Spell_name_editor_tbox.Text;
            SEDITOR_SPELL.Description = spell_desc_editor_tbox.Text;
            SEDITOR_SPELL.Tier = (int)Tier_Spell_editor_ud.Value;
            SEDITOR_SPELL.Rank = (int)Rank_Spell_editor_ud.Value;
            SEDITOR_SPELL.MaxSlots = (int)MSlots_Spell_editor_ud.Value;
            SEDITOR_SPELL.Slots = (int)Slots_Spell_editor_ud.Value;
            SEDITOR_SPELL.C_MP = (int)C_MP_UD.Value;

            if (Spell_Character_Cbox.SelectedItem != null)
            {
                string IID = Spell_Character_Cbox.SelectedItem.ToString().Split('<', '>')[1];
                SEDITOR_SPELL.OWNER_ID = Convert.ToInt32(IID);
            }
            SEDITOR_SPELL.PostData();
            Refresh_Spell_editor_BTN.PerformClick();
        }

        private void Delete_Spell_editor_BTN_Click(object sender, EventArgs e)
        {
            SPELL SEDITOR_SPELL= new SPELL(conn);
            SEDITOR_SPELL.SpellID = (int)ID_editor_up.Value;
            SEDITOR_SPELL.GetData();
            SEDITOR_SPELL.Delete();
            Refresh_Spell_editor_BTN.PerformClick();
        }

        private void Spells_Edititor_lbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string IID = "Dead";
            foreach (ListViewItem spell in Spells_Edititor_lbox.SelectedItems)
            {
                IID = spell.Text.Split('<', '>')[1];
            }

            if (IID != "Dead")
            {
                SPELL SEDITOR_SPELL = new SPELL(conn);
                SEDITOR_SPELL.SpellID = Convert.ToInt32(IID);
                SEDITOR_SPELL.GetData();

                ID_spell_editor_up.Value = SEDITOR_SPELL.SpellID;
                Spell_name_editor_tbox.Text = SEDITOR_SPELL.Name;
                spell_desc_editor_tbox.Text = SEDITOR_SPELL.Description;
                Tier_Spell_editor_ud.Value = SEDITOR_SPELL.Tier;
                Rank_Spell_editor_ud.Value = SEDITOR_SPELL.Rank;
                MSlots_Spell_editor_ud.Value = SEDITOR_SPELL.MaxSlots;
                Slots_Spell_editor_ud.Value = SEDITOR_SPELL.Slots;
                C_MP_UD.Value = SEDITOR_SPELL.C_MP;

                foreach (object option in Spell_Character_Cbox.Items)
                {
                    string CID = option.ToString().Split('<', '>')[1];
                    if (Convert.ToInt32(CID) == SEDITOR_SPELL.OWNER_ID)
                    {
                        Spell_Character_Cbox.SelectedItem = option.ToString();
                    }
                }
            }

        }

        private void Equipable_lbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Equipable_lbox.SelectedItem != null)
            {
                string IID = Equipable_lbox.SelectedItem.ToString().Split('<', '>')[1];
                ItemView Iview = new ItemView(Convert.ToInt32(IID), conn, MyPlayer.PlayerID);
                //Iview.Show();
                Equipment_info_CTRL.Controls.Clear();
                Iview.TopLevel = false;
                Iview.TopMost = false;
                Iview.FormBorderStyle = FormBorderStyle.None;
                Iview.Dock = DockStyle.Fill;
                Iview.Visible = true;
                Equipment_info_CTRL.Controls.Add(Iview);
            }
        }

        private void DeEquipAll_btn_Click(object sender, EventArgs e)
        {
            MyPlayer.DeEquip("ALL");
            UPDATE_btn.PerformClick();
        }

        private void DeEquip_Helmet_btn_Click(object sender, EventArgs e)
        {
            MyPlayer.DeEquip("Helmet");
            UPDATE_btn.PerformClick();
        }

        private void DeEquip_Maille_btn_Click(object sender, EventArgs e)
        {
            MyPlayer.DeEquip("Maille");
            UPDATE_btn.PerformClick();
        }

        private void DeEquip_Pants_btn_Click(object sender, EventArgs e)
        {
            MyPlayer.DeEquip("Pants");
            UPDATE_btn.PerformClick();
        }

        private void DeEquip_Boots_btn_Click(object sender, EventArgs e)
        {
            MyPlayer.DeEquip("Boots");
            UPDATE_btn.PerformClick();
        }

        private void DeEquip_Gloves_btn_Click(object sender, EventArgs e)
        {
            MyPlayer.DeEquip("Gloves");
            UPDATE_btn.PerformClick();
        }

        private void DeEquip_Weapon_btn_Click(object sender, EventArgs e)
        {
            MyPlayer.DeEquip("WeaponALL");
            UPDATE_btn.PerformClick();
        }

        private void DeEquip_Artifact_btn_Click(object sender, EventArgs e)
        {
            MyPlayer.DeEquip("Artifact");
            UPDATE_btn.PerformClick();
        }

        private void Helmet_tbox_Click(object sender, EventArgs e)
        {
            if (Helmet_tbox.Text != "")
            {
                string IID = Helmet_tbox.Text.Split('<', '>')[1];
                ItemView Iview = new ItemView(Convert.ToInt32(IID), conn, MyPlayer.PlayerID);
                //Iview.Show();
                Equipment_info_CTRL.Controls.Clear();
                Iview.TopLevel = false;
                Iview.TopMost = false;
                Iview.FormBorderStyle = FormBorderStyle.None;
                Iview.Dock = DockStyle.Fill;
                Iview.Visible = true;
                Equipment_info_CTRL.Controls.Add(Iview);
            }
        }

        private void Maille_tbox_Click(object sender, EventArgs e)
        {
            if (Maille_tbox.Text != "")
            {
                string IID = Maille_tbox.Text.Split('<', '>')[1];
                ItemView Iview = new ItemView(Convert.ToInt32(IID), conn, MyPlayer.PlayerID);
                //Iview.Show();
                Equipment_info_CTRL.Controls.Clear();
                Iview.TopLevel = false;
                Iview.TopMost = false;
                Iview.FormBorderStyle = FormBorderStyle.None;
                Iview.Dock = DockStyle.Fill;
                Iview.Visible = true;
                Equipment_info_CTRL.Controls.Add(Iview);
            }
        }

        private void Pants__tbox_Click(object sender, EventArgs e)
        {
            if (Pants__tbox.Text != "")
            {
                string IID = Pants__tbox.Text.Split('<', '>')[1];
                ItemView Iview = new ItemView(Convert.ToInt32(IID), conn, MyPlayer.PlayerID);
                //Iview.Show();
                Equipment_info_CTRL.Controls.Clear();
                Iview.TopLevel = false;
                Iview.TopMost = false;
                Iview.FormBorderStyle = FormBorderStyle.None;
                Iview.Dock = DockStyle.Fill;
                Iview.Visible = true;
                Equipment_info_CTRL.Controls.Add(Iview);
            }
        }

        private void Boots_tbox_Click(object sender, EventArgs e)
        {
            if (Boots_tbox.Text != "")
            {
                string IID = Boots_tbox.Text.Split('<', '>')[1];
                ItemView Iview = new ItemView(Convert.ToInt32(IID), conn, MyPlayer.PlayerID);
                //Iview.Show();
                Equipment_info_CTRL.Controls.Clear();
                Iview.TopLevel = false;
                Iview.TopMost = false;
                Iview.FormBorderStyle = FormBorderStyle.None;
                Iview.Dock = DockStyle.Fill;
                Iview.Visible = true;
                Equipment_info_CTRL.Controls.Add(Iview);
            }
        }

        private void Gloves_tbox_Click(object sender, EventArgs e)
        {
            if (Gloves_tbox.Text != "")
            {
                string IID = Gloves_tbox.Text.Split('<', '>')[1];
                ItemView Iview = new ItemView(Convert.ToInt32(IID), conn, MyPlayer.PlayerID);
                //Iview.Show();
                Equipment_info_CTRL.Controls.Clear();
                Iview.TopLevel = false;
                Iview.TopMost = false;
                Iview.FormBorderStyle = FormBorderStyle.None;
                Iview.Dock = DockStyle.Fill;
                Iview.Visible = true;
                Equipment_info_CTRL.Controls.Add(Iview);
            }
        }

        private void WeaponRight_tbox_Click(object sender, EventArgs e)
        {
            if (WeaponRight_tbox.Text != "")
            {
                string IID = WeaponRight_tbox.Text.Split('<', '>')[1];
                ItemView Iview = new ItemView(Convert.ToInt32(IID), conn, MyPlayer.PlayerID);
                //Iview.Show();
                Equipment_info_CTRL.Controls.Clear();
                Iview.TopLevel = false;
                Iview.TopMost = false;
                Iview.FormBorderStyle = FormBorderStyle.None;
                Iview.Dock = DockStyle.Fill;
                Iview.Visible = true;
                Equipment_info_CTRL.Controls.Add(Iview);
            }
        }

        private void Weapon_tbox_Click(object sender, EventArgs e)
        {
            if (WeaponLeft_tbox.Text != "")
            {
                string IID = WeaponLeft_tbox.Text.Split('<', '>')[1];
                ItemView Iview = new ItemView(Convert.ToInt32(IID), conn, MyPlayer.PlayerID);
                //Iview.Show();
                Equipment_info_CTRL.Controls.Clear();
                Iview.TopLevel = false;
                Iview.TopMost = false;
                Iview.FormBorderStyle = FormBorderStyle.None;
                Iview.Dock = DockStyle.Fill;
                Iview.Visible = true;
                Equipment_info_CTRL.Controls.Add(Iview);
            }
        }

        private void Artifact_tbox_Click(object sender, EventArgs e)
        {
            if (Artifact_tbox.Text != "")
            {
                string IID = Artifact_tbox.Text.Split('<', '>')[1];
                ItemView Iview = new ItemView(Convert.ToInt32(IID), conn, MyPlayer.PlayerID);
                //Iview.Show();
                Equipment_info_CTRL.Controls.Clear();
                Iview.TopLevel = false;
                Iview.TopMost = false;
                Iview.FormBorderStyle = FormBorderStyle.None;
                Iview.Dock = DockStyle.Fill;
                Iview.Visible = true;
                Equipment_info_CTRL.Controls.Add(Iview);
            }
        }

        private void Filter_Relation_SelectedIndexChanged(object sender, EventArgs e)
        {
            CM_UPDATE_BTN.PerformClick();
        }

        private void GenerateEnemy()
        {
            for (int it = 0; it < Creature_Ammount_UD.Value; it++)
            {
                NPC Creature = new NPC(conn);
                int ITERATION = it + 1;
                Creature.PName = CCName_tbox.Text + ITERATION.ToString();
                Creature.isNPC = !Enemy_cbox.Checked;
                Creature.isEnemy = Enemy_cbox.Checked;
                Creature.isPlayer = false;
                Creature.PlayerOwner = "1";
                Creature.UserName = Creature.PName + " " + rnd.Next(0, 999999).ToString();
                Creature.Age = rnd.Next(15, 71);
                Creature.XPREQ = 999999999;

                if (!CCmbase_chbox.Checked)
                {
                    Creature.HPMax = rnd.Next(0, 11) + 10;
                    Creature.MPMax = rnd.Next(0, 11) + 10;
                    Creature.ATK = rnd.Next(0, 5);
                    Creature.SATK = rnd.Next(0, 5);
                    Creature.DEF = rnd.Next(0, 5);
                    Creature.SDEF = rnd.Next(0, 5);
                    Creature.CHARIS = rnd.Next(0, 5);
                    Creature.DEX = rnd.Next(0, 5);
                    Creature.STR = rnd.Next(0, 5);
                    Creature.INTEL = rnd.Next(0, 5);
                    Creature.PERC = rnd.Next(0, 5);
                }
                else
                {
                    Creature.HPMax = (int)CCHP_UD.Value;
                    Creature.MPMax = (int)CCMP_UD.Value;
                    Creature.ATK = (int)CCATK_UD.Value;
                    Creature.SATK = (int)CCSATK_UD.Value;
                    Creature.DEF = (int)CCDEF_UD.Value;
                    Creature.SDEF = (int)CCSDEF_UD.Value;
                    Creature.CHARIS = (int)CCCHAR_UD.Value;
                    Creature.DEX = (int)CCDEX_UD.Value;
                    Creature.STR = (int)CCSTR_UD.Value;
                    Creature.INTEL = (int)CCINT_UD.Value;
                    Creature.PERC = (int)CCPERC_UD.Value;
                }

                double ENH_luck = 0;
                int MaxSTAT = 0;
                int MaxENCH = 0;
                double Ench_luck = 0;
                switch (CCLEVELSEL_CBOX.SelectedItem)
                {
                    case "Sanim":
                        Creature.Level = rnd.Next(1, 6);
                        MaxSTAT = 10;
                        ENH_luck = 0.7578582833;
                        Ench_luck = 0;
                        MaxENCH = 4;
                        break;
                    case "Twilith":
                        Creature.Level = rnd.Next(6, 11);
                        MaxSTAT = 10;
                        ENH_luck = 0.8705505633;
                        Ench_luck = 0.5;
                        MaxENCH = 4;
                        break;
                    case "Salvian":
                        Creature.Level = rnd.Next(11, 16);
                        MaxSTAT = 10;
                        ENH_luck = 0.9117224886;
                        Ench_luck = 0.7071067812;
                        MaxENCH = 4;
                        break;
                    case "Forlorn":
                        Creature.Level = rnd.Next(16, 21);
                        MaxSTAT = 10;
                        ENH_luck = 0.9330329915;
                        Ench_luck = 0.793700526;
                        MaxENCH = 4;
                        break;
                    case "Shutat":
                        Creature.Level = rnd.Next(21, 26);
                        MaxSTAT = 20;
                        ENH_luck = 0.9438743127;
                        Ench_luck = 0.8332620064;
                        MaxENCH = 8;
                        break;
                    case "Twixes":
                        Creature.Level = rnd.Next(26, 31);
                        MaxSTAT = 20;
                        ENH_luck = 0.951695153;
                        Ench_luck = 0.8601193075;
                        MaxENCH = 8;
                        break;
                    case "Grawlith":
                        Creature.Level = rnd.Next(31, 36);
                        MaxSTAT = 20;
                        ENH_luck = 0.9576032807;
                        Ench_luck = 0.8795361709;
                        MaxENCH = 8;
                        break;
                    case "Xerxiar":
                        Creature.Level = rnd.Next(36, 41);
                        MaxSTAT = 20;
                        ENH_luck = 0.9622238369;
                        Ench_luck = 0.8942249332;
                        MaxENCH = 8;
                        break;
                    case "Azimat":
                        Creature.Level = rnd.Next(41, 46);
                        MaxSTAT = 20;
                        ENH_luck = 0.9659363289;
                        Ench_luck = 0.9057236643;
                        MaxENCH = 8;
                        break;
                    case "Xerxes":
                        Creature.Level = rnd.Next(46, 51);
                        MaxSTAT = 30;
                        ENH_luck = 0.9696631446;
                        Ench_luck = 0.9170040432;
                        MaxENCH = 12;
                        break;
                    case "Flittigan":
                        Creature.Level = rnd.Next(51, 56);
                        MaxSTAT = 30;
                        ENH_luck = 0.9726549474;
                        Ench_luck = 0.9258747123;
                        MaxENCH = 12;
                        break;
                    case "Partavial":
                        Creature.Level = rnd.Next(56, 61);
                        MaxSTAT = 30;
                        ENH_luck = 0.9751096507;
                        Ench_luck = 0.9330329915;
                        MaxENCH = 12;
                        break;
                    case "Pheonoe":
                        Creature.Level = rnd.Next(61, 66);
                        MaxSTAT = 30;
                        ENH_luck = 0.9771599684;
                        Ench_luck = 0.9389309107;
                        MaxENCH = 12;
                        break;
                    case "Grawmat":
                        Creature.Level = rnd.Next(66, 71);
                        MaxSTAT = 40;
                        ENH_luck = 0.9788982195;
                        Ench_luck = 0.9438743127;
                        MaxENCH = 16;
                        break;
                    case "Bardum":
                        Creature.Level = rnd.Next(71, 76);
                        MaxSTAT = 40;
                        ENH_luck = 0.9803906099;
                        Ench_luck = 0.9480775143;
                        MaxENCH = 16;
                        break;
                    case "Valethor":
                        Creature.Level = rnd.Next(76, 81);
                        MaxSTAT = 40;
                        ENH_luck = 0.9816858552;
                        Ench_luck = 0.951695153;
                        MaxENCH = 16;
                        break;
                    case "Rigis":
                        Creature.Level = rnd.Next(81, 86);
                        MaxSTAT = 40;
                        ENH_luck = 0.9828205985;
                        Ench_luck = 0.9548416039;
                        MaxENCH = 16;
                        break;
                    case "Aziar":
                        Creature.Level = rnd.Next(86, 91);
                        MaxSTAT = 50;
                        ENH_luck = 0.9838229319;
                        Ench_luck = 0.9576032807;
                        MaxENCH = 20;
                        break;
                    case "Akinawa":
                        Creature.Level = rnd.Next(91, 96);
                        MaxSTAT = 50;
                        ENH_luck = 0.9847147529;
                        Ench_luck = 0.9600466869;
                        MaxENCH = 20;
                        break;
                    case "Gaelidia":
                        Creature.Level = rnd.Next(96, 101);
                        MaxSTAT = 50;
                        ENH_luck = 0.9855133833;
                        Ench_luck = 0.9622238369;
                        MaxENCH = 20;
                        break;
                    case "Angiel":
                        Creature.Level = rnd.Next(101, 106);
                        MaxSTAT = 50;
                        ENH_luck = 0.9862327045;
                        Ench_luck = 0.9641759979;
                        MaxENCH = 20;
                        break;
                    case "Custom":
                        Creature.Level = (int)CCCUSLVL_UD.Value;
                        MaxSTAT = (int)CCCUSMSP_UD.Value;
                        ENH_luck = (double)CCCUSLCK_UD.Value;
                        Ench_luck = (double)CCCUSELCK_ud.Value;
                        MaxENCH = (int)CCCUSMEL_UD.Value;
                        break;
                }

                for (int i = 0; i < (((Creature.Level * (Creature.Level - 1)) / 2)) * (Convert.ToInt32(CCBos_chbox.Checked) + 1); i++)
                {
                    switch (rnd.Next(1, 12))
                    {
                        case 1:
                            Creature.HPMax++;
                            break;
                        case 2:
                            Creature.MPMax++;
                            break;
                        case 3:
                            Creature.ATK++;
                            break;
                        case 4:
                            Creature.SATK++;
                            break;
                        case 5:
                            Creature.DEF++;
                            break;
                        case 6:
                            Creature.SDEF++;
                            break;
                        case 7:
                            Creature.CHARIS++;
                            break;
                        case 8:
                            Creature.DEX++;
                            break;
                        case 9:
                            Creature.STR++;
                            break;
                        case 10:
                            Creature.INTEL++;
                            break;
                        case 11:
                            Creature.PERC++;
                            break;
                    }
                }

                double XP = 0;
                for (int i = 1; i < (Creature.Level + 1); i++)
                {
                    XP += Math.Pow(i, 3);
                }
                XP /= (double)Creature.Level;
                XP = Math.Round(XP, MidpointRounding.AwayFromZero);
                if (XP < 0)
                {
                    MessageBox.Show("XP Error");
                    return;
                }
                Creature.XP = (int)XP;



                Creature.XP = (int)Math.Ceiling(Creature.XP * CCOXPMOD_tbox.Value);
                Creature.HPMax = (int)Math.Ceiling(Creature.HPMax * CCOXPMOD_tbox.Value);
                Creature.MPMax = (int)Math.Ceiling(Creature.MPMax * CCOXPMOD_tbox.Value);
                Creature.ATK = (int)Math.Ceiling(Creature.ATK * CCOXPMOD_tbox.Value);
                Creature.SATK = (int)Math.Ceiling(Creature.SATK * CCOXPMOD_tbox.Value);
                Creature.DEF = (int)Math.Ceiling(Creature.DEF * CCOXPMOD_tbox.Value);
                Creature.SDEF = (int)Math.Ceiling(Creature.SDEF * CCOXPMOD_tbox.Value);
                Creature.CHARIS = (int)Math.Ceiling(Creature.CHARIS * CCOXPMOD_tbox.Value);
                Creature.DEX = (int)Math.Ceiling(Creature.DEX * CCOXPMOD_tbox.Value);
                Creature.STR = (int)Math.Ceiling(Creature.STR * CCOXPMOD_tbox.Value);
                Creature.INTEL = (int)Math.Ceiling(Creature.INTEL * CCOXPMOD_tbox.Value);
                Creature.PERC = (int)Math.Ceiling(Creature.PERC * CCOXPMOD_tbox.Value);

                if (CCCustom__chbox.Checked)
                {
                    Creature.XP = (int)CCXP_UD.Value;
                    Creature.HPMax = (int)CCHP_UD.Value;
                    Creature.MPMax = (int)CCMP_UD.Value;
                    Creature.ATK = (int)CCATK_UD.Value;
                    Creature.SATK = (int)CCSATK_UD.Value;
                    Creature.DEF = (int)CCDEF_UD.Value;
                    Creature.SDEF = (int)CCSDEF_UD.Value;
                    Creature.CHARIS = (int)CCCHAR_UD.Value;
                    Creature.DEX = (int)CCDEX_UD.Value;
                    Creature.STR = (int)CCSTR_UD.Value;
                    Creature.INTEL = (int)CCINT_UD.Value;
                    Creature.PERC = (int)CCPERC_UD.Value;
                }

                switch (CCTYPE_cbox.SelectedItem)
                {
                    case "None":
                        break;
                    case "Fire":
                        Creature.Fire = 1;
                        break;
                    case "Ice":
                        Creature.Ice = 1;
                        break;
                    case "Earth":
                        Creature.Earth = 1;
                        break;
                    case "Lightning":
                        Creature.Lightning = 1;
                        break;
                    case "Holy":
                        Creature.Holy = 1;
                        break;
                    case "Unholy":
                        Creature.Unholy = 1;
                        break;
                    case "Oracalcite":
                        Creature.Fire = 1;
                        Creature.Ice = 1;
                        Creature.Earth = 1;
                        Creature.Lightning = 1;
                        Creature.Holy = 1;
                        Creature.Unholy = 1;
                        break;
                }

                if (CCGolem__chbox.Checked)
                {
                    Creature.MPMax += Creature.HPMax;
                    Creature.HPMax = 0;
                }

                Creature.HP = Creature.HPMax;
                Creature.MP = Creature.MPMax;
                Creature.CreateData();

                if (GITEMS_cbox.Checked)
                {
                    Generate_item(Creature.PlayerID, Creature.PName, "Helmet", ENH_luck, Ench_luck, MaxSTAT, MaxENCH, Helm_HP.Checked, Helm_MP.Checked, Helm_ATK.Checked,
                        Helm_SATK.Checked, Helm_DEF.Checked, Helm_SDEF.Checked, Helm_CHAR.Checked, Helm_DEX.Checked, Helm_STR.Checked, Helm_INT.Checked, Helm_PERC.Checked);

                    Generate_item(Creature.PlayerID, Creature.PName, "Maille", ENH_luck, Ench_luck, MaxSTAT, MaxENCH, Maille_HP.Checked, Maille_MP.Checked, Maille_ATK.Checked,
                        Maille_SATK.Checked, Maille_DEF.Checked, Maille_SDEF.Checked, Maille_CHAR.Checked, Maille_DEX.Checked, Maille_STR.Checked, Maille_INT.Checked, Maille_PERC.Checked);

                    Generate_item(Creature.PlayerID, Creature.PName, "Gloves", ENH_luck, Ench_luck, MaxSTAT, MaxENCH, Gloves_HP.Checked, Gloves_MP.Checked, Gloves_ATK.Checked,
                        Gloves_SATK.Checked, Gloves_DEF.Checked, Gloves_SDEF.Checked, Gloves_CHAR.Checked, Gloves_DEX.Checked, Gloves_STR.Checked, Gloves_INT.Checked, Gloves_PERC.Checked);

                    Generate_item(Creature.PlayerID, Creature.PName, "Pants", ENH_luck, Ench_luck, MaxSTAT, MaxENCH, Pants_HP.Checked, Pants_MP.Checked, Pants_ATK.Checked,
                        Pants_SATK.Checked, Pants_DEF.Checked, Pants_SDEF.Checked, Pants_CHAR.Checked, Pants_DEX.Checked, Pants_STR.Checked, Pants_INT.Checked, Pants_PERC.Checked);

                    Generate_item(Creature.PlayerID, Creature.PName, "Boots", ENH_luck, Ench_luck, MaxSTAT, MaxENCH, Boots_HP.Checked, Boots_MP.Checked, Boots_ATK.Checked,
                        Boots_SATK.Checked, Boots_DEF.Checked, Boots_SDEF.Checked, Boots_CHAR.Checked, Boots_DEX.Checked, Boots_STR.Checked, Boots_INT.Checked, Boots_PERC.Checked);


                    Generate_item(Creature.PlayerID, Creature.PName, "Artifact", ENH_luck, Ench_luck, MaxSTAT, MaxENCH, Artifact_HP.Checked, Artifact_MP.Checked, Artifact_ATK.Checked,
                        Artifact_SATK.Checked, Artifact_DEF.Checked, Artifact_SDEF.Checked, Artifact_CHAR.Checked, Artifact_DEX.Checked, Artifact_STR.Checked, Artifact_INT.Checked, Artifact_PERC.Checked);

                    if (rnd.Next(0, 101) >= 50)
                    {

                        Generate_item(Creature.PlayerID, Creature.PName, "Weapon", ENH_luck, Ench_luck, MaxSTAT, MaxENCH, LWeapon_HP.Checked, LWeapon_MP.Checked, LWeapon_ATK.Checked,
                            LWeapon_SATK.Checked, LWeapon_DEF.Checked, LWeapon_SDEF.Checked, LWeapon_CHAR.Checked, LWeapon_DEX.Checked, LWeapon_STR.Checked, LWeapon_INT.Checked, LWeapon_PERC.Checked);

                        Generate_item(Creature.PlayerID, Creature.PName, "Weapon", ENH_luck, Ench_luck, MaxSTAT, MaxENCH, RWeapon_HP.Checked, RWeapon_MP.Checked, RWeapon_ATK.Checked,
                            RWeapon_SATK.Checked, RWeapon_DEF.Checked, RWeapon_SDEF.Checked, RWeapon_CHAR.Checked, RWeapon_DEX.Checked, RWeapon_STR.Checked, RWeapon_INT.Checked, RWeapon_PERC.Checked);

                    }
                    else
                    {

                        Generate_item(Creature.PlayerID, Creature.PName, "Weapon", ENH_luck, Ench_luck, MaxSTAT, MaxENCH, LWeapon_HP.Checked, LWeapon_MP.Checked, LWeapon_ATK.Checked,
                            LWeapon_SATK.Checked, LWeapon_DEF.Checked, LWeapon_SDEF.Checked, LWeapon_CHAR.Checked, LWeapon_DEX.Checked, LWeapon_STR.Checked, LWeapon_INT.Checked, LWeapon_PERC.Checked);

                    }
                }



            }
            MessageBox.Show("Creature Created");
        }

        private void Generate_item(int PlayerID, string PName, string ITEMType, double ENH_luck, double Ench_luck, int MaxSTAT, int MaxENCH, bool C_HP, bool C_MP, bool C_ATK, bool C_SATK, bool C_DEF, bool C_SDEF, bool C_CHAR, bool C_DEX, bool C_STR, bool C_INT, bool C_PERC)
        {

            ITEM CITEM = new ITEM(conn);
            CITEM.Name = PName + " " + ITEMType;
            CITEM.Description = "";
            CITEM.Type_To_Prop(ITEMType);
            CITEM.OWNER_ID = PlayerID;
            CITEM.Equipped = true;

            //Base for Item
            bool notZero = true;
            while (notZero)
            {
                CITEM.M_HP = (rnd.Next(0, MaxSTAT) * Convert.ToInt32(C_HP));
                CITEM.M_MP = (rnd.Next(0, MaxSTAT) * Convert.ToInt32(C_MP));
                CITEM.M_ATK = (rnd.Next(0, MaxSTAT) * Convert.ToInt32(C_ATK));
                CITEM.M_SATK = (rnd.Next(0, MaxSTAT) * Convert.ToInt32(C_SATK));
                CITEM.M_DEF = (rnd.Next(0, MaxSTAT) * Convert.ToInt32(C_DEF));
                CITEM.M_SDEF = (rnd.Next(0, MaxSTAT) * Convert.ToInt32(C_SDEF));
                CITEM.M_CHAR = (rnd.Next(0, MaxSTAT) * Convert.ToInt32(C_CHAR));
                CITEM.M_DEX = (rnd.Next(0, MaxSTAT) * Convert.ToInt32(C_DEX));
                CITEM.M_STR = (rnd.Next(0, MaxSTAT) * Convert.ToInt32(C_STR));
                CITEM.M_INT = (rnd.Next(0, MaxSTAT) * Convert.ToInt32(C_INT));
                CITEM.M_PERC = (rnd.Next(0, MaxSTAT) * Convert.ToInt32(C_PERC));

                if (CITEM.M_HP + CITEM.M_MP + CITEM.M_ATK + CITEM.M_SATK + CITEM.M_DEF + CITEM.M_SDEF + CITEM.M_CHAR + CITEM.M_DEX
                    + CITEM.M_STR + CITEM.M_INT + CITEM.M_PERC != 0) notZero = false;
            }

            if (ITEMType != "Artifact")
            {
                //Enhance for Item
                bool enhancing = true;
                if (RandomNumberBetween(0.0000000000, 1.0000000000) > ENH_luck) enhancing = false;
                while (enhancing)
                {
                    decimal TotalStatPoints = CITEM.M_HP + CITEM.M_MP + CITEM.M_ATK + CITEM.M_SATK + CITEM.M_DEF + CITEM.M_SDEF + CITEM.M_CHAR + CITEM.M_DEX
                        + CITEM.M_STR + CITEM.M_INT + CITEM.M_PERC;

                    decimal TargetStatPoints = ((Math.Ceiling(((decimal)(CITEM.Enhance) + 1) / 10)) / 10) * TotalStatPoints;
                    CITEM.Enhance += 1;

                    while (TargetStatPoints > 0)
                    {
                        switch (rnd.Next(0, 11))
                        {
                            case 0:
                                if (CITEM.M_HP > 0)
                                {
                                    CITEM.M_HP += 1;
                                    TargetStatPoints -= 1;
                                }
                                break;
                            case 1:
                                if (CITEM.M_MP > 0)
                                {
                                    CITEM.M_MP += 1;
                                    TargetStatPoints -= 1;
                                }
                                break;
                            case 2:
                                if (CITEM.M_ATK > 0)
                                {
                                    CITEM.M_ATK += 1;
                                    TargetStatPoints -= 1;
                                }
                                break;
                            case 3:
                                if (CITEM.M_SATK > 0)
                                {
                                    CITEM.M_SATK += 1;
                                    TargetStatPoints -= 1;
                                }
                                break;
                            case 4:
                                if (CITEM.M_DEF > 0)
                                {
                                    CITEM.M_DEF += 1;
                                    TargetStatPoints -= 1;
                                }
                                break;
                            case 5:
                                if (CITEM.M_SDEF > 0)
                                {
                                    CITEM.M_SDEF += 1;
                                    TargetStatPoints -= 1;
                                }
                                break;
                            case 6:
                                if (CITEM.M_CHAR > 0)
                                {
                                    CITEM.M_CHAR += 1;
                                    TargetStatPoints -= 1;
                                }
                                break;
                            case 7:
                                if (CITEM.M_DEX > 0)
                                {
                                    CITEM.M_DEX += 1;
                                    TargetStatPoints -= 1;
                                }
                                break;
                            case 8:
                                if (CITEM.M_STR > 0)
                                {
                                    CITEM.M_STR += 1;
                                    TargetStatPoints -= 1;
                                }
                                break;
                            case 9:
                                if (CITEM.M_INT > 0)
                                {
                                    CITEM.M_INT += 1;
                                    TargetStatPoints -= 1;
                                }
                                break;
                            case 10:
                                if (CITEM.M_PERC > 0)
                                {
                                    CITEM.M_PERC += 1;
                                    TargetStatPoints -= 1;
                                }
                                break;
                        }
                    }
                    if (CITEM.Enhance >= MaxSTAT) enhancing = false;
                    if (RandomNumberBetween(0.0000000000, 1.0000000000) > ENH_luck) enhancing = false;
                }
            }

            if (ITEMType == "Weapon")
            {
                switch(rnd.Next(1,7))
                {
                    case 1:
                        CITEM.Dice = 4;
                        break;
                    case 2:
                        CITEM.Dice = 6;
                        break;
                    case 3:
                        CITEM.Dice = 8;
                        break;
                    case 4:
                        CITEM.Dice = 10;
                        break;
                    case 5:
                        CITEM.Dice = 12;
                        break;
                    case 6:
                        CITEM.Dice = 20;
                        break;
                }
            }

            if (ITEMType != "Artifact")
            {
                if (GenEnchants_cbox.Checked)
                {
                    if (rnd.Next(1, 6) == 5)
                    {
                        switch (rnd.Next(1, 7))
                        {
                            case 1:
                                CITEM.EType = "F";
                                break;
                            case 2:
                                CITEM.EType = "E";
                                break;
                            case 3:
                                CITEM.EType = "L";
                                break;
                            case 4:
                                CITEM.EType = "I";
                                break;
                            case 5:
                                CITEM.EType = "H";
                                break;
                            case 6:
                                CITEM.EType = "U";
                                break;
                        }
                        bool ELeveling = true;
                        while (ELeveling)
                        {
                            CITEM.ELevel += 1;
                            if (RandomNumberBetween(0.00000000000, 1.00000000000) > Ench_luck) ELeveling = false;
                        }
                    }
                }
            }

            CITEM.CreateData();
        }


        private void CCLEVELSEL_CBOX_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CCLEVELSEL_CBOX.SelectedItem == "Custom")
            {
                CCCUSLVL_UD.Enabled = true;
                CCCUSLCK_UD.Enabled = true;
                CCCUSMSP_UD.Enabled = true;
                CCCUSELCK_ud.Enabled = true;
                CCCUSMEL_UD.Enabled = true;
            }
            else
            {
                CCCUSLVL_UD.Enabled = false;
                CCCUSLCK_UD.Enabled = false;
                CCCUSMSP_UD.Enabled = false;
                CCCUSELCK_ud.Enabled = false;
                CCCUSMEL_UD.Enabled = false;
            }
        }

        private void CCmbase_chbox_CheckedChanged(object sender, EventArgs e)
        {
            CCHP_UD.Enabled = CCmbase_chbox.Checked;
            CCMP_UD.Enabled = CCmbase_chbox.Checked;
            CCATK_UD.Enabled = CCmbase_chbox.Checked;
            CCSATK_UD.Enabled = CCmbase_chbox.Checked;
            CCDEF_UD.Enabled = CCmbase_chbox.Checked;
            CCSDEF_UD.Enabled = CCmbase_chbox.Checked;
            CCCHAR_UD.Enabled = CCmbase_chbox.Checked;
            CCDEX_UD.Enabled = CCmbase_chbox.Checked;
            CCSTR_UD.Enabled = CCmbase_chbox.Checked;
            CCINT_UD.Enabled = CCmbase_chbox.Checked;
            CCPERC_UD.Enabled = CCmbase_chbox.Checked;
            CCCustom__chbox.Checked = false;
            CCCustom__chbox.Enabled = !CCmbase_chbox.Checked;
        }

        private void NPC_Create_btn_Click(object sender, EventArgs e)
        {
            GenerateEnemy();
        }

        private void AutoRefresh_cbox_CheckedChanged(object sender, EventArgs e)
        {
            if (!AutoRefresh_cbox.Checked)
            {
                Update_timer.Stop();
            } else
            {
                Update_timer.Start();
            }

        }

        private void CCCustom__chbox_CheckedChanged(object sender, EventArgs e)
        {
            CCHP_UD.Enabled = CCCustom__chbox.Checked;
            CCMP_UD.Enabled = CCCustom__chbox.Checked;
            CCATK_UD.Enabled = CCCustom__chbox.Checked;
            CCSATK_UD.Enabled = CCCustom__chbox.Checked;
            CCDEF_UD.Enabled = CCCustom__chbox.Checked;
            CCSDEF_UD.Enabled = CCCustom__chbox.Checked;
            CCCHAR_UD.Enabled = CCCustom__chbox.Checked;
            CCDEX_UD.Enabled = CCCustom__chbox.Checked;
            CCSTR_UD.Enabled = CCCustom__chbox.Checked;
            CCINT_UD.Enabled = CCCustom__chbox.Checked;
            CCPERC_UD.Enabled = CCCustom__chbox.Checked;
            CCXP_UD.Enabled = CCCustom__chbox.Checked;
            CCmbase_chbox.Checked = false;
            CCmbase_chbox.Enabled = !CCCustom__chbox.Checked;
        }

        private void SpellFilter_sbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SpellFilter_sbox.SelectedItem == null || SpellFilter_sbox.SelectedItem.ToString() == "ALL")
            {
                List<SPELL> GM_SPELLS = GM_SPELLS_LIST.GetSPELLS("ALL", "1");
                Spells_Edititor_lbox.Items.Clear();
                foreach (SPELL GM_SPELL in GM_SPELLS)
                {
                    Spells_Edititor_lbox.Items.Add(GM_SPELL.SPELL_DATA());
                }
            }
            else
            {
                List<SPELL> GM_SPELLS = GM_SPELLS_LIST.GetSPELLS("OWNER_ID", SpellFilter_sbox.SelectedItem.ToString().Split('<', '>')[1]);
                Spells_Edititor_lbox.Items.Clear();
                foreach (SPELL GM_SPELL in GM_SPELLS)
                {
                    Spells_Edititor_lbox.Items.Add(GM_SPELL.SPELL_DATA());
                }
            }
        }

        private void ItemFilter_sbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ItemFilter_sbox.SelectedItem == null || ItemFilter_sbox.SelectedItem.ToString() == "ALL")
            {
                List<ITEM> GM_ITEMS = GM_ITEM_LIST.GetITEM("ALL", "1");
                EditorItems_lbox.Items.Clear();
                foreach (ITEM GM_ITEM in GM_ITEMS)
                {
                    EditorItems_lbox.Items.Add(GM_ITEM.ITEM_DATA());
                }
            }
            else
            {
                List<ITEM> GM_ITEMS = GM_ITEM_LIST.GetITEM("OWNER_ID", ItemFilter_sbox.SelectedItem.ToString().Split('<', '>')[1]);
                EditorItems_lbox.Items.Clear();
                foreach (ITEM GM_ITEM in GM_ITEMS)
                {
                    EditorItems_lbox.Items.Add(GM_ITEM.ITEM_DATA());
                }
            }
        }

        private void InvSort_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                bool swapped;
                switch (InvSort.SelectedItem)
                {
                    case "A-Z":
                        Inventory_lbox.Sorting = SortOrder.Ascending;
                        break;
                    case "Z-A":
                        Inventory_lbox.Sorting = SortOrder.Descending;
                        break;
                    case "Old-New":
                        Inventory_lbox.Sorting = SortOrder.None;
                        do
                        {
                            int count = Inventory_lbox.Items.Count - 1;
                            swapped = false;
                            while (count > 0)
                            {
                                if (Convert.ToInt32(Inventory_lbox.Items[count].ToString().Split('<', '>')[1]) < Convert.ToInt32(Inventory_lbox.Items[count - 1].ToString().Split('<', '>')[1]))
                                {
                                    String temp = Inventory_lbox.Items[count].Text;
                                    Inventory_lbox.Items[count].Text = Inventory_lbox.Items[count - 1].Text;
                                    Inventory_lbox.Items[count - 1].Text = temp;
                                    swapped = true;
                                }
                                count -= 1;
                            }
                        } while (swapped == true);
                        break;
                    case "New-Old":
                        Inventory_lbox.Sorting = SortOrder.None;
                        do
                        {
                            int count = Inventory_lbox.Items.Count - 1;
                            swapped = false;
                            while (count > 0)
                            {
                                if (Convert.ToInt32(Inventory_lbox.Items[count].ToString().Split('<', '>')[1]) > Convert.ToInt32(Inventory_lbox.Items[count - 1].ToString().Split('<', '>')[1]))
                                {
                                    String temp = Inventory_lbox.Items[count].Text;
                                    Inventory_lbox.Items[count].Text = Inventory_lbox.Items[count - 1].Text;
                                    Inventory_lbox.Items[count - 1].Text = temp;
                                    swapped = true;
                                }
                                count -= 1;
                            }
                        } while (swapped == true);
                        break;
                }
            } catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void SpellSort_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                bool swapped;
                switch (SpellSort.SelectedItem)
                {
                    case "A-Z":
                        Spells_lbox.Sorting = SortOrder.Ascending;
                        break;
                    case "Z-A":
                        Spells_lbox.Sorting = SortOrder.Descending;
                        break;
                    case "Old-New":
                        Spells_lbox.Sorting = SortOrder.None;
                        do
                        {
                            int count = Spells_lbox.Items.Count - 1;
                            swapped = false;
                            while (count > 0)
                            {
                                if (Convert.ToInt32(Spells_lbox.Items[count].ToString().Split('<', '>')[1]) < Convert.ToInt32(Spells_lbox.Items[count - 1].ToString().Split('<', '>')[1]))
                                {
                                    String temp = Spells_lbox.Items[count].Text;
                                    Spells_lbox.Items[count].Text = Inventory_lbox.Items[count - 1].Text;
                                    Spells_lbox.Items[count - 1].Text = temp;
                                    swapped = true;
                                }
                                count -= 1;
                            }
                        } while (swapped == true);
                        break;
                    case "New-Old":
                        Spells_lbox.Sorting = SortOrder.None;
                        do
                        {
                            int count = Spells_lbox.Items.Count - 1;
                            swapped = false;
                            while (count > 0)
                            {
                                if (Convert.ToInt32(Spells_lbox.Items[count].ToString().Split('<', '>')[1]) > Convert.ToInt32(Spells_lbox.Items[count - 1].ToString().Split('<', '>')[1]))
                                {
                                    String temp = Spells_lbox.Items[count].Text;
                                    Spells_lbox.Items[count].Text = Inventory_lbox.Items[count - 1].Text;
                                    Spells_lbox.Items[count - 1].Text = temp;
                                    swapped = true;
                                }
                                count -= 1;
                            }
                        } while (swapped == true);
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }

}
