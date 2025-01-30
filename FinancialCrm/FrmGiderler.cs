using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FinancialCrm.Models;

namespace FinancialCrm
{
    public partial class FrmGiderler : Form
    {
        public FrmGiderler()
        {
            InitializeComponent();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmCategories frm = new FrmCategories();
            frm.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmBanks frm = new FrmBanks();
            frm.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FrmBilling frm = new FrmBilling();
            frm.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            FrmDashboard frm = new FrmDashboard();
            frm.Show();
            this.Hide();
        }

        FinancialCrmDbEntities db = new FinancialCrmDbEntities();
        private void FrmGiderler_Load(object sender, EventArgs e)
        {
            var values = db.Spendings.ToList();
            dataGridView1.DataSource= values;
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            string title = txtBaslik.Text;
            int category = int.Parse( txtKategori.Text);
            decimal amount = decimal.Parse( txtMiktar.Text);
            DateTime date = DateTime.Parse(mskDate.Text);
            Spendings spendings = new Spendings();
            spendings.SpendingTitle= title;
            spendings.SpendingAmount= amount;
            spendings.CategoryId = category;
            spendings.SpendingDate = date;
            db.Spendings.Add(spendings);
            db.SaveChanges();
            MessageBox.Show("Yeni bir harcama eklendi");

            var values = db.Spendings.ToList();
            dataGridView1.DataSource = values;
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            var values = db.Spendings.ToList();
            dataGridView1.DataSource = values;
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtHarcamaId.Text);
            var removeValue = db.Spendings.Find(id);
            db.Spendings.Remove(removeValue);
            db.SaveChanges();
            MessageBox.Show("Harcama Listeden başarıyla kaldırıldı.");
            var values = db.Spendings.ToList();
            dataGridView1.DataSource = values;
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            string title = txtBaslik.Text;
            int category = int.Parse(txtKategori.Text);
            decimal amount = decimal.Parse(txtMiktar.Text);
            DateTime date = DateTime.Parse(mskDate.Text);
            int id = int.Parse(txtHarcamaId.Text);
            var values = db.Spendings.Find(id);

            values.SpendingTitle = title;
            values.SpendingAmount = amount;
            values.CategoryId = category;
            values.SpendingDate = date;
            db.SaveChanges();
            MessageBox.Show("İstenilen harcama bilgileri başarıyla güncellendi");
            var values2 = db.Spendings.ToList();
            dataGridView1.DataSource = values2;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FrmBankaHareketleri frm=new FrmBankaHareketleri();
            frm.Show();
            this.Hide();
        }
    }
}
