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
    public partial class Form6 : Form
    {



        SqlConnection con = new SqlConnection("Server=DESKTOP-ROF8JMT;Database=bankdatab;Trusted_Connection=True;");

        public Form6()
        {
            InitializeComponent();
        }

        private void Form6_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                string sql = "select * from bankdata where num =@nn";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@nn", int.Parse(textBox1.Text));

                con.Open();

                SqlDataReader re = cmd.ExecuteReader();

                string amount = null;
                string name = null;
                string num = null;
                string dat=null;
                string url = null;
                string type = null;
                if (re.HasRows)
                {

                   

                    while (re.Read())
                    {
                        num = re["num"].ToString();
                        amount = re["amount"].ToString();
                        name = re["name"].ToString();
                        url = re["img"].ToString();
                        dat = re["datecreate"].ToString();
                        type = re["type"].ToString();

                    }

                    con.Close();
                    string u = "";
                    foreach (var i in url)
                    {
                        if (i == '\\')
                            u = u + '/';
                        else
                            u = u + i;
                    }



                    
                    pictureBox1.BackgroundImage = Image.FromFile(u);
                    label2.Text = label2.Text + name.ToUpper();
                    label3.Text = label3.Text +num.ToUpper();
                    label4.Text = label4.Text + amount.ToUpper();
                    label5.Text = label5.Text + dat.ToUpper();
                    label6.Text = label6.Text + type.ToUpper();



                    this.Width = 718;
                    this.Height = 630;
                    label1.Visible = false;
                    textBox1.Visible = false;
                    button1.Visible = false;
                    pictureBox1.Visible = true;
                    label2.Visible = true;
                    label3.Visible = true;
                    label4.Visible = true;
                    label5.Visible = true;
                    label6.Visible = true;







                }
                else
                {
                    MessageBox.Show("NO ACCOUNT FIND "); 

                }
            }
            else
            {
                MessageBox.Show("SHOULD ENTER NUMBER OF ACCOUNT ");
                
            }

            con.Close();

        }
    }
}
