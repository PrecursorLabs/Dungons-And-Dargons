﻿using System;
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
    public class NPC
    {
        MySqlConnection conn;
        public int PlayerID { get; set; }
        public string UserName { get; set; }
        public string PName { get; set; }
        public string Description { get; set; }

        public int Level { get; set; }
        public int XP { get; set; }
        public int XPREQ { get; set; }
        public int Age { get; set; }
        public int Gold { get; set; }
        public int HP { get; set; }
        public int MP { get; set; }
        public int HPMax { get; set; }
        public int MPMax { get; set; }
        public int ATK { get; set; }
        public int SATK { get; set; }
        public int DEF { get; set; }
        public int SDEF { get; set; }
        public int CHARIS { get; set; }
        public int DEX { get; set; }
        public int STR { get; set; }
        public int INTEL { get; set; }
        public int PERC { get; set; }
        public int SATIE { get; set; }
        public int STATS { get; set; }

        public string PlayerOwner { get; set; }

        public Boolean GAMEMASTER { get; set; }
        public Boolean isPlayer { get; set; }
        public Boolean isEnemy { get; set; }
        public Boolean isNPC { get; set; }

        public List<string> Inventory { get; set; }

        public int NHPMax { get; set; }
        public int NMPMax { get; set; }
        public int NATK { get; set; }
        public int NSATK { get; set; }
        public int NDEF { get; set; }
        public int NSDEF { get; set; }
        public int NCHARIS { get; set; }
        public int NDEX { get; set; }
        public int NSTR { get; set; }
        public int NINTEL { get; set; }
        public int NPERC { get; set; }

        public int NSTAT { get; set; }

        public NPC(MySqlConnection inconn)
        {
            conn = inconn;
            Inventory = new List<String>();
        }

        public void GetData()
        {
            try
            {
                string sql = "SELECT `idPlayer`," +
                    " `GAMEMASTER`," +
                    " `PLevel`, " +
                    " `XP`," +
                    " `Age`," +
                    " `Gold`," +
                    " `PName`," +
                    " `PDescription`," +
                    " `HPMax`," +
                    " `HPCur`," +
                    " `MPMax`," +
                    " `MPCur`," +
                    " `ATK`," +
                    " `SATK`," +
                    " `DEF`," +
                    " `SDEF`," +
                    " `CHARIS`," +
                    " `DEX`," +
                    " `STR`," +
                    " `INTEL`," +
                    " `PERC`," +
                    " `Satiety`," +
                    " `POwner`," +
                    " `PLAYER`," +
                    " `NPC`," +
                    " `ENEMY`," +
                    " `XPREQ`," +
                    " `STATS`" +
                    " FROM `player` WHERE `idPlayer`='" + PlayerID + "'";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    PlayerID = Convert.ToInt32(rdr[0]);
                    GAMEMASTER = Convert.ToBoolean(rdr[1]);
                    Level = Convert.ToInt32(rdr[2]);
                    XP = Convert.ToInt32(rdr[3]);
                    Age = Convert.ToInt32(rdr[4]);
                    Gold = Convert.ToInt32(rdr[5]);
                    PName = Convert.ToString(rdr[6]);
                    Description = Convert.ToString(rdr[7]);
                    HPMax = Convert.ToInt32(rdr[8]);
                    HP = Convert.ToInt32(rdr[9]);
                    MPMax = Convert.ToInt32(rdr[10]);
                    MP = Convert.ToInt32(rdr[11]);
                    ATK = Convert.ToInt32(rdr[12]);
                    SATK = Convert.ToInt32(rdr[13]);
                    DEF = Convert.ToInt32(rdr[14]);
                    SDEF = Convert.ToInt32(rdr[15]);
                    CHARIS = Convert.ToInt32(rdr[16]);
                    DEX = Convert.ToInt32(rdr[17]);
                    STR = Convert.ToInt32(rdr[18]);
                    INTEL = Convert.ToInt32(rdr[19]);
                    PERC = Convert.ToInt32(rdr[20]);
                    SATIE = Convert.ToInt32(rdr[21]);
                    PlayerOwner = Convert.ToString(rdr[22]);
                    isPlayer = Convert.ToBoolean(rdr[23]);
                    isNPC = Convert.ToBoolean(rdr[24]);
                    isEnemy = Convert.ToBoolean(rdr[25]);
                    XPREQ = Convert.ToInt32(rdr[26]);
                    STATS = Convert.ToInt32(rdr[27]);
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
            double XPREQC = 0;
            for (int i = 1; i < (Level + 1); i++)
            {
                XPREQC += Math.Pow(i, 3);
            }
            XPREQC = Math.Round(XPREQC, MidpointRounding.AwayFromZero);

            XPREQ = (int)XPREQC;
            try
            {
                string sql = "UPDATE player SET" +
                    " GAMEMASTER = '" + Convert.ToInt32(GAMEMASTER) + "'," +
                    " PLevel = '" + Level + "'," +
                    " XP = '" + XP + "'," +
                    " Age = '" + Age + "'," +
                    " Gold = '" + Gold + "'," +
                    " PName = '" + PName + "'," +
                    " PDescription = '" + Description + "'," +
                    " HPMax = '" + HPMax + "'," +
                    " HPCur = '" + HP + "'," +
                    " MPMax = '" + MPMax + "'," +
                    " MPCur = '" + MP + "'," +
                    " ATK = '" + ATK + "'," +
                    " SATK = '" + SATK + "'," +
                    " DEF = '" + DEF + "'," +
                    " SDEF = '" + SDEF + "'," +
                    " CHARIS = '" + CHARIS + "'," +
                    " DEX = '" + DEX + "'," +
                    " STR = '" + STR + "'," +
                    " INTEL = '" + INTEL + "'," +
                    " PERC = '" + PERC + "'," +
                    " Satiety = '" + SATIE + "'," +
                    " PLAYER = '" + Convert.ToInt32(isPlayer) + "'," +
                    " NPC = '" + Convert.ToInt32(isNPC) + "'," +
                    " ENEMY = '" + Convert.ToInt32(isEnemy) + "'," +
                    " XPREQ = '" + XPREQC + "'," +
                    " STATS = '" + STATS + "'" +
                    " WHERE idPlayer='" + PlayerID + "'";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void GetInventory()
        {
            try
            {
                Inventory.Clear();
                string sql = "SELECT `Items_idItems` FROM `player_has_items` WHERE `Player_idPlayer`=" + PlayerID.ToString();
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                List<int> al = new List<int>();
                while (rdr.Read())
                {
                    al.Add(Convert.ToInt32(rdr[0]));
                }
                rdr.Close();
                foreach (int ItemID in al)
                {
                    string sql2 = "SELECT `Name` FROM `items` WHERE `idItems`=" + ItemID.ToString();
                    MySqlCommand cmd2 = new MySqlCommand(sql2, conn);
                    MySqlDataReader rdr2 = cmd2.ExecuteReader();
                    while (rdr2.Read())
                    {
                        Inventory.Add(Convert.ToString(rdr2[0]) + " (ID: <" + ItemID.ToString() + ">)");
                    }
                    rdr2.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void SetInventory()
        {
            try
            {
                string sql = "DELETE FROM `player_has_items` WHERE `Player_idPlayer` = '" + PlayerID + "'";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            foreach (string item in Inventory)
            {

                string IID = item.Split('<', '>')[1];
                try
                {
                    string sql = "INSERT INTO `player_has_items` (`Player_idPlayer`, `Items_idItems`) " +
                        "VALUES (" + PlayerID + "," + IID + ")";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }

        }

    }

    class NPCS
    {
        MySqlConnection conn;
        public NPCS(MySqlConnection inconn)
        {
            conn = inconn;
        }

        public List<NPC> GetNPCS(string WHERE, string Propety)
        {
            List<NPC> GotNPCS = new List<NPC>();
            try
            {
                string sql = "SELECT `idPlayer` FROM `player` WHERE `" + WHERE + "`='" + Propety + "'";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                List<int> al = new List<int>();
                while (rdr.Read())
                {
                    NPC GotNPC = new NPC(conn);
                    GotNPC.PlayerID = Convert.ToInt32(rdr[0]);
                    GotNPCS.Add(GotNPC);
                }
                rdr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return GotNPCS;
        }
    }
}
