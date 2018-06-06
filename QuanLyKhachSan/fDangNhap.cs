
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
    public partial class fDangNhap : Form
    {
        SqlConnection _connection = null;
        SqlCommand _command = null;
        public fDangNhap()
        {
            InitializeComponent();
        }
        
        #region methods
        #endregion

        #region events
        private void btnDki_Click(object sender, EventArgs e)
        {
            this.Hide();
            fDangKi f = new fDangKi();
            f.Show();
        }

        private void btnDNDnhap_Click(object sender, EventArgs e)
        {
            if (txbDNTenDN.Text == "nv" && txbDNMk.Text == "nv")
            {
                this.Hide();
                fNhanVien f = new fNhanVien();
                f.Show();
            }
            else
            {
                try
                {
                    _connection = Connection.ConnectionData();
                    string proc = "sp_DangNhap";
                    _command = new SqlCommand(proc);
                    _command.CommandType = CommandType.StoredProcedure;
                    _command.Connection = _connection;
                    _command.Parameters.Add("@id", SqlDbType.VarChar,20);
                    _command.Parameters.Add("@mk", SqlDbType.VarChar,20);
                    _command.Parameters.Add("@maKH", SqlDbType.VarChar,20).Direction = ParameterDirection.Output;
                    _command.Parameters.Add("@hoTen", SqlDbType.NVarChar,30).Direction = ParameterDirection.Output;

                    _command.Parameters["@id"].Value = txbDNTenDN.Text;
                    _command.Parameters["@mk"].Value = txbDNMk.Text;

                    int n = _command.ExecuteNonQuery();
                    string maKH = (string)_command.Parameters["@maKH"].Value;
                    string hoTen = (string)_command.Parameters["@hoTen"].Value;

                    MessageBox.Show("Xin chào \n" + maKH + "\n" + hoTen);
                    _connection.Close();

                    KhachHangDTO username = new KhachHangDTO(maKH,hoTen,"","","","","","","");
                    UserInformation.CurrentLoggedInUser = username;
                    this.Hide();
                    fBatDau f = new fBatDau();
                    f.Show();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        internal class UserInformation
        {
            public static KhachHangDTO CurrentLoggedInUser
            {
                get;
                set;
            }
        }
        private void fDangNhap_FormClosed(object sender, FormClosedEventArgs e)
        {
            fBatDau f = new fBatDau();
            f.Show();
        }

        private void fDangNhap_Load(object sender, EventArgs e)
        {
            //this.Close();
        }
        #endregion

    }
}
