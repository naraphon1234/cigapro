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
    public partial class busket : Form
    {
        
        public static int num1;
        public static int num2;
        public static int num3;
        public static int num4;
        public static int num5;
        public static int num6;
        public static int num7;
        public static int num8;
        public static int num9;
        public static int num10;
        public static int num11;
        public static int num12;
        public static int num13;
        public static int num14;
        public static int num15;
        public static int num16;
        public static int num17;
        public static int num18;
        public static int num19;
        public static int num20;
        public static int num21;
        public static string user;


        private MySqlConnection databaseConnection()
        {
            string connectionString = "datasource=127.0.01;port=3306;user=root;password=;database=mycigarete";
            MySqlConnection conn = new MySqlConnection(connectionString);
            return conn;
        }
        private void showCigarete()
        {
            MySqlConnection conn = databaseConnection();
            DataSet ds = new DataSet();
            conn.Open();

            MySqlCommand cmd;

            cmd = conn.CreateCommand();
            cmd.CommandText = $"SELECT  * FROM `buylist` WHERE user='{Program.user}' and status = '0' ";

            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(ds);

            conn.Close();
            dataCigaretes.DataSource = ds.Tables[0].DefaultView;

            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=mycigarete";
            string sql = "SELECT * FROM `stockcigaretes` WHERE name= 'canyon vanilla'  ";
            MySqlConnection conn_ = new MySqlConnection(connectionString);
            MySqlCommand cmd_ = new MySqlCommand(sql, conn);
            conn.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            int x = 0;
            while (reader.Read())
            {
                x+=reader.GetInt32(4);
            }
            textBox1.Text = $"{x}";

        }
        public busket()
        {
            InitializeComponent();
            label3.Text = Program.user;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
            }

        private void Form5_Load(object sender, EventArgs e)
        {
            showCigarete();
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
         
        }

        private void button1_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=mycigarete";
                string sql2 = $"UPDATE `buylist` SET status = '1' WHERE user='{Program.user}' ";
                MySqlConnection con2 = new MySqlConnection(connectionString);
                MySqlCommand cmd2 = new MySqlCommand(sql2, con2);
                con2.Open();
                int rows2 = cmd2.ExecuteNonQuery();
                con2.Close();
                MessageBox.Show("คำสั่งซื้อได้รับมายืนยัน");
            showCigarete();
            


        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
            this.Hide();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString("นราพลบุหรี่นอก", new Font("TH SarabunPSK", 20, FontStyle.Bold), Brushes.Black, new Point(268, 40));
            e.Graphics.DrawString("วันที่   " + System.DateTime.Now.ToString("dd/MM/yyyy "), new Font("TH SarabunPSK", 14, FontStyle.Bold), Brushes.Black, new PointF(570, 128));
            e.Graphics.DrawString("เวลา   " + System.DateTime.Now.ToString("HH : mm : ss น."), new Font("TH SarabunPSK", 14, FontStyle.Bold), Brushes.Black, new PointF(571, 145));
            e.Graphics.DrawString("     ", new Font("TH SarabunPSK", 16, FontStyle.Bold), Brushes.Black, new Point(45, 80));
            e.Graphics.DrawString($"    ผู้ใช้ {Program.user} ", new Font("TH SarabunPSK", 16, FontStyle.Bold), Brushes.Black, new Point(45, 90));
            e.Graphics.DrawString("    เบอร์ติดต่อ 0630067097 ", new Font("TH SarabunPSK", 16, FontStyle.Bold), Brushes.Black, new Point(45, 110));
            e.Graphics.DrawString("    PromptPay 0630067097 ", new Font("TH SarabunPSK", 16, FontStyle.Bold), Brushes.Black, new Point(45, 140));

            e.Graphics.DrawString("-------------------------------------------------------------------------------------------------------------------------------------", new Font("TH SarabunPSK", 18, FontStyle.Bold), Brushes.Black, new PointF(0, 150));
            e.Graphics.DrawString("ชื่อสินค้า", new Font("TH SarabunPSK", 18, FontStyle.Bold), Brushes.Black, new PointF(30, 170));
            e.Graphics.DrawString("จำนวน", new Font("TH SarabunPSK", 18, FontStyle.Bold), Brushes.Black, new PointF(650, 170));
            e.Graphics.DrawString("ราคา", new Font("TH SarabunPSK", 18, FontStyle.Bold), Brushes.Black, new PointF(740, 170));
            e.Graphics.DrawString("-------------------------------------------------------------------------------------------------------------------------------------", new Font("TH SarabunPSK", 18, FontStyle.Bold), Brushes.Black, new PointF(0, 200));
            string sql6 = "SELECT * FROM `buylist` WHERE user ='" + login.globaluser + "'and status = '0'";
            MySqlConnection conn6 = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=mycigarete;");
            MySqlCommand cmd6 = new MySqlCommand(sql6, conn6);
            conn6.Open();
            MySqlDataReader reader6 = cmd6.ExecuteReader();
            int y = 250, จำนวนน = 0, ราคาา = 0;
            while (reader6.Read())
            {
                e.Graphics.DrawString(reader6.GetString(2), new Font("TH SarabunPSK", 16, FontStyle.Regular), Brushes.Black, new PointF(30, y));
                e.Graphics.DrawString(reader6.GetString(3), new Font("TH SarabunPSK", 16, FontStyle.Regular), Brushes.Black, new PointF(650, y));
                e.Graphics.DrawString(reader6.GetString(4), new Font("TH SarabunPSK", 16, FontStyle.Regular), Brushes.Black, new PointF(740, y));
                y += 25;
                จำนวนน += reader6.GetInt32(3);
                ราคาา += reader6.GetInt32(4);
            }
             
            


            e.Graphics.DrawString("-------------------------------------------------------------------------------------------------------------------------------------------------------------------", new Font("TH SarabunPSK", 16, FontStyle.Regular), Brushes.Black, new Point(0, y + 20));
            e.Graphics.DrawString("รวมทั้งสิ้น    " + จำนวนน + "   บาท", new Font("TH SarabunPSK", 16, FontStyle.Regular), Brushes.Black, new Point(312, (y) + 45));
            e.Graphics.DrawString("จ่ายเงิน      " + ราคาา + "    บาท", new Font("TH SarabunPSK", 16, FontStyle.Regular), Brushes.Black, new Point(312, ((y - 10) + 45) + 45));
            e.Graphics.DrawString("------------------------------------------------------------------------------------------------------------------------------------------------------------------", new Font("TH SarabunPSK", 16, FontStyle.Regular), Brushes.Black, new Point(0, ((((y - 10) + 45) + 45) + 45) + 10));
            e.Graphics.DrawString(" ขอบคุณที่ใช้บริการ 😊 😊 ", new Font("TH SarabunPSK", 16, FontStyle.Regular), Brushes.Black, new Point(275, ((((y + 10) + 45) + 45) + 45) + 10));
        
    }

        private void button3_Click(object sender, EventArgs e)
        {
            int selectedRow = dataCigaretes.CurrentCell.RowIndex;
            int deleteId = Convert.ToInt32(dataCigaretes.Rows[selectedRow].Cells["id"].Value);

            MySqlConnection conn = databaseConnection();

            String sql = $"DELETE FROM buylist WHERE id = '"+deleteId+"'";

            MySqlCommand cmd = new MySqlCommand (sql, conn);

            conn.Open();

            int rows = cmd.ExecuteNonQuery();


            if (rows > 0)
            {
                MessageBox.Show("ลบรายการ");
                showCigarete();

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            history formhis = new history();
            formhis.Show();
        }
    }
}
