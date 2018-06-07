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
        }

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
                _connection = Connection.ConnectionData();
                string proc = "sp_LapHoaDon";
                _command = new SqlCommand(proc);
                _command.CommandType = CommandType.StoredProcedure;
                _command.Connection = _connection;
                _command.Parameters.Add("@maDP", SqlDbType.Char, 10);
                _command.Parameters.Add("@tongTien", SqlDbType.Int);
                _command.Parameters.Add("@ngLap", SqlDbType.DateTime);

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
            string proc = "sp_BaoCaoDoanhThu";
            _command = new SqlCommand(proc);
            _command.CommandType = CommandType.StoredProcedure;
            _command.Connection = _connection;
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = _command;

            DataTable table = new DataTable();
            adapter.Fill(table);

            BindingSource bSource = new BindingSource();
            bSource.DataSource = table;

            dtgvNVTKBC.DataSource = bSource;

            adapter.Update(table);

            label12.Text = "Báo cáo doanh thu";
        }

        private void btnNVTke_Click(object sender, EventArgs e)
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

            dtgvNVTKBC.DataSource = bSource;

            adapter.Update(table);
            label12.Text = "Thống kê số lượng phòng trống";
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

        private void dtgvNVTTHD_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 || (e.ColumnIndex == -1 && dtgvNVTTHD.Rows[e.RowIndex].Cells["Mã hóa đơn"].Value.ToString() == "" || dtgvNVTTHD.Rows[e.RowIndex].Cells["Mã hóa đơn"].Value.ToString() == ""))
            {
                return;
            }
            DialogResult res = MessageBox.Show("Bạn có muốn in hóa đơn này ?", "Thông báo", MessageBoxButtons.OKCancel);
            if (res == DialogResult.OK)
            {
                MessageBox.Show("Xác nhận chuẩn bị cho quá trình in !", "Thông báo");
            }
        }
    }
}
