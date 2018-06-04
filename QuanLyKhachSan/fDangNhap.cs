using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKhachSan
{
    public partial class fDangNhap : Form
    {
        public fDangNhap()
        {
            InitializeComponent();
            
        }

        private void btnDki_Click(object sender, EventArgs e)
        {
            this.Hide();
            fDangKi f = new fDangKi();
            f.Show();
        }

        private void btnDNDnhap_Click(object sender, EventArgs e)
        {
            if(txbDNTenDN.Text == "nv" && txbDNMk.Text == "nv")
            {
                this.Hide();
                fNhanVien f = new fNhanVien();
                f.Show();
            }
            else if (txbDNTenDN.Text == "kh" && txbDNMk.Text == "kh")
            {
                string username = txbDNTenDN.Text.ToString();
                UserInformation.CurrentLoggedInUser = username;
                this.Hide();
                fBatDau f = new fBatDau();
                f.Show();
            }
            else
            {
                MessageBox.Show("Tên hoặc password sai");
            }
        }
        internal class UserInformation
        {
            public static string CurrentLoggedInUser
            {
                get;
                set;
            }
        }

        private void fDangNhap_FormClosed(object sender, FormClosedEventArgs e)
        {
            fBatDau f = new fBatDau();
            f.Show();
        }
    }
}
