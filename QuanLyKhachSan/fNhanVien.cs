using QuanLyKhachSan.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKhachSan
{
    public partial class fNhanVien : Form
    {
        SqlConnection _connection = null;
        SqlCommand _command = null;
        public fNhanVien()
        {
            InitializeComponent();
            panel2.Hide();
            txbNVNgLap.Text = "dd/mm/yyyy";
            labelIn.Hide();
            //LoadBaoCao();
            //LoadThongKe();
            btnNVTke.Hide();
        }

        #region event
        private void btnNVTroVe_Click(object sender, EventArgs e)
        {
            this.Hide();
            fBatDau f = new fBatDau();
            f.Show();
        }

        private void fNhanVien_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thật sự thoát chương trình", "Thông báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
        }

        public int tongTien = 0;
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                dtgvLapHDKH.Hide();
                tongTien = 0;
                _connection = Connection.ConnectionData();
                string proc = "sp_XuatThongTinHoaDon";
                _command = new SqlCommand(proc);
                _command.CommandType = CommandType.StoredProcedure;
                _command.Connection = _connection;
                _command.Parameters.Add("@maDP", SqlDbType.Char, 10);
                _command.Parameters.Add("@tongTien", SqlDbType.Int).Direction = ParameterDirection.Output;

                _command.Parameters["@maDP"].Value = txbNVMaDP.Text;
                int n = _command.ExecuteNonQuery();
                tongTien = (int)_command.Parameters["@tongTien"].Value;
                txbNVMaDPXuat.Text = txbNVMaDP.Text;
                txbNVTtienXuat.Text = tongTien.ToString();
                panel2.Show();
                _connection.Close();
            }
            catch (SqlException err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void fNhanVien_FormClosed(object sender, FormClosedEventArgs e)
        {
            Process.GetCurrentProcess().Kill();
        }

        private void btnNVLuuHD_Click(object sender, EventArgs e)
        {
            try
            {
                string maHD = RandomMaHD();

                _connection = Connection.ConnectionData();
                string proc = "sp_LapHoaDon";
                _command = new SqlCommand(proc);
                _command.CommandType = CommandType.StoredProcedure;
                _command.Connection = _connection;
                _command.Parameters.Add("@maHD", SqlDbType.Char, 20);                
                _command.Parameters.Add("@maDP", SqlDbType.Char, 10);
                _command.Parameters.Add("@tongTien", SqlDbType.Int);
                _command.Parameters.Add("@ngLap", SqlDbType.DateTime);

                _command.Parameters["@maHD"].Value = maHD;
                _command.Parameters["@maDP"].Value = txbNVMaDP.Text;
                _command.Parameters["@tongTien"].Value = tongTien;
                _command.Parameters["@ngLap"].Value = dtpkTTNgttXuat.Value;

                int n = _command.ExecuteNonQuery();
                if (n > 0)
                {
                    MessageBox.Show("Ghi hóa đơn thành công", "Thông báo");
                }

                _connection.Close();
            }
            catch (SqlException err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void btnNVBcao_Click(object sender, EventArgs e)
        {
            _connection = Connection.ConnectionData();

            string selectedThang = cbxNVChonThang.SelectedItem.ToString();
            string selectedNam = cbxNVChonNam.SelectedItem.ToString();

            int thang = -1, nam = -1;

            if (selectedThang != "--Chọn tháng")
                thang = Convert.ToInt32(selectedThang);
            if (selectedNam != "--Chọn năm")
                nam = Convert.ToInt32(selectedNam);
            string proc = "";

            try
            {
                proc = "sp_BaoCaoDoanhThu";
                _command = new SqlCommand(proc);
                _command.CommandType = CommandType.StoredProcedure;
                _command.Connection = _connection;
                _command.Parameters.Add("@thang", SqlDbType.Int);
                _command.Parameters.Add("@nam", SqlDbType.Int);

                _command.Parameters["@thang"].Value = thang;
                _command.Parameters["@nam"].Value = nam;

                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = _command;

                DataTable table = new DataTable();
                adapter.Fill(table);

                BindingSource bSource = new BindingSource();
                bSource.DataSource = table;

                dtgvNVBcao.DataSource = bSource;
                adapter.Update(table);
                label12.Text = "Báo cáo doanh thu";
                _connection.Close();
            }
            catch (SqlException sqlEr)
            {
                MessageBox.Show(sqlEr.Message);
            }
        }

        private void btnNVTimKiem_Click(object sender, EventArgs e)
        {
            DateTime ngLap = new DateTime(1753,1,1,1,1,1);
            string maKH = txbNVMaKH.Text;
            int tongTien;
            if (txbNVTien.Text == "")
                tongTien = 0;
            else
                tongTien = Convert.ToInt32(txbNVTien.Text);
            if (txbNVNgLap.Text != "dd/mm/yyyy")
                ngLap = DateTime.ParseExact(txbNVNgLap.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            try
            {
                _connection = Connection.ConnectionData();
                string proc = "sp_TimHoaDon";
                _command = new SqlCommand(proc);
                _command.CommandType = CommandType.StoredProcedure;
                _command.Connection = _connection;
                _command.Parameters.Add("@maKH", SqlDbType.Char, 10);
                _command.Parameters.Add("@nglap", SqlDbType.DateTime);
                _command.Parameters.Add("@tongTien", SqlDbType.Int);

                _command.Parameters["@maKH"].Value = maKH;
                _command.Parameters["@nglap"].Value = ngLap;
                _command.Parameters["@tongTien"].Value = tongTien;

                int n = _command.ExecuteNonQuery();


                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = _command;

                DataTable table = new DataTable();
                adapter.Fill(table);

                BindingSource bSource = new BindingSource();
                bSource.DataSource = table;

                dtgvNVTTHD.DataSource = bSource;
                adapter.Update(table);

                labelIn.Show();
                _connection.Close();
            }
            catch (SqlException error)
            {
                
                MessageBox.Show(error.Message);
            }
        }

        private void txbNVNgLap_Enter(object sender, EventArgs e)
        {
            if (txbNVNgLap.Text == "dd/mm/yyyy")
            {
                txbNVNgLap.Text = "";
            }
        }

        private void txbNVNgLap_Leave(object sender, EventArgs e)
        {
            if (txbNVNgLap.Text == "")
            {
                txbNVNgLap.Text = "dd/mm/yyyy";
            }
        }


        private void dtgvNVTKe_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 || (e.ColumnIndex == -1 && dtgvNVTKe.Rows[e.RowIndex].Cells["Mã hóa đơn"].Value.ToString() == "" || dtgvNVTKe.Rows[e.RowIndex].Cells["Mã hóa đơn"].Value.ToString() == ""))
            {
                return;
            }
            DialogResult res = MessageBox.Show("Bạn có muốn in hóa đơn này ?", "Thông báo", MessageBoxButtons.OKCancel);
            if (res == DialogResult.OK)
            {
                MessageBox.Show("Xác nhận chuẩn bị cho quá trình in !", "Thông báo");
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            LoadBaoCao();
            cbxNVChonThang.Text = "--Chọn tháng";
            cbxNVChonNam.Text = "--Chọn năm";
        }

       
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            LoadThongKe();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            panel2.Hide();
            dtgvLapHDKH.Show();
            LoadLapHDKH();
        }

        private void dtgvLapHDKH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 || e.ColumnIndex == -1)
            {
                return;
            }
            else
            {
                txbNVMaDP.Text = dtgvLapHDKH.Rows[e.RowIndex].Cells["Mã đặt phòng"].Value.ToString();
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            LoadDSHD();
            labelIn.Show();
        }

        private void dtgvNVTTHD_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 || e.ColumnIndex == -1)
            {
                return;
            }
            else
            {
                MessageBox.Show("Bắt đầu tiến hành in hoá đơn !");
            }
        }
        private void pictureBox5_Click(object sender, EventArgs e)
        {
            LoadTTKH();
        }

        private void btnTTKHTimKiem_Click(object sender, EventArgs e)
        {
            if (txbTTKHSoCMND.Text == "")
            {
                MessageBox.Show("Vui lòng nhập số CMND để tìm kiếm");
                return;
            }
            _connection = Connection.ConnectionData();
            string sql = @"SELECT hoTen AS 'Họ tên', soCMND AS 'Số CMND', diaChi AS 'Địa chỉ', soDienThoai AS 'Số điện thoại', moTa AS 'Mô tả', email AS 'Email' FROM KhachHang WHERE soCMND = '" + txbTTKHSoCMND.Text + "'";
            _command = new SqlCommand(sql, _connection);
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = _command;

            DataTable table = new DataTable();
            adapter.Fill(table);

            dtgvTTKH.DataSource = table;

            adapter.Update(table);
            _connection.Close();
        }

        #endregion

        #region Function

        public string RandomMaHD()
        {
            Random r = new Random();
            string maHD = "HD" + r.Next(10, 99999999).ToString();
            return maHD;
        }

        public void LoadLapHDKH()
        {
            try
            {
                _connection = Connection.ConnectionData();

                string sql = @"select TOP 100 maDp AS 'Mã đặt phòng', maLoaiPhong AS 'Mã loại phòng', maKH AS 'Mã khách hàng', ngayBatDau AS 'Ngày bắt đầu', ngayTraPhong AS 'Ngày trả phòng', ngayDat AS 'Ngày Đặt', donGia AS 'Đơn giá', moTa AS 'Mô tả', tinhTrang AS 'Tình trạng' FROM DatPhong";
                _command = new SqlCommand(sql, _connection);

                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = _command;

                DataTable table = new DataTable();
                adapter.Fill(table);

                dtgvLapHDKH.DataSource = table;

                adapter.Update(table);
                _connection.Close();
            }

            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void LoadDSHD()
        {
            try
            {
                _connection = Connection.ConnectionData();

                string sql = @"SELECT TOP 50 maHD AS 'Mã hóa đơn', maKH AS 'Mã khách hàng', ngayThanhToan AS 'Ngày lập', tongTien AS 'Tổng tiền' FROM HoaDon H, DatPhong D WHERE H.MaDP = D.MaDP";
                _command = new SqlCommand(sql, _connection);

                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = _command;

                DataTable table = new DataTable();
                adapter.Fill(table);

                dtgvNVTTHD.DataSource = table;

                adapter.Update(table);
                _connection.Close();
            }

            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void LoadBaoCao()
        {
            try
            {
                _connection = Connection.ConnectionData();

                string sql =
                    @"SELECT MONTH(ngayThanhToan) AS 'Tháng',YEAR(ngayThanhToan) AS 'Năm',SUM(tongTien) AS 'Tổng doanh thu'
                    FROM HoaDon
                    GROUP BY MONTH(ngayThanhToan), YEAR(ngayThanhToan)
                    ORDER BY MONTH(ngayThanhToan)";
                _command = new SqlCommand(sql, _connection);

                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = _command;

                DataTable table = new DataTable();
                adapter.Fill(table);

                BindingSource bSource = new BindingSource();
                bSource.DataSource = table;

                dtgvNVBcao.DataSource = bSource;

                adapter.Update(table);
                _connection.Close();
                label12.Text = "Báo cáo doanh thu";
            }

            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        public void LoadThongKe()
        {
            _connection = Connection.ConnectionData();
            string proc = "sp_ThongKePhongTrong";
            _command = new SqlCommand(proc);
            _command.CommandType = CommandType.StoredProcedure;
            _command.Connection = _connection;
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = _command;

            DataTable table = new DataTable();
            adapter.Fill(table);

            BindingSource bSource = new BindingSource();
            bSource.DataSource = table;

            dtgvNVTKe.DataSource = bSource;

            adapter.Update(table);
            //label123.Text = "Thống kê số lượng phòng trống";
            _connection.Close();
        }

        public void LoadTTKH()
        {
            _connection = Connection.ConnectionData();

            string sql = @"SELECT top 100 hoTen AS 'Họ tên', soCMND AS 'Số CMND', diaChi AS 'Địa chỉ', soDienThoai AS 'Số điện thoại', moTa AS 'Mô tả', email AS 'Email' FROM KhachHang ";
            _command = new SqlCommand(sql, _connection);

            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = _command;

            DataTable table = new DataTable();
            adapter.Fill(table);

            dtgvTTKH.DataSource = table;

            adapter.Update(table);
            _connection.Close();
        }

        #endregion 



        
    }
}
