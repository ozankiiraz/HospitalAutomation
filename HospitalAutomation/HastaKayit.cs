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



        private void btn_hasta_ara_Click(object sender, EventArgs e)
        {
            string sorgu1 = "select * from Patients where PatientTC = @patTC";
            string sorgu2 = "select * from Patients where PatientLastname = @patLast";
            SqlDataAdapter dap = new SqlDataAdapter(sorgu1 + ' ' + sorgu2, con);
            dap.SelectCommand.Parameters.AddWithValue("@patTC",txt_hastatc.Text);
            dap.SelectCommand.Parameters.AddWithValue("@patLast", textBox1.Text);
            DataSet ds = new DataSet();
            dap.Fill(ds);

            if (txt_hastatc.Text.Length != 11 && textBox1.Text.Length == 0) 
            {
                MessageBox.Show("Lütfen 11 haneli TC veya soyisim bilgisi giriniz.");
            }
            else if (ds.Tables[0].Rows.Count > 0 && ds.Tables[1].Rows.Count <= 0)
            {
                txt_tc.Text = ds.Tables[0].Rows[0][1].ToString();
                txt_ad.Text = ds.Tables[0].Rows[0][2].ToString();
                txt_soyad.Text = ds.Tables[0].Rows[0][3].ToString();
                dtp_dt.Value = Convert.ToDateTime(ds.Tables[0].Rows[0][4]);
                int cinsiyet = Convert.ToInt32(ds.Tables[0].Rows[0][5]);
                if (cinsiyet == 0)
                {
                    checkBox1.Checked = true;
                    checkBox2.Checked = false;
                }
                else if (cinsiyet == 1 )
                {
                    checkBox2.Checked = true;
                    checkBox1.Checked = false;

                }
                txt_telno.Text = ds.Tables[0].Rows[0][6].ToString();
                chx_durum.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0][7]);
            }
            else if (ds.Tables[1].Rows.Count > 0 && ds.Tables[0].Rows.Count <= 0)
            {
                txt_tc.Text = ds.Tables[1].Rows[0][1].ToString();
                txt_ad.Text = ds.Tables[1].Rows[0][2].ToString();
                txt_soyad.Text = ds.Tables[1].Rows[0][3].ToString();
                dtp_dt.Value = Convert.ToDateTime(ds.Tables[1].Rows[0][4]);
                int cinsiyet = Convert.ToInt32(ds.Tables[1].Rows[0][5]);
                if (cinsiyet == 0)
                {
                    checkBox1.Checked = true;
                    checkBox2.Checked = false;
                }
                else if (cinsiyet == 1)
                {
                    checkBox2.Checked = true;
                    checkBox1.Checked = false;

                }
                txt_telno.Text = ds.Tables[1].Rows[0][6].ToString();
                chx_durum.Checked = Convert.ToBoolean(ds.Tables[1].Rows[0][7]);
            }
            else if (ds.Tables[0].Rows.Count > 0 && ds.Tables[1].Rows.Count > 0)
            {
                MessageBox.Show("Aynı anda hem TC hem Soyisim üzerinden arama yapma!");
            }
            else if (ds.Tables[0].Rows.Count == 0 && ds.Tables[1].Rows.Count == 0)
            {
                MessageBox.Show("Hastanın Kaydı Bulunmamaktadır!");
            }
        }


    }
}