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
			// TODO: This line of code loads data into the 'hOSPITALDataSet.Patients' table. You can move, or remove it, as needed.
			this.patientsTableAdapter.Fill(this.hOSPITALDataSet.Patients);

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

		private void button1_Click(object sender, EventArgs e)
		{
			if (textBox1 != null)
			{
				string sorgu2 = "INSERT INTO Appointments(Patient_ID,Doctor_ID,AppointmentDate,AppointmentTime,Department) VALUES (@d_id,@p_id,@date,@time,@dep)";
				SqlCommand cmd = new SqlCommand(sorgu2, con);
				cmd.Parameters.AddWithValue("@p_id", textBox3.Text);
				cmd.Parameters.AddWithValue("@d_id", comboBox2.SelectedValue);
				cmd.Parameters.AddWithValue("@date", dateTimePicker1.Value);
				cmd.Parameters.AddWithValue("@time", textBox2.Text);
				cmd.Parameters.AddWithValue("@dep", comboBox1.SelectedValue);

				con.Open();
				cmd.ExecuteNonQuery();
				MessageBox.Show("İşlem Başarılı");
				con.Close();
			}
			else
			{
				MessageBox.Show("Lütfen bilgileri doldurunuz.");
			}
		}

		private void button3_Click_1(object sender, EventArgs e)
		{
			string sorgu = "Select AppointmentID,p.PatientTC,Department,d.DoctorName+' '+d.DoctorLastname as [DoctorFullName],p.PatientName+' '+p.PatientLastname as [PatientFullName],AppointmentDate,AppointmentTime from Appointments a inner join Doctors d ON a.Doctor_ID = d.DoctorID inner join Patients p ON a.Patient_ID = p.PatientID";
			SqlCommand cmd = new SqlCommand(sorgu, con);
			con.Open();
			bs = new BindingSource();
			SqlDataReader dr = cmd.ExecuteReader();

			bs.DataSource = dr;
			dataGridView1.DataSource = bs;
			con.Close();
		}

		private void button4_Click(object sender, EventArgs e)
		{
			if (textBox1.Text != null)
			{
				string sorgu1 = "select * from Patients where PatientTC = @patTC";
			
				SqlDataAdapter dap = new SqlDataAdapter(sorgu1, con);
				dap.SelectCommand.Parameters.AddWithValue("@patTC", textBox1.Text);
				DataSet ds = new DataSet();
				dap.Fill(ds);

			    if (ds.Tables[0].Rows.Count > 0)
				{
					textBox1.Text = ds.Tables[0].Rows[0][1].ToString();
					label7.Text = textBox1.Text;
			
				}



				//string sorgu3 = "select * from Patients where PatientTC = @patTC";
				//SqlCommand command = new SqlCommand(sorgu3, con);
				//command.Parameters.AddWithValue("@patTC", textBox1.Text);
				//con.Open();
				//SqlDataReader dr = command.ExecuteReader();
				//DataTable dt = new DataTable();
				//dt.Load(dr);
				//dataGridView1.DataSource = dt;
				//con.Close();
			}
			else
			{
				MessageBox.Show("hasta bulunamadı");
			}
		}

		private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			string id =(dataGridView1.SelectedRows[0].Cells[1].Value).ToString();
			
			comboBox3.SelectedItem= dataGridView1.SelectedRows[0].Cells[4].Value;

		}
	}
}
