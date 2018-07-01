using QuanLyKhachSan.BUS;
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
                label10.Hide();
                labelChuY.Show();
            }
            else
            {
                txbTTMaKH.Text = kh.MaKH;
                btnTTDatPhong.Show();
                label10.Show();
                labelChuY.Hide();
            }
            LoadComboboxData();
        }

       

        #region events
        private void btnTTDatPhong_Click(object sender, EventArgs e)
        {
            DatPhongDTO d = new DatPhongDTO();
            d.MaDP = RandomMaDP();
            d.MaLoaiPhong = lphong;
            d.MaKH = kh.MaKH;
            d.NgayBD = dtpkDKngBD.Value;
            d.NgayTP = dtpkDKngTP.Value;
            d.NgayDat = DateTime.Now;
            d.DonGia = Convert.ToInt32(dgia);
            d.MoTa = "";
            if (cbxDKTt.SelectedItem.ToString() == "--Chọn tình trạng")
            {
                MessageBox.Show("Vui lòng chọn tình trạng");
                return;
            }
            d.TinhTrang = cbxDKTt.SelectedItem.ToString();
            string phongTrong = "";
            phongTrong = cbxTTPhongTrong.SelectedValue.ToString();

            int n = DatPhongBUS.DatPhong(d, phongTrong);
            if (n > 0)
            {
                MessageBox.Show("Bạn đã đặt phòng thành công !");
                this.Close();
            }
            else
            {
                MessageBox.Show("đặt phòng thất bại !");
            }
        }
        #endregion
        #region Method
        public void LoadComboboxData()
        {
            SqlConnection cn = Connection.ConnectionData();
            string sql = @"SELECT DISTINCT P.soPhong, P.maPhong
                            FROM Phong P, TrangThaiPhong T, LoaiPhong L
                            WHERE P.maPhong = T.maPhong AND L.maLoaiPhong = P.loaiPhong              AND T.tinhTrang = N'Còn trống' 
                            AND L.maLoaiPhong = '" + lphong + @"'";
            SqlCommand cmd = new SqlCommand(sql, cn);
            SqlDataAdapter da = new SqlDataAdapter(sql, cn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            //cmd.ExecuteNonQuery();
            cn.Close();

            cbxTTPhongTrong.DataSource = ds.Tables[0];
            cbxTTPhongTrong.DisplayMember = "soPhong";
            cbxTTPhongTrong.ValueMember = "maPhong";
        }
        public string RandomMaDP()
        {
            Random r = new Random();
            string maDP = "DP" + r.Next(10, 99999999).ToString();
            return maDP;
        }
        #endregion 

        private void fDatPhong_Load(object sender, EventArgs e)
        {

        }

    }
}
