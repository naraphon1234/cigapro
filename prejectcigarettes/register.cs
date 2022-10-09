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
    public partial class register : Form
    {
        private MySqlConnection databaseConnection()
        {
            string connectionString = "datasource=127.0.01;port=3306;user=root;password=;database=mycigarete";
            MySqlConnection conn = new MySqlConnection(connectionString);
            return conn;
        }
        private void showRegister()
        {
            MySqlConnection conn = databaseConnection();
            DataSet ds = new DataSet();
            conn.Open();

            MySqlCommand cmd;

            cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT `id`, `username`, `password`, `phone`, `email`, `birthday`, `birthmonth`, `birthyears`, `address` FROM `userinfor`";

            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(ds);

            conn.Close();

        }
        public register()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (username.Text.Length > 0 )
            {
                if (textBox3.Text.Length > 0)
                {
                    if (phone.Text.Length == 10)
                    {
                        if (username.Text.Length >= 5 && username.Text.Length <= 20)
                        {
                            if (password.Text.Length >= 5 && password.Text.Length <= 20)
                            {
                                if (password.Text == textBox1.Text)
                                {

                                    MySqlConnection conn = databaseConnection();

                                    String sql = "INSERT INTO `userinfor`(`username`, `password`, `phone`, `email`, `birthday`, `birthmonth`, `birthyears`, `address`) VALUES('" + username.Text + "','" + password.Text + "','" +phone.Text+ "','" + textBox3.Text + "','" + comboBox1.Text + "','" + comboBox3.Text + "','" + comboBox2.Text + "','"+richTextBox1.Text+"')";

                                    MySqlCommand cmd = new MySqlCommand(sql, conn);

                                    conn.Open();

                                    int rows = cmd.ExecuteNonQuery();

                                    conn.Close();

                                    if (rows > 0)
                                    {
                                        MessageBox.Show("Added Data", "System", MessageBoxButtons.YesNo);

                                        this.Hide();

                                        login form1 = new login();

                                        form1.Show();

                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Password must same");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Password must have more than 4 character and less than 21 character");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Username must have more than 4 character and less than 21 character");
                        }

                    }
                    else
                    {
                        MessageBox.Show("Please enter your phonenumber ");
                    }

                }
                else
                {
                    MessageBox.Show("Please enter your email");
                }
            }
            else
            {
                MessageBox.Show("Please enter your name and lastname");
            }
            



        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataRegister_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void register_Load(object sender, EventArgs e)
        {
            showRegister();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}


