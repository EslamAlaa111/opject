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
    public partial class Form2 : Form
    {
        string img= "C:/Users/Eslam Alaa/Pictures/person.jpj.jpeg";

        SqlConnection con = new SqlConnection("Server=DESKTOP-ROF8JMT;Database=bankdatab;Trusted_Connection=True;");



        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            string sqll = "select * from bankdata where num =@nn";
            SqlCommand cmmd = new SqlCommand(sqll, con);
            cmmd.Parameters.AddWithValue("@nn", int.Parse(txt2.Text));

            con.Open();

            SqlDataReader re = cmmd.ExecuteReader();

            if (re.HasRows)
            {

                MessageBox.Show("THERE IS ACCOUNT HAS SAME NUM");
                txt2.Focus();
                con.Close();    
            }
            else {
                con.Close();
                string sql = "insert into bankdata values (@name,@num,@amount,@type,@datecreate,@img)";

                SqlCommand cm = new SqlCommand(sql, con);
               
                if (int.Parse(txt3.Text) > 500)
                {
                    cm.Parameters.AddWithValue("@amount", int.Parse(txt3.Text));
                    cm.Parameters.AddWithValue("@name", txt1.Text);
                    cm.Parameters.AddWithValue("@num", int.Parse(txt2.Text));
                    cm.Parameters.AddWithValue("@img",img );
                    if (radioButton1.Checked)
                        cm.Parameters.AddWithValue("@type", "Salary account");
                    else
                        cm.Parameters.AddWithValue("@type", "Current account");

                    cm.Parameters.AddWithValue("@datecreate", System.DateTime.Now);

                    con.Open();
                    cm.ExecuteNonQuery();
                    con.Close();
                    progressBar1.Visible = true;
                    for (int i = 0; i < 200; i++)
                    {
                        if (i > 9)
                            continue;
                        progressBar1.Value += 10;
                        
                    }
                    if(progressBar1.Value==100)
                    MessageBox.Show("NEW ACCOUNT CREATED");
                    this.Close();











                }
                else
                    MessageBox.Show("MUST AMOUNT BE MORE THAN OR EQUAL 500 $");

               


            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog()== DialogResult.OK)
                pictureBox1.BackgroundImage=Image.FromFile(openFileDialog1.FileName);
            img = (openFileDialog1.FileName).ToString();

        }
    }
}
