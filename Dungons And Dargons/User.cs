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

        public User(int PlayerID, string ip, string password)
        {
            String version = "1.0.6.0";
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
            UpdateDisplay();
            if (!MyPlayer.GAMEMASTER) Main_tabs.TabPages.Remove(GameMaster_tab);
        }


        public void UpdateDisplay()
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

            if (MyPlayer.Weapon.Name != null)
            {
                Weapon_tbox.Text = MyPlayer.Weapon.ITEM_DATA();
            }
            else
            {
                Weapon_tbox.Text = "";
            }

            if (MyPlayer.Artifact.Name != null)
            {
                Artifact_tbox.Text = MyPlayer.Artifact.ITEM_DATA();
            }
            else
            {
                Artifact_tbox.Text = "";
            }


            HP_pbar.Maximum = MyPlayer.HPMax + MyPlayer.M_HP;
            if (MyPlayer.HP > MyPlayer.HPMax + MyPlayer.M_HP)
            {
                HP_pbar.Value = MyPlayer.HPMax + MyPlayer.M_HP;
            }
            else
            {
                HP_pbar.Value = MyPlayer.HP;
            }

            MP_pbar.Maximum = MyPlayer.MPMax + MyPlayer.M_MP;
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
            } else
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
            foreach(ITEM item in MyPlayer.Inventory) NINVTOT = string.Format("{0}{1}", NINVTOT, item.ItemID);
            foreach(ITEM item in OLD_INVENTORY) OINVTOT = string.Format("{0}{1}", OINVTOT, item.ItemID);

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
                        Equipable_lbox.Items.Add(item.Prop_To_Type() + ": " + item.ITEM_DATA());
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

        private void UPDATE_btn_Click(object sender, EventArgs e)
        {
            UpdateDisplay();
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
                string IID = Inventory_lbox.SelectedItem.ToString().Split('<', '>')[1];
                ItemView Iview = new ItemView(Convert.ToInt32(IID), conn, MyPlayer.PlayerID);
                Iview.Show();
            }
        }

        private void Spells_lbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Spells_lbox.SelectedItem != null)
            {
                string IID = Spells_lbox.SelectedItem.ToString().Split('<', '>')[1];
                SpellView Sview = new SpellView(Convert.ToInt32(IID), conn);
                Sview.Show();
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
            List<ITEM> GM_ITEMS = GM_ITEM_LIST.GetITEM("ALL", "1");
            EditorItems_lbox.Items.Clear();
            foreach (ITEM GM_ITEM in GM_ITEMS)
            {
                EditorItems_lbox.Items.Add(GM_ITEM.ITEM_DATA());
            }

            List<NPC> GM_NPCS= GM_NPC_LIST.GetNPCS("ALL", "1");
            Item_Character_Cbox.Items.Clear();
            foreach (NPC GM_NPC in GM_NPCS)
            {
                Item_Character_Cbox.Items.Add(GM_NPC.PLAYER_DATA());
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
            List<SPELL> GM_SPELLS = GM_SPELLS_LIST.GetSPELLS("ALL", "1");
            Spells_Edititor_lbox.Items.Clear();
            foreach (SPELL GM_SPELL in GM_SPELLS)
            {
                Spells_Edititor_lbox.Items.Add(GM_SPELL.SPELL_DATA());
            }

            List<NPC> GM_NPCS = GM_NPC_LIST.GetNPCS("ALL", "1");
            Spell_Character_Cbox.Items.Clear();
            foreach (NPC GM_NPC in GM_NPCS)
            {
                Spell_Character_Cbox.Items.Add(GM_NPC.PLAYER_DATA());
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
                Iview.Show();
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
            MyPlayer.DeEquip("Weapon");
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
                Iview.Show();
            }
        }

        private void Maille_tbox_Click(object sender, EventArgs e)
        {
            if (Maille_tbox.Text != "")
            {
                string IID = Maille_tbox.Text.Split('<', '>')[1];
                ItemView Iview = new ItemView(Convert.ToInt32(IID), conn, MyPlayer.PlayerID);
                Iview.Show();
            }
        }

        private void Pants__tbox_Click(object sender, EventArgs e)
        {
            if (Pants__tbox.Text != "")
            {
                string IID = Pants__tbox.Text.Split('<', '>')[1];
                ItemView Iview = new ItemView(Convert.ToInt32(IID), conn, MyPlayer.PlayerID);
                Iview.Show();
            }
        }

        private void Boots_tbox_Click(object sender, EventArgs e)
        {
            if (Boots_tbox.Text != "")
            {
                string IID = Boots_tbox.Text.Split('<', '>')[1];
                ItemView Iview = new ItemView(Convert.ToInt32(IID), conn, MyPlayer.PlayerID);
                Iview.Show();
            }
        }

        private void Gloves_tbox_Click(object sender, EventArgs e)
        {
            if (Gloves_tbox.Text != "")
            {
                string IID = Gloves_tbox.Text.Split('<', '>')[1];
                ItemView Iview = new ItemView(Convert.ToInt32(IID), conn, MyPlayer.PlayerID);
                Iview.Show();
            }
        }

        private void Weapon_tbox_Click(object sender, EventArgs e)
        {
            if (Weapon_tbox.Text != "")
            {
                string IID = Weapon_tbox.Text.Split('<', '>')[1];
                ItemView Iview = new ItemView(Convert.ToInt32(IID), conn, MyPlayer.PlayerID);
                Iview.Show();
            }
        }

        private void Artifact_tbox_Click(object sender, EventArgs e)
        {
            if (Artifact_tbox.Text != "")
            {
                string IID = Artifact_tbox.Text.Split('<', '>')[1];
                ItemView Iview = new ItemView(Convert.ToInt32(IID), conn, MyPlayer.PlayerID);
                Iview.Show();
            }
        }

        private void Filter_Relation_SelectedIndexChanged(object sender, EventArgs e)
        {
            CM_UPDATE_BTN.PerformClick();
        }
    }
}
