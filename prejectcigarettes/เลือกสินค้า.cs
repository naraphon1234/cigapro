using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prejectcigarettes
{
    public partial class เลือกสินค้า : Form
    {
        public เลือกสินค้า()
        {
            InitializeComponent();
            label3.Text = Program.user;

        }

        private void label1_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            busket form2 = new busket();
            form2.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            history history = new history();
            history.Show();
            this.Hide();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
