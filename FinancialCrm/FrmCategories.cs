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
    public partial class FrmCategories : Form
    {
        public FrmCategories()
        {
            InitializeComponent();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmBanks frm=new FrmBanks();
            frm.Show();
            this.Hide();
        }

        private void btnBillForm_Click(object sender, EventArgs e)
        {
            FrmGiderler frm=new FrmGiderler();
            frm.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            FrmDashboard frm=new FrmDashboard();
            frm.Show();
            this.Hide();
        }

        FinancialCrmDbEntities db = new FinancialCrmDbEntities();
        private void FrmCategories_Load(object sender, EventArgs e)
        {
            var values = db.Categories.ToList();
            dataGridView1.DataSource= values;
        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            string CategoryName = txtCategoryName.Text;

            Categories categories = new Categories();
            categories.CategoryName = CategoryName;
            db.Categories.Add(categories);
            db.SaveChanges();
            MessageBox.Show("Kategori ekleme işlemi başarılı");
            var values = db.Categories.ToList();
            dataGridView1.DataSource = values;
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtCategoryId.Text);
            var removeValue = db.Categories.Find(id);
            db.Categories.Remove(removeValue);
            db.SaveChanges();
            MessageBox.Show("Kategori Silme İşlemi Başarılı");
            var values = db.Categories.ToList();
            dataGridView1.DataSource = values;
        }

        private void btnGüncelle_Click(object sender, EventArgs e)
        {
            string categoryName = txtCategoryName.Text;
            int id= int.Parse(txtCategoryId.Text);
            var values=db.Categories.Find(id);
            values.CategoryName = categoryName;
            db.SaveChanges();
            MessageBox.Show("Kategori Güncelleme işlemi başarılı");
            var values2 = db.Categories.ToList();
            dataGridView1.DataSource = values2;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FrmBilling frm = new FrmBilling();
            frm.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FrmBankaHareketleri frm = new FrmBankaHareketleri();
            frm.Show();
            this.Hide();
        }
    }
}
