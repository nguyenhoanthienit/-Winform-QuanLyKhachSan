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
        String _connectionString = "";
        SqlConnection _connection = null;
        SqlCommand _command = null;

        public fBatDau()
        {
            InitializeComponent();
            _connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=DoAnCSDLNC_Index;Integrated Security=True";
            LoadData();
        }
        private void btnDki_Click(object sender, EventArgs e)
        {
            this.Hide();
            fDangKi f = new fDangKi();
            f.ShowDialog();
        }

        private void btnDnhap_Click(object sender, EventArgs e)
        {
            this.Hide();
            fDangNhap f = new fDangNhap();
            f.ShowDialog();
        }

        private void btnDxuat_Click(object sender, EventArgs e)
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

        public string currentUser = fDangNhap.UserInformation.CurrentLoggedInUser;
        private void fBatDau_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'doAnCSDLNC_IndexDataSet.KhachSan' table. You can move, or remove it, as needed.
            if (currentUser != null)
            {
                btnDVDnhap.Hide();
                btnDVDki.Hide();
                btnDVDxuat.Show();
                labelTenKH.Text = currentUser;
                labelTenKH.Show();
            }
            else
            {
                btnDVDnhap.Show();
                btnDVDki.Show();
                btnDVDxuat.Hide();
                labelTenKH.Text = null;
            }
        }


        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.Hide();
            fDatPhong f = new fDatPhong();
            f.Show();
        }

        private void fBatDau_FormClosed(object sender, FormClosedEventArgs e)
        {
            Process.GetCurrentProcess().Kill();
        }

        
        public Control labelXinChao { get; set; }
        private void btnDVDxuat_Click(object sender, EventArgs e)
        {
            btnDVDnhap.Show();
            btnDVDki.Show();
            btnDVDxuat.Hide();
            labelTenKH.Text = null;
        }

        public string GetComboboxData(string data)
        {
            if (data[0] == '-')
                return null;
            else
                return data;
        }

        private void btnDVTimKiem_Click(object sender, EventArgs e)
        {
            _connection = new SqlConnection(_connectionString);
            _connection.Open();

            string giaMin = cbxDVGiaMin.SelectedItem.ToString();
            string giaMax = cbxDVGiaMax.SelectedItem.ToString();
            string sao = cbxDVSao.SelectedItem.ToString();
            string tpho = cbxDVTp.SelectedItem.ToString();

            string proc = "";
            if (tpho == "--Chọn thành phố")
            {
                MessageBox.Show("*Chỉ hỗ trợ tìm kiếm theo\nGiá - Thành phố\nHạng sao - Thành phố\nThành phố");
                return;
            }
            else
            {
                if (sao == "--Chọn hạng sao")
                {
                    if (giaMin == "--Chọn giá")
                    {
                        proc = "sp_TimKiemThongTinKhachSanTheoGiaTP";
                        _command = new SqlCommand(proc);
                        _command.CommandType = CommandType.StoredProcedure;
                        _command.Connection = _connection;
                        _command.Parameters.Add("@giaMin", SqlDbType.Int);
                        _command.Parameters.Add("@giaMax", SqlDbType.Int);
                        _command.Parameters.Add("@tpho", SqlDbType.NVarChar);

                        _command.Parameters["@giaMin"].Value = 0;
                        _command.Parameters["@giaMax"].Value = giaMax;
                        _command.Parameters["@tpho"].Value = tpho;
                    }
                    else if (giaMax == "--Chọn giá")
                    {
                        proc = "sp_TimKiemThongTinKhachSanTheoGiaTP";
                        _command = new SqlCommand(proc);
                        _command.CommandType = CommandType.StoredProcedure;
                        _command.Connection = _connection;
                        _command.Parameters.Add("@giaMin", SqlDbType.Int);
                        _command.Parameters.Add("@giaMax", SqlDbType.Int);
                        _command.Parameters.Add("@tpho", SqlDbType.NVarChar);

                        _command.Parameters["@giaMin"].Value = giaMin;
                        _command.Parameters["@giaMax"].Value = 500000;
                        _command.Parameters["@tpho"].Value = tpho;
                    }
                    else
                    {
                        proc = "sp_TimKiemThongTinKhachSanTheoGiaTP";
                        _command = new SqlCommand(proc);
                        _command.CommandType = CommandType.StoredProcedure;
                        _command.Connection = _connection;
                        _command.Parameters.Add("@giaMin", SqlDbType.Int);
                        _command.Parameters.Add("@giaMax", SqlDbType.Int);
                        _command.Parameters.Add("@tpho", SqlDbType.NVarChar);

                        _command.Parameters["@giaMin"].Value = giaMin;
                        _command.Parameters["@giaMax"].Value = giaMax;
                        _command.Parameters["@tpho"].Value = tpho;
                    }
                }

                if (giaMin == "--Chọn giá" && giaMax == "--Chọn giá")
                {
                    if (sao == "--Chọn hạng sao")
                    {
                        proc = "sp_TimKiemThongTinKhachSanTheoTP";
                        _command = new SqlCommand(proc);
                        _command.CommandType = CommandType.StoredProcedure;
                        _command.Connection = _connection;
                        _command.Parameters.Add("@tpho", SqlDbType.NVarChar);

                        _command.Parameters["@tpho"].Value = tpho;
                    }
                    else
                    {
                        proc = "sp_TimKiemThongTinKhachSanTheoSaoTP";
                        _command = new SqlCommand(proc);
                        _command.CommandType = CommandType.StoredProcedure;
                        _command.Connection = _connection;
                        _command.Parameters.Add("@sao", SqlDbType.Int);
                        _command.Parameters.Add("@tpho", SqlDbType.NVarChar);

                        _command.Parameters["@sao"].Value = sao;
                        _command.Parameters["@tpho"].Value = tpho;
                    }
                }

                if (giaMin != "--Chọn giá" && giaMax != "--Chọn giá" && sao != "--Chọn hạng sao")
                {
                    proc = "sp_TimKiemThongTinKhachSan";
                    _command = new SqlCommand(proc);
                    _command.CommandType = CommandType.StoredProcedure;
                    _command.Connection = _connection;
                    _command.Parameters.Add("@giaMin", SqlDbType.Int);
                    _command.Parameters.Add("@giaMax", SqlDbType.Int);
                    _command.Parameters.Add("@sao", SqlDbType.Int);
                    _command.Parameters.Add("@tpho", SqlDbType.NVarChar);

                    _command.Parameters["@giaMin"].Value = giaMin;
                    _command.Parameters["@giaMax"].Value = giaMax;
                    _command.Parameters["@sao"].Value = sao;
                    _command.Parameters["@tpho"].Value = tpho;
                }
            }
            
           

            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = _command;

            DataTable table = new DataTable();
            adapter.Fill(table);

            BindingSource bSource = new BindingSource();
            bSource.DataSource = table;

            dtgvTimKiemKhachSan.DataSource = bSource;
            adapter.Update(table);
        }

        public void LoadData()
        {
            _connection = new SqlConnection(_connectionString);
            _connection.Open();

            string sql = 
                @"SELECT L.maLoaiPhong AS 'Mã loại phòng',L.tenLoaiPhong AS 'Tên loại phòng',L.donGia AS 'Đơn giá', L.moTa AS 'Mô tả', L.slTrong AS 'Số lượng trống', K.tenKS AS 'Tên khách sạn', K.giaTB AS 'Giá TB khách sạn', K.soSao AS 'Số sao',K.thanhPho AS 'Thành phố'
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
        }

        private void btnDVLoad_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
