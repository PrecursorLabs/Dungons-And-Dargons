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
        public string IName;
        public string Type;
        public string IPOwner;
        public string Description;
        public string[] Buffs = new string[17];
        public string[] Players = new string[32];

        private bool Weapon = false;
        private bool Consumable = false;
        private bool Helm = false;
        private bool Maille = false;
        private bool Gloves = false;
        private bool Pants = false;
        private bool Boot = false;
        private bool Artifact = false;
        private bool Healing = false;

        public ItemView(int ID, MySqlConnection conn, string POwner = null)
        {
            InitializeComponent();
            IID = ID;
            Iconn = conn;
            IPOwner = POwner;
        }

        private void Item_Load(object sender, EventArgs e)
        {
            try
            {
                string sql = "SELECT idItems, Name, Description, Weapon, Consumable, Helm, Maille, Gloves, Pants, Boots, Artifact, Healing, M_HP, M_MP, M_ATK, M_SATK, M_DEF, M_SDEF, M_CHAR, M_DEX, M_STR, M_INT, M_PERC, Tier, Grade, Enhance, Durability, MaxDurability, Dice FROM items WHERE idItems=" + IID;
                MySqlCommand cmd = new MySqlCommand(sql, Iconn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                int count = 0;
                while (rdr.Read())
                {
                    IName = Convert.ToString(rdr[1]);
                    Description = Convert.ToString(rdr[2]);

                    Weapon = Convert.ToBoolean(rdr[3]);
                    Consumable = Convert.ToBoolean(rdr[4]);
                    Helm = Convert.ToBoolean(rdr[5]);
                    Maille = Convert.ToBoolean(rdr[6]);
                    Gloves = Convert.ToBoolean(rdr[7]);
                    Pants = Convert.ToBoolean(rdr[8]);
                    Boot = Convert.ToBoolean(rdr[9]);
                    Artifact = Convert.ToBoolean(rdr[10]);
                    Healing = Convert.ToBoolean(rdr[11]);

                    Buffs[0] = "HP +" + rdr[12];
                    Buffs[1] = "MP +" + rdr[13];
                    Buffs[2] = "ATK +" + rdr[14];
                    Buffs[3] = "SATK +" + rdr[15];
                    Buffs[4] = "DEF +" + rdr[16];
                    Buffs[5] = "SDEF +" + rdr[17];
                    Buffs[6] = "CHAR +" + rdr[18];
                    Buffs[7] = "DEX +" + rdr[19];
                    Buffs[8] = "STR +" + rdr[20];
                    Buffs[9] = "INT +" + rdr[21];
                    Buffs[10] = "PERC +" + rdr[22];

                    if (Convert.ToInt16(rdr[23]) > 0 || Convert.ToInt16(rdr[24]) > 0)
                    {
                        Buffs[11] = "Tier +" + rdr[23];
                        Buffs[12] = "Grade +" + rdr[24];
                    }
                    if (Convert.ToInt16(rdr[25]) > 0)
                    {
                        Buffs[13] = "Enhance +" + rdr[25];
                    }
                    if (rdr[27].GetType() != typeof(DBNull))
                    {
                        Buffs[14] = "Durability +" + rdr[26];
                        Buffs[15] = "Max Durability +" + rdr[27];
                    }
                    if (Convert.ToInt16(rdr[28]) > 0)
                    {
                        Buffs[16] = "Dice D" + rdr[28];
                    }

                    count++;
                }

                rdr.Close();

                if (Weapon)
                {
                    Type = "Weapon";
                }
                if (Consumable) {
                    Type = "Consumable";
                }
                if (Healing)
                {
                    Type = "Healing";
                }
                if (Healing && Consumable)
                {
                    Type = "Healing Consumable";
                }
                if (Helm)
                {
                    Type = "Helm";
                }
                if (Maille)
                {
                    Type = "Maille";
                }
                if (Gloves)
                {
                    Type = "Gloves";
                }
                if (Pants)
                {
                    Type = "Pants";
                }
                if (Boot)
                {
                    Type = "Boots";
                }
                if (Artifact)
                {
                    Type += "Artifact";
                }

                this.Text = IName;
                Name_tbox.Text = IName;
                Type_tbox.Text = Type;
                Description_tbox.Text = Description;

                foreach (string buff in Buffs)
                {
                    if(buff != null)
                    {
                        int buffdig = Convert.ToInt32(new String(buff.Where(Char.IsDigit).ToArray()));
                        if (buffdig > 0)
                        {
                            Buffs_lbox.Items.Add(buff);
                        }
                    }
                    
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void Item_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void Give_btn_Click(object sender, EventArgs e)
        {

        }
    }
}
