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
    public partial class newitem : Form
    {
        private MySqlConnection databaseConnection()
        {
            string connectionString = "datasource=127.0.01;port=3306;user=root;password=;database=mycigarete";
            MySqlConnection conn = new MySqlConnection(connectionString);
            return conn;
        }
        private void showNewitem()
        {
            MySqlConnection conn = databaseConnection();
            DataSet ds = new DataSet();
            conn.Open();

            MySqlCommand cmd;

            cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT  * FROM `stockcigaretes`  WHERE status = '1'";

            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(ds);

            conn.Close();
            dataNewitem.DataSource = ds.Tables[0].DefaultView;

        }
        public newitem()
        {
            InitializeComponent();
        }
        public static int num21;

        private void newitem_Load(object sender, EventArgs e)
        {
            showNewitem();
        }
        string lab_path;
        private void button6_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files(*.png; *.jpg; *.jpeg; *.gif; *.bmp)| *.png; *.jpg; *.jpeg; *.gif; *.bmp";
            if (open.ShowDialog() == DialogResult.OK)    /*เป็นที่ที่เราคลิ๊กเพื่อเปิดโฟลเดอร์รูปภาพ ตามประเภทต่างๆของไฟล์ภาพ*/
            {
                pictureBox1.Image = new Bitmap(open.FileName);
                lab_path = open.FileName;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
            this.Hide();
        }


        int id;
        private void dataNewitem_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                dataNewitem.CurrentRow.Selected = true;
                label1.Text= dataNewitem.Rows[e.RowIndex].Cells["name"].FormattedValue.ToString();
                pictureBox1.LoadAsync(dataNewitem.Rows[e.RowIndex].Cells["pic"].FormattedValue.ToString());
                id = Convert.ToInt32(dataNewitem.Rows[e.RowIndex].Cells["id"].FormattedValue.ToString());
                a= dataNewitem.Rows[e.RowIndex].Cells["price"].FormattedValue.ToString();

            }
            catch
            {

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=mycigarete";
            string sql = "SELECT * FROM `stockcigaretes` WHERE `status` = 1  ";
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            conn.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
   
            if (reader.Read() && Convert.ToInt32(reader.GetString("stock")) >= Convert.ToInt32(numericUpDown1.Value)
                && Convert.ToInt32(reader.GetString("stock")) > 0)
            {

                int ss_ss = Convert.ToInt32(reader.GetString("stock")) - Convert.ToInt32(numericUpDown1.Value);
                string sql2 = $"UPDATE `stockcigaretes` SET `stock` = {ss_ss} WHERE `id` = '"+id+"' ";
                MySqlConnection con2 = new MySqlConnection(connectionString);
                MySqlCommand cmd2 = new MySqlCommand(sql2, con2);
                con2.Open();
                int rows2 = cmd2.ExecuteNonQuery();
                con2.Close();
                MessageBox.Show("คำสั่งซื้อได้รับมายืนยัน");

                conn = databaseConnection();
                sql = $"INSERT INTO `buylist`(`user`, `item`, `total`, `price`, `time`, `status`) VALUES ('{Program.user}','{label1.Text}'," +
                    $"'{Convert.ToInt32(numericUpDown1.Value)}','{textBox1.Text}','{DateTime.Now.ToString("dd/MM/yyyy HH:mm")}','0')";
                cmd = new MySqlCommand(sql, conn);

                conn.Open();

                int rows = cmd.ExecuteNonQuery();

                conn.Close();

                if (rows > 0)
                {

                }

            }
            else
            {
                MessageBox.Show("สินค้าหมด");
            }
        }
        string a;
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
        
            textBox1.Text = (Convert.ToInt32(a) * (int)numericUpDown1.Value).ToString();
            //num21 = textBox1.Text;
        }

        private void dataNewitem_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
