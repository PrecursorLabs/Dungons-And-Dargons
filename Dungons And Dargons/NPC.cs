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
    public class NPC
    {
        public MySqlConnection conn;
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

        public int T_HP { get; set; }
        public int T_MP { get; set; }
        public int T_ATK { get; set; }
        public int T_SATK { get; set; }
        public int T_DEF { get; set; }
        public int T_SDEF { get; set; }
        public int T_CHAR { get; set; }
        public int T_DEX { get; set; }
        public int T_STR { get; set; }
        public int T_INT { get; set; }
        public int T_PERC { get; set; }

        public int Earth { get; set; }
        public int Lightning { get; set; }
        public int Fire { get; set; }
        public int Ice { get; set; }
        public int Unholy { get; set; }
        public int Holy { get; set; }

        public string PlayerOwner { get; set; }

        public Boolean GAMEMASTER { get; set; }
        public Boolean isPlayer { get; set; }
        public Boolean isEnemy { get; set; }
        public Boolean isNPC { get; set; }
        public Boolean isALL { get; set; }

        public List<ITEM> Inventory { get; }
        public List<SPELL> Spells { get; }

        public ITEM Helmet { get; private set; }
        public ITEM Maille { get; private set; }
        public ITEM Pants { get; private set; }
        public ITEM Boots { get; private set; }
        public ITEM Gloves { get; private set; }
        public ITEM WeaponLeft { get; private set; }
        public ITEM WeaponRight { get; private set; }
        public ITEM Artifact { get; private set; }

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
            Inventory = new List<ITEM>();
            Spells = new List<SPELL>();

            Helmet = new ITEM(conn);
            Maille = new ITEM(conn);
            Pants = new ITEM(conn);
            Boots = new ITEM(conn);
            Gloves = new ITEM(conn);
            WeaponLeft = new ITEM(conn);
            WeaponRight = new ITEM(conn);
            Artifact = new ITEM(conn);
        }


        public string PLAYER_DATA()
        {
            return PName + " (ID: <" + PlayerID + ">)";
        }


        public void DeEquip(string EquipType, bool Networking=true)
        {
            try
            {
                if (EquipType == "Helmet")
                {
                    string sql = "UPDATE `items` SET `Equipped` = 0 WHERE `Helm`=1 AND `OWNER_ID` = '" + PlayerID + "'";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                    Helmet = new ITEM(conn);
                }

                if (EquipType == "Maille")
                {
                    string sql = "UPDATE `items` SET `Equipped` = 0 WHERE `Maille`=1 AND `OWNER_ID` = '" + PlayerID + "'";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                    Maille = new ITEM(conn);
                }

                if (EquipType == "Pants")
                {
                    string sql = "UPDATE `items` SET `Equipped` = 0 WHERE `Pants`=1 AND `OWNER_ID` = '" + PlayerID + "'";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                    Pants = new ITEM(conn);
                }

                if (EquipType == "Boots")
                {
                    string sql = "UPDATE `items` SET `Equipped` = 0 WHERE `Boots`=1 AND `OWNER_ID` = '" + PlayerID + "'";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                    Boots = new ITEM(conn);
                }

                if (EquipType == "Gloves")
                {
                    string sql = "UPDATE `items` SET `Equipped` = 0 WHERE `Gloves`=1 AND `OWNER_ID` = '" + PlayerID + "'";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                    Gloves = new ITEM(conn);
                }

                if (EquipType == "Weapon")
                {
                    if (WeaponRight.Name != null && WeaponLeft.Name != null)
                    {
                        string sql = "UPDATE `items` SET `Equipped` = 0 WHERE `Weapon`=1 AND `OWNER_ID` = '" + PlayerID + "'";
                        MySqlCommand cmd = new MySqlCommand(sql, conn);
                        cmd.ExecuteNonQuery();
                        WeaponLeft = new ITEM(conn);
                        WeaponRight = new ITEM(conn);
                    }
                }

                if (EquipType == "WeaponALL")
                {
                    string sql = "UPDATE `items` SET `Equipped` = 0 WHERE `Weapon`=1 AND `OWNER_ID` = '" + PlayerID + "'";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                    WeaponLeft = new ITEM(conn);
                    WeaponRight = new ITEM(conn);
                }

                if (EquipType == "Artifact")
                {
                    string sql = "UPDATE `items` SET `Equipped` = 0 WHERE `Artifact`=1 AND `OWNER_ID` = '" + PlayerID + "'";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                    Artifact = new ITEM(conn);
                }

                if (EquipType == "ALL")
                {
                    if (Networking)
                    {
                        string sql = "UPDATE `items` SET `Equipped` = 0 WHERE `OWNER_ID` = '" + PlayerID + "'";
                        MySqlCommand cmd = new MySqlCommand(sql, conn);
                        cmd.ExecuteNonQuery();
                    }

                    Helmet = new ITEM(conn);
                    Maille = new ITEM(conn);
                    Pants = new ITEM(conn);
                    Boots = new ITEM(conn);
                    Gloves = new ITEM(conn);
                    WeaponLeft = new ITEM(conn);
                    WeaponRight = new ITEM(conn);
                    Artifact = new ITEM(conn);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public bool Equip(ITEM DC_ITEM)
        {
            bool success = false;
            DC_ITEM.GetData();
            if (DC_ITEM.Prop_To_Type() == "Helmet")
            {
                success = true;
                DC_ITEM.Equipped = true;
                DC_ITEM.PostData();
                Helmet.ItemID = DC_ITEM.ItemID;
                Helmet.Name = DC_ITEM.Name;
                Helmet.GetData();
            }

            if (DC_ITEM.Prop_To_Type() == "Maille")
            {
                success = true;
                DC_ITEM.Equipped = true;
                DC_ITEM.PostData();
                Maille.ItemID = DC_ITEM.ItemID;
                Maille.Name = DC_ITEM.Name;
                Maille.GetData();
            }

            if (DC_ITEM.Prop_To_Type() == "Pants")
            {
                success = true;
                DC_ITEM.Equipped = true;
                DC_ITEM.PostData();
                Pants.ItemID = DC_ITEM.ItemID;
                Pants.Name = DC_ITEM.Name;
                Pants.GetData();
            }

            if (DC_ITEM.Prop_To_Type() == "Boots")
            {
                success = true;
                DC_ITEM.Equipped = true;
                DC_ITEM.PostData();
                Boots.ItemID = DC_ITEM.ItemID;
                Boots.Name = DC_ITEM.Name;
                Boots.GetData();
            }

            if (DC_ITEM.Prop_To_Type() == "Gloves")
            {
                success = true;
                DC_ITEM.Equipped = true;
                DC_ITEM.PostData();
                Gloves.ItemID = DC_ITEM.ItemID;
                Gloves.Name = DC_ITEM.Name;
                Gloves.GetData();
            }

            if (DC_ITEM.Prop_To_Type() == "Weapon")
            {
                success = true;
                DC_ITEM.Equipped = true;
                DC_ITEM.PostData();
                if (WeaponLeft.Name != null)
                {
                    WeaponRight.ItemID = DC_ITEM.ItemID;
                    WeaponRight.Name = DC_ITEM.Name;
                    WeaponRight.GetData();
                } else {
                    WeaponLeft.ItemID = DC_ITEM.ItemID;
                    WeaponLeft.Name = DC_ITEM.Name;
                    WeaponLeft.GetData();
                }
            }

            if (DC_ITEM.Prop_To_Type() == "Artifact")
            {
                success = true;
                DC_ITEM.Equipped = true;
                DC_ITEM.PostData();
                Artifact.ItemID = DC_ITEM.ItemID;
                Artifact.Name = DC_ITEM.Name;
                Artifact.GetData();
            }
            return success;
        }

        public void CreateData()
        {
            try
            {

                string sql = "INSERT INTO `player` (`PName`, `PDescription`, `PLevel`, `XPREQ`, `XP`, `Age`, `Gold`, `HPCur`, `HPMax`, `MPCur`, `MPMax`" +
                    ", `ATK`, `SATK`, `DEF`, `SDEF`, `CHARIS`, `DEX`, `STR`, `INTEL`, `PERC`, `Satiety`, `POwner`, `USERNAME`, `PASSWORD`" +
                    ", `GAMEMASTER`, `PLAYER`, `NPC`, `ENEMY`, `STATS`, `ALL`, `Earth`, `Lightning`, `Fire`, `Ice`, `Unholy`, `Holy`) " +
                    "VALUES (" +
                    "'" + PName + "'," +
                    "'" + Description + "'," +
                    "'" + Level + "'," +
                    "'" + XPREQ + "'," +
                    "'" + XP + "'," +
                    "'" + Age + "'," +
                    "'" + Gold + "'," +
                    "'" + HP + "'," +
                    "'" + HPMax + "'," +
                    "'" + MP + "'," +
                    "'" + MPMax + "'," +
                    "'" + ATK + "'," +
                    "'" + SATK + "'," +
                    "'" + DEF + "'," +
                    "'" + SDEF + "'," +
                    "'" + CHARIS + "'," +
                    "'" + DEX + "'," +
                    "'" + STR + "'," +
                    "'" + INTEL + "'," +
                    "'" + PERC + "'," +
                    "'" + SATIE + "'," +
                    "'" + PlayerOwner + "'," +
                    "'" + UserName + "'," +
                    "'" + "PASSWORD" + "'," +
                    "'" + Convert.ToInt32(GAMEMASTER) + "'," +
                    "'" + Convert.ToInt32(isPlayer) + "'," +
                    "'" + Convert.ToInt32(isNPC) + "'," +
                    "'" + Convert.ToInt32(isEnemy) + "'," +
                    "'" + STATS + "'," +
                    "'" + "1" + "'," +
                    "'" + Earth + "'," +
                    "'" + Lightning + "'," +
                    "'" + Fire + "'," +
                    "'" + Ice + "'," +
                    "'" + Unholy + "'," +
                    "'" + Holy + "'"
                    + ");";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();

                MySqlCommand cmd2 = new MySqlCommand("SELECT `idPlayer` FROM `player` WHERE UserName = '" + UserName + "'", conn);
                MySqlDataReader rdr2 = cmd2.ExecuteReader();
                while (rdr2.Read())
                {
                    PlayerID = Convert.ToInt32(rdr2[0]);
                }
                rdr2.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void Delete(bool INV)
        {
            try
            {
                if (INV)
                {
                    string sql = "DELETE FROM `items` WHERE `OWNER_ID`='" + PlayerID + "';";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                }
                string sql2 = "DELETE FROM `player` WHERE `idPlayer`='" + PlayerID + "';";
                MySqlCommand cmd2 = new MySqlCommand(sql2, conn);
                cmd2.ExecuteNonQuery();
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
                    " `ALL`," +
                    " `XPREQ`," +
                    " `STATS`," +
                    " `Earth`," +
                    " `Lightning`," +
                    " `Fire`," +
                    " `Ice`," +
                    " `Unholy`," +
                    " `Holy`" +
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
                    isALL = Convert.ToBoolean(rdr[26]);
                    XPREQ = Convert.ToInt32(rdr[27]);
                    STATS = Convert.ToInt32(rdr[28]);
                    Earth = Convert.ToInt32(rdr[29]);
                    Lightning = Convert.ToInt32(rdr[30]);
                    Fire = Convert.ToInt32(rdr[31]);
                    Ice = Convert.ToInt32(rdr[32]);
                    Unholy = Convert.ToInt32(rdr[33]);
                    Holy = Convert.ToInt32(rdr[34]);

                    T_HP = HPMax + M_HP;
                    T_MP = MPMax + M_MP;
                    T_ATK = ATK + M_ATK;
                    T_SATK = SATK + M_SATK;
                    T_DEF = DEF + M_DEF;
                    T_SDEF = SDEF + M_SDEF;
                    T_CHAR = CHARIS + M_CHAR;
                    T_DEX = DEX + M_DEX;
                    T_STR = STR + M_STR;
                    T_INT = INTEL + M_INT;
                    T_PERC = PERC + M_PERC;
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
                string sql = "UPDATE `player` SET" +
                    " `GAMEMASTER` = '" + Convert.ToInt32(GAMEMASTER) + "'," +
                    " `PLevel` = '" + Level + "'," +
                    " `XP` = '" + XP + "'," +
                    " `Age` = '" + Age + "'," +
                    " `Gold` = '" + Gold + "'," +
                    " `PName` = '" + PName + "'," +
                    " `PDescription` = '" + Description + "'," +
                    " `HPMax` = '" + HPMax + "'," +
                    " `HPCur` = '" + HP + "'," +
                    " `MPMax` = '" + MPMax + "'," +
                    " `MPCur` = '" + MP + "'," +
                    " `ATK` = '" + ATK + "'," +
                    " `SATK` = '" + SATK + "'," +
                    " `DEF` = '" + DEF + "'," +
                    " `SDEF` = '" + SDEF + "'," +
                    " `CHARIS` = '" + CHARIS + "'," +
                    " `DEX` = '" + DEX + "'," +
                    " `STR` = '" + STR + "'," +
                    " `INTEL` = '" + INTEL + "'," +
                    " `PERC` = '" + PERC + "'," +
                    " `Satiety` = '" + SATIE + "'," +
                    " `PLAYER` = '" + Convert.ToInt32(isPlayer) + "'," +
                    " `NPC` = '" + Convert.ToInt32(isNPC) + "'," +
                    " `ENEMY` = '" + Convert.ToInt32(isEnemy) + "'," +
                    " `ALL` = '" + Convert.ToInt32(isALL) + "'," +
                    " `XPREQ` = '" + XPREQC + "'," +
                    " `STATS` = '" + STATS + "'," +
                    " `Earth` = '" + Earth + "'," +
                    " `Lightning` = '" + Lightning + "'," +
                    " `Fire` = '" + Fire + "'," +
                    " `Ice` = '" + Ice + "'," +
                    " `Unholy` = '" + Unholy + "'," +
                    " `Holy` = '" + Holy + "'" +
                    " WHERE `idPlayer`='" + PlayerID + "'";
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
                string sql = "SELECT `idItems`, `Name`, `Equipped` FROM `items` WHERE `OWNER_ID` = '" + PlayerID + "'";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                Inventory.Clear();
                List<ITEM> Equiped = new List<ITEM>();
                while (rdr.Read())
                {
                    ITEM GotITEM = new ITEM(conn);
                    GotITEM.ItemID = Convert.ToInt32(rdr[0]);
                    GotITEM.Name = Convert.ToString(rdr[1]);
                    GotITEM.Equipped = Convert.ToBoolean(rdr[2]);
                    if (Convert.ToBoolean(rdr[2]))
                    {
                        Equiped.Add(GotITEM);
                    }
                    Inventory.Add(GotITEM);
                }
                rdr.Close();

                DeEquip("ALL", false);

                foreach (ITEM equipable in Equiped)
                {
                    Equip(equipable);
                }

                M_HP = Helmet.M_HP + Maille.M_HP + Pants.M_HP + Boots.M_HP + WeaponLeft.M_HP + WeaponRight.M_HP + Artifact.M_HP;
                M_MP = Helmet.M_MP + Maille.M_MP + Pants.M_MP + Boots.M_MP + WeaponLeft.M_MP + WeaponRight.M_MP + Artifact.M_MP;
                M_ATK = Helmet.M_ATK + Maille.M_ATK + Pants.M_ATK + Boots.M_ATK + WeaponLeft.M_ATK + WeaponRight.M_ATK + Artifact.M_ATK;
                M_SATK = Helmet.M_SATK + Maille.M_SATK + Pants.M_SATK + Boots.M_SATK + WeaponLeft.M_SATK + WeaponRight.M_SATK + Artifact.M_SATK;
                M_DEF = Helmet.M_DEF + Maille.M_DEF + Pants.M_DEF + Boots.M_DEF + WeaponLeft.M_DEF + WeaponRight.M_DEF + Artifact.M_DEF;
                M_SDEF = Helmet.M_SDEF + Maille.M_SDEF + Pants.M_SDEF + Boots.M_SDEF + WeaponLeft.M_SDEF + WeaponRight.M_SDEF + Artifact.M_SDEF;
                M_CHAR = Helmet.M_CHAR + Maille.M_CHAR + Pants.M_CHAR + Boots.M_CHAR + WeaponLeft.M_CHAR + WeaponRight.M_CHAR + Artifact.M_CHAR;
                M_DEX = Helmet.M_DEX + Maille.M_DEX + Pants.M_DEX + Boots.M_DEX + WeaponLeft.M_DEX + WeaponRight.M_DEX + Artifact.M_DEX;
                M_STR = Helmet.M_STR + Maille.M_STR + Pants.M_STR + Boots.M_STR + WeaponLeft.M_STR + WeaponRight.M_STR + Artifact.M_STR;
                M_INT = Helmet.M_INT + Maille.M_INT + Pants.M_INT + Boots.M_INT + WeaponLeft.M_INT + WeaponRight.M_INT + Artifact.M_INT;
                M_PERC = Helmet.M_PERC + Maille.M_PERC + Pants.M_PERC + Boots.M_PERC + WeaponLeft.M_PERC + WeaponRight.M_PERC + Artifact.M_PERC;

                if (WeaponLeft.Name != null || WeaponRight.Name != null)
                {
                    decimal Lweight;
                    decimal Rweight;
                    if (WeaponLeft.Dice == 20)
                    {
                        Lweight = 1;
                    } else
                    {
                        Lweight = (decimal)(WeaponLeft.Dice) / 10;
                    }

                    if (WeaponRight.Dice == 20)
                    {
                        Rweight = 1;
                    }
                    else
                    {
                        Rweight = (decimal)(WeaponRight.Dice) / 10;
                    }

                    decimal Weight = Lweight + Rweight;
                    decimal DEXMod = 1 / Weight;
                    T_DEX = (int)(Math.Ceiling(T_DEX * DEXMod));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void GetSpells()
        {
            try
            {
                string sql = "SELECT `idSpells`, `Name` FROM `spells` WHERE `OWNER_ID` = '" + PlayerID + "'";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                Spells.Clear();
                while (rdr.Read())
                {
                    SPELL GotSPELL = new SPELL(conn);
                    GotSPELL.SpellID = Convert.ToInt32(rdr[0]);
                    GotSPELL.Name = Convert.ToString(rdr[1]);
                    Spells.Add(GotSPELL);
                }
                rdr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

    }

    public class NPCS
    {
        MySqlConnection conn;
        public NPCS(MySqlConnection inconn)
        {
            conn = inconn;
        }

        public List<NPC> GetNPCS(string WHERE, string Property)
        {
            List<NPC> GotNPCS = new List<NPC>();
            try
            {
                string sql = "SELECT `idPlayer`, `PName` FROM `player` WHERE `" + WHERE + "`='" + Property + "'";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                List<int> al = new List<int>();
                while (rdr.Read())
                {
                    NPC GotNPC = new NPC(conn);
                    GotNPC.PlayerID = Convert.ToInt32(rdr[0]);
                    GotNPC.PName = Convert.ToString(rdr[1]);
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
