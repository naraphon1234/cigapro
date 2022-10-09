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
    public partial class Form3 : Form
    {
        
        public Form3()
        {
            InitializeComponent();
            label21.Text = Program.user;
        }

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
        

        private MySqlConnection databaseConnection()
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=mycigarete";
            MySqlConnection conn = new MySqlConnection(connectionString);
            return conn;
        }
        private void button12_Click(object sender, EventArgs e)
        {
            this.Hide();
            เลือกสินค้า form2 = new เลือกสินค้า();
            form2.Show();

        }

        private void button11_Click(object sender, EventArgs e)
        {
            this.Hide();
            stock1 form4 = new stock1();
            form4.Show();


        }

        private void numericUpDown10F3_ValueChanged(object sender, EventArgs e)
        {
            int a = 650 * (int)numericUpDown10F3.Value;
            textBox10.Text = a.ToString();
            num10 = a;
        }

        private void numericUpDown1F3_ValueChanged(object sender, EventArgs e)
        {
            int b = 330 * (int)numericUpDown1F3.Value;
            textBox1.Text = b.ToString();
            num1 = b;
        }

        private void numericUpDown6F3_ValueChanged(object sender, EventArgs e)
        {
            int c = 450 * (int)numericUpDown6F3.Value;
            textBox6.Text = c.ToString();
            num6 = c;
        }

        private void numericUpDown7F3_ValueChanged(object sender, EventArgs e)
        {
            int d = 250 * (int)numericUpDown7F3.Value;
            textBox7.Text = d.ToString();
            num7 = d;
        }

        private void numericUpDown2F3_ValueChanged(object sender, EventArgs e)
        {
            int f = 320 * (int)numericUpDown2F3.Value;
            textBox2.Text = f.ToString();
            num2 = f;
        }

        private void numericUpDown3F3_ValueChanged(object sender, EventArgs e)
        {
            int g = 420 * (int)numericUpDown3F3.Value;
            textBox3.Text = g.ToString();
            num3 = g;
        }

        private void numericUpDown8F3_ValueChanged(object sender, EventArgs e)
        {
            int h = 500 * (int)numericUpDown8F3.Value;
            textBox8.Text = h.ToString();
            num8 = h;
        }

        private void numericUpDown9F3_ValueChanged(object sender, EventArgs e)
        {
            int i = 500 * (int)numericUpDown9F3.Value;
            textBox9.Text = i.ToString();
            num9 = i;
        }

        private void numericUpDown4F3_ValueChanged(object sender, EventArgs e)
        {
            int j = 400 * (int)numericUpDown4F3.Value;
            textBox4.Text = j.ToString();
            num4 = j;
        }

        private void numericUpDown5F3_ValueChanged(object sender, EventArgs e)
        {
            int k = 570 * (int)numericUpDown5F3.Value;
            textBox5.Text = k.ToString();
            num5 = k;
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }
        
        String sql;
        MySqlConnection conn;
        MySqlCommand cmd;
        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=mycigarete";
            string sql = "SELECT * FROM `stockcigaretes` WHERE name= 'zouk'  ";
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            conn.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read() && Convert.ToInt32(reader.GetString("stock")) >= Convert.ToInt32(numericUpDown1F3.Value)
                && Convert.ToInt32(reader.GetString("stock")) > 0)
            {

                int ss_ss = Convert.ToInt32(reader.GetString("stock")) - Convert.ToInt32(numericUpDown1F3.Value);
                string sql2 = $"UPDATE `stockcigaretes` SET `stock` = {ss_ss} WHERE `name` = 'zouk' ";
                MySqlConnection con2 = new MySqlConnection(connectionString);
                MySqlCommand cmd2 = new MySqlCommand(sql2, con2);
                con2.Open();
                int rows2 = cmd2.ExecuteNonQuery();
                con2.Close();
                MessageBox.Show("คำสั่งซื้อได้รับมายืนยัน");
                conn = databaseConnection();


                sql = $"INSERT INTO `buylist`(`user`, `item`, `total`, `price`, `time`, `status`) VALUES ('{label21.Text}','zouk'," +
                    $"'{Convert.ToInt32(numericUpDown1F3.Value)}','{330* Convert.ToInt32(numericUpDown1F3.Value)}','{DateTime.Now.ToString("dd/MM/yyyy HH:mm")}','0')";
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
            string sql = "SELECT * FROM `stockcigaretes` WHERE name= 'voxx ดำ'  ";
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            conn.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read() && Convert.ToInt32(reader.GetString("stock")) >= Convert.ToInt32(numericUpDown2F3.Value)
                && Convert.ToInt32(reader.GetString("stock")) > 0)
            {

                int ss_ss = Convert.ToInt32(reader.GetString("stock")) - Convert.ToInt32(numericUpDown2F3.Value);
                string sql2 = $"UPDATE `stockcigaretes` SET `stock` = {ss_ss} WHERE `name` = 'voxx ดำ' ";
                MySqlConnection con2 = new MySqlConnection(connectionString);
                MySqlCommand cmd2 = new MySqlCommand(sql2, con2);
                con2.Open();
                int rows2 = cmd2.ExecuteNonQuery();
                con2.Close();
                MessageBox.Show("คำสั่งซื้อได้รับมายืนยัน");
                conn = databaseConnection();
                sql = $"INSERT INTO `buylist`(`user`, `item`, `total`, `price`, `time`, `status`) VALUES ('{label21.Text}','voxx ดำ'," +
                    $"'{Convert.ToInt32(numericUpDown2F3.Value)}','{320 * Convert.ToInt32(numericUpDown2F3.Value)}','{DateTime.Now.ToString("dd/MM/yyyy HH:mm")}','0')";
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
            string sql = "SELECT * FROM `stockcigaretes` WHERE name= 'voxx เขียว'  ";
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            conn.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read() && Convert.ToInt32(reader.GetString("stock")) >= Convert.ToInt32(numericUpDown3F3.Value)
                && Convert.ToInt32(reader.GetString("stock")) > 0)
            {

                int ss_ss = Convert.ToInt32(reader.GetString("stock")) - Convert.ToInt32(numericUpDown3F3.Value);
                string sql2 = $"UPDATE `stockcigaretes` SET `stock` = {ss_ss} WHERE `name` = 'voxx เขียว' ";
                MySqlConnection con2 = new MySqlConnection(connectionString);
                MySqlCommand cmd2 = new MySqlCommand(sql2, con2);
                con2.Open();
                int rows2 = cmd2.ExecuteNonQuery();
                con2.Close();
                MessageBox.Show("คำสั่งซื้อได้รับมายืนยัน");
                conn = databaseConnection();
                sql = $"INSERT INTO `buylist`(`user`, `item`, `total`, `price`, `time`, `status`) VALUES ('{label21.Text}','voxx เขียว'," +
                    $"'{Convert.ToInt32(numericUpDown3F3.Value)}','{420 * Convert.ToInt32(numericUpDown3F3.Value)}','{DateTime.Now.ToString("dd/MM/yyyy HH:mm")}','0')";
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
            string sql = "SELECT * FROM `stockcigaretes` WHERE name= 'vess เขียว'  ";
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            conn.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read() && Convert.ToInt32(reader.GetString("stock")) >= Convert.ToInt32(numericUpDown4F3.Value)
                && Convert.ToInt32(reader.GetString("stock")) > 0)
            {

                int ss_ss = Convert.ToInt32(reader.GetString("stock")) - Convert.ToInt32(numericUpDown4F3.Value);
                string sql2 = $"UPDATE `stockcigaretes` SET `stock` = {ss_ss} WHERE `name` = 'vess เขียว' ";
                MySqlConnection con2 = new MySqlConnection(connectionString);
                MySqlCommand cmd2 = new MySqlCommand(sql2, con2);
                con2.Open();
                int rows2 = cmd2.ExecuteNonQuery();
                con2.Close();
                MessageBox.Show("คำสั่งซื้อได้รับมายืนยัน");
                conn = databaseConnection();
                sql = $"INSERT INTO `buylist`(`user`, `item`, `total`, `price`, `time`, `status`) VALUES ('{label21.Text}','vess เขียว'," +
                    $"'{Convert.ToInt32(numericUpDown4F3.Value)}','{400 * Convert.ToInt32(numericUpDown4F3.Value)}','{DateTime.Now.ToString("dd/MM/yyyy HH:mm")}','0')";
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
            string sql = "SELECT * FROM `stockcigaretes` WHERE name= 'vess แดง'  ";
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            conn.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read() && Convert.ToInt32(reader.GetString("stock")) >= Convert.ToInt32(numericUpDown5F3.Value)
                && Convert.ToInt32(reader.GetString("stock")) > 0)
            {

                int ss_ss = Convert.ToInt32(reader.GetString("stock")) - Convert.ToInt32(numericUpDown5F3.Value);
                string sql2 = $"UPDATE `stockcigaretes` SET `stock` = {ss_ss} WHERE `name` = 'vess แดง' ";
                MySqlConnection con2 = new MySqlConnection(connectionString);
                MySqlCommand cmd2 = new MySqlCommand(sql2, con2);
                con2.Open();
                int rows2 = cmd2.ExecuteNonQuery();
                con2.Close();
                MessageBox.Show("คำสั่งซื้อได้รับมายืนยัน");
                conn = databaseConnection();
                sql = $"INSERT INTO `buylist`(`user`, `item`, `total`, `price`, `time`, `status`) VALUES ('{label21.Text}','vess แดง'," +
                    $"'{Convert.ToInt32(numericUpDown5F3.Value)}','{570 * Convert.ToInt32(numericUpDown5F3.Value)}','{DateTime.Now.ToString("dd/MM/yyyy HH:mm")}','0')";
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

        private void button6_Click(object sender, EventArgs e)
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=mycigarete";
            string sql = "SELECT * FROM `stockcigaretes` WHERE name= 'denver silver'  ";
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            conn.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read() && Convert.ToInt32(reader.GetString("stock")) >= Convert.ToInt32(numericUpDown6F3.Value)
                && Convert.ToInt32(reader.GetString("stock")) > 0)
            {

                int ss_ss = Convert.ToInt32(reader.GetString("stock")) - Convert.ToInt32(numericUpDown6F3.Value);
                string sql2 = $"UPDATE `stockcigaretes` SET `stock` = {ss_ss} WHERE `name` = 'denver silver' ";
                MySqlConnection con2 = new MySqlConnection(connectionString);
                MySqlCommand cmd2 = new MySqlCommand(sql2, con2);
                con2.Open();
                int rows2 = cmd2.ExecuteNonQuery();
                con2.Close();
                MessageBox.Show("คำสั่งซื้อได้รับมายืนยัน");
                conn = databaseConnection();
                sql = $"INSERT INTO `buylist`(`user`, `item`, `total`, `price`, `time`, `status`) VALUES ('{label21.Text}','denver silver'," +
                    $"'{Convert.ToInt32(numericUpDown6F3.Value)}','{250 * Convert.ToInt32(numericUpDown6F3.Value)}','{DateTime.Now.ToString("dd/MM/yyyy HH:mm")}','0')";
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

        private void button7_Click(object sender, EventArgs e)
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=mycigarete";
            string sql = "SELECT * FROM `stockcigaretes` WHERE name= 'denver green'  ";
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            conn.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read() && Convert.ToInt32(reader.GetString("stock")) >= Convert.ToInt32(numericUpDown7F3.Value)
                && Convert.ToInt32(reader.GetString("stock")) > 0)
            {

                int ss_ss = Convert.ToInt32(reader.GetString("stock")) - Convert.ToInt32(numericUpDown7F3.Value);
                string sql2 = $"UPDATE `stockcigaretes` SET `stock` = {ss_ss} WHERE `name` = 'denver green' ";
                MySqlConnection con2 = new MySqlConnection(connectionString);
                MySqlCommand cmd2 = new MySqlCommand(sql2, con2);
                con2.Open();
                int rows2 = cmd2.ExecuteNonQuery();
                con2.Close();
                MessageBox.Show("คำสั่งซื้อได้รับมายืนยัน");
                conn = databaseConnection();
                sql = $"INSERT INTO `buylist`(`user`, `item`, `total`, `price`, `time`, `status`) VALUES ('{label21.Text}','denver green'," +
                    $"'{Convert.ToInt32(numericUpDown7F3.Value)}','{500 * Convert.ToInt32(numericUpDown7F3.Value)}','{DateTime.Now.ToString("dd/MM/yyyy HH:mm")}','0')";
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
            string sql = "SELECT * FROM `stockcigaretes` WHERE name= 'canyon vanilla'  ";
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            conn.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read() && Convert.ToInt32(reader.GetString("stock")) >= Convert.ToInt32(numericUpDown8F3.Value)
                && Convert.ToInt32(reader.GetString("stock")) > 0)
            {

                int ss_ss = Convert.ToInt32(reader.GetString("stock")) - Convert.ToInt32(numericUpDown8F3.Value);
                string sql2 = $"UPDATE `stockcigaretes` SET `stock` = {ss_ss} WHERE `name` = 'canyon vanilla' ";
                MySqlConnection con2 = new MySqlConnection(connectionString);
                MySqlCommand cmd2 = new MySqlCommand(sql2, con2);
                con2.Open();
                int rows2 = cmd2.ExecuteNonQuery();
                con2.Close();
                MessageBox.Show("คำสั่งซื้อได้รับมายืนยัน");
                conn = databaseConnection();
                sql = $"INSERT INTO `buylist`(`user`, `item`, `total`, `price`, `time`, `status`) VALUES ('{label21.Text}','canyon vanilla'," +
                    $"'{Convert.ToInt32(numericUpDown8F3.Value)}','{500 * Convert.ToInt32(numericUpDown8F3.Value)}','{DateTime.Now.ToString("dd/MM/yyyy HH:mm")}','0')";
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
            string sql = "SELECT * FROM `stockcigaretes` WHERE name= 'milano x-merge'  ";
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            conn.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read() && Convert.ToInt32(reader.GetString("stock")) >= Convert.ToInt32(numericUpDown9F3.Value)
                && Convert.ToInt32(reader.GetString("stock")) > 0)
            {

                int ss_ss = Convert.ToInt32(reader.GetString("stock")) - Convert.ToInt32(numericUpDown9F3.Value);
                string sql2 = $"UPDATE `stockcigaretes` SET `stock` = {ss_ss} WHERE `name` = 'milano x-merge' ";
                MySqlConnection con2 = new MySqlConnection(connectionString);
                MySqlCommand cmd2 = new MySqlCommand(sql2, con2);
                con2.Open();
                int rows2 = cmd2.ExecuteNonQuery();
                con2.Close();
                MessageBox.Show("คำสั่งซื้อได้รับมายืนยัน");
                conn = databaseConnection();
                sql = $"INSERT INTO `buylist`(`user`, `item`, `total`, `price`, `time`, `status`) VALUES ('{label21.Text}','milano x-merge'," +
                    $"'{Convert.ToInt32(numericUpDown9F3.Value)}','{500 * Convert.ToInt32(numericUpDown9F3.Value)}','{DateTime.Now.ToString("dd/MM/yyyy HH:mm")}','0')";
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
            string sql = "SELECT * FROM `stockcigaretes` WHERE name= 'gudang garam'  ";
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            conn.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read() && Convert.ToInt32(reader.GetString("stock")) >= Convert.ToInt32(numericUpDown10F3.Value)
                && Convert.ToInt32(reader.GetString("stock")) > 0)
            {

                int ss_ss = Convert.ToInt32(reader.GetString("stock")) - Convert.ToInt32(numericUpDown10F3.Value);
                string sql2 = $"UPDATE `stockcigaretes` SET `stock` = {ss_ss} WHERE `name` = 'gudang garam' ";
                MySqlConnection con2 = new MySqlConnection(connectionString);
                MySqlCommand cmd2 = new MySqlCommand(sql2, con2);
                con2.Open();
                int rows2 = cmd2.ExecuteNonQuery();
                con2.Close();
                MessageBox.Show("คำสั่งซื้อได้รับมายืนยัน");
                conn = databaseConnection();
                sql = $"INSERT INTO `buylist`(`user`, `item`, `total`, `price`, `time`, `status`) VALUES ('{label21.Text}','gudang garam'," +
                    $"'{Convert.ToInt32(numericUpDown10F3.Value)}','{850 * Convert.ToInt32(numericUpDown10F3.Value)}','{DateTime.Now.ToString("dd/MM/yyyy HH:mm")}','0')";
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

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("บุหรี่ zouk มีมวนและก้นกรองสีดำ บุหรี่ประเภทร้อน กลิ่นหอมของวนิลลา ก้นกรองหวาน ไม่ค่อยหวานมาก ไม่ค่อยแรง");
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("บุหรี่ voxx black มีมวนสีขาวก้นกรองสีน้ำตาล บุหรี่ประเภทร้อน ไม่หอม ไม่หวาน มีความแรงแต่ไม่แรงมาก");

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("บุหรี่ voxx green มีมวนและก้นกรองสีขาว บุหรี่ประเภทเย็น มีสติ๊กเกอร์กันก้นกรอง มีความเย็นแน่น ไม่หอม ไม่หวาน");
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("บุหรี่ vess green มีมวนและก้นกรองสีขาว บุหรี่ประเภทเย็น กลิ่นเมนทอลชัดเจน มีความเย็นระดับกลางๆ มวนแน่น มีความนุ่ม ไม่หอม ไม่หวาน");

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("บุหรี่ vess red มีมวนสีขาวก้นกรองสีน้ำตาล บุหรี่ประเภทร้อน ไม่ระคายเคือง มีความนุ่ม ไม่หอม ไม่หวาน ไม่แรงมาก");

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            MessageBox.Show("บุหรี่ denver silver มีมวนสีขาวก้นกรองสีเงิน บุหรี่ประเภทร้อนแบบเบา ใบยาแน่น มีความแน่นน้อยมาก ไม่หอม ไม่หวาน");

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            MessageBox.Show("บุหรี่ denver green มีมวนสีขาวก้นกรองสีขาวตัวอักษรสีเขียว บุหรี่ประเภทเย็น มวนเล็กกว่าปกตินิดหน่อย ใบยาแน่น ความเย็นติดปากนิดๆ หอมเมนทอล ไม่หวาน ไม่หอม");
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            MessageBox.Show("บุหรี่ canyon vanilla มีมวนสีน้ำตาลและก้นกรองสีขาว บุหรี่ประเภทร้อน กลิ่นหอมของวนิลลา ก้นกรองไม่หวาน ไม่ค่อยหวานมาก หอมปานกลาง ไม่แรงมาก");
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            MessageBox.Show("บุหรี่ milano x-merge มีมวนและก้นกรองสีขาว บุหรี่ประเภทเย็น  มีเม็ดบีบ 2 เม็ด เย็นติดปาก หอมมิ้นและบูลเบอร์รี่ หวานบูลเบอร์รี่ ");
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            MessageBox.Show("บุหรี่ gudang garam มีมวนสีขาว ก้นกรองสีน้ำตาล บุหรี่ประเภทร้อน มีน้ำมันกานพูล ไม่หอม ไม่หวาน มีความแรงมาก ตัวบุหรี่ใหญ่แน่น");

        }

        private void button13_Click(object sender, EventArgs e)
        {
            newitem newitem = new newitem();
            newitem.Show();
            this.Hide();
        }

        private void label21_Click(object sender, EventArgs e)
        {

        }
    }
}