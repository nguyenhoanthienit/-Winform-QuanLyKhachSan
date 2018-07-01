
using QuanLyKhachSan.DAO;
using QuanLyKhachSan.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKhachSan
{
    public partial class fBatDau : Form
    {
        SqlConnection _connection = null;
        SqlCommand _command = null;
        KhachHangDTO currentUser = fDangNhap.UserInformation.CurrentLoggedInUser;

        public fBatDau()
        {
            InitializeComponent();
            LoadData();
            txbTenKH.ReadOnly = true;
            txbTenKH.Hide();
        }

        #region events
        private void btnDki_Click(object sender, EventArgs e)
        {
            fDangKi f = new fDangKi();
            f.ShowDialog();
            this.Show();
        }

        private void btnDnhap_Click(object sender, EventArgs e)
        {
            this.Hide();
            fDangNhap f = new fDangNhap();
            f.ShowDialog();
        }

        private void fBatDau_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thật sự thoát chương trình", "Thông báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
        }

        private void fBatDau_Load(object sender, EventArgs e)
        {
            if (currentUser != null)
            {
                btnDVDnhap.Hide();
                btnDVDki.Hide();
                btnDVDxuat.Show();
                txbTenKH.Text += currentUser.HoTen;
                txbTenKH.Show();
            }
            else
            {
                btnDVDnhap.Show();
                btnDVDki.Show();
                btnDVDxuat.Hide();
                txbTenKH.Text = null;
            }
        }


        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string loaiPhong = "";
            string donGia = "";
            if (e.RowIndex == -1 || e.ColumnIndex == -1)
            {
                return;
            }
            else
            {
                loaiPhong = dtgvTimKiemKhachSan.Rows[e.RowIndex].Cells["Mã Loại Phòng"].Value.ToString();
                donGia = dtgvTimKiemKhachSan.Rows[e.RowIndex].Cells["Đơn giá phòng"].Value.ToString();
                LoaiPhong.getLoaiPhong = loaiPhong;
                LoaiPhong.getDonGia = donGia;
                fDatPhong f = new fDatPhong();
                f.ShowDialog();
            }
        }

        private void fBatDau_FormClosed(object sender, FormClosedEventArgs e)
        {
            Process.GetCurrentProcess().Kill();
        }

        
        public Control labelXinChao { get; set; }

        private void btnDVDxuat_Click(object sender, EventArgs e)
        {
            //btnDVDnhap.Show();
            //btnDVDki.Show();
            //btnDVDxuat.Hide();
            //labelTenKH.Text = null;
            this.Hide();
            fDangNhap.UserInformation.CurrentLoggedInUser = null;
            fBatDau f = new fBatDau();
            f.Show();
        }

        private void btnDVTimKiem_Click(object sender, EventArgs e)
        {
            _connection = Connection.ConnectionData();

            string selectedGiaMin = cbxDVGiaMin.SelectedItem.ToString();
            string selectedGiaMax = cbxDVGiaMax.SelectedItem.ToString();
            string selectedSoSao = cbxDVSao.SelectedItem.ToString();
            string selectedTpho = cbxDVTp.SelectedItem.ToString();
            int min = -1, max = -1, sao = -1;

            if (selectedGiaMin != "--Chọn giá")
                min = Convert.ToInt32(selectedGiaMin);
            if (selectedGiaMax != "--Chọn giá")
                max = Convert.ToInt32(selectedGiaMax);
            if (selectedSoSao != "--Chọn hạng sao")
                sao = Convert.ToInt32(selectedSoSao);
            if (selectedTpho == "--Chọn thành phố")
                selectedTpho = "";
            string proc = "";
            //MessageBox.Show(min + "\n" + max + "\n" + sao + "\n" + selectedTpho);
            //return;
            try
            {
                proc = "sp_TimKiemThongTinKhachSan";
                _command = new SqlCommand(proc);
                _command.CommandType = CommandType.StoredProcedure;
                _command.Connection = _connection;
                _command.Parameters.Add("@min", SqlDbType.Int);
                _command.Parameters.Add("@max", SqlDbType.Int);
                _command.Parameters.Add("@sao", SqlDbType.Int);
                _command.Parameters.Add("@tp", SqlDbType.NVarChar);

                _command.Parameters["@min"].Value = min;
                _command.Parameters["@max"].Value = max;
                _command.Parameters["@sao"].Value = sao;
                _command.Parameters["@tp"].Value = selectedTpho;

                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = _command;

                DataTable table = new DataTable();
                adapter.Fill(table);

                BindingSource bSource = new BindingSource();
                bSource.DataSource = table;

                dtgvTimKiemKhachSan.DataSource = bSource;
                adapter.Update(table);

                _connection.Close();
            }
            catch (SqlException sqlE)
            {
                MessageBox.Show(sqlE.Message);
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnDVLoad_Click(object sender, EventArgs e)
        {
            LoadData();
        }
        #endregion

        #region function
        public void LoadData()
        {
            _connection = Connection.ConnectionData();

            string sql =
                @"SELECT L.maLoaiPhong AS 'Mã loại phòng',L.tenLoaiPhong AS 'Tên loại phòng',L.donGia AS 'Đơn giá phòng', L.moTa AS 'Mô tả', L.slTrong AS 'Số lượng trống', K.tenKS AS 'Tên khách sạn', K.giaTB AS 'Giá TB khách sạn', K.soSao AS 'Số sao',K.thanhPho AS 'Thành phố'
	                FROM LoaiPhong L, KhachSan K
	                WHERE L.maKS = K.maKS AND L.slTrong > 0";
            _command = new SqlCommand(sql, _connection);

            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = _command;

            DataTable table = new DataTable();
            adapter.Fill(table);

            BindingSource bSource = new BindingSource();
            bSource.DataSource = table;

            dtgvTimKiemKhachSan.DataSource = bSource;

            adapter.Update(table);
            _connection.Close();

            cbxDVGiaMin.Text = "--Chọn giá";
            cbxDVGiaMax.Text = "--Chọn giá";
            cbxDVSao.Text = "--Chọn sao";
            cbxDVTp.Text = "--Chọn thành phố";

        }

        internal class LoaiPhong
        {
            public static string getLoaiPhong
            {
                get;
                set;
            }
            public static string getDonGia
            {
                get;
                set;
            }
        }

        
        #endregion
    }
}
