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
    public partial class PlayerView : Form
    {
        MySqlConnection Pconn;
        public int PID;
        NPC SELNPC;
        private static readonly Random random = new Random();

        private static double RandomNumberBetween(double minValue, double maxValue)
        {
            var next = random.NextDouble();

            return minValue + (next * (maxValue - minValue));
        }

        public PlayerView(int ID, MySqlConnection conn)
        {
            InitializeComponent();
            PID = ID;
            Pconn = conn;
            SELNPC = new NPC(Pconn);
            SELNPC.PlayerID = PID;
            SELNPC.GetData();
            SELNPC.GetInventory();
            Text = SELNPC.PName;
        }

        private void Player_Load(object sender, EventArgs e)
        {
            Refresh_btn.PerformClick();
        }

        private void Refresh_btn_Click(object sender, EventArgs e)
        {
            Inventory_lbox.Items.Clear();
            Equipment_lbox.Items.Clear();
            Spells_lbox.Items.Clear();

            SELNPC.GetData();
            SELNPC.GetInventory();
            SELNPC.GetSpells();
            Name_tbox.Text = SELNPC.PName;
            LVL_tbox.Text = SELNPC.Level.ToString();
            XP_lbl.Text = "XP: " + SELNPC.XP.ToString() + "/" + SELNPC.XPREQ.ToString();
            HP_lbl.Text = "HP: " + SELNPC.HP.ToString() + "/" + SELNPC.T_HP.ToString();
            MP_lbl.Text = "MP: " + SELNPC.MP.ToString() + "/" + SELNPC.T_MP.ToString();
            ATK_tbox.Text = SELNPC.ATK.ToString();
            SATK_tbox.Text = SELNPC.SATK.ToString();
            DEF_tbox.Text = SELNPC.DEF.ToString();
            SDEF_tbox.Text = SELNPC.SDEF.ToString();
            CHAR_tbox.Text = SELNPC.CHARIS.ToString();
            DEX_tbox.Text = SELNPC.DEX.ToString();
            STR_tbox.Text = SELNPC.STR.ToString();
            INT_tbox.Text = SELNPC.INTEL.ToString();
            PERC_tbox.Text = SELNPC.PERC.ToString();
            Satiety_tbox.Text = SELNPC.SATIE.ToString();
            Gold_tbox.Text = SELNPC.Gold.ToString();

            M_ATK_tbox.Text = SELNPC.M_ATK.ToString();
            M_SATK_tbox.Text = SELNPC.M_SATK.ToString();
            M_DEF_tbox.Text = SELNPC.M_DEF.ToString();
            M_SDEF_tbox.Text = SELNPC.M_SDEF.ToString();
            M_CHAR_tbox.Text = SELNPC.M_CHAR.ToString();
            M_DEX_tbox.Text = SELNPC.M_DEX.ToString();
            M_STR_tbox.Text = SELNPC.M_STR.ToString();
            M_INT_tbox.Text = SELNPC.M_INT.ToString();
            M_PERC_tbox.Text = SELNPC.M_PERC.ToString();

            T_ATK_tbox.Text = SELNPC.T_ATK.ToString();
            T_SATK_tbox.Text = SELNPC.T_SATK.ToString();
            T_DEF_tbox.Text = SELNPC.T_DEF.ToString();
            T_SDEF_tbox.Text = SELNPC.T_SDEF.ToString();
            T_CHAR_tbox.Text = SELNPC.T_CHAR.ToString();
            T_DEX_tbox.Text = SELNPC.T_DEX.ToString();
            T_STR_tbox.Text = SELNPC.T_STR.ToString();
            T_INT_tbox.Text = SELNPC.T_INT.ToString();
            T_PERC_tbox.Text = SELNPC.T_PERC.ToString();

            Earth_tbox.Text = SELNPC.Earth.ToString();
            Fire_tbox.Text = SELNPC.Fire.ToString();
            Lightning_tbox.Text = SELNPC.Lightning.ToString();
            Ice_tbox.Text = SELNPC.Ice.ToString();
            Holy_tbox.Text = SELNPC.Holy.ToString();
            Unholy_tbox.Text = SELNPC.Unholy.ToString();

            if (SELNPC.Helmet.Name != null)
            {
                Equipment_lbox.Items.Add("Helmet: " + SELNPC.Helmet.ITEM_DATA());
            }

            if (SELNPC.Maille.Name != null)
            {
                Equipment_lbox.Items.Add("Maille: " + SELNPC.Maille.ITEM_DATA());
            }

            if (SELNPC.Pants.Name != null)
            {
                Equipment_lbox.Items.Add("Pants: " + SELNPC.Pants.ITEM_DATA());
            }

            if (SELNPC.Boots.Name != null)
            {
                Equipment_lbox.Items.Add("Boots: " + SELNPC.Boots.ITEM_DATA());
            }

            if (SELNPC.Gloves.Name != null)
            {
                Equipment_lbox.Items.Add("Gloves: " + SELNPC.Gloves.ITEM_DATA());
            }

            if (SELNPC.WeaponLeft.Name != null)
            {
                Equipment_lbox.Items.Add("LWeapon: " + SELNPC.WeaponLeft.ITEM_DATA());
            }

            if (SELNPC.WeaponRight.Name != null)
            {
                Equipment_lbox.Items.Add("RWeapon: " + SELNPC.WeaponRight.ITEM_DATA());
            }

            if (SELNPC.Artifact.Name != null)
            {
                Equipment_lbox.Items.Add("Artifact: " + SELNPC.Artifact.ITEM_DATA());
            }

            HP_pbar.Maximum = SELNPC.T_HP;
            HP_pbar.Value = SELNPC.HP;

            MP_pbar.Maximum = SELNPC.T_MP;
            MP_pbar.Value = SELNPC.MP;
            if (SELNPC.XPREQ >= SELNPC.XP)
            {
                XP_pbar.Maximum = SELNPC.XPREQ;
                XP_pbar.Value = SELNPC.XP;
            }
            else
            {
                XP_pbar.Maximum = SELNPC.XPREQ;
                XP_pbar.Value = SELNPC.XPREQ;

            }

            HP_pbar.ForeColor = Color.LawnGreen;

            if (SELNPC.HP < SELNPC.HPMax / 2)
            {
                HP_pbar.ForeColor = Color.Yellow;
            }

            if (SELNPC.HP < SELNPC.HPMax / 4)
            {
                HP_pbar.ForeColor = Color.Red;
            }

            foreach (ITEM item in SELNPC.Inventory)
            {
                Inventory_lbox.Items.Add(item.ITEM_DATA());
            }

            foreach (SPELL spell in SELNPC.Spells)
            {
                Spells_lbox.Items.Add(spell.SPELL_DATA());
            }

            Delete_btn.Enabled = !SELNPC.isPlayer;
            Sleep_btn.Enabled = !SELNPC.isPlayer;
        }

        private void Plus_BTN_Click(object sender, EventArgs e)
        {
            SELNPC.Gold += (int)Gold_UD.Value;
            SELNPC.XP += (int)XP_UD.Value;
            SELNPC.HP += (int)HP_UD.Value;
            SELNPC.MP += (int)MP_UD.Value;
            SELNPC.SATIE += (int) SAT_UD.Value;

            SELNPC.Earth += (int) Earth_UD.Value;
            SELNPC.Lightning += (int) Lightning_UD.Value;
            SELNPC.Fire += (int) Fire_UD.Value;
            SELNPC.Ice += (int) Ice_UD.Value;
            SELNPC.Holy += (int) Holy_UD.Value;
            SELNPC.Unholy += (int) Unholy_UD.Value;


            Gold_UD.Value = 0;
            XP_UD.Value = 0;
            HP_UD.Value = 0;
            MP_UD.Value = 0;
            SAT_UD.Value = 0;

            Earth_UD.Value = 0;
            Lightning_UD.Value = 0;
            Fire_UD.Value = 0;
            Ice_UD.Value = 0;
            Holy_UD.Value = 0;
            Unholy_UD.Value = 0;

            SELNPC.PostData();
            Refresh_btn.PerformClick();
        }

        private void Minus_BTN_Click(object sender, EventArgs e)
        {
            SELNPC.Gold -= (int)Gold_UD.Value;
            SELNPC.XP -= (int)XP_UD.Value;
            SELNPC.HP -= (int)HP_UD.Value;
            SELNPC.MP -= (int)MP_UD.Value;
            SELNPC.SATIE -= (int)SAT_UD.Value;

            SELNPC.Earth -= (int)Earth_UD.Value;
            SELNPC.Lightning -= (int)Lightning_UD.Value;
            SELNPC.Fire -= (int)Fire_UD.Value;
            SELNPC.Ice -= (int)Ice_UD.Value;
            SELNPC.Holy -= (int)Holy_UD.Value;
            SELNPC.Unholy -= (int)Unholy_UD.Value;

            Gold_UD.Value = 0;
            XP_UD.Value = 0;
            HP_UD.Value = 0;
            MP_UD.Value = 0;
            SAT_UD.Value = 0;

            Earth_UD.Value = 0;
            Lightning_UD.Value = 0;
            Fire_UD.Value = 0;
            Ice_UD.Value = 0;
            Holy_UD.Value = 0;
            Unholy_UD.Value = 0;

            SELNPC.PostData();
            Refresh_btn.PerformClick();
        }

        private void Inventory_lbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Inventory_lbox.SelectedItem != null)
            {
                string IID = Inventory_lbox.SelectedItem.ToString().Split('<', '>')[1];
                ItemView Iview = new ItemView(Convert.ToInt32(IID), Pconn, -1);
                Iview.Show();
            }
        }

        private void Spells_lbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Spells_lbox.SelectedItem != null)
            {
                string IID = Spells_lbox.SelectedItem.ToString().Split('<', '>')[1];
                SpellView Sview = new SpellView(Convert.ToInt32(IID), Pconn);
                Sview.Show();
            }
        }

        private void Equipment_lbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Equipment_lbox.SelectedItem != null)
            {
                string IID = Equipment_lbox.SelectedItem.ToString().Split('<', '>')[1];
                ItemView Iview = new ItemView(Convert.ToInt32(IID), Pconn, -1);
                Iview.Show();
            }
        }

        private void Sleep_btn_Click(object sender, EventArgs e)
        {
            SELNPC.isALL = false;
            SELNPC.isEnemy = false;
            SELNPC.isPlayer = false;
            SELNPC.isNPC = false;
            SELNPC.PostData();
            MessageBox.Show("Character In Hibernation and will not show up in any lists");
        }

        private void Delete_btn_Click(object sender, EventArgs e)
        {
            SELNPC.Delete(DINV_cbox.Checked);
            MessageBox.Show("Character Not Found Exiting");
            this.Close();
        }

        private void ACC_Submit_btn_Click(object sender, EventArgs e)
        {
            decimal ADEX = ADEX_ud.Value;
            decimal DDEX = SELNPC.T_DEX;
            decimal AROLL = AROLL_ud.Value;
            decimal DROLL = DROLL_ud.Value;
            float Accuracy = (float)(ADEX * AROLL) / (float)(DDEX * DROLL);
            if (Accuracy > 1) Accuracy = 1;
            Accuracy *= 100;
            Accuracy_lbl.Text = Convert.ToString(Math.Round(Accuracy, 2, MidpointRounding.AwayFromZero));
            Double RND = RandomNumberBetween(0.00000000000000000000, 100.00000000000000000000);
            if (RND <= Accuracy)
            {
                HitMiss_lbl.Text = "HIT";
            }
            else
            {
                HitMiss_lbl.Text = "MISS";
            }
        }
    }
}
