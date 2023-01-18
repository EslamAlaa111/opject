using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace opject
{
    public partial class Form1 : Form
    {

        SqlConnection con = new SqlConnection("Server=DESKTOP-ROF8JMT;Database=bankdatab;Trusted_Connection=True;");
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();  
            form3.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            form4.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            form.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form5 form5 = new Form5();
            form5.ShowDialog();
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            button1.BackgroundImage =Image.FromFile("D:/obj/Resources/hove.jpeg") ;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackgroundImage = Image.FromFile(@"D:\obj\Resources\button.jpeg");
        }

        private void button2_MouseHover(object sender, EventArgs e)
        {
            button2.BackgroundImage = Image.FromFile("D:/obj/Resources/hove.jpeg");
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.BackgroundImage = Image.FromFile(@"D:\obj\Resources\button.jpeg");
        }

        private void button3_MouseHover(object sender, EventArgs e)
        {
            button3.BackgroundImage = Image.FromFile("D:/obj/Resources/hove.jpeg");
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            button3.BackgroundImage = Image.FromFile(@"D:\obj\Resources\button.jpeg");
        }

        private void button5_MouseHover(object sender, EventArgs e)
        {
            button5.BackgroundImage = Image.FromFile("D:/obj/Resources/hove.jpeg");
        }

        private void button5_MouseLeave(object sender, EventArgs e)
        {
            button5.BackgroundImage = Image.FromFile(@"D:\obj\Resources\button.jpeg");
        }

        private void button4_MouseHover(object sender, EventArgs e)
        {
            button4.BackgroundImage = Image.FromFile("D:/obj/Resources/hove.jpeg");
        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {
            button4.BackgroundImage = Image.FromFile(@"D:\obj\Resources\button.jpeg");
        }

        private void button6_MouseHover(object sender, EventArgs e)
        {
            button6.BackgroundImage = Image.FromFile("D:/obj/Resources/hove.jpeg");
        }

        private void button6_MouseLeave(object sender, EventArgs e)
        {
            button6.BackgroundImage = Image.FromFile(@"D:\obj\Resources\button.jpeg");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form6 form6 = new Form6();
            form6.ShowDialog();
        }
    }
}
