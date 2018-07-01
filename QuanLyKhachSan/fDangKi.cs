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
            labelKTCMND.Hide();
            labelKTSDT.Hide();
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
            k.MoTa = "";

            if (k.HoTen == "" || k.TenDangNhap == "" || k.MatKhau == "" || txbDKNLMkhau.Text == "" || k.SoCMND == "" || k.SoDienThoai == "" || k.DiaChi == "" || k.Email == "")
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin");
                return;
            }

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

        private void txbDKCMND_TextChanged(object sender, EventArgs e)
        {
            if (txbDKCMND.Text.Length != 9 && txbDKCMND.Text.Length != 12)
            {
                labelKTCMND.Show();
            }
            else
            {
                labelKTCMND.Hide();
            }
        }

        private void txbDKDT_TextChanged(object sender, EventArgs e)
        {
            if (txbDKDT.Text.Length != 10 && txbDKDT.Text.Length != 11)
            {
                labelKTSDT.Show();
            }
            else
            {
                labelKTSDT.Hide();
            }
        }
        #endregion
    }
}
