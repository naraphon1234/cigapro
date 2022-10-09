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
    public partial class adminedit : Form
    {
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
            cmd.CommandText = "SELECT `id`, `name`, `price`, `stock` FROM `stockcigaretes`";

            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(ds);

            conn.Close();
            dataCigaretes.DataSource = ds.Tables[0].DefaultView;

        }
        public adminedit()
        {
            InitializeComponent();
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            เลือกสินค้า form2 = new เลือกสินค้า();
            form2.Show();
            this.Hide();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            showCigarete();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int selectedRow = dataCigaretes.CurrentCell.RowIndex;
            int editId = Convert.ToInt32(dataCigaretes.Rows[selectedRow].Cells["id"].Value);
            MySqlConnection conn = databaseConnection();
            String sql = "UPDATE `stockcigaretes` SET `stock`='"+textBox1.Text+"'WHERE id = '" + editId+"'";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            conn.Open();
            int rows = cmd.ExecuteNonQuery();
            conn.Close();
            if (rows > 0)
            {
                MessageBox.Show("แก้ไขสินค้าเรียบร้อย");
                showCigarete();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataCigaretes.CurrentRow.Selected = true;
            textBox1.Text = dataCigaretes.Rows[e.RowIndex].Cells["stock"].FormattedValue.ToString();
            name.Text = dataCigaretes.Rows[e.RowIndex].Cells["name"].FormattedValue.ToString();
            price.Text = dataCigaretes.Rows[e.RowIndex].Cells["price"].FormattedValue.ToString();



        }

        private void button3_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = databaseConnection();
            string sql = "INSERT INTO stockcigaretes (name, price, stock,status,pic) VALUES ('"+name.Text+"','"+price.Text+"','"+textBox1.Text+ "','1','" + lab_path.Replace("\\","\\\\") + "')";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            
            conn.Open();

            int rows = cmd.ExecuteNonQuery();

            conn.Close();

            if(rows > 0)
            {
                MessageBox.Show("เพิ่มสินค้าเรียบร้อย");
            }
            showCigarete();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int selectRow = dataCigaretes.CurrentCell.RowIndex;
            int deleteId = Convert.ToInt32(dataCigaretes.Rows[selectRow].Cells["id"].Value);

            MySqlConnection conn = databaseConnection();

            String sql = "DELETE FROM stockcigaretes WHERE id = '"+deleteId+"'";

            MySqlCommand cmd = new MySqlCommand(sql, conn);

            conn.Open();

            int rows = cmd.ExecuteNonQuery();

            conn.Close();

            if( rows > 0 )
            {
                MessageBox.Show("ลบสินค้าเรียบร้อย");
                showCigarete();
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
           
            adminsales adminsales = new adminsales();
            adminsales.Show();
            this.Hide();
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

        private void name_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
