using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachSan.DTO
{
    class DatPhongDTO
    {
        private string _maDB;

        public string MaDB
        {
            get { return _maDB; }
            set { _maDB = value; }
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
        private string moTa;

        public string MoTa
        {
            get { return moTa; }
            set { moTa = value; }
        }
        private string tinhTrang;

        public string TinhTrang
        {
            get { return tinhTrang; }
            set { tinhTrang = value; }
        }
    }
}
