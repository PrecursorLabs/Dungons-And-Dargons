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
    public partial class SpellView : Form
    {
        MySqlConnection Iconn;
        public int IID;
        public SPELL SPELLVIEW;

        public SpellView(int ID, MySqlConnection conn)
        {
            InitializeComponent();
            IID = ID;
            Iconn = conn;
            SPELLVIEW = new SPELL(Iconn);
            SPELLVIEW.SpellID= IID;
        }

        private void SpellView_Load(object sender, EventArgs e)
        {
            Refresh_BTN.PerformClick();
        }

        private void Refresh_BTN_Click(object sender, EventArgs e)
        {
            SPELLVIEW.GetData();
            Buffs_lbox.Items.Clear();

            Text = SPELLVIEW.Name;
            Name_tbox.Text = SPELLVIEW.Name;
            Description_tbox.Text = SPELLVIEW.Description;
            if (SPELLVIEW.MaxSlots > 0) Buffs_lbox.Items.Add("Slots: " + SPELLVIEW.Slots + "/" + SPELLVIEW.MaxSlots);
            if (SPELLVIEW.Tier > 0) Buffs_lbox.Items.Add("TIER: " + SPELLVIEW.Tier);
            if (SPELLVIEW.Rank > 0) Buffs_lbox.Items.Add("Rank: " + SPELLVIEW.Rank);
            if (SPELLVIEW.Dice > 0) Buffs_lbox.Items.Add("Dice: " + SPELLVIEW.Dice);
        }
    }
}
