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
    public partial class Player : Form
    {
        MySqlConnection Pconn;
        public int PID;
        NPC SELNPC;

        public Player(int ID, MySqlConnection conn)
        {
            InitializeComponent();
            PID = ID;
            Pconn = conn;
            SELNPC = new NPC(Pconn);
            SELNPC.GetData();
            SELNPC.GetInventory();
        }

        private void Player_Load(object sender, EventArgs e)
        {

        }
    }
}
