using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKhachSan
{
    public partial class fBatDau : Form
    {
        public fBatDau()
        {
            InitializeComponent();
        }

        private void btnDki_Click(object sender, EventArgs e)
        {
            this.Hide();
            fDangKi f = new fDangKi();
            f.ShowDialog();
        }

        private void btnDnhap_Click(object sender, EventArgs e)
        {
            this.Hide();
            fDangNhap f = new fDangNhap();
            f.ShowDialog();
        }

        private void btnDxuat_Click(object sender, EventArgs e)
        {
            this.Hide();
            fDangNhap f = new fDangNhap();
            f.ShowDialog();
        }

        private void fBatDau_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thật sự thoát chương trình", "Thông báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
        }

        public string currentUser = fDangNhap.UserInformation.CurrentLoggedInUser;
        private void fBatDau_Load(object sender, EventArgs e)
        {
            if (currentUser != null)
            {
                btnDVDnhap.Hide();
                btnDVDki.Hide();
                btnDVDxuat.Show();
                labelTenKH.Text = currentUser;
                labelTenKH.Show();
            }
            else
            {
                btnDVDnhap.Show();
                btnDVDki.Show();
                btnDVDxuat.Hide();
                labelTenKH.Text = null;
            }
        }


        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.Hide();
            fDatPhong f = new fDatPhong();
            f.Show();
        }

        private void fBatDau_FormClosed(object sender, FormClosedEventArgs e)
        {
            Process.GetCurrentProcess().Kill();
        }

        private void btnDVTimKiem_Click(object sender, EventArgs e)
        {

        }

        public Control labelXinChao { get; set; }
        private void btnDVDxuat_Click(object sender, EventArgs e)
        {
            btnDVDnhap.Show();
            btnDVDki.Show();
            btnDVDxuat.Hide();
            labelTenKH.Text = null;
        }
    }
}
