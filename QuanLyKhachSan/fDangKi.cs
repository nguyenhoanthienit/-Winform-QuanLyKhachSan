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
    public partial class fDangKi : Form
    {
        public fDangKi()
        {
            InitializeComponent();
        }

        private void btnDki_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Đăng kí thành công", "Thông báo");
            this.Close();
        }

        private void fDangKi_FormClosed(object sender, FormClosedEventArgs e)
        {
            fBatDau f = new fBatDau();
            f.Show();
        }
    }
}
