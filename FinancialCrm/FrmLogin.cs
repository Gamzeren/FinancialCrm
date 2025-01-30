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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace FinancialCrm
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        FinancialCrmDbEntities db = new FinancialCrmDbEntities();
        private void button1_Click(object sender, EventArgs e)
        {
            string userName=txtUserName.Text;
            string password = txtPassword.Text;

            var user = db.Users.FirstOrDefault(u => u.UserName.Trim() == userName.Trim());

            if (user == null)
            {
                MessageBox.Show("Kullanıcı bulunamadı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (user.Password.Trim() != password.Trim())
            {
                MessageBox.Show("Şifre yanlış!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Giriş başarılı!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                FrmDashboard frm = new FrmDashboard();
                frm.Show();
                this.Hide();
            }
        }
    }
}
