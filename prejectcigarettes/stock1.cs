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
    public partial class stock1 : Form
    {
        public stock1()
        {
            InitializeComponent();
            label21.Text = Program.user;
        }
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
        
        private MySqlConnection databaseConnection()
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=mycigarete";
            MySqlConnection conn = new MySqlConnection(connectionString);
            return conn;
        }
        private void button6_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            busket form5 = new busket();
            form5.Show();
            this.Hide();
        }

        

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void numericUpDown1F4_ValueChanged(object sender, EventArgs e)
        {
            int a = 430 * (int)numericUpDown1F4.Value;
            textBox1.Text = a.ToString();
            num11 = a;
        }

        private void numericUpDown2F4_ValueChanged(object sender, EventArgs e)
        {
            int b = 500 * (int)numericUpDown2F4.Value;
            textBox2.Text = b.ToString();
            num12 = b;
        }

        private void numericUpDown3F4_ValueChanged(object sender, EventArgs e)
        {
            int c = 290 * (int)numericUpDown3F4.Value;
            textBox3.Text = c.ToString();
            num13 = c;
        }

        private void numericUpDown4F4_ValueChanged(object sender, EventArgs e)
        {
            int d = 320 * (int)numericUpDown4F4.Value;
            textBox4.Text = d.ToString();
            num14 = d;
        }

        private void numericUpDown5F4_ValueChanged(object sender, EventArgs e)
        {
            int f = 550 * (int)numericUpDown5F4.Value;
            textBox5.Text = f.ToString();
            num15 = f;
        }

        private void numericUpDown6F4_ValueChanged(object sender, EventArgs e)
        {
            int g =  260 * (int)numericUpDown6F4.Value;
            textBox6.Text = g.ToString();
            num16 = g;
        }

        private void numericUpDown7F4_ValueChanged(object sender, EventArgs e)
        {
            int h = 280 * (int)numericUpDown7F4.Value;
            textBox7.Text = h.ToString();
            num17 = h;
        }

        private void numericUpDown8F4_ValueChanged(object sender, EventArgs e)
        {
            int i = 460 * (int)numericUpDown8F4.Value;
            textBox8.Text = i.ToString();
            num18 = i;
        }

        private void numericUpDown9F4_ValueChanged(object sender, EventArgs e)
        {
            int j = 340 * (int)numericUpDown9F4.Value;
            textBox9.Text = j.ToString();
            num19 = j;
        }

        

        private void numericUpDown10F4_ValueChanged_1(object sender, EventArgs e)
        {
            int k = 290 * (int)numericUpDown10F4.Value;
            textBox10.Text = k.ToString();
            num20 = k;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=mycigarete";
            string sql = "SELECT * FROM `stockcigaretes` WHERE name= 'mond รุ้ง'  ";
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            conn.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read() && Convert.ToInt32(reader.GetString("stock")) >= Convert.ToInt32(numericUpDown1F4.Value)
                && Convert.ToInt32(reader.GetString("stock")) > 0)
            {

                int ss_ss = Convert.ToInt32(reader.GetString("stock")) - Convert.ToInt32(numericUpDown1F4.Value);
                string sql2 = $"UPDATE `stockcigaretes` SET `stock` = {ss_ss} WHERE `name` = 'mond รุ้ง' ";
                MySqlConnection con2 = new MySqlConnection(connectionString);
                MySqlCommand cmd2 = new MySqlCommand(sql2, con2);
                con2.Open();
                int rows2 = cmd2.ExecuteNonQuery();
                con2.Close();
                MessageBox.Show("คำสั่งซื้อได้รับมายืนยัน");

                conn = databaseConnection();
                sql = $"INSERT INTO `buylist`(`user`, `item`, `total`, `price`, `time`, `status`) VALUES ('{label21.Text}','mond รุ้ง'," +
                    $"'{Convert.ToInt32(numericUpDown1F4.Value)}','{570 * Convert.ToInt32(numericUpDown1F4.Value)}','{DateTime.Now.ToString("dd/MM/yyyy HH:mm")}','0')";
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

        private void button2_Click(object sender, EventArgs e)
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=mycigarete";
            string sql = "SELECT * FROM `stockcigaretes` WHERE name= 'mond ดำ'  ";
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            conn.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read() && Convert.ToInt32(reader.GetString("stock")) >= Convert.ToInt32(numericUpDown2F4.Value)
                && Convert.ToInt32(reader.GetString("stock")) > 0)
            {

                int ss_ss = Convert.ToInt32(reader.GetString("stock")) - Convert.ToInt32(numericUpDown2F4.Value);
                string sql2 = $"UPDATE `stockcigaretes` SET `stock` = {ss_ss} WHERE `name` = 'mond ดำ' ";
                MySqlConnection con2 = new MySqlConnection(connectionString);
                MySqlCommand cmd2 = new MySqlCommand(sql2, con2);
                con2.Open();
                int rows2 = cmd2.ExecuteNonQuery();
                con2.Close();
                MessageBox.Show("คำสั่งซื้อได้รับมายืนยัน");
                conn = databaseConnection();
                sql = $"INSERT INTO `buylist`(`user`, `item`, `total`, `price`, `time`, `status`) VALUES ('{label21.Text}','mond ดำ'," +
                    $"'{Convert.ToInt32(numericUpDown2F4.Value)}','{570 * Convert.ToInt32(numericUpDown2F4.Value)}','{DateTime.Now.ToString("dd/MM/yyyy HH:mm")}','0')";
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

        private void button3_Click(object sender, EventArgs e)
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=mycigarete";
            string sql = "SELECT * FROM `stockcigaretes` WHERE name= 'MILANO ทอง'  ";
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            conn.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read() && Convert.ToInt32(reader.GetString("stock")) >= Convert.ToInt32(numericUpDown3F4.Value)
                && Convert.ToInt32(reader.GetString("stock")) > 0)
            {

                int ss_ss = Convert.ToInt32(reader.GetString("stock")) - Convert.ToInt32(numericUpDown3F4.Value);
                string sql2 = $"UPDATE `stockcigaretes` SET `stock` = {ss_ss} WHERE `name` = 'MILANO ทอง' ";
                MySqlConnection con2 = new MySqlConnection(connectionString);
                MySqlCommand cmd2 = new MySqlCommand(sql2, con2);
                con2.Open();
                int rows2 = cmd2.ExecuteNonQuery();
                con2.Close();
                MessageBox.Show("คำสั่งซื้อได้รับมายืนยัน");

                conn = databaseConnection();
                sql = $"INSERT INTO `buylist`(`user`, `item`, `total`, `price`, `time`, `status`) VALUES ('{label21.Text}','MILANO ทอง'," +
                    $"'{Convert.ToInt32(numericUpDown3F4.Value)}','{570 * Convert.ToInt32(numericUpDown3F4.Value)}','{DateTime.Now.ToString("dd/MM/yyyy HH:mm")}','0')";
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

        private void button4_Click(object sender, EventArgs e)
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=mycigarete";
            string sql = "SELECT * FROM `stockcigaretes` WHERE name= 'LM Green'  ";
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            conn.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read() && Convert.ToInt32(reader.GetString("stock")) >= Convert.ToInt32(numericUpDown4F4.Value)
                && Convert.ToInt32(reader.GetString("stock")) > 0)
            {

                int ss_ss = Convert.ToInt32(reader.GetString("stock")) - Convert.ToInt32(numericUpDown4F4.Value);
                string sql2 = $"UPDATE `stockcigaretes` SET `stock` = {ss_ss} WHERE `name` = 'LM Green' ";
                MySqlConnection con2 = new MySqlConnection(connectionString);
                MySqlCommand cmd2 = new MySqlCommand(sql2, con2);
                con2.Open();
                int rows2 = cmd2.ExecuteNonQuery();
                con2.Close();
                MessageBox.Show("คำสั่งซื้อได้รับมายืนยัน");

                conn = databaseConnection();
                sql = $"INSERT INTO `buylist`(`user`, `item`, `total`, `price`, `time`, `status`) VALUES ('{label21.Text}','LM Green'," +
                    $"'{Convert.ToInt32(numericUpDown4F4.Value)}','{570 * Convert.ToInt32(numericUpDown4F4.Value)}','{DateTime.Now.ToString("dd/MM/yyyy HH:mm")}','0')";
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

        private void button5_Click(object sender, EventArgs e)
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=mycigarete";
            string sql = "SELECT * FROM `stockcigaretes` WHERE name= 'Blue ice blast'  ";
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            conn.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read() && Convert.ToInt32(reader.GetString("stock")) >= Convert.ToInt32(numericUpDown5F4.Value)
                && Convert.ToInt32(reader.GetString("stock")) > 0)
            {

                int ss_ss = Convert.ToInt32(reader.GetString("stock")) - Convert.ToInt32(numericUpDown5F4.Value);
                string sql2 = $"UPDATE `stockcigaretes` SET `stock` = {ss_ss} WHERE `name` = 'Blue ice blast' ";
                MySqlConnection con2 = new MySqlConnection(connectionString);
                MySqlCommand cmd2 = new MySqlCommand(sql2, con2);
                con2.Open();
                int rows2 = cmd2.ExecuteNonQuery();
                con2.Close();
                MessageBox.Show("คำสั่งซื้อได้รับมายืนยัน");

                conn = databaseConnection();
                sql = $"INSERT INTO `buylist`(`user`, `item`, `total`, `price`, `time`, `status`) VALUES ('{label21.Text}','Blue ice blast'," +
                    $"'{Convert.ToInt32(numericUpDown5F4.Value)}','{570 * Convert.ToInt32(numericUpDown5F4.Value)}','{DateTime.Now.ToString("dd/MM/yyyy HH:mm")}','0')";
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

        private void button8_Click(object sender, EventArgs e)
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=mycigarete";
            string sql = "SELECT * FROM `stockcigaretes` WHERE name= 'บุหรี่หวาน โบกามัส'  ";
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            conn.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read() && Convert.ToInt32(reader.GetString("stock")) >= Convert.ToInt32(numericUpDown6F4.Value)
                && Convert.ToInt32(reader.GetString("stock")) > 0)
            {

                int ss_ss = Convert.ToInt32(reader.GetString("stock")) - Convert.ToInt32(numericUpDown6F4.Value);
                string sql2 = $"UPDATE `stockcigaretes` SET `stock` = {ss_ss} WHERE `name` = 'บุหรี่หวาน โบกามัส' ";
                MySqlConnection con2 = new MySqlConnection(connectionString);
                MySqlCommand cmd2 = new MySqlCommand(sql2, con2);
                con2.Open();
                int rows2 = cmd2.ExecuteNonQuery();
                con2.Close();
                MessageBox.Show("คำสั่งซื้อได้รับมายืนยัน");

                conn = databaseConnection();
                sql = $"INSERT INTO `buylist`(`user`, `item`, `total`, `price`, `time`, `status`) VALUES ('{label21.Text}','บุหรี่หวาน โบกามัส'," +
                    $"'{Convert.ToInt32(numericUpDown6F4.Value)}','{570 * Convert.ToInt32(numericUpDown6F4.Value)}','{DateTime.Now.ToString("dd/MM/yyyy HH:mm")}','0')";
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

        private void button9_Click(object sender, EventArgs e)
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=mycigarete";
            string sql = "SELECT * FROM `stockcigaretes` WHERE name= 'Marbolo lights'  ";
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            conn.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read() && Convert.ToInt32(reader.GetString("stock")) >= Convert.ToInt32(numericUpDown7F4.Value)
                && Convert.ToInt32(reader.GetString("stock")) > 0)
            {

                int ss_ss = Convert.ToInt32(reader.GetString("stock")) - Convert.ToInt32(numericUpDown7F4.Value);
                string sql2 = $"UPDATE `stockcigaretes` SET `stock` = {ss_ss} WHERE `name` = 'Marbolo lights' ";
                MySqlConnection con2 = new MySqlConnection(connectionString);
                MySqlCommand cmd2 = new MySqlCommand(sql2, con2);
                con2.Open();
                int rows2 = cmd2.ExecuteNonQuery();
                con2.Close();
                MessageBox.Show("คำสั่งซื้อได้รับมายืนยัน");

                conn = databaseConnection();
                sql = $"INSERT INTO `buylist`(`user`, `item`, `total`, `price`, `time`, `status`) VALUES ('{label21.Text}','Marbolo lights'," +
                    $"'{Convert.ToInt32(numericUpDown7F4.Value)}','{570 * Convert.ToInt32(numericUpDown7F4.Value)}','{DateTime.Now.ToString("dd/MM/yyyy HH:mm")}','0')";
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

        private void button10_Click(object sender, EventArgs e)
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=mycigarete";
            string sql = "SELECT * FROM `stockcigaretes` WHERE name= 'ไวเบส (วนิลา)'  ";
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            conn.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read() && Convert.ToInt32(reader.GetString("stock")) >= Convert.ToInt32(numericUpDown8F4.Value)
                && Convert.ToInt32(reader.GetString("stock")) > 0)
            {

                int ss_ss = Convert.ToInt32(reader.GetString("stock")) - Convert.ToInt32(numericUpDown8F4.Value);
                string sql2 = $"UPDATE `stockcigaretes` SET `stock` = {ss_ss} WHERE `name` = 'ไวเบส (วนิลา)' ";
                MySqlConnection con2 = new MySqlConnection(connectionString);
                MySqlCommand cmd2 = new MySqlCommand(sql2, con2);
                con2.Open();
                int rows2 = cmd2.ExecuteNonQuery();
                con2.Close();
                MessageBox.Show("คำสั่งซื้อได้รับมายืนยัน");

                conn = databaseConnection();
                sql = $"INSERT INTO `buylist`(`user`, `item`, `total`, `price`, `time`, `status`) VALUES ('{label21.Text}','ไวเบส (วนิลา)'," +
                    $"'{Convert.ToInt32(numericUpDown8F4.Value)}','{570 * Convert.ToInt32(numericUpDown8F4.Value)}','{DateTime.Now.ToString("dd/MM/yyyy HH:mm")}','0')";
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

        private void button11_Click(object sender, EventArgs e)
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=mycigarete";
            string sql = "SELECT * FROM `stockcigaretes` WHERE name= 'cavallo twinball'  ";
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            conn.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read() && Convert.ToInt32(reader.GetString("stock")) >= Convert.ToInt32(numericUpDown9F4.Value)
                && Convert.ToInt32(reader.GetString("stock")) > 0)
            {

                int ss_ss = Convert.ToInt32(reader.GetString("stock")) - Convert.ToInt32(numericUpDown9F4.Value);
                string sql2 = $"UPDATE `stockcigaretes` SET `stock` = {ss_ss} WHERE `name` = 'cavallo twinball' ";
                MySqlConnection con2 = new MySqlConnection(connectionString);
                MySqlCommand cmd2 = new MySqlCommand(sql2, con2);
                con2.Open();
                int rows2 = cmd2.ExecuteNonQuery();
                con2.Close();
                MessageBox.Show("คำสั่งซื้อได้รับมายืนยัน");

                conn = databaseConnection();
                sql = $"INSERT INTO `buylist`(`user`, `item`, `total`, `price`, `time`, `status`) VALUES ('{label21.Text}','cavallo twinball'," +
                    $"'{Convert.ToInt32(numericUpDown9F4.Value)}','{570 * Convert.ToInt32(numericUpDown9F4.Value)}','{DateTime.Now.ToString("dd/MM/yyyy HH:mm")}','0')";
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

        private void button12_Click(object sender, EventArgs e)
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=mycigarete";
            string sql = "SELECT * FROM `stockcigaretes` WHERE name= 'walton'  ";
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            conn.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read() && Convert.ToInt32(reader.GetString("stock")) >= Convert.ToInt32(numericUpDown10F4.Value)
                && Convert.ToInt32(reader.GetString("stock")) > 0)
            {

                int ss_ss = Convert.ToInt32(reader.GetString("stock")) - Convert.ToInt32(numericUpDown10F4.Value);
                string sql2 = $"UPDATE `stockcigaretes` SET `stock` = {ss_ss} WHERE `name` = 'walton' ";
                MySqlConnection con2 = new MySqlConnection(connectionString);
                MySqlCommand cmd2 = new MySqlCommand(sql2, con2);
                con2.Open();
                int rows2 = cmd2.ExecuteNonQuery();
                con2.Close();
                MessageBox.Show("คำสั่งซื้อได้รับมายืนยัน");

                conn = databaseConnection();
                sql = $"INSERT INTO `buylist`(`user`, `item`, `total`, `price`, `time`, `status`) VALUES ('{label21.Text}','walton'," +
                    $"'{Convert.ToInt32(numericUpDown10F4.Value)}','{570 * Convert.ToInt32(numericUpDown10F4.Value)}','{DateTime.Now.ToString("dd/MM/yyyy HH:mm")}','0')";
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

        private void Form4_Shown(object sender, EventArgs e)
        {
            label21.Text = Program.user;
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            MessageBox.Show("บุหรี่ widebase มีมวนและก้นกรองสีดำ บุหรี่ประเภทร้อนมีความหอมไม่มาก กลิ่นหวานมาก ก้นกรองมีความหวาน");
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("บุหรี่ mond rainbow มีมวนและก้นกรองสีขาว บุหรี่ประเภทเย็น มี 2 เม็ดบีบ เย็นมิ้น มีกลิ่นหอมบูลเบอร์รี่");

        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("บุหรี่ mond black มีมวนก้นกรองสีขาว บุหรี่ประเภทเย็น มี 2 เม็ดบีบ เย็นมาก มีกลิ่นหอมหมากฝรั่ง");
        }
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("บุหรี่ milano gold มีมวนสีขาวก้นกรองสีน้ำตาล บุหรี่ประเภทร้อนแบบเบา ไม่หอม ไม่หวาน มีความแรงน้อย");
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("บุหรี่ lm green มีมวนและก้นกรองสีขาว บุหรี่ประเภทผสม ไม่หอม ไม่หวาน มีความเย็นและร้อนนิดหน่อย");

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        { 
            MessageBox.Show("บุหรี่ blue ice blast มีมวนและก้นกรองสีขาว บุหรี่ประเภทเย็น มีใบบอกสรรพคุณในกล่อง มี 1 เม็ดบีบ ไม่หอม ไม่หวาน มีความเย็นมาก");
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            MessageBox.Show("บุหรี่ bokormas มีมวนและก้นกรองสีขาว บุหรี่ประเภทร้อน มีน้ำมันกานพลู หอมและหวานชัดเจน  มีความแรงแต่ไม่แรงมาก");
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            MessageBox.Show("บุหรี่ marlbolo lights มีมวนและก้นกรองสีขาว บุหรี่ประเภทร้อนแบบเบา  ไม่หอม ไม่หวาน นุ่ม ความแรงเบา");

        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            MessageBox.Show("บุหรี่ cavallo twinball มีมวนและก้นกรองสีขาว บุหรี่ประเภทเย็น มี 2 เม็ดบีบ กลิ่นหอมบลูเบอร์รี่ ไม่หวาน  ความเย็นแรงมาก");

        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            MessageBox.Show("บุหรี่ walton มีมวนสีขาวก้นกรองสีน้ำตาล บุหรี่ประเภทร้อนแบบเบา  ไม่หอม ไม่หวาน นุ่ม ความแรงปานกลาง");
        }
    }
}
