using System;
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
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Login_btn_Click(object sender, EventArgs e)
        {
            string connStr = "server=" + ip_tbox.Text + ";user=DBUser;database=dungonsdargons;port=3306;password=" + dbpassword_tbox.Text + "";
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Log_lbox.Items.Add("Connecting");
                conn.Open();

                string sql = "SELECT idPlayer FROM player WHERE USERNAME='" + Name_tbox.Text + "' AND PASSWORD='" + Pass_tbox.Text + "'";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                Log_lbox.Items.Add("Connected");
                int count = 0;
                while (rdr.Read())
                {
                    count++;
                }

                if (count > 0)
                {
                    Log_lbox.Items.Add("Login Succesful Your id is " + rdr[0]);
                    MessageBox.Show("Login Succesful Your id is " + rdr[0]);
                    this.Hide();
                    User UserForm = new User(Convert.ToInt32(rdr[0]), ip_tbox.Text, dbpassword_tbox.Text);
                    UserForm.ShowDialog();
                    Application.UserAppDataRegistry.SetValue("IPString", ip_tbox.Text);
                    Application.UserAppDataRegistry.SetValue("DBPassString", dbpassword_tbox.Text);
                    Application.UserAppDataRegistry.SetValue("UsernameString", Name_tbox.Text);
                    Application.UserAppDataRegistry.SetValue("PasswordString", Pass_tbox.Text);
                    rdr.Close();
                    conn.Close();
                    this.Close();
                } else
                {
                    Log_lbox.Items.Add("Login Incorrect");
                    MessageBox.Show("Login Incorrect");
                }
                rdr.Close();
            }
            catch (Exception ex)
            {
                Log_lbox.Items.Add((ex.ToString()));
            }

            conn.Close();

        }

        private void Main_Load(object sender, EventArgs e)
        {
            try
            {
                if (Application.UserAppDataRegistry.GetValue("IPString") != null)
                {
                    ip_tbox.Text = Application.UserAppDataRegistry.GetValue("IPString").ToString();
                    dbpassword_tbox.Text = Application.UserAppDataRegistry.GetValue("DBPassString").ToString();
                    Name_tbox.Text = Application.UserAppDataRegistry.GetValue("UsernameString").ToString();
                    Pass_tbox.Text = Application.UserAppDataRegistry.GetValue("PasswordString").ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Name_tbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void Pass_tbox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
