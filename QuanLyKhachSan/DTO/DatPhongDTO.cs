using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachSan.DTO
{
    class DatPhongDTO
    {
        private string _maDP;

        public string MaDP
        {
            get { return _maDP; }
            set { _maDP = value; }
        }

        private string _maLoaiPhong;

        public string MaLoaiPhong
        {
            get { return _maLoaiPhong; }
            set { _maLoaiPhong = value; }
        }

        private string _maKH;

        public string MaKH
        {
            get { return _maKH; }
            set { _maKH = value; }
        }
        private DateTime _ngayBD;

        public DateTime NgayBD
        {
            get { return _ngayBD; }
            set { _ngayBD = value; }
        }
        private DateTime _ngayTP;

        public DateTime NgayTP
        {
            get { return _ngayTP; }
            set { _ngayTP = value; }
        }
        private DateTime _ngayDat;

        public DateTime NgayDat
        {
            get { return _ngayDat; }
            set { _ngayDat = value; }
        }
        private int _donGia;

        public int DonGia
        {
            get { return _donGia; }
            set { _donGia = value; }
        }
        private string _moTa;

        public string MoTa
        {
            get { return _moTa; }
            set { _moTa = value; }
        }
        private string _tinhTrang;

        public string TinhTrang
        {
            get { return _tinhTrang; }
            set { _tinhTrang = value; }
        }

        public DatPhongDTO(string maDP, string maLP, string maKH, DateTime ngbd, DateTime ngtp, DateTime ngdat, int dgia, string mt, string tt)
        {
            _maDP = maDP;
            _maLoaiPhong = maLP;
            _maKH = maKH;
            _ngayBD = ngbd;
            _ngayTP = ngtp;
            _ngayDat = ngdat;
            _donGia = dgia;
            _moTa = mt;
            _tinhTrang = tt;
        }

        public DatPhongDTO()
        {
            _maDP = "";
            _maLoaiPhong = "";
            _maKH = "";
            _ngayBD = DateTime.Now;
            _ngayTP = DateTime.Now;
            _ngayDat = DateTime.Now;
            _donGia = 0;
            _moTa = "";
            _tinhTrang = "";
        }
    }
}
