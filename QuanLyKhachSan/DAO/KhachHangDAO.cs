using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachSan.DAO
{
    public class KhachHangDAO
    {
        private static KhachHangDAO instance;

        public static KhachHangDAO Instance { get => instance; set => instance = value; }

        private KhachHangDAO()
        {

        }

        public bool DangNhap(string tenDN, string MK)
        {
            string query = "sp_DangNhap @id, @mk "; // store produce
            DataTable result = DataProvider.Instance.ExecuteQuery(query, new object[] {tenDN, MK });
            return result.Rows.Count > 0;
        }
        
    }
}
