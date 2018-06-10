using QuanLyKhachSan.DTO;
using QuanLyKhachSan.BUS;

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

        #region methods
        public string RandomMaKH()
        {
            Random r = new Random();
            string maKH = "KH" + r.Next(10, 99999999).ToString();
            return maKH;
        }
        #endregion

        #region events
        private void btnDki_Click(object sender, EventArgs e)
        {
            KhachHangDTO k = new KhachHangDTO();
            k.MaKH = RandomMaKH();
            k.HoTen = txbDKHoTen.Text;
            k.TenDangNhap = txbDKDnhap.Text;
            k.MatKhau = txbDKMkhau.Text;
            k.SoCMND = txbDKCMND.Text;
            k.SoDienThoai = txbDKDT.Text;
            k.DiaChi = txbDKDC.Text;
            k.Email = txbDKEmail.Text;
            k.MoTa = "Đẹp trai";

            if (k.MatKhau != txbDKNLMkhau.Text || txbDKNLMkhau.Text == "")
            {
                MessageBox.Show("Lỗi : Mật khẩu không giống nhau !");
                return;
            }
            
            int n = KhachHangBUS.ThemKhachHang(k);
            if (n > 0)
            {
                MessageBox.Show("Bạn đã đăng kí thành công !");
                this.Close();
            }
            else
            {
                MessageBox.Show("Đăng kí thất bại !");
            }
        }

        #endregion

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (txbDKMkhau.UseSystemPasswordChar == true)
            {
                txbDKMkhau.UseSystemPasswordChar = false;
            }
            else
                txbDKMkhau.UseSystemPasswordChar = true;
            
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (txbDKNLMkhau.UseSystemPasswordChar == true)
            {
                txbDKNLMkhau.UseSystemPasswordChar = false;
            }
            else
                txbDKNLMkhau.UseSystemPasswordChar = true;
        }

    }
}
