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
            // TODO: This line of code loads data into the 'hOSPITALDataSet2.Doctors' table. You can move, or remove it, as needed.
            this.doctorsTableAdapter.Fill(this.hOSPITALDataSet2.Doctors);
            // TODO: This line of code loads data into the 'hOSPITALDataSet1.Departments' table. You can move, or remove it, as needed.
            this.departmentsTableAdapter.Fill(this.hOSPITALDataSet1.Departments);
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
				cmd.Parameters.AddWithValue("@d_id", textBox5.Text);
				cmd.Parameters.AddWithValue("@date", dateTimePicker1.Value);
				cmd.Parameters.AddWithValue("@time", textBox2.Text);
				cmd.Parameters.AddWithValue("@dep", textBox4.Text);

                if (con.State == ConnectionState.Closed)
                {
					con.Open();
					cmd.ExecuteNonQuery();
					MessageBox.Show("İşlem Başarılı");
					con.Close();
				}
				else
                {
					con.Close();
                }

			}
			else
			{
				MessageBox.Show("Lütfen bilgileri doldurunuz.");
			}
		}

		private void button3_Click_1(object sender, EventArgs e)
		{
			RandevularıGetir();

		}

        private void RandevularıGetir()
        {
			string sorgu = "Select AppointmentID,p.PatientTC,Department as [Sikayet],d.DoctorName,p.PatientName+' '+p.PatientLastname as [PatientFullName],AppointmentDate,AppointmentTime, Doctor_ID from Appointments a inner join Doctors d ON a.Doctor_ID = d.DoctorID inner join Patients p ON a.Patient_ID = p.PatientID";
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
					textBox3.Text = ds.Tables[0].Rows[0][0].ToString();			
				}
			}
			else
			{
				MessageBox.Show("hasta bulunamadı");
			}
		}
		int appID;
		int docID;
		int patID;
		private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			string sorgu1 = "select * from Patients where PatientTC = @patTC";

			SqlDataAdapter dap = new SqlDataAdapter(sorgu1, con);
			dap.SelectCommand.Parameters.AddWithValue("@patTC", dataGridView1.SelectedRows[0].Cells[1].Value.ToString());
			DataSet ds = new DataSet();
			dap.Fill(ds);
			patID = Convert.ToInt32(ds.Tables[0].Rows[0][0]);




			string tc =(dataGridView1.SelectedRows[0].Cells[1].Value).ToString();
			appID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
			textBox1.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox3.Text = patID.ToString();
			textBox4.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
			textBox5.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
			//comboBox1.DisplayMember = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
			//comboBox2.DisplayMember = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
			dateTimePicker1.Value = Convert.ToDateTime(dataGridView1.SelectedRows[0].Cells[5].Value);
			textBox2.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
			docID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[7].Value);
		}

		private void button2_Click(object sender, EventArgs e)
        {
            try
            {
				string sorguupdate = "Update Appointments Set Patient_ID = @pID, Doctor_ID = @dID, AppointmentDate = @appDate, AppointmentTime = @appTime, Department = @dep where AppointmentID = @appID";
				SqlCommand cmd = new SqlCommand(sorguupdate, con);
				cmd.Parameters.AddWithValue("@appID",appID);
				cmd.Parameters.AddWithValue("@pID", patID);
				cmd.Parameters.AddWithValue("@dID", docID);
				cmd.Parameters.AddWithValue("@appDate", dateTimePicker1.Value);
				cmd.Parameters.AddWithValue("@appTime", Convert.ToDateTime(textBox2.Text));
				cmd.Parameters.AddWithValue("@dep", textBox4.Text);
				con.Open();
				cmd.ExecuteNonQuery();
				MessageBox.Show("İşlem Başarılı");
				con.Close();
			}
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
			RandevularıGetir();
			Temizle();
		}

        private void Temizle()
        {
            foreach (Control item in groupBox1.Controls)
            {
                if (item is TextBox)
                {
					TextBox txt = (TextBox)item;
					txt.Clear();
                }
            }
        }
    }
}
