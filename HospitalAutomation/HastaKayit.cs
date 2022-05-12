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
    public partial class HastaKayit : Form
    {
        public HastaKayit()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Hastane"].ConnectionString);
        private void HastaKayit_Load(object sender, EventArgs e)
        {
           

        }

        private void btn_kaydet_Click(object sender, EventArgs e)
        {
            string selectsorgu = "INSERT Patients(PatientTC,PatientName,PatientLastname,PatientBirthDate,PatientGender,PatientPhoneNumber,Status) VALUES (@TCKN,@ad,@soyad,@dogumtarihi,@cinsiyet,@telno,@durum)";
            //SqlCommand cmd = new SqlCommand(selectsorgu, con);
            //cmd.Parameters.AddWithValue("@TCKN", txt_tc.Text);
            //cmd.Parameters.AddWithValue("@ad", txt_ad.Text);
            //cmd.Parameters.AddWithValue("@soyad", txt_soyad);
            //cmd.Parameters.AddWithValue("@dogumtarihi", dtp_dt.Value);
            //cmd.Parameters.AddWithValue("@cinsiyet", cbx_cinsiyet.Text);
            //cmd.Parameters.AddWithValue("@telno", txt_telno);
            //cmd.Parameters.AddWithValue("@status", chx_durum.Checked);


        }


    }
}