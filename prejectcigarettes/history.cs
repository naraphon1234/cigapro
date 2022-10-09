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
    public partial class history : Form
    {
        private MySqlConnection databaseConnection()
        {
            string connectionString = "datasource=127.0.01;port=3306;user=root;password=;database=mycigarete";
            MySqlConnection conn = new MySqlConnection(connectionString);
            return conn;
        }
        public history()
        {
            InitializeComponent();
            label1.Text = Program.user;
        }
        private void showHistory()
        {
            MySqlConnection conn = databaseConnection();
            DataSet ds = new DataSet();
            conn.Open();

            MySqlCommand cmd;

            cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT  `user`, `item`, `total`, `price`, `time` FROM `buylist` WHERE user='"+login.globaluser+"'";

            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(ds);

            conn.Close();
            dataHistory.DataSource = ds.Tables[0].DefaultView;

        }
        private void history_Load(object sender, EventArgs e)
        {
            showHistory();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            เลือกสินค้า form2 = new เลือกสินค้า();
            form2.Show();
            this.Hide();
        }

        private void dataHistory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
