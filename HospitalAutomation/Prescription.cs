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
    public partial class Prescription : Form
    {
        public Prescription()
        {
            InitializeComponent();
        }
        //DEĞİŞKENLER   DEĞİŞKENLER     DEĞİŞKENLER     DEĞİŞKENLER     DEĞİŞKENLER     DEĞİŞKENLER     DEĞİŞKENLER     DEĞİŞKENLER

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Hastane"].ConnectionString);
        DataSet PrescriptionTablolar = new DataSet();
        BindingSource PrescriptionTablolar2 = new BindingSource();
        int receteIndex;
        int medicineID;
        int silinecekID;
        string medicineName;
        //List<Ilac> ilacListe = new List<Ilac>();
        BindingList<Ilac> ilacListe = new BindingList<Ilac>();
        int index;
        string receteson;

        //METOTLAR  METOTLAR    METOTLAR    METOTLAR    METOTLAR    METOTLAR    METOTLAR    METOTLAR    METOTLAR    METOTLAR    METOTLAR    
        private int Sil()
        {
            foreach (var item in ilacListe)
            {
                if (item.ID == silinecekID)
                {
                    index = ilacListe.IndexOf(item);
                }
            }
            return index;
        }

        private void Getir()                            //REÇETEYİ LİSTELER.
        {
            dataGridViewRecete.DataSource = ilacListe;
            dataGridViewRecete.Columns[0].Visible = false;
            dataGridViewRecete.Columns[1].Visible = false;
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        private void Prescription_Load(object sender, EventArgs e)
        {
            SqlDataAdapter ilaclar = new SqlDataAdapter("SELECT MedicineID,MedicineName FROM Medicines where [Status]=1", con);
            ilaclar.Fill(PrescriptionTablolar);
            dataGridViewIlaclar.DataSource = PrescriptionTablolar.Tables[0];
            dataGridViewIlaclar.Columns[0].Visible = false;
            dataGridViewIlaclar.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewIlaclar.MultiSelect = false;
            dataGridViewRecete.MultiSelect = false;
            button3.Enabled = false;
            dataGridViewIlaclar.Refresh();
        }

        private void dataGridViewIlaclar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            medicineID = Convert.ToInt32(dataGridViewIlaclar.CurrentRow.Cells[0].Value);
            medicineName = dataGridViewIlaclar.CurrentRow.Cells[1].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)          //EKLE BUTONU
        {
            dataGridViewRecete.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            receteIndex++;
            Ilac i = new Ilac();
            i.ID = receteIndex;
            i.MedicineId = medicineID;
            i.MedicineName = medicineName;
            ilacListe.Add(i);
            Getir();
        }

        private void button2_Click(object sender, EventArgs e)          //ÇIKAR BUTONU
        {
            try
            {
                ilacListe.RemoveAt(Sil());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lütfen bir ilaç seçiniz!!");
            }
            Getir();
        }

        private void button3_Click(object sender, EventArgs e)          //REÇETE ONAYLA BUTONU. BURADA DATABASE'E VERİ EKLENİR.
        {
            
            receteIndex = 0;
            foreach (var ilac in ilacListe)
            {
                receteson += ilac.MedicineName + "\n";
            }
            MessageBox.Show(receteson);

            try
            {
                //PRESCRIPTION TABLOSUNA EKLEME
                int id = HastaID();
                DateTime date = DateTime.Now;   //date
                date.ToShortDateString();
                con.Open();
                SqlCommand prescriptionEkle = new SqlCommand("INSERT INTO Prescriptions (Patient_ID,PrescriptionDate) VALUES (@patientID,@date)", con);
                prescriptionEkle.Parameters.AddWithValue("@patientID", id);
                prescriptionEkle.Parameters.AddWithValue("@date", date);
                prescriptionEkle.ExecuteNonQuery();

                MessageBox.Show("Prescription tablosuna veri başarıyla eklendi.");

                //PRESCRIPTION TABLOSUNDAN PrescriptionID ÇEKME
                SqlDataAdapter dap = new SqlDataAdapter("SELECT IDENT_CURRENT('dbo.Prescriptions')", con);
                DataTable dt = new DataTable();
                dap.Fill(dt);
                int prescriptionID = Convert.ToInt32(dt.Rows[0][0]);
                con.Close();
                //PrescriptionDetails TABLOSUNA VERİLERİ EKLEME
                foreach (var item in ilacListe)
                {
                    try
                    {
                        con.Open();
                        SqlCommand prescriptionDetailsEkle = new SqlCommand("INSERT INTO PrescriptionDetails(Prescription_ID,Medicine_ID) VALUES (@prescID,@medID)", con);
                        prescriptionDetailsEkle.Parameters.AddWithValue("@prescID", prescriptionID);
                        prescriptionDetailsEkle.Parameters.AddWithValue("@medID", item.MedicineId);
                        prescriptionDetailsEkle.ExecuteNonQuery();
                        con.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message + "line141");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "line129");
            }
            MessageBox.Show("Reçete başarıyla oluşturuldu.");
            System.Threading.Thread.Sleep(2000);
            this.Close();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            
        }

        private int HastaID()
        {
            int pID=0;
            string tc = textBox1.Text;
            SqlCommand cmd = new SqlCommand("SELECT [PatientID],[PatientTC] FROM [Patients] where [PatientTC]=@tc", con);
            cmd.Parameters.AddWithValue("@tc", tc);
            try
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                PrescriptionTablolar.Tables.Add().Load(dr);
                pID =Convert.ToInt32( PrescriptionTablolar.Tables[1].Rows[0][0]);
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "line153");
            }
            return pID;
        }

        private void dataGridViewRecete_CellClick(object sender, DataGridViewCellEventArgs e)       //REÇETEYE TIKLADIĞIMIZ SATIRIN ID DEĞERİNİ VERİR.
        {
            silinecekID=Convert.ToInt32(dataGridViewRecete.Rows[e.RowIndex].Cells[0].Value);
        }


        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        //KONTROLLER
        private void textBox2_TextChanged(object sender, EventArgs e)           //İLAÇLAR TABLOSUNDA ARAMA YAPMAK.
        {
            PrescriptionTablolar2.DataSource = dataGridViewIlaclar.DataSource;
            PrescriptionTablolar2.Filter = string.Format("MedicineName LIKE '%{0}%'", textBox2.Text);
        }

        private void dataGridViewRecete_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)          //REÇETEYE İLAÇ EKLENDİĞİNDE REÇETE ONAYLA BUTONUNU AKTİF EDER
        {
            button3.Enabled = true;
        }

        private void dataGridViewRecete_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)      //REÇETEDEN İLAÇ ÇIKARILDIĞINDA TABLONUN ELEMAN SAYISINA GÖRE REÇETE ONAYLA BUTONUNU INAKTİF EDER
        {
            if (ilacListe.Count == 0)
            {
                button3.Enabled = false;
            }
        }


    }
}
