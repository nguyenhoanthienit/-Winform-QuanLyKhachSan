using QuanLyKhachSan.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachSan.DAO
{
    public class TimKiemKhachSanDAO
    {
        private static TimKiemKhachSanDAO instance;

        public static TimKiemKhachSanDAO Instance {
            get { if (instance == null) instance = new TimKiemKhachSanDAO(); return TimKiemKhachSanDAO.instance; }
            private set { TimKiemKhachSanDAO.instance = value; }
        }

        private TimKiemKhachSanDAO()
        {

        }

        public List<TimKiemKhachSan> GetTimKiemKhachSanByAll()
        {
            List<TimKiemKhachSan> listTimKiemKhachSan = new List<TimKiemKhachSan>();
            //string query = "SELECT * FROM dbo.KhachSan";
            DataTable data = DataProvider.Instance.ExecuteQuery("select *from dbo.KhachSan ks where ks.soSao> 4");
            foreach (DataRow item in data.Rows)
            {
                TimKiemKhachSan table = new TimKiemKhachSan(item);
                listTimKiemKhachSan.Add(table);
            }
            return listTimKiemKhachSan;
        }
        public List<TimKiemKhachSan> GetTimKiemKhachSanBy_GiaCa(int giaCa)
        {
            List<TimKiemKhachSan> listTimKiemKhachSanTheo_GiaCa = new List<TimKiemKhachSan>();
            string query = "SELECT * FROM dbo.KhachSan where giaTB = " + giaCa;
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                TimKiemKhachSan table = new TimKiemKhachSan(item);
                listTimKiemKhachSanTheo_GiaCa.Add(table);
            }
            return listTimKiemKhachSanTheo_GiaCa;
        }

        public List<TimKiemKhachSan> GetTimKiemKhachSanBy_TenThanhPho(string tenThanhPho)
        {
            List<TimKiemKhachSan> listTimKiemKhachSanTheo_TenThanhPho = new List<TimKiemKhachSan>();
            string query = "SELECT * FROM dbo.KhachSan = thanhPho = " + tenThanhPho;
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                TimKiemKhachSan table = new TimKiemKhachSan(item);
                listTimKiemKhachSanTheo_TenThanhPho.Add(table);
            }
            return listTimKiemKhachSanTheo_TenThanhPho;
        }
        public List<TimKiemKhachSan> GetTimKiemKhachSanBy_soSao(int soSao)
        {

            List<TimKiemKhachSan> listTimKiemKhachSanTheo_soSao = new List<TimKiemKhachSan>();
            string query = "SELECT * FROM dbo.KhachSan = soSao = " + soSao;
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                TimKiemKhachSan table = new TimKiemKhachSan(item);
                listTimKiemKhachSanTheo_soSao.Add(table);
            }
            return listTimKiemKhachSanTheo_soSao;
        }
    }
}
