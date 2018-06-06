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
    class KhachHangDAO
    {
        static public SqlCommand _command = null;
        public static int ThemKhachHang(KhachHangDTO k)
        {
            try
            {
                SqlConnection _connection;
                _connection = Connection.ConnectionData();
                string proc = "sp_ThemKhachHang";

                _command = new SqlCommand(proc);
                _command.CommandType = CommandType.StoredProcedure;
                _command.Connection = _connection;

                _command.Parameters.Add("@MaKH", SqlDbType.Char);
                _command.Parameters.Add("@HoTen", SqlDbType.NVarChar);
                _command.Parameters.Add("@ID", SqlDbType.VarChar);
                _command.Parameters.Add("@MK", SqlDbType.VarChar);
                _command.Parameters.Add("@CMND", SqlDbType.VarChar);
                _command.Parameters.Add("@DC", SqlDbType.NVarChar);
                _command.Parameters.Add("@SDT", SqlDbType.VarChar);
                _command.Parameters.Add("@MT", SqlDbType.NVarChar);
                _command.Parameters.Add("@EM", SqlDbType.VarChar);

                _command.Parameters["@MaKH"].Value = k.MaKH;
                _command.Parameters["@HoTen"].Value = k.HoTen;
                _command.Parameters["@ID"].Value = k.TenDangNhap;
                _command.Parameters["@MK"].Value = k.MatKhau;
                _command.Parameters["@CMND"].Value = k.SoCMND;
                _command.Parameters["@DC"].Value = k.DiaChi;
                _command.Parameters["@SDT"].Value = k.SoDienThoai;
                _command.Parameters["@MT"].Value = k.MoTa;
                _command.Parameters["@EM"].Value = k.Email;

                int n = _command.ExecuteNonQuery();
                _connection.Close();
                return n;
            }
            catch(SqlException ex)
            {
                MessageBox.Show(ex.Message);
                return -1;
            }
        }
    }
}
