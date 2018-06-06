using QuanLyKhachSan.DAO;
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
    public partial class fNhanVien : Form
    {
        SqlConnection _connection = null;
        SqlCommand _command = null;
        public fNhanVien()
        {
            InitializeComponent();
            panel2.Hide();
            panel3.Hide();
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
                _command.Parameters["@ngLap"].Value = dtpkNVNgayLap.Value;

                int n = _command.ExecuteNonQuery();
                if (n > 0)
                {
                    MessageBox.Show("Ghi hóa đơn thành công");
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
        }
    }
}
