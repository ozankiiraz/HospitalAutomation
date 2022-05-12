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

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Hastane"].ConnectionString);
        DataSet PrescriptionTablolar = new DataSet();
        int medicineID;
        string medicineName;

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
            MessageBox.Show(medicineID.ToString());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //SqlDataAdapter ilaclar2 = new SqlDataAdapter("SELECT MedicineID,MedicineName FROM Medicines where [Status]=1 and MedicineID=@medicineId", con);
            //DataTable dt = new DataTable();
            //ilaclar2.SelectCommand.Parameters.AddWithValue("@medicineId", medicineID);
            //ilaclar2.Fill(dt);
            //dataGridViewRecete.DataSource = dt;
            dataGridViewRecete.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            List<Ilac> ilacListe = new List<Ilac>();
            Ilac i = new Ilac();
            i.ID = 1;
            i.MedicineId = medicineID;
            i.MedicineName = medicineName;
            ilacListe.Add(i);

        }
    }
}
