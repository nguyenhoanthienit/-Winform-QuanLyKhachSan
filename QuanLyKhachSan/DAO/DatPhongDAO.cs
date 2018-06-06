using QuanLyKhachSan.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKhachSan.DAO
{
    class DatPhongDAO
    {
        static public SqlCommand _command = null;
        public static int DatPhong(DatPhongDTO d)
        {
            try
            {
                SqlConnection _connection;
                _connection = Connection.ConnectionData();
                string proc = "sp_DatPhong";

                _command = new SqlCommand(proc);
                _command.CommandType = CommandType.StoredProcedure;
                _command.Connection = _connection;

                _command.Parameters.Add("@maDP", SqlDbType.Char, 10);
                _command.Parameters.Add("@maLoaiPhong", SqlDbType.Char, 10);
                _command.Parameters.Add("@maKH", SqlDbType.Char, 10);
                _command.Parameters.Add("@ngbd", SqlDbType.DateTime);
                _command.Parameters.Add("@ngtrp", SqlDbType.DateTime);
                _command.Parameters.Add("@ngdat", SqlDbType.DateTime);
                _command.Parameters.Add("@dongia", SqlDbType.Int);
                _command.Parameters.Add("@mota", SqlDbType.NVarChar, 50);
                _command.Parameters.Add("@ttrang", SqlDbType.NVarChar, 15);

                _command.Parameters["@maDP"].Value = d.MaDB;
                _command.Parameters["@maLoaiPhong"].Value = d.MaLoaiPhong;
                _command.Parameters["@maKH"].Value = d.MaKH;
                _command.Parameters["@ngbd"].Value = d.NgayBD;
                _command.Parameters["@ngtrp"].Value = d.NgayTP;
                _command.Parameters["@ngdat"].Value = d.NgayDat;
                _command.Parameters["@dongia"].Value = d.DonGia;
                _command.Parameters["@mota"].Value = d.MoTa;
                _command.Parameters["@ttrang"].Value = d.TinhTrang;

                int n = _command.ExecuteNonQuery();
                _connection.Close();
                return n;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
                return -1;
            }
        }
    }
}
