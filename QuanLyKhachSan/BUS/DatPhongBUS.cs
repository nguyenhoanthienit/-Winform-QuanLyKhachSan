using QuanLyKhachSan.DAO;
using QuanLyKhachSan.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachSan.BUS
{
    class DatPhongBUS
    {
        public static int DatPhong(DatPhongDTO d, string maPhong)
        {
            int n = DatPhongDAO.DatPhong(d, maPhong);
            return n;
        }
    }
}
