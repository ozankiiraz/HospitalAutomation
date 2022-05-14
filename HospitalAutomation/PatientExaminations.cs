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
    public partial class PatientExaminations : Form
    {
        public PatientExaminations()
        {
            InitializeComponent();
        }

        private void PatientExaminations_Load(object sender, EventArgs e)
        {
            button1.Enabled = false;
        }
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Hastane"].ConnectionString);

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                //string sorgu1 = "select ap.AppointmentDate, ap.Department, pe.ProcessName from Patients as pa JOIN Appointments as ap ON pa.PatientID = ap.Patient_ID JOIN ExaminationDetails as ed ON ed.Appointment_ID = ap.AppointmentID JOIN PatientExaminations as pe ON pe.ProcessID = ed.Process_ID where pa.PatientTC = '@TCKN'";
                string sorgu1 = "select * from vw_PatientExaminations where PatientTC = @TCKN";
                SqlDataAdapter dap = new SqlDataAdapter(sorgu1, con);
                dap.SelectCommand.Parameters.AddWithValue("@TCKN", textBox1.Text);
                DataSet ds = new DataSet();
                dap.Fill(ds);

                if (textBox1.Text.Length == 11)
                {
                    if (ds.Tables[0].Rows.Count == 0)
                    {
                        MessageBox.Show("Hasta geçmişi bulunamadı.");
                    }
                    else
                    {

                        dataGridView1.DataSource = ds.Tables[0];
                        dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    }

                }
                else
                {
                    MessageBox.Show("TCKN 11 hane olmalıdır");
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 11)
            {
                button1.Enabled = true;
            }
            else
            {
                button1.Enabled = false;
            }
        }
    }
}       
