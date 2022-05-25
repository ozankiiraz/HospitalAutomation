using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HospitalAutomation
{
    public partial class DoctorScreen : Form
    {
        public DoctorScreen()
        {
            InitializeComponent();
        }

        private void FormGetir(Form frm)
        {
            panel2.Controls.Clear();
            frm.MdiParent = this; // bu sayfada aç diyorum
            frm.FormBorderStyle = FormBorderStyle.None; // oynatama diye sabitledik
            panel2.Controls.Add(frm);
            frm.Show();

        }
        private void button2_Click(object sender, EventArgs e)
        {
            //Hasta Geçmişi
            PatientExaminations pe = new PatientExaminations();
            FormGetir(pe);
        }

        private void button3_Click(object sender, EventArgs e)
        { // Reçete 
            Prescription pres = new Prescription();

            FormGetir(pres);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Randevu
            Randevu ran = new Randevu();
            FormGetir(ran);

        }
    }
}
