using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachSan.DTO
{
    public class KhachHang
    {
        public KhachHang(string maKH, string hoTen, string tenDangNhap, string matKhau, string soCMND, string soDienThoai, string moTa, string email)
        {
            this.MaKH = maKH;
            this.HoTen = HoTen;
            this.TenDangNhap = tenDangNhap;
            this.MatKhau = matKhau;
            this.SoCMND = soCMND;
            this.SoDienThoai = soDienThoai;
            this.MoTa = MoTa;
            this.email = email;
        }

        public KhachHang(DataRow row)
        {
            this.MaKH = row["maKH"].ToString();
            this.HoTen = row["HoTen"].ToString();
            this.TenDangNhap = row["tenDangNhap"].ToString();
            this.MatKhau = row["matKhau"].ToString();
            this.SoCMND = row["soCMND"].ToString();
            this.SoDienThoai = row["soDienThoai"].ToString();
            this.MoTa = row["MoTa"].ToString();
            this.Email = row["email"].ToString();
        }

        private string maKH;
        private string hoTen;
        private string tenDangNhap;
        private string matKhau;
        private string soCMND;
        private string soDienThoai;
        private string moTa;
        private string email;

        public string MaKH { get => maKH; set => maKH = value; }
        public string HoTen { get => hoTen; set => hoTen = value; }
        public string TenDangNhap { get => tenDangNhap; set => tenDangNhap = value; }
        public string MatKhau { get => matKhau; set => matKhau = value; }
        public string SoCMND { get => soCMND; set => soCMND = value; }
        public string SoDienThoai { get => soDienThoai; set => soDienThoai = value; }
        public string MoTa { get => moTa; set => moTa = value; }
        public string Email { get => email; set => email = value; }
    }
}
