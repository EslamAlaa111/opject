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
    public partial class Form3 : Form
    {

        int amm;
        SqlConnection con = new SqlConnection("Server=DESKTOP-ROF8JMT;Database=bankdatab;Trusted_Connection=True;");

        public Form3()
        {
            InitializeComponent();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

            if (checkBox1.Checked)
                if (radioButton1.Checked)
                {
                    txtw.Text = "";
                    groupBox2.Visible = true;
                }
                else
                    groupBox2.Visible = false;


        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {


            if (checkBox1.Checked)
                if (radioButton2.Checked)
                {
                    txtd.Text = "";
                    groupBox1.Visible = true;
                }
                else
                    groupBox1.Visible = false;


        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //w

            int upnum;
            if (int.TryParse(txtw.Text, out upnum))
            {
                amm -= upnum;
                if (amm <= 500)
                {
                    MessageBox.Show("MUST BE IN ACCOUNT MORE THAN 500$");
                    con.Close();
                }
                else
                {
                    string sql = "UPDATE bankdata SET amount  =@nn WHERE num =@nnu;";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@nn", amm);
                    cmd.Parameters.AddWithValue("@nnu", int.Parse(textBox1.Text));
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                    checkBox1.Checked = false;

                    checkBox1.Checked = true;

                }
            }
            else
                MessageBox.Show("ENTER AMOUNT");

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //d
            int upnum;
            if (int.TryParse(txtd.Text, out upnum))
            {
                upnum += amm;
                string sql = "UPDATE bankdata SET amount =@nn WHERE num =@nnu;";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@nn", upnum);
                cmd.Parameters.AddWithValue("@nnu", int.Parse(textBox1.Text));
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                checkBox1.Checked = false;

                checkBox1.Checked = true;   






            }
            else
                MessageBox.Show("ENTER AMOUNT");


        }





        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked )
            {
                if (textBox1.Text != "")
                {
                    string sql = "select * from bankdata where num =@nn";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@nn", int.Parse(textBox1.Text));

                    con.Open();

                    SqlDataReader re = cmd.ExecuteReader();

                    string amount = null;
                    string na = null;
                    if (re.HasRows)
                    {
                        while (re.Read())
                        {

                            amount = re["amount"].ToString();
                            na = re["name"].ToString();


                        }
                        lbl.Text = "AMOUNT:" + amount;
                        lbl2.Text = "AMOUNT:" + amount;
                        textBox2.Text = na;


                        amm = int.Parse(amount);
                    }
                    else
                    {
                        MessageBox.Show("NO ACCOUNT FIND "); checkBox1.Checked = false;

                    }
                }
                else
                {
                    MessageBox.Show("SHOULD ENTER NUMBER OF ACCOUNT ");
                    checkBox1.Checked = false;
                }

                con.Close();





            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            checkBox1.Checked = false;
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            txtd.Text = "";
            txtw.Text = "";
            textBox2.Text = "";
            lbl.Text = "AMOUNT :";
            lbl2.Text = "AMOUNT :";



        }
    }
}
