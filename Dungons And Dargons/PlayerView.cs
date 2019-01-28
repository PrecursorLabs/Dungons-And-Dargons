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
            HP_lbl.Text = "HP: " + SELNPC.HP.ToString() + "/" + SELNPC.HPMax.ToString();
            MP_lbl.Text = "MP: " + SELNPC.MP.ToString() + "/" + SELNPC.MPMax.ToString();
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

            HP_pbar.Maximum = SELNPC.HPMax;
            HP_pbar.Value = SELNPC.HP;

            MP_pbar.Maximum = SELNPC.MPMax;
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
        }

        private void Plus_BTN_Click(object sender, EventArgs e)
        {
            SELNPC.Gold += (int)Gold_UD.Value;
            SELNPC.XP += (int)XP_UD.Value;
            SELNPC.HP += (int)HP_UD.Value;
            SELNPC.MP += (int)MP_UD.Value;

            Gold_UD.Value = 0;
            XP_UD.Value = 0;
            HP_UD.Value = 0;
            MP_UD.Value = 0;

            SELNPC.PostData();
            Refresh_btn.PerformClick();
        }

        private void Minus_BTN_Click(object sender, EventArgs e)
        {
            SELNPC.Gold -= (int)Gold_UD.Value;
            SELNPC.XP -= (int)XP_UD.Value;
            SELNPC.HP -= (int)HP_UD.Value;
            SELNPC.MP -= (int)MP_UD.Value;

            Gold_UD.Value = 0;
            XP_UD.Value = 0;
            HP_UD.Value = 0;
            MP_UD.Value = 0;

            SELNPC.PostData();
            Refresh_btn.PerformClick();
        }

        private void SET_BTN_Click(object sender, EventArgs e)
        {
            SELNPC.Gold = (int)Gold_UD.Value;
            SELNPC.XP = (int)XP_UD.Value;
            SELNPC.HP = (int)HP_UD.Value;
            SELNPC.MP = (int)MP_UD.Value;

            Gold_UD.Value = 0;
            XP_UD.Value = 0;
            HP_UD.Value = 0;
            MP_UD.Value = 0;

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
    }
}
