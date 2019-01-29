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
    public class SPELL
    {
        MySqlConnection conn;
        public int SpellID { get; set; }
        public int OWNER_ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Tier { get; set; }
        public int Rank { get; set; }
        public int MaxSlots { get; set; }
        public int Slots { get; set; }

        public int Dice { get; set; }


        public SPELL(MySqlConnection inconn)
        {
            conn = inconn;
            Dice = 0;
        }

        public string SPELL_DATA()
        {
            return Name + " (ID: <" + SpellID + ">)";
        }

        public void Delete()
        {
            try
            {

                string sql = "DELETE FROM `spells` WHERE `idSpells`='" + SpellID + "';";
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

                string sql = "INSERT INTO `spells`" +
                    " (`Name`, `Description`, `Tier`, `Rank`, `MaxSlots`, `Slots`, `OWNER_ID`)" +
                    " VALUES" +
                    " ('" + Name.Replace("'", "\\'") + "'," +
                    " '" + Description.Replace("'", "\\'") + "'," +
                    " '" + Tier + "'," +
                    " '" + Rank + "'," +
                    " '" + MaxSlots + "'," +
                    " '" + Slots + "'," +
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
                string sql = "SELECT `idSpells`, `Name`, `Description`, `Tier`, `Rank`, `MaxSlots`, `Slots`, `OWNER_ID`" +
                    " FROM `spells` WHERE `idSpells`=" + SpellID;
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    SpellID = Convert.ToInt32(rdr[0]);
                    Name = Convert.ToString(rdr[1]);
                    Description = Convert.ToString(rdr[2]);
                    Tier = Convert.ToInt32(rdr[3]);
                    Rank = Convert.ToInt32(rdr[4]);
                    MaxSlots = Convert.ToInt32(rdr[5]);
                    Slots = Convert.ToInt32(rdr[6]);
                    OWNER_ID = Convert.ToInt32(rdr[7]);
                }
                rdr.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            Dice = (Tier * 2) + 2;

            if (Tier >= 6)
            {
                Dice = 20;
            } 
        }

        public void PostData()
        {
            try
            {
                string sql = "UPDATE `spells` SET" +
                    " `Name` = '" + Name.Replace("'", "\\'") + "'," +
                    " `Description` = '" + Description.Replace("'", "\\'") + "'," +
                    " `Tier` = '" + Tier + "', " +
                    " `Rank` = '" + Rank + "', " +
                    " `MaxSlots` = '" + MaxSlots + "', " +
                    " `Slots` = '" + Slots + "', " +
                    " `OWNER_ID` = '" + OWNER_ID + "'" +
                    " WHERE `idSpells`='" + SpellID + "'";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

    }
    public class SPELLS
    {
        MySqlConnection conn;
        public SPELLS(MySqlConnection inconn)
        {
            conn = inconn;
        }

        public List<SPELL> GetSPELLS(string WHERE, string Property)
        {
            List<SPELL> GotSPELLS = new List<SPELL>();
            try
            {

                string sql = "SELECT `idSpells`, `Name` FROM `spells` WHERE `" + WHERE + "`='" + Property + "'";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                List<int> al = new List<int>();
                while (rdr.Read())
                {
                    SPELL GotSPELL = new SPELL(conn);
                    GotSPELL.SpellID = Convert.ToInt32(rdr[0]);
                    GotSPELL.Name = Convert.ToString(rdr[1]);
                    GotSPELLS.Add(GotSPELL);
                }
                rdr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return GotSPELLS;
        }
    }
}
