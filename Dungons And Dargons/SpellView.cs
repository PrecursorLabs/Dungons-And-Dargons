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
            if (SPELLVIEW.Tier > 0) Buffs_lbox.Items.Add("TIER: " + ToRoman(SPELLVIEW.Tier));
            if (SPELLVIEW.Rank > 0) Buffs_lbox.Items.Add("Rank: " + SPELLVIEW.Rank);
            if (SPELLVIEW.Dice > 0) Buffs_lbox.Items.Add("Dice: D" + SPELLVIEW.Dice);
        }

        public static string ToRoman(int number)
        {
            if ((number < 0) || (number > 3999)) throw new ArgumentOutOfRangeException("insert value betwheen 1 and 3999");
            if (number < 1) return string.Empty;
            if (number >= 1000) return "M" + ToRoman(number - 1000);
            if (number >= 900) return "CM" + ToRoman(number - 900);
            if (number >= 500) return "D" + ToRoman(number - 500);
            if (number >= 400) return "CD" + ToRoman(number - 400);
            if (number >= 100) return "C" + ToRoman(number - 100);
            if (number >= 90) return "XC" + ToRoman(number - 90);
            if (number >= 50) return "L" + ToRoman(number - 50);
            if (number >= 40) return "XL" + ToRoman(number - 40);
            if (number >= 10) return "X" + ToRoman(number - 10);
            if (number >= 9) return "IX" + ToRoman(number - 9);
            if (number >= 5) return "V" + ToRoman(number - 5);
            if (number >= 4) return "IV" + ToRoman(number - 4);
            if (number >= 1) return "I" + ToRoman(number - 1);
            throw new ArgumentOutOfRangeException("something bad happened");
        }
    }
}
