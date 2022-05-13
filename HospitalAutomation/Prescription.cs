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
        int receteIndex;
        int medicineID;
        int silinecekID;
        string medicineName;
        List<Ilac> ilacListe = new List<Ilac>();
        int index;

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

        private void Getir()
        {
            dataGridViewRecete.DataSource = ilacListe;
            //dataGridViewRecete.Columns[0].Visible = false;
            //dataGridViewRecete.Columns[1].Visible = false; 
        }

        //------------------------------------------------------------------------------------------------------------------------------------
        private void Prescription_Load(object sender, EventArgs e)
        {
            SqlDataAdapter ilaclar = new SqlDataAdapter("SELECT MedicineID,MedicineName FROM Medicines where [Status]=1", con);
            ilaclar.Fill(PrescriptionTablolar);
            dataGridViewIlaclar.DataSource = PrescriptionTablolar.Tables[0];
            dataGridViewIlaclar.Columns[0].Visible = false;
            dataGridViewIlaclar.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void dataGridViewIlaclar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            medicineID = Convert.ToInt32(dataGridViewIlaclar.CurrentRow.Cells[0].Value);
            medicineName = dataGridViewIlaclar.CurrentRow.Cells[1].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)          //EKLE BUTONU
        {
            dataGridViewRecete.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewRecete.DataSource = null;
            receteIndex++;
            Ilac i = new Ilac();
            i.ID = receteIndex;
            i.MedicineId = medicineID;
            i.MedicineName = medicineName;
            ilacListe.Add(i);
            Getir();
        }

        private void button2_Click(object sender, EventArgs e)          //ÇIKAR BUTONU          HATALI  HATALI  HATALI  HATALI
        {
            try
            {
                ilacListe.RemoveAt(Sil());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            receteIndex = 0;
            this.Close();
        }

        private void dataGridViewRecete_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            silinecekID=Convert.ToInt32(dataGridViewRecete.Rows[e.RowIndex].Cells[0].Value);
            MessageBox.Show(silinecekID.ToString());
        }
    }
}
