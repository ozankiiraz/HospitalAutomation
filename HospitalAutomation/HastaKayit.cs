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
            btn_düzenle.Enabled = false;
            btn_sil.Enabled = false;
        }
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Hastane"].ConnectionString);
        int cinsiyet;
        int id;
        private void btn_kaydet_Click(object sender, EventArgs e)
        {
            Cinsiyet();

            if (txt_tc.Text != null && txt_ad.Text != null && txt_soyad.Text != null && (cinsiyet == 1 || cinsiyet == 0) && txt_telno.Text != null)
            {
                string selectsorgu = "INSERT INTO Patients(PatientTC,PatientName,PatientLastname,PatientBirthDate,PatientGender,PatientPhoneNumber,Status) VALUES (@TCKN,@ad,@soyad,@dogumtarihi,@cinsiyet,@telno,@durum)";
                SqlCommand cmd = new SqlCommand(selectsorgu, con);
                cmd.Parameters.AddWithValue("@TCKN", txt_tc.Text);
                cmd.Parameters.AddWithValue("@ad", txt_ad.Text);
                cmd.Parameters.AddWithValue("@soyad", txt_soyad.Text);
                cmd.Parameters.AddWithValue("@dogumtarihi", dtp_dt.Value);
                cmd.Parameters.AddWithValue("@cinsiyet", Convert.ToInt32(cinsiyet));
                cmd.Parameters.AddWithValue("@telno", txt_telno.Text);
                cmd.Parameters.AddWithValue("@durum", chx_durum.Checked);
              
                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("İşlem Başarılı");
                con.Close();
            }
            else
            {
                MessageBox.Show("Lütfen bilgileri doldurunuz.");
            }

            Temizle();

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
                id = Convert.ToInt32(ds.Tables[0].Rows[0][0]);
                MessageBox.Show(Convert.ToString(id));
                btn_düzenle.Enabled = true;
                btn_sil.Enabled = true;
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
                id = Convert.ToInt32(ds.Tables[1].Rows[0][0]);
                btn_düzenle.Enabled = true;
                btn_sil.Enabled = true;
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

        private void Temizle()
        {
            foreach (Control item in groupBox1.Controls)
            {
                if (item is TextBox)
                {
                    TextBox txt = (TextBox)item;
                    txt.Clear();
                }
                if (item is DateTimePicker)
                {
                    DateTimePicker dtp = (DateTimePicker)item;
                    dtp.Value = DateTime.Now;
                }
                if (item is CheckBox)
                {
                    CheckBox cb = (CheckBox)item;
                    cb.Checked = false;

                }
            }
            foreach (Control item in groupBox2.Controls)
            {
                if (item is TextBox)
                {
                    TextBox txt = (TextBox)item;
                    txt.Clear();
                }
            }
        }

        private void HastaKayit_Load(object sender, EventArgs e)
        {

        }

        private void btn_düzenle_Click(object sender, EventArgs e)
        {
            
            string sorgu1 = "Update Patients SET PatientTC = @TCKN,PatientName = @ad,PatientLastname = @soyad,PatientBirthDate = @dogumtarihi,PatientGender = @cinsiyet,PatientPhoneNumber = @telno,[Status] = @status  where PatientID = @patID";
            SqlCommand cmd = new SqlCommand(sorgu1, con);
            Cinsiyet();
            cmd.Parameters.AddWithValue("@TCKN", txt_tc.Text);
            cmd.Parameters.AddWithValue("@ad", txt_ad.Text);
            cmd.Parameters.AddWithValue("@soyad", txt_soyad.Text);
            cmd.Parameters.AddWithValue("@dogumtarihi", dtp_dt.Value);
            cmd.Parameters.AddWithValue("@cinsiyet", Convert.ToInt32(cinsiyet));
            cmd.Parameters.AddWithValue("@telno", txt_telno.Text);
            cmd.Parameters.AddWithValue("@status", chx_durum.Checked);
            cmd.Parameters.AddWithValue("patID", id);
            con.Open();
            cmd.ExecuteNonQuery();
            MessageBox.Show("İşlem Başarılı");
            con.Close();
            Temizle();
            id = 0;
            btn_düzenle.Enabled = false;

        }

        private void Cinsiyet()
        {
            if (checkBox1.Checked == true && checkBox2.Checked == false)
            {
                cinsiyet = 0;
            }
            else if (checkBox1.Checked == false && checkBox2.Checked == true)
            {
                cinsiyet = 1;
            }
            else
            {
                cinsiyet = 2; // belirsiz
            }

        }
        private void btn_temizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            
            //checkBox1.Checked = false;
            //checkBox2.Checked = true;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            //checkBox2.Checked = false;
            //checkBox1.Checked = true;
        }
    }
}