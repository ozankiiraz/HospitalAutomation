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

        //------------------------------------------------------------------------------------------------------------------------------------
        private void Prescription_Load(object sender, EventArgs e)
        {
            SqlDataAdapter ilaclar = new SqlDataAdapter("SELECT MedicineID,MedicineName FROM Medicines where [Status]=1", con);
            ilaclar.Fill(PrescriptionTablolar);
            foreach (var item in PrescriptionTablolar)
            {

            }

            dataGridViewIlaclar.DataSource = PrescriptionTablolar2;

            //dataGridViewIlaclar.Columns[0].Visible = false;
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

        private void button2_Click(object sender, EventArgs e)          //ÇIKAR BUTONU          HATALI  HATALI  HATALI  HATALI
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
            //this.Close();
        }

        private void dataGridViewRecete_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            silinecekID=Convert.ToInt32(dataGridViewRecete.Rows[e.RowIndex].Cells[0].Value);
        }

        private void dataGridViewRecete_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            button3.Enabled = true;
        }

        private void dataGridViewRecete_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            if (ilacListe.Count==0)
            {
                button3.Enabled = false;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            PrescriptionTablolar2.Filter = string.Format("MedicineName LIKE '%{0}%'", textBox2.Text);
            dataGridViewIlaclar.Refresh();
        }
    }
}
