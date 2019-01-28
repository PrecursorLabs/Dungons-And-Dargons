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
    public class ITEM
    {
        MySqlConnection conn;
        public int ItemID { get; set; }
        public int OWNER_ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public int Dice { get; set; }
        public int M_HP { get; set; }
        public int M_MP { get; set; }
        public int M_ATK { get; set; }
        public int M_SATK { get; set; }
        public int M_DEF { get; set; }
        public int M_SDEF { get; set; }
        public int M_CHAR { get; set; }
        public int M_DEX { get; set; }
        public int M_STR { get; set; }
        public int M_INT { get; set; }
        public int M_PERC { get; set; }
        public bool Weapon { get; set; }
        public bool Consumable { get; set; }
        public bool Helm { get; set; }
        public bool Maille { get; set; }
        public bool Gloves { get; set; }
        public bool Pants { get; set; }
        public bool Boots { get; set; }
        public bool Artifact { get; set; }
        public bool Healing { get; set; }
        public int Satiety { get; set; }
        public bool Equipped { get; set; }
        public int Turns { get; set; }
        public int Quantity { get; set; }
        public int Enhance { get; set; }
        public int Durability { get; set; }
        public int MaxDurability { get; set; }
        public int Tier { get; set; }
        public int Grade { get; set; }
        public string EType { get; set; }
        public int ELevel { get; set; }
        public bool Oracalcite { get; set; }


        public ITEM(MySqlConnection inconn)
        {
            conn = inconn;
        }

        public string ITEM_DATA()
        {
            return Name + " (ID: <" + ItemID + ">)";
        }

        public void Type_To_Prop(string ITEM_TYPE)
        {
            switch (ITEM_TYPE)
            {
                case "HealthPotion":
                    Healing = true;
                    Consumable = true;
                    M_HP = 1;
                    break;
                case "ManaPotion":
                    Healing = true;
                    Consumable = true;
                    M_MP = 1;
                    break;
                case "Consumable":
                    Consumable = true;
                    break;
                case "Artifact":
                    Artifact = true;
                    break;
                case "Weapon":
                    Weapon = true;
                    break;
                case "Helmet":
                    Helm = true;
                    break;
                case "Maille":
                    Maille = true;
                    break;
                case "Gloves":
                    Gloves = true;
                    break;
                case "Pants":
                    Pants = true;
                    break;
                case "Boots":
                    Boots = true;
                    break;
                case "Miscellaneous":
                    break;

            }
        }

        public string Prop_To_Type()
        {
            string ITEMTYPE = "Miscellaneous";
            if (Healing == true && Consumable == true && M_HP == 1) ITEMTYPE = "HealthPotion";
            if (Healing == true && Consumable == true && M_MP == 1) ITEMTYPE = "ManaPotion";
            if (Artifact == true) ITEMTYPE = "Artifact";
            if (Weapon == true) ITEMTYPE = "Weapon";
            if (Helm == true) ITEMTYPE = "Helmet";
            if (Maille == true) ITEMTYPE = "Maille";
            if (Gloves == true) ITEMTYPE = "Gloves";
            if (Pants == true) ITEMTYPE = "Pants";
            if (Boots == true) ITEMTYPE = "Boots";
            return ITEMTYPE;
        }

        public void Delete()
        {
            try
            {

                string sql = "DELETE FROM `items` WHERE `idItems`='" + ItemID + "';";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        public void CreateData()
        {
            try
            {

                string sql = "INSERT INTO `items`" +
                    " (`Name`, `Description`, `Dice`, `M_HP`, `M_MP`, `M_ATK`, `M_SATK`, `M_DEF`, `M_SDEF`, `M_CHAR`, `M_DEX`, `M_STR`, `M_INT`, `M_PERC`" +
                    ", `Weapon`, `Consumable`, `Helm`, `Maille`, `Gloves`, `Pants`, `Boots`, `Artifact`, `Healing`, `Satiety`, `Equipped`, `Turns`, `Quantity`, `Enhance`, `Durability`, `MaxDurability`, `Tier`, `Grade`, `EType`, `ELevel`, `Oracalcite`, `OWNER_ID`)" +
                    " VALUES" +
                    " ('" + Name.Replace("'", "\\'") + "'," +
                    " '" + Description.Replace("'", "\\'") + "'," +
                    " '" + Dice + "'," +
                    " '" + M_HP + "'," +
                    " '" + M_MP + "'," +
                    " '" + M_ATK + "'," +
                    " '" + M_SATK + "'," +
                    " '" + M_DEF + "'," +
                    " '" + M_SDEF + "'," +
                    " '" + M_CHAR + "'," +
                    " '" + M_DEX + "'," +
                    " '" + M_STR + "'," +
                    " '" + M_INT + "'," +
                    " '" + M_PERC + "'," +
                    " '" + Convert.ToInt32(Weapon) + "'," +
                    " '" + Convert.ToInt32(Consumable) + "'," +
                    " '" + Convert.ToInt32(Helm) + "'," +
                    " '" + Convert.ToInt32(Maille) + "'," +
                    " '" + Convert.ToInt32(Gloves) + "'," +
                    " '" + Convert.ToInt32(Pants) + "'," +
                    " '" + Convert.ToInt32(Boots) + "'," +
                    " '" + Convert.ToInt32(Artifact) + "'," +
                    " '" + Convert.ToInt32(Healing) + "'," +
                    " '" + Satiety + "'," +
                    " '" + Convert.ToInt32(Equipped) + "'," +
                    " '" + Turns + "'," +
                    " '" + Quantity + "'," +
                    " '" + Enhance + "'," +
                    " '" + Durability + "'," +
                    " '" + MaxDurability + "'," +
                    " '" + Tier + "'," +
                    " '" + Grade + "'," +
                    " '" + EType + "'," +
                    " '" + ELevel + "'," +
                    " '" + Convert.ToInt32(Oracalcite) + "'," +
                    " '" + OWNER_ID + "');";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void GetData()
        {
            try
            {
                string sql = "SELECT `idItems`, `Name`, `Description`, `Dice`, `M_HP`, `M_MP`, `M_ATK`, `M_SATK`, `M_DEF`, `M_SDEF`, `M_CHAR`," +
                    " `M_DEX`, `M_STR`, `M_INT`, `M_PERC`, `Weapon`, `Consumable`, `Helm`, `Maille`, `Gloves`, `Pants`, `Boots`, `Artifact`, `Healing`," +
                    " `Satiety`, `Turns`, `Quantity`, `Enhance`, `Durability`, `MaxDurability`, `Tier`, `Grade`, `EType`, `ELevel`, `Oracalcite`, `OWNER_ID`" +
                    " FROM `items` WHERE `idItems`=" + ItemID;
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                int count = 0;

                while (rdr.Read())
                {
                    ItemID = Convert.ToInt32(rdr[0]);
                    Name = Convert.ToString(rdr[1]);
                    Description = Convert.ToString(rdr[2]);
                    Dice = Convert.ToInt32(rdr[3]);
                    M_HP = Convert.ToInt32(rdr[4]);
                    M_MP = Convert.ToInt32(rdr[5]);
                    M_ATK = Convert.ToInt32(rdr[6]);
                    M_SATK = Convert.ToInt32(rdr[7]);
                    M_DEF = Convert.ToInt32(rdr[8]);
                    M_SDEF = Convert.ToInt32(rdr[9]);
                    M_CHAR = Convert.ToInt32(rdr[10]);
                    M_DEX = Convert.ToInt32(rdr[11]);
                    M_STR = Convert.ToInt32(rdr[12]);
                    M_INT = Convert.ToInt32(rdr[13]);
                    M_PERC = Convert.ToInt32(rdr[14]);
                    Weapon = Convert.ToBoolean(rdr[15]);
                    Consumable = Convert.ToBoolean(rdr[16]);
                    Helm = Convert.ToBoolean(rdr[17]);
                    Maille = Convert.ToBoolean(rdr[18]);
                    Gloves = Convert.ToBoolean(rdr[19]);
                    Pants = Convert.ToBoolean(rdr[20]);
                    Boots = Convert.ToBoolean(rdr[21]);
                    Artifact = Convert.ToBoolean(rdr[22]);
                    Healing = Convert.ToBoolean(rdr[23]);
                    Satiety = Convert.ToInt32(rdr[24]);
                    Turns = Convert.ToInt32(rdr[25]);
                    Quantity = Convert.ToInt32(rdr[26]);
                    Enhance = Convert.ToInt32(rdr[27]);
                    Durability = Convert.ToInt32(rdr[28]);
                    MaxDurability = Convert.ToInt32(rdr[29]);
                    Tier = Convert.ToInt32(rdr[30]);
                    Grade = Convert.ToInt32(rdr[31]);
                    EType = Convert.ToString(rdr[32]);
                    ELevel = Convert.ToInt32(rdr[33]);
                    Oracalcite = Convert.ToBoolean(rdr[34]);
                    OWNER_ID = Convert.ToInt32(rdr[35]);
                    count++;
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
            try
            {
                string sql = "UPDATE `items` SET" +
                    " `Name` = '" + Name.Replace("'", "\\'") + "'," +
                    " `Description` = '" + Description.Replace("'", "\\'") + "'," +
                    " `Dice` = '" + Dice + "', " +
                    " `M_HP` = '" + M_HP + "'," +
                    " `M_MP` = '" + M_MP + "'," +
                    " `M_ATK` = '" + M_ATK + "'," +
                    " `M_SATK` = '" + M_SATK + "'," +
                    " `M_DEF` = '" + M_DEF + "'," +
                    " `M_SDEF` = '" + M_SDEF + "'," +
                    " `M_CHAR` = '" + M_CHAR + "'," +
                    " `M_DEX` = '" + M_DEX + "'," +
                    " `M_STR` = '" + M_STR + "'," +
                    " `M_INT` = '" + M_INT + "'," +
                    " `M_PERC` = '" + M_PERC + "'," +
                    " `Weapon` = '" + Convert.ToInt32(Weapon) + "'," +
                    " `Consumable` = '" + Convert.ToInt32(Consumable) + "'," +
                    " `Helm` = '" + Convert.ToInt32(Helm) + "'," +
                    " `Maille` = '" + Convert.ToInt32(Maille) + "'," +
                    " `Gloves` = '" + Convert.ToInt32(Gloves) + "'," +
                    " `Pants` = '" + Convert.ToInt32(Pants) + "'," +
                    " `Boots` = '" + Convert.ToInt32(Boots) + "'," +
                    " `Artifact` = '" + Convert.ToInt32(Artifact) + "'," +
                    " `Healing` = '" + Convert.ToInt32(Healing) + "'," +
                    " `Satiety` = '" + Satiety + "'," +
                    " `Equipped` = '" + Convert.ToInt32(Equipped) + "'," +
                    " `Turns` = '" + Turns + "'," +
                    " `Quantity` = '" + Quantity + "'," +
                    " `Enhance` = '" + Enhance + "'," +
                    " `Durability` = '" + Durability + "'," +
                    " `MaxDurability` = '" + MaxDurability + "'," +
                    " `Tier` = '" + Tier + "'," +
                    " `Grade` = '" + Grade + "'," +
                    " `EType` = '" + EType + "'," +
                    " `ELevel` = '" + ELevel + "'," +
                    " `Oracalcite` = '" + Convert.ToInt32(Oracalcite) + "'," +
                    " `OWNER_ID` = '" + OWNER_ID + "'" +
                    " WHERE `idItems`='" + ItemID + "'";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

    }
    public class ITEMS
    {
        MySqlConnection conn;
        public ITEMS(MySqlConnection inconn)
        {
            conn = inconn;
        }

        public List<ITEM> GetITEM(string WHERE, string Property)
        {
            List<ITEM> GotITEMS = new List<ITEM>();
            try
            {
                
                string sql = "SELECT `idItems`, `Name` FROM `items` WHERE `" + WHERE + "`='" + Property + "'";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                List<int> al = new List<int>();
                while (rdr.Read())
                {
                    ITEM GotITEM = new ITEM(conn);
                    GotITEM.ItemID = Convert.ToInt32(rdr[0]);
                    GotITEM.Name = Convert.ToString(rdr[1]);
                    GotITEMS.Add(GotITEM);
                }
                rdr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return GotITEMS;
        }
    }
}
