using QuanLyKhachSan.DTO;
using QuanLyKhachSan.DAO;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachSan.BUS
{
    class KhachHangBUS
    {
        public static int ThemKhachHang(KhachHangDTO k)
        {
            int n = KhachHangDAO.ThemKhachHang(k);
            return n;
        }
    }
}
