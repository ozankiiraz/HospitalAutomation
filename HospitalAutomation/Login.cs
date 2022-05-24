using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HospitalAutomation
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            

        }
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Hastane"].ConnectionString);
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if(textBox1.Text != "" && textBox2.Text != "")
            {
                            
                SqlDataAdapter dap = new SqlDataAdapter("Select * from Users where KullaniciAdi = @Ka AND Password = @psw", con);
                dap.SelectCommand.Parameters.AddWithValue("@Ka", textBox1.Text);
                dap.SelectCommand.Parameters.AddWithValue("@psw", textBox2.Text);
                DataTable dt = new DataTable();    
                dap.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("Hoşgeldiniz");
                    this.Hide();
                    DoctorScreen ds = new DoctorScreen();
                    ds.Show();
                }
                else
                {
                    MessageBox.Show("Kullanıcı adı veya şifre hatalı.");
                }
                

            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {


        }
    }
}
