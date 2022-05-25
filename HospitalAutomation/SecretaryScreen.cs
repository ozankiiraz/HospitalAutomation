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
    public partial class SecretaryScreen : Form
    {
        public SecretaryScreen()
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
        private void button1_Click(object sender, EventArgs e)
        {
            HastaKayit hk = new HastaKayit();
            FormGetir(hk);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Randevu ran = new Randevu();
            FormGetir(ran);

        }
    }
}
