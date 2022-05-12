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
	public partial class Randevu : Form
	{
		public Randevu()
		{
			InitializeComponent();
		}
		SqlConnection con = new SqlConnection("Server =.; Database=HOSPITAL;UID=sa;PWD=987654321;MultipleActiveResultSets=True");
		BindingSource bs;
		private void Randevu_Load(object sender, EventArgs e)
		{

		}

		private void button3_Click(object sender, EventArgs e)
		{
			SqlCommand cmd = new SqlCommand("Select Department,Doctor_ID,Patient_ID AppointmentDate,AppointmentTime from Appointments", con);
			con.Open();
			bs = new BindingSource();
			SqlDataReader dr = cmd.ExecuteReader();

			bs.DataSource = dr;
			dataGridView1.DataSource = bs;
			con.Close();
		}
	}
}
