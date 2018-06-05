using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachSan.DTO
{
    class KhachHangDTO
    {
        private string _maKH;

        public string MaKH
        {
            get { return _maKH; }
            set { _maKH = value; }
        }
        private string _hoTen;

        public string HoTen
        {
            get { return _hoTen; }
            set { _hoTen = value; }
        }
        private string _tenDangNhap;

        public string TenDangNhap
        {
            get { return _tenDangNhap; }
            set { _tenDangNhap = value; }
        }
        private string _matKhau;

        public string MatKhau
        {
            get { return _matKhau; }
            set { _matKhau = value; }
        }
        private string _soCMND;

        public string SoCMND
        {
            get { return _soCMND; }
            set { _soCMND = value; }
        }
        private string _diaChi;

        public string DiaChi
        {
            get { return _diaChi; }
            set { _diaChi = value; }
        }
        private string _soDienThoai;

        public string SoDienThoai
        {
            get { return _soDienThoai; }
            set { _soDienThoai = value; }
        }
        private string _moTa;

        public string MoTa
        {
            get { return _moTa; }
            set { _moTa = value; }
        }
        private string _email;

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        public KhachHangDTO(string maKH, string hoTen, string tenDN, string Mk, string CMND, string dc, string dt, string mota, string email)
        {
            _maKH = maKH;
            _hoTen = hoTen;
            _tenDangNhap = tenDN;
            _matKhau = Mk;
            _soCMND = CMND;
            _diaChi = dc;
            _soDienThoai = dt;
            _moTa = mota;
            _email = email;
        }

        public KhachHangDTO()
        {
            _maKH = "";
            _hoTen = "";
            _tenDangNhap = "";
            _matKhau = "";
            _soCMND = "";
            _diaChi = "";
            _soDienThoai = "";
            _moTa = "";
            _email = "";
        }
    }
}
