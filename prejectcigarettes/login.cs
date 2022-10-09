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
    public partial class login : Form
    {
        MySqlConnection connect = new MySqlConnection("datasource = 127.0.0.1;port=3306;username=root;password=;database=mycigarete;charset=utf8");
        MySqlDataAdapter adapter;
        DataTable table;

        public login()
        {
            InitializeComponent();
        }
        public void openConnection()
    {

            if (connect.State == ConnectionState.Closed)
            {
                connect.Open();
            }

        }
        public void closeConnection()
        {
            if (connect.State == ConnectionState.Open)
            {
                connect.Close();
            }
        }
        
        public void dataAdapterLogin(String query)
        {
            openConnection();
            adapter = new MySqlDataAdapter(query, connect);
            table = new DataTable();
            adapter.Fill(table);
            if(textBox1.Text == "fong" && textBox2.Text == "fong"|| textBox1.Text =="naraphon" && textBox2.Text=="naraphon")
            {
                if (table.Rows.Count > 0)
                {   
                    Program.user = textBox1.Text;
                    string status = table.Rows[0][4].ToString();
                    
                    this.Hide();
                    adminedit cus = new adminedit();
                    cus.Show();
                    

                }
                else
                {
                    MessageBox.Show("ไม่พบข้อมูลผู้ใช้");
                }
            }
            else 
            {
                Program.user = textBox1.Text;
                this.Hide();
                เลือกสินค้า cus = new เลือกสินค้า();
                cus.Show();
            }
        }
        public static string globaluser;
        private void button1_Click(object sender, EventArgs e)
        {
            string login = "SELECT * FROM mycigarete.userinfor WHERE username='"+textBox1.Text+"' AND password='"+textBox2.Text+"'";
            dataAdapterLogin(login);
            globaluser = textBox1.Text;
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            register cus = new register();
            cus.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void login_Load(object sender, EventArgs e)
        {
           
            
        }

        private void login_Click(object sender, EventArgs e)
        {
            MessageBox.Show(DateTime.Now.ToString("dd/MM/yyyy HH:mm"));
        }
    }
}
