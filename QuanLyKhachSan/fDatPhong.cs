using QuanLyKhachSan.DAO;
using QuanLyKhachSan.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKhachSan
{
    public partial class fDatPhong : Form
    {
        string lphong = fBatDau.LoaiPhong.getLoaiPhong;
        string dgia = fBatDau.LoaiPhong.getDonGia;
        KhachHangDTO kh = fDangNhap.UserInformation.CurrentLoggedInUser;
        public fDatPhong()
        {
            InitializeComponent();
            txbTTMaLP.Text = lphong;
            txbTTDonGia.Text = dgia;
            if (kh == null)
            {
                btnTTDatPhong.Hide();
                labelChuY.Show();
            }
            else
            {
                txbTTMaKH.Text = kh.MaKH;
                btnTTDatPhong.Show();
                labelChuY.Hide();
            }
            LoadComboboxData();
        }

        private void btnTTDatPhong_Click(object sender, EventArgs e)
        {

        }

        #region Method
        public void LoadComboboxData()
        {
            SqlConnection cn = Connection.ConnectionData();
            string sql = @"SELECT DISTINCT P.maPhong
                            FROM Phong P, TrangThaiPhong T, LoaiPhong L
                            WHERE P.maPhong = T.maPhong AND L.maLoaiPhong = P.loaiPhong              AND T.tinhTrang = N'Còn trống' 
                            AND L.maLoaiPhong = '" + lphong + @"'";
            SqlCommand cmd = new SqlCommand(sql, cn);
            SqlDataAdapter da = new SqlDataAdapter(sql, cn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            cmd.ExecuteNonQuery();
            cn.Close();

            cbxTTPhongTrong.DataSource = ds.Tables[0];
            cbxTTPhongTrong.DisplayMember = ds.Tables[0].Columns[0].ToString();           
        }
        #endregion 
    }
}
