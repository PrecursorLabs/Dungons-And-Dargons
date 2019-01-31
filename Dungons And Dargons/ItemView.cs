using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Dungons_And_Dargons
{
    public partial class ItemView : Form
    {
        MySqlConnection Iconn;
        public int IID;
        public ITEM ITEMVIEW;
        private NPCS GM_NPC_LIST;
        private NPC MyPlayer;
        public int PLAYERID;

        public ItemView(int ID, MySqlConnection conn, int PlayerId = -1)
        {
            InitializeComponent();
            IID = ID;
            Iconn = conn;
            ITEMVIEW = new ITEM(Iconn);
            ITEMVIEW.ItemID = IID;
            GM_NPC_LIST = new NPCS(Iconn);
            MyPlayer = new NPC(Iconn);
            PLAYERID = PlayerId;
            MyPlayer.PlayerID = PLAYERID;
        }

        private void Item_Load(object sender, EventArgs e)
        {
            Refresh_BTN.PerformClick();
        }

        private void Item_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void Give_btn_Click(object sender, EventArgs e)
        {
            if (GPlayers_lbox.SelectedItem != null)
            {
                MessageBox.Show("Giving " + Name_tbox.Text + " to " + GPlayers_lbox.SelectedItem);
                ITEMVIEW.GetData();
                ITEMVIEW.OWNER_ID = Convert.ToInt32(GPlayers_lbox.SelectedItem.ToString().Split('<', '>')[1]);
                ITEMVIEW.Equipped = false;
                ITEMVIEW.PostData();
                MessageBox.Show("You No Longer Own This Item");
                this.Close();
            }
        }

        private void Refresh_BTN_Click(object sender, EventArgs e)
        {
            ITEMVIEW.GetData();

            if (PLAYERID != -1)
            {
                if (PLAYERID != ITEMVIEW.OWNER_ID)
                {
                    MessageBox.Show("You Don't Own This Item");
                    Give_BTN.Enabled = false;
                    GPlayers_lbox.Enabled = false;
                }
            }
            else
            {
                Give_BTN.Enabled = false;
                GPlayers_lbox.Enabled = false;
                Equip_btn.Enabled = false;
            }

            Text = ITEMVIEW.Name;
            Name_tbox.Text = ITEMVIEW.Name;
            Description_tbox.Text = ITEMVIEW.Description;
            Type_tbox.Text = ITEMVIEW.Prop_To_Type();
            Buffs_lbox.Items.Clear();
            if (ITEMVIEW.Enhance > 0) Buffs_lbox.Items.Add("ENH +" + ITEMVIEW.Enhance);
            if (ITEMVIEW.Quantity > 1) Buffs_lbox.Items.Add("Quantity: " + ITEMVIEW.Quantity);
            if (ITEMVIEW.M_HP > 0) Buffs_lbox.Items.Add("HP +" + ITEMVIEW.M_HP);
            if (ITEMVIEW.M_MP > 0) Buffs_lbox.Items.Add("MP +" + ITEMVIEW.M_MP);
            if (ITEMVIEW.M_ATK > 0) Buffs_lbox.Items.Add("ATK +" + ITEMVIEW.M_ATK);
            if (ITEMVIEW.M_SATK > 0) Buffs_lbox.Items.Add("SATK +" + ITEMVIEW.M_SATK);
            if (ITEMVIEW.M_DEF > 0) Buffs_lbox.Items.Add("DEF +" + ITEMVIEW.M_DEF);
            if (ITEMVIEW.M_SDEF > 0) Buffs_lbox.Items.Add("SDEF +" + ITEMVIEW.M_SDEF);
            if (ITEMVIEW.M_CHAR > 0) Buffs_lbox.Items.Add("CHAR +" + ITEMVIEW.M_CHAR);
            if (ITEMVIEW.M_DEX > 0) Buffs_lbox.Items.Add("DEX +" + ITEMVIEW.M_DEX);
            if (ITEMVIEW.M_STR > 0) Buffs_lbox.Items.Add("STR +" + ITEMVIEW.M_STR);
            if (ITEMVIEW.M_INT > 0) Buffs_lbox.Items.Add("INT +" + ITEMVIEW.M_INT);
            if (ITEMVIEW.M_PERC > 0) Buffs_lbox.Items.Add("PERC +" + ITEMVIEW.M_PERC);
            if (ITEMVIEW.Tier > 0) Buffs_lbox.Items.Add("TIER: " + ITEMVIEW.Tier);
            if (ITEMVIEW.Grade > 0) Buffs_lbox.Items.Add("GRADE: " + ITEMVIEW.Grade);
            if (ITEMVIEW.Dice > 0) Buffs_lbox.Items.Add("Dice: d" + ITEMVIEW.Dice);
            if (ITEMVIEW.ELevel > 0) Buffs_lbox.Items.Add("Enchants: (" + ITEMVIEW.EType + ") LVL: " + ITEMVIEW.ELevel);
            if (ITEMVIEW.MaxDurability > 0) Buffs_lbox.Items.Add("Durability: " + ITEMVIEW.Durability + "/" + ITEMVIEW.MaxDurability);

            List<NPC> GM_NPCS = GM_NPC_LIST.GetNPCS("PLAYER", "1");
            GPlayers_lbox.Items.Clear();
            foreach (NPC GM_NPC in GM_NPCS)
            {
                if (GM_NPC.PlayerID != PLAYERID)
                    GPlayers_lbox.Items.Add(GM_NPC.PLAYER_DATA());
            }
        }

        private void Equip_btn_Click(object sender, EventArgs e)
        {
            ITEM TO_Equip = new ITEM(Iconn);
            TO_Equip.ItemID = Convert.ToInt32(IID);
            TO_Equip.GetData();
            MyPlayer.GetData();
            MyPlayer.GetInventory();
            MyPlayer.DeEquip(TO_Equip.Prop_To_Type());
            MyPlayer.Equip(TO_Equip);
            MessageBox.Show("Equipped");
            this.Close();
        }
    }
}
