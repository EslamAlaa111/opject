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
    public partial class Form5 : Form
    {
        SqlConnection con = new SqlConnection("Server=DESKTOP-ROF8JMT;Database=bankdatab;Trusted_Connection=True;");

        




        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (textBox2.Text != "" && textBox1.Text != "")
            {
                string sq = "select * from bankdata where num =@nnu and name =@nn;";
                SqlCommand cd = new SqlCommand(sq, con);
                cd.Parameters.AddWithValue("@nnu", int.Parse(textBox1.Text));
                cd.Parameters.AddWithValue("@nn", textBox2.Text);
                con.Open();

                SqlDataReader re = cd.ExecuteReader();

                bool flag = false;
                if (re.HasRows)
                {
                    flag = true;
                }
                con.Close();
                if (flag)
                {

                    string sql = "delete from bankdata WHERE num =@nnu and name =@nn;";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@nnu", int.Parse(textBox1.Text));
                    cmd.Parameters.AddWithValue("@nn", textBox2.Text);
                    con.Open();
                   
                        cmd.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("YOU CLOSE THE ACCOUNT");
                        textBox1.Text = "";
                        textBox2.Text = "";
                   
                    }
                else
                {

                    MessageBox.Show("MUST SURE OF ACCOUNT NUMBER AND FULL NAME");
                }
            }
            else
                MessageBox.Show("ENTER NUM OF ACCOUNT AND NAME");
            

        }
    }
}
