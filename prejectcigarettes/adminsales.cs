using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace prejectcigarettes
{
    public partial class adminsales : Form
    {
        private MySqlConnection databaseConnection()
        {
            string connectionString = "datasource=127.0.01;port=3306;user=root;password=;database=mycigarete";
            MySqlConnection conn = new MySqlConnection(connectionString);
            return conn;
        }
        public adminsales()
        {
            InitializeComponent();
        }
        private void showSales()
        {
            MySqlConnection conn = databaseConnection();
            DataSet ds = new DataSet();
            conn.Open();

            MySqlCommand cmd;

            cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT  `user`, `item`, `total`, `price`, `time` FROM `buylist`  ";

            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(ds);

            conn.Close();
            dataSales.DataSource = ds.Tables[0].DefaultView;

            string sql6 = "SELECT  `user`, `item`, `total`, `price`, `time` FROM `buylist`  ";
            MySqlConnection conn6 = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=mycigarete;");
            MySqlCommand cmd6 = new MySqlCommand(sql6, conn6);
            conn6.Open();
            MySqlDataReader reader6 = cmd6.ExecuteReader();
            int จำนวนน = 0, ราคาา = 0;
            while (reader6.Read())
            {
                
                จำนวนน += reader6.GetInt32(3);
                
            }
            label2.Text = $"{จำนวนน}";
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            showSales();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            adminedit admin = new adminedit();
            admin.Show();
            this.Hide();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            MySqlConnection conn = databaseConnection();
            DataSet ds = new DataSet();
            conn.Open();

            MySqlCommand cmd;

            cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT  `user`, `item`, `total`, `price`, `time` FROM `buylist` WHERE `time` Like '%/" + comboBox1.Text + "/%'  ";

            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(ds);

            conn.Close();
            dataSales.DataSource = ds.Tables[0].DefaultView;
        }
    }
}
