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
    public partial class Form4 : Form
    {
        SqlConnection con = new SqlConnection("Server=DESKTOP-ROF8JMT;Database=bankdatab;Trusted_Connection=True;");


        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            con.Open();
            string sql = "select * from bankdata";
            SqlDataAdapter ad= new SqlDataAdapter(sql,con);
            DataTable dt=new DataTable();
            ad.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.ReadOnly= true;   
            con.Close();    
           
        }

    }
        
}

